using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    public int currentRound = 1;
    private Text roundText;
    private GameOverManager gameOverManager;

    void Start()
    {
        roundText = GetComponent<Text>();
        UpdateRoundDisplay();

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

    public void NextRound()
    {
        if (currentRound >= 4)
        {
            // Round 4 is the last round.
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
