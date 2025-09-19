using UnityEngine;
#if !UNITY_WEBGL
using UnityEngine.InputSystem; // Only include InputSystem on non-WebGL platforms
#endif

public class Basket : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public ScoreCounter scoreCounter;
    private GameOverManager gameOverManager;

    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();

        GameObject goCanvas = GameObject.Find("GameOverCanvas");

        if (goCanvas != null)
        {
            gameOverManager = goCanvas.GetComponent<GameOverManager>();
        }

        if (gameOverManager == null)
        {
            // had to do this because it wouldn't find it because it's inactive
            GameOverManager[] all = Resources.FindObjectsOfTypeAll<GameOverManager>();
            if (all != null && all.Length > 0)
            {
                gameOverManager = all[0];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputPos2D = Input.mousePosition;
        
        // Touch support with legacy Input
        if (Input.touchCount > 0)
        {
            inputPos2D = Input.GetTouch(0).position;
        }

        inputPos2D.z = -Camera.main.transform.position.z;
        Vector3 inputPos3D = Camera.main.ScreenToWorldPoint(inputPos2D);
        Vector3 pos = this.transform.position;
        pos.x = inputPos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            scoreCounter.score += 100;
            HighScore.TRY_TO_SET_HIGH_SCORE(scoreCounter.score);

            // Notify ApplePicker that an apple was caught
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleCaught();
        }
        else if (collidedWith.CompareTag("Branch"))
        {
            Destroy(collidedWith);
            // Trigger game over when a branch is caught
            if (gameOverManager != null)
            {
                gameOverManager.ShowGameOver();
                scoreCounter.score -= 10000;
            }
        }
        
    }
}
