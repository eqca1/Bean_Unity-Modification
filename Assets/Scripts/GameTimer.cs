using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;
    private float timeElapsed = 0f;
    private bool isTimerRunning = false;

    void Update()
    {
        if (isTimerRunning)
        {
            timeElapsed += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResetTimer()
    {
        timeElapsed = 0f;
        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        float minutes = Mathf.FloorToInt(timeElapsed / 60);
        float seconds = Mathf.FloorToInt(timeElapsed % 60);
        if (timerText != null)
            timerText.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);
    }
}