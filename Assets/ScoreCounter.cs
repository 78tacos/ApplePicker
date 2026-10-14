using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    private Text uiText;
    public int score;

    void Start()
    {
        uiText = GetComponent<Text>();
    }

    void Update()
    {
        uiText.text = score.ToString( "#,0" );
    }
}
