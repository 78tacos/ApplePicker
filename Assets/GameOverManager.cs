using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}
