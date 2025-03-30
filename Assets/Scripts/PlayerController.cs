using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody; // Rigidbody 组件
    public float moveSpeed = 5f;      // 移动速度
    public float jumpForce = 5f;      // 跳跃力度
    public float dashMultiplier = 3f; // 冲刺速度倍数
    public float rayLength = 0.6f;    // 射线检测长度
    public Transform cameraTransform; // 摄像机的 Transform

    private bool isGrounded = false;  // 是否在地面
    private bool isDashing = false;   // 是否正在冲刺
    private bool canDash = false;     // 是否可以冲刺（由Buff激活）
    private int jumpCount = 0;        // 跳跃次数

    private Vector3 originalSize;     // 原始大小
    private float sizeChangeTimer = 0f; // 大小变化计时器
    private bool isSizeChanged = false; // 大小是否已改变
    private string sizeChangeType;    // 大小变化类型（变大或变小）

    private float dashTimer = 0f;     // 冲刺计时器
    private bool isDashEnabled = false; // 冲刺功能是否已启用

    private Animator animator;        // Animator 组件

    [SerializeField] private GameObject maze1;
    [SerializeField] private GameObject maze2;
    [SerializeField] private GameObject guidePath;

    private bool isWallTransparent = false; // 是否正在透明状态
    private bool isCursorLocked = true;

    void Start()
    {

        LockCursor();

        // 如果没有手动赋值 Rigidbody，尝试自动获取
        if (playerRigidbody == null)
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }

        // 如果没有手动赋值摄像机，使用主摄像机
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        // 获取 Animator 组件
        animator = GetComponent<Animator>();

        // 存储玩家的原始大小
        originalSize = transform.localScale;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 直接根据当前状态切换，而不是依赖布尔变量
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                UnlockCursor();
            }
            else
            {
                LockCursor();
            }
        }

        // 大小变化计时逻辑
        if (isSizeChanged)
        {
            sizeChangeTimer -= Time.deltaTime;
            if (sizeChangeTimer <= 0)
            {
                ResetSize(); // 恢复原始大小
            }
        }

        // 冲刺计时逻辑
        if (isDashEnabled)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
            {
                DisableDash(); // 禁用冲刺
            }
        }

        // 让角色面向摄像机的反方向
        Vector3 cameraPosition = cameraTransform.position;
        Vector3 playerPosition = transform.position;
        Vector3 directionToCamera = (cameraPosition - playerPosition).normalized;
        Vector3 lookDirection = -new Vector3(directionToCamera.x, 0, directionToCamera.z); // 忽略 y 轴，防止角色倾斜
        if (lookDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }

        // 获取输入
        Vector2 inputVector = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) inputVector += Vector2.up;
        if (Input.GetKey(KeyCode.S)) inputVector += Vector2.down;
        if (Input.GetKey(KeyCode.D)) inputVector += Vector2.right;
        if (Input.GetKey(KeyCode.A)) inputVector += Vector2.left;

        // 将输入转换为 3D 平面移动方向（基于摄像机方向）
        Vector3 moveDirection = cameraTransform.forward * inputVector.y + cameraTransform.right * inputVector.x;
        moveDirection.y = 0; // 确保角色不会在垂直方向上移动
        moveDirection.Normalize(); // 归一化方向，防止斜向移动速度过快

        // 冲刺逻辑（只有当 canDash 为 true 时才可以冲刺）
        if (canDash)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isDashing = true;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                isDashing = false;
            }
        }

        // 计算移动速度
        float currentSpeed = isDashing ? moveSpeed * dashMultiplier : moveSpeed;
        playerRigidbody.linearVelocity = new Vector3(moveDirection.x * currentSpeed, playerRigidbody.linearVelocity.y, moveDirection.z * currentSpeed);

        // 更新 Animator 的 Speed 参数
        animator.SetFloat("Speed", moveDirection.magnitude * currentSpeed);
        animator.SetBool("IsJumping", !isGrounded);

        // 地面检测
        RaycastHit hit;
        Vector3 rayOrigin = transform.position + Vector3.down * 0.5f; // 确保射线从角色的脚底发射
        isGrounded = Physics.Raycast(rayOrigin, Vector3.down, out hit, rayLength);

        // 如果角色在地面上，重置跳跃次数
        if (isGrounded)
        {
            jumpCount = 0;
        }

        // 跳跃控制
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount < 2) // 允许二段跳
            {
                playerRigidbody.linearVelocity = new Vector3(playerRigidbody.linearVelocity.x, 0, playerRigidbody.linearVelocity.z); // 清除 Y 轴速度，确保跳跃高度一致
                playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpCount++;
            }
        }
    }

    void OnDrawGizmos()
    {
        // 绘制地面检测射线
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayLength);
    }

    // 启用冲刺功能并设置时限
    public void EnableDash(float duration)
    {
        canDash = true;
        dashTimer = duration;
        isDashEnabled = true;
        Debug.Log("Dash buff started.");
    }

    // 禁用冲刺功能
    public void DisableDash()
    {
        canDash = false;
        isDashEnabled = false;
        isDashing = false; // 强制结束冲刺状态
        Debug.Log("Dash buff ended.");
    }

    // 改变大小的方法
    public void ChangeSize(Vector3 newSize, float duration, string changeType)
    {
        transform.localScale = newSize;
        sizeChangeTimer = duration;
        isSizeChanged = true;
        sizeChangeType = changeType;
        Debug.Log($"{changeType} buff started.");
    }

    // 恢复原始大小的方法
    private void ResetSize()
    {
        transform.localScale = originalSize;
        isSizeChanged = false;
        Debug.Log($"{sizeChangeType} buff ended.");
    }


    // 当透明墙 Buff 触发时调用
    public void ApplyTransparentWallBuff(float duration)
    {
        if (isWallTransparent)
        {
            Debug.Log("Wall is already transparent!");
            return;
        }

        Debug.Log("Applying Transparent Wall Buff!");
        StartCoroutine(TransparentWallRoutine(duration));
    }

    private IEnumerator TransparentWallRoutine(float duration)
    {
        // 直接调用原版的 MakeWallsTransparent() 方法
        MakeWallsTransparent();
        isWallTransparent = true;

        yield return new WaitForSeconds(duration);

        // 恢复墙的不透明状态
        RevertWalls();
        isWallTransparent = false;
        Debug.Log("Transparent Wall Buff ended!");
    }

    // 你的原版方法（直接从 Buff 脚本复制过来）
    private void MakeWallsTransparent()
    {
        GameObject maze1 = GameObject.Find("Maze_01");
        GameObject maze2 = GameObject.Find("Maze_02");
        GameObject guide = GameObject.Find("GuidePath");
        GameObject guidePath = guide?.transform.Find("Guide")?.gameObject;

        if (maze1 != null) SetTransparency(maze1, 0.3f);
        if (maze2 != null) SetTransparency(maze2, 0.3f);
        if (guidePath != null) guidePath.SetActive(true);
    }

    private void RevertWalls()
    {
        GameObject maze1 = GameObject.Find("Maze_01");
        GameObject maze2 = GameObject.Find("Maze_02");
        GameObject guide = GameObject.Find("GuidePath");
        GameObject guidePath = guide?.transform.Find("Guide")?.gameObject;

        if (maze1 != null) SetTransparency(maze1, 1f);
        if (maze2 != null) SetTransparency(maze2, 1f);
        if (guidePath != null) guidePath.SetActive(false);
    }

    // 你的原版 SetTransparency 方法（确保使用 URP Shader 设置）
    private void SetTransparency(GameObject obj, float alpha)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            Material mat = renderer.material;
            mat.SetFloat("_Surface", 1); // URP 透明模式
            mat.SetFloat("_Blend", 1);
            mat.SetInt("_ZWrite", 0);
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

            Color color = mat.GetColor("_BaseColor");
            color.a = alpha;
            mat.SetColor("_BaseColor", color);
            mat.renderQueue = 3000;
        }
    }

    // 隐藏鼠标并锁定
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("鼠标已隐藏并锁定");
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("鼠标已显示并解锁");
    }

}