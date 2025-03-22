using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadDemo1Scene()
    {
        SceneManager.LoadScene("PolygonHorrorMansion/Scenes/Demo_01");
    }
}
