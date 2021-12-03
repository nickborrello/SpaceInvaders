using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public sealed class originalGameManager : MonoBehaviour
{
    private originalPlayer player;
    private originalInvaders invaders;
    private originalMysteryShip mysteryShip;
    private originalBunker[] bunkers;
    public GameObject gameOverUI;

    public Text scoreText;
    public Text livesText;

    public int score { get; private set; }
    public int lives { get; private set; }

    private void Awake()
    {
        Time.timeScale = 1f;
        this.player = FindObjectOfType<originalPlayer>();
        this.invaders = FindObjectOfType<originalInvaders>();
        this.mysteryShip = FindObjectOfType<originalMysteryShip>();
        this.bunkers = FindObjectsOfType<originalBunker>();
        PauseMenu.GameIsPaused = false;
    }

    private void Start()
    {
        this.player.killed += OnPlayerKilled;
        this.mysteryShip.killed += OnMysteryShipKilled;
        this.invaders.killed += OnInvaderKilled;

        NewGame();
    }

    private void Update()
    {
        if (this.lives <= 0) {
            NewGame();
        }
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
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
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    private void SetScore(int score)
    {
        this.score = score;
        this.scoreText.text = this.score.ToString().PadLeft(4, '0');
    }

    private void SetLives(int lives)
    {
        this.lives = Mathf.Max(lives, 0);
        this.livesText.text = this.lives.ToString();
    }

    private void OnPlayerKilled()
    {
        SetLives(this.lives - 1);

        this.player.gameObject.SetActive(false);

        if (this.lives > 0) {
            Invoke(nameof(NewRound), 1.0f);
        } else {
            GameOver();
        }
    }

    private void OnInvaderKilled(originalInvader invader)
    {
        SetScore(this.score + invader.score);

        if (this.invaders.AmountKilled == this.invaders.TotalAmount) {
            NewRound();
        }
    }

    private void OnMysteryShipKilled(originalMysteryShip mysteryShip)
    {
        SetScore(this.score + mysteryShip.score);
    }

}
