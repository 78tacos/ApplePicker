using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    void Start()
    {
        // Hide the game over screen initially
        gameObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        // Show the game over screen
        gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        // Restart the game by loading the main scene
        SceneManager.LoadScene("_Scene_0");
    }
}
