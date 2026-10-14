using UnityEngine;
#if !UNITY_WEBGL
using UnityEngine.InputSystem; // Only include InputSystem on non-WebGL platforms
#endif

public class Basket : MonoBehaviour
{
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
            // GameObject.Find skips inactive objects.
            GameOverManager[] all = Resources.FindObjectsOfTypeAll<GameOverManager>();
            if (all != null && all.Length > 0)
            {
                gameOverManager = all[0];
            }
        }
    }

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

            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleCaught();
        }
        else if (collidedWith.CompareTag("Branch"))
        {
            Destroy(collidedWith);
            if (gameOverManager != null)
            {
                gameOverManager.ShowGameOver();
                scoreCounter.score -= 10000;
            }
        }
        
    }
}
