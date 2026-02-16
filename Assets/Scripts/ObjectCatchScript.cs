using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectCatchScript : MonoBehaviour
{
    public TMP_Text scoreText;
    public Image healthBarImage;
    public Sprite[] healthSprites;
    public GameTimer gameTimer;


    public int score = 0;
    public int lives = 4;

    private SFX_Script sfx;

    void Start()
    {
        sfx = FindFirstObjectByType<SFX_Script>();
        ResetPlayerStats();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("DonutPurple")) { AddScore(1); Destroy(collision.gameObject); }
        else if (collision.CompareTag("DonutPink")) { AddScore(2); Destroy(collision.gameObject); }
        else if (collision.CompareTag("GoldenDonut")) { AddScore(10); Destroy(collision.gameObject); }
    }

    void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI(); 
        if (sfx != null) sfx.PlaySFX(4);
    }

    void TakeDamage()
    {
        if (lives > 0)
        {
            lives--;
            UpdateHealthUI();
            if (sfx != null) sfx.PlaySFX(3);
            if (lives <= 0)
            {
                Time.timeScale = 0;
                if (gameTimer != null) gameTimer.StopTimer();
            }
        }
    }

    void UpdateHealthUI()
    {
        if (healthBarImage != null && healthSprites.Length > lives)
            healthBarImage.sprite = healthSprites[lives];
    }
    public void ResetPlayerStats()
    {
        this.score = 0;

        this.lives = healthSprites.Length - 1;

        if (scoreText != null)
        {
            scoreText.text = "Score: 0";
        }
        UpdateHealthUI();

        Time.timeScale = 1;
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}