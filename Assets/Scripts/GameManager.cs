using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int lives = 3;

    private int currentScore = 0;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text gameOverText;
     [SerializeField] private TMP_Text finalScoreText;
    
    [SerializeField] private PlayerController playerController;
    public AudioClip LifeLost;


    public int Lives
    {
        get { return lives; }
        set { lives = value; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScore(0);
        UpdateLivesText(0);
        
        

    }

    private void UpdateScore(int points)
    {
        currentScore += points;
        scoreText.text = "Score: " + currentScore;
    }

    public void UpdateLivesText(int liveschange)
    {
        Lives += liveschange;
        livesText.text = "Lives: " + lives;
        AudioSource.PlayClipAtPoint(LifeLost, transform.position);


        if (lives <= 0)
        {

            GameOver();
        }




    }

    private void GameOver()
    {
        playerController.Die();
        gameOverText.gameObject.SetActive(true);
     

        finalScoreText.text = "Final Score: " + currentScore;
        Time.timeScale = 0f; // Pause the game
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
