using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public TMP_Text LevelText;
    public TMP_Text ScoreText;
    public TMP_Text HighScoreText;

    public void Update()
    {
        //ABSRACTION
        setText();
    }

    public void setText()
    {
        LevelText.SetText("Level " + GameManager.Instance.level);
        ScoreText.SetText("" + GameManager.Instance.playerScore);
        HighScoreText.SetText("Highscore: " + GameManager.Instance.highScore);
    }


}
