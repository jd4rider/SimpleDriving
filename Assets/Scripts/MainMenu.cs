using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    
    void Start() {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
    }
    public void Play() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
