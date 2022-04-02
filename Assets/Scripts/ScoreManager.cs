using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public TextMeshProUGUI scoreText;
    public int score;

    private void Start()
    {
        this.score = 0;
    }

    public void UpdateScore()
    {
        this.score++;
        this.scoreText.text = this.score.ToString();
    }
}
