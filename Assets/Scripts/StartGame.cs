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
            StartGameButton();
        }
    }
    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }

}
