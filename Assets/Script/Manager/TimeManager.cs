using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; 

    private float timeElapsed;

    private void Start()
    {
        timeElapsed = 0f; 
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime; 
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        // Actualiza el texto del temporizador
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
