using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private AndroidNotificationHandler androidNotificationHandler;
    [SerializeField] private iOSNotificationHandler iosNotificationHandler;
    [SerializeField] private Button playButton;
    [SerializeField] private int maxEnergy;
    [SerializeField] private int energyRechargeDuration;
    
    private int _energy;
    
    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";

    private void Start()
    {
        OnApplicationFocus(true);
    }

    void OnApplicationFocus(bool hasFocus) {
        if (!hasFocus) return;
        CancelInvoke();
        
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0)}";

        _energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);
        
        if (_energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);
            if (energyReadyString == string.Empty) return;
            DateTime energyReady = DateTime.Parse(energyReadyString);

            if (DateTime.Now > energyReady)
            {
                _energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, _energy);
            } else {
                playButton.interactable = false;
                Invoke(nameof(EnergyRecharged), (energyReady - DateTime.Now).Seconds);
            }

        }
        energyText.text = $"Play ({_energy})";
    }
    
    private void EnergyRecharged() {
        playButton.interactable = true;
        _energy = maxEnergy;
        PlayerPrefs.SetInt(EnergyKey, _energy);
        energyText.text = $"Play ({_energy})";
    }
    public void Play() {
        if (_energy < 1) return;
        _energy--;
        PlayerPrefs.SetInt(EnergyKey, _energy);
        if (_energy == 0)
        {
            DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadyKey, energyReady.ToSafeString());
            #if UNITY_ANDROID
                androidNotificationHandler.ScheduleNotification(energyReady);
            #elif UNITY_IOS
                iosNotificationHandler.ScheduleNotification(energyRechargeDuration);
            #endif
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
