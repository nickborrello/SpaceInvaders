using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PointShop : MonoBehaviour
{

    public GameObject speedButton;
    public GameObject livesButton;
    public GameObject MaxLives;
    public GameObject MaxSpeed;
    public GameObject spt;
    public GameObject lpt;


    int points;
    int startingLives;
    float playerSpeed;

    int livesPrice;
    int speedPrice;

    public Text pointsText;
    public Text livesText;
    public Text speedText;

    public Text livePriceText;
    public Text speedPriceText;

    private void Update()
    {
        points = PlayerPrefs.GetInt("Points");
        startingLives = 1 + PlayerPrefs.GetInt("Starting Lives");
        playerSpeed = 1 + PlayerPrefs.GetFloat("Player Speed");

        livesPrice = 200 + PlayerPrefs.GetInt("Lives Price");
        speedPrice = 200 + PlayerPrefs.GetInt("Speed Price");

        this.pointsText.text = points.ToString() + " Test Points";
        this.livesText.text = startingLives.ToString() + " lives";
        this.speedText.text = playerSpeed.ToString() + "x Speed";
        this.speedPriceText.text = speedPrice.ToString() + " Points";
        this.livePriceText.text = livesPrice.ToString() + " Points";

        if (points < livesPrice | (PlayerPrefs.GetInt("Starting Lives") >= 4))
        {
            livesButton.SetActive(false);
            MaxLives.SetActive(true);
            lpt.SetActive(false);
        }
        else
        {
            livesButton.SetActive(true);
            MaxLives.SetActive(false);
            lpt.SetActive(true);
        }
        if (points < speedPrice | (PlayerPrefs.GetFloat("Player Speed") >= 1))
        {
            speedButton.SetActive(false);
            MaxSpeed.SetActive(true);
            spt.SetActive(false);
        }
        else
        {
            speedButton.SetActive(true);
            MaxSpeed.SetActive(false);
            spt.SetActive(true);
        }

    }

    public void buySpeed()
    {
        PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points") - speedPrice);
        PlayerPrefs.SetFloat("Player Speed", PlayerPrefs.GetFloat("Player Speed") + 0.1f);
        PlayerPrefs.SetInt("Speed Price", PlayerPrefs.GetInt("Speed Price") + 200);
    }

    public void buyLives()
    {
        PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points") - livesPrice);
        PlayerPrefs.SetInt("Starting Lives", PlayerPrefs.GetInt("Starting Lives") + 1);
        PlayerPrefs.SetInt("Lives Price", PlayerPrefs.GetInt("Lives Price") + 200);
    }

    public void resetStats()
    {
        PlayerPrefs.SetInt("Starting Lives", 0);
        PlayerPrefs.SetInt("Lives Price", 0);
        PlayerPrefs.SetFloat("Player Speed", 0);
        PlayerPrefs.SetInt("Speed Price", 0);
    }
}
