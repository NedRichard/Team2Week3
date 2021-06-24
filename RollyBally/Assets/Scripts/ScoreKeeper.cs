using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{

    public static ScoreKeeper instance;

    public Text scoreText;

    public Text eaterText;

    int score = 0;

    int eaterScore = 0;

    private void Awake() {
        instance = this;
    }

    void Start() {
        scoreText.text = "Player: " + score.ToString();
        eaterText.text = "Rival: " + eaterScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log("Score:" + score);
    }

    public void AddToPlayerScore() {
        score++;
        scoreText.text = "Player: " + score.ToString();
    }

    public void AddToEaterScore() {
        eaterScore++;
        eaterText.text = "Rival: " + score.ToString();
    }

}
