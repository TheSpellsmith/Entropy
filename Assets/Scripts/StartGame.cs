using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.finalScore = 0;
            GameManager.Instance.previousHighScore = GameManager.Instance.highScore;
            StartGameButton();
        }
    }
    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }

}
