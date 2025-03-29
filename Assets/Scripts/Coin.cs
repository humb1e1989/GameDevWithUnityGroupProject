using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 30f; // 旋转速度
    private CoinCounterUI coinCounterUI; // 引用 CoinCounterUI

    void Start()
    {
        coinCounterUI = FindObjectOfType<CoinCounterUI>(); // 查找 CoinCounterUI 组件
    }

    void Update()
    {
        // 旋转金币
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinCounterUI.score += 1; // 增加分数
            coinCounterUI.UpdateScore(CoinCounterUI.score); // 更新UI显示分数
            Destroy(gameObject); // 金币消失
        }
    }
}