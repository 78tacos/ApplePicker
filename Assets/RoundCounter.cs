using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    public int currentRound = 1; // Starting round number
    private Text roundText; // Reference to the on-screen text component
    private GameOverManager gameOverManager;

    void Start()
    {
        // Get the Text component attached to this GameObject
        roundText = GetComponent<Text>();
        UpdateRoundDisplay(); // Display initial round

        // Find and reference the GameOverManager
        GameObject goCanvas = GameObject.Find("GameOverCanvas");
        if (goCanvas != null)
        {
            gameOverManager = goCanvas.GetComponent<GameOverManager>();
        }

        if (gameOverManager == null)
        {
            GameOverManager[] all = Resources.FindObjectsOfTypeAll<GameOverManager>();
            if (all != null && all.Length > 0)
            {
                gameOverManager = all[0];
            }
        }
    }

    // Call this method to advance to the next round
    public void NextRound()
    {
        if (currentRound >= 4)
        {
            // End the game at the end of round 4
            if (gameOverManager != null)
            {
                gameOverManager.ShowGameOver();
            }
        }
        else
        {
            currentRound++;
            UpdateRoundDisplay();
        }
    }

    private void UpdateRoundDisplay()
    {
        if (roundText != null)
        {
            roundText.text = "Round: " + currentRound.ToString();
        }
    }
}
