using UnityEngine;
using TMPro;

public class ObjectCatchScript : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text scoreText;
    public TMP_Text livesText;

    [Header("Game Settings")]
    public int score = 0;
    public int lives = 3;

    [Header("References")]
    private SFX_Script sfx;
    public GameTimer gameTimer;

    void Start()
    {
        sfx = FindFirstObjectByType<SFX_Script>();
        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.IsChildOf(transform))
            return;

        if (collision.CompareTag("DonutPurple")) 
        {
            AddScore(1);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("DonutPink")) 
        {
            AddScore(2);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("GoldenDonut")) 
        {
            AddScore(10);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Hazard")) 
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }

    void AddScore(int amount)
    {
        score += amount;
        sfx.PlaySFX(4);
        UpdateUI();
    }

    void TakeDamage()
    {
        lives--;
        sfx.PlaySFX(3);
        UpdateUI();
        if (lives <= 0) GameOver();
    }

    public void ResetPlayerStats()
    {
        score = 0;
        lives = 3;
        UpdateUI();
        Time.timeScale = 1; 
    }

    void UpdateUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
        if (livesText != null) livesText.text = "Lives: " + lives;
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        if (gameTimer != null) gameTimer.StopTimer();
        Time.timeScale = 0;
    }
}