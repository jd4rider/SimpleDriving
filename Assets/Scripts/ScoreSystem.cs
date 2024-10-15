using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier = 1.2f;
    
    public const string HighScoreKey = "HighScore";
    
    private float _score;

    // Update is called once per frame
    void Update()
    {
        _score += Time.deltaTime * scoreMultiplier;
        scoreText.text = Mathf.FloorToInt(_score).ToString();
    }
    
    void OnDestroy() {
        if (_score > PlayerPrefs.GetInt(HighScoreKey, 0))
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(_score));
        }
    }
}
