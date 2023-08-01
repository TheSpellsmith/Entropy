using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text LevelText;
    public TMP_Text ScoreText;
    public TMP_Text HighScoreText;

    public void Update()
    {
        setText();
    }

    public void setText()
    {
        LevelText.SetText("Level " + ScoreTracker.Instance.level);
        ScoreText.SetText("" + ScoreTracker.Instance.playerScore);
        HighScoreText.SetText("Highscore: " + ScoreTracker.Instance.highScore);
    }


}
