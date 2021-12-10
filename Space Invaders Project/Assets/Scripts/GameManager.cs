using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviour
{
    private Player player;
    private Invaders invaders;
    private MysteryShip mysteryShip;
    private Bunker[] bunkers;

    public int level;

    public Text scoreText;
    public Text livesText;
    public Text shieldsText;

    public Text finalScore;
    public Text highText;

    int highScore;
    public static int score { get; private set; }
    int savedHighScore;

    public CameraShake cameraShake;
    public GameObject gameOverUI;

    public int lives { get; private set; }

    private void Awake()
    {
        Time.timeScale = 1f;
        this.player = FindObjectOfType<Player>();
        this.invaders = FindObjectOfType<Invaders>();
        this.mysteryShip = FindObjectOfType<MysteryShip>();
        this.bunkers = FindObjectsOfType<Bunker>();
        PauseMenu.GameIsPaused = false;
    }

    private void Start()
    {
        lives = 1 + PlayerPrefs.GetInt("Starting Lives");
        this.player.shieldsInt = 1 + PlayerPrefs.GetInt("Starting Shields");


        if (level == 1)
        {
            savedHighScore = PlayerPrefs.GetInt("HighScore1");

        }
        if (level == 2)
        {
            savedHighScore = PlayerPrefs.GetInt("HighScore2");

        }
        this.player.killed += OnPlayerKilled;
        this.mysteryShip.killed += OnMysteryShipKilled;
        this.invaders.killed += OnInvaderKilled;

        NewGame();
    }

    private void Update()
    {
        this.shieldsText.text = this.player.shieldsInt.ToString() + "x";

        if (this.lives <= 0) {
            NewGame();
        }

        if (score > highScore)
        {
            highScore = score;
        }

        if (highScore > savedHighScore)
        {
            savedHighScore = highScore;
            if (level == 1)
            {
                PlayerPrefs.SetInt("HighScore1", highScore);
            }
            if (level == 2)
            {
                PlayerPrefs.SetInt("HighScore2", highScore);
            }
        }
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(lives);
        NewRound();
    }

    private void NewRound()
    {
        this.invaders.ResetInvaders();
        this.invaders.gameObject.SetActive(true);

        for (int i = 0; i < this.bunkers.Length; i++) {
            this.bunkers[i].ResetBunker();
        }

        Respawn();
    }

    private void Respawn()
    {
        Vector3 position = this.player.transform.position;
        position.x = 0.0f;
        this.player.transform.position = position;
        this.player.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        this.highText.text = "- High Score: " + savedHighScore.ToString() + " -";
        this.finalScore.text = "Your Score: " + score.ToString();
        gameOverUI.SetActive(true);
        savedHighScore = highScore;
        PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points") + score);
    }

    private void SetScore(int currentScore)
    {
        score = currentScore;
        this.scoreText.text = score.ToString().PadLeft(4, '0');
    }

    private void SetLives(int lives)
    {
        this.lives = Mathf.Max(lives, 0);
        this.livesText.text = this.lives.ToString();
    }

    private void OnPlayerKilled()
    {
        SetLives(this.lives - 1);
        StartCoroutine(cameraShake.Shake(.15f, .2f));

        this.player.gameObject.SetActive(false);

        if (this.lives > 0) {
            Invoke(nameof(NewRound), 1.0f);
        } else {
            GameOver();
        }
    }

    private void OnInvaderKilled(Invader invader)
    {
        SetScore(score + invader.score);
        StartCoroutine(cameraShake.Shake(.15f, .2f));

        if (this.invaders.AmountKilled == this.invaders.TotalAmount) {
            NewRound();
        }
    }

    private void OnMysteryShipKilled(MysteryShip mysteryShip)
    {
        SetScore(score + mysteryShip.score);
        StartCoroutine(cameraShake.Shake(.15f, .2f));
        this.player.shieldsInt++;
    }

}
