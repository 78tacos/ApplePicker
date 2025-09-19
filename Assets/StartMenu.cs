using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // For Button

public class StartScreenController : MonoBehaviour
{
    public Button startButton; 

    void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene("_Scene_0");  
    }
}