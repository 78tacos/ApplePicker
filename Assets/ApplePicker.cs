using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;

    public List<GameObject> basketList;
    private RoundCounter roundCounter;
    private int caughtApples = 0;
    private GameOverManager gameOverManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Create the baskets
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }

        
        GameObject roundGO = GameObject.Find("RoundCounter");
        if (roundGO != null)
        {
            roundCounter = roundGO.GetComponent<RoundCounter>();
        }

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

    public void AppleCaught()
    {
        caughtApples++;
        if (caughtApples >= 5)
        {
            if (roundCounter != null)
            {
                roundCounter.NextRound();
            }
            caughtApples = 0; // Reset for next round
        }
    }

    public void AppleMissed()
    {
        // Destroy all of the falling apples
        GameObject[] AppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in AppleArray)
        {
            Destroy(tempGO);
        }

        int basketIndex = basketList.Count - 1;

        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        if (basketIndex >= 0)
        {
            Destroy(basketGO);
        }
        // end the game
        if (basketList.Count == 0)
        {
            if (gameOverManager != null)
            {
                gameOverManager.ShowGameOver();
            }
        }
    }
}
