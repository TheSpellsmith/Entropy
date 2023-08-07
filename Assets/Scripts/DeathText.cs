using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathText : MonoBehaviour
{
    public TMP_Text deathText;
    private float pointDif;

    private void Start()
    {
        SetDeathText();
    }
    private void SetDeathText()
    {
        if(GameManager.Instance.previousHighScore != GameManager.Instance.highScore)
        {
            deathText.SetText("You got a new highscore of " + GameManager.Instance.highScore + " points!");
        }
        else
        {
            pointDif= GameManager.Instance.highScore - GameManager.Instance.finalScore;
            deathText.SetText("You got " + GameManager.Instance.finalScore + " points and were "  + pointDif + " points away from a your previous highscore of " + GameManager.Instance.highScore + " points!");
        }
    }
}
