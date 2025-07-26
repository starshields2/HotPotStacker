using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DataManager : MonoBehaviour
{ //DATAMANAGER controls point mults, 

    public TextMeshProUGUI scoreText;
    public PlayerController player;

    public float speedMult;
    public bool genMultOn;
    public int score;
    public int scoreUpdate;
    public int multiplier;
  
    public bool playerSpeedOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = score.ToString();
        speedMult = 6;
        multiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GeneralMultiplier()
    {
        if (!genMultOn)
        {
            StartCoroutine(GeneralMultiplierLogic());
            genMultOn = true;
            //multiplier = 2;
        }
        
    }

    public IEnumerator GeneralMultiplierLogic()
    {
        multiplier = 2;
        yield return new WaitForSeconds(10);
        multiplier = 1;
        genMultOn = false;
    }

    public void UpdateScore()
    {
        score = score + scoreUpdate * multiplier;
        scoreText.text = score.ToString();
    }

    void RamenMultOn()
    {
        float multTimer = 30f;

    }

    public void IncreaseSpeed()
    {
        if (!playerSpeedOn)
        {
            playerSpeedOn = true;
            player.speed = player.speed + speedMult;

        }
    }

}
