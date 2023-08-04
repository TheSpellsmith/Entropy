using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Astroid : MovingObject
{
    private float scaleMultiplyer;
    private Vector2 newScale;

    private void Start()
    {
        AddDownForce();
        RandomizeSize();
        RandomizeRotation();
    }
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ship"))
        {
            ScoreTracker.Instance.finalScore = ScoreTracker.Instance.playerScore;
            ScoreTracker.Instance.setHighScore();
            ScoreTracker.Instance.satalitesDestroyed = 0;
            ScoreTracker.Instance.playerScore = 0;
            ScoreTracker.Instance.finalScore = 0;
            SceneManager.LoadScene(0);
        }
    }

    private void RandomizeSize()
    {
        scaleMultiplyer = Random.Range(.1f, .4f);
        newScale = new Vector2(scaleMultiplyer, scaleMultiplyer);
        gameObject.transform.localScale = newScale;
    }

    public void DestroyOffScreen ()
    {
        if (gameObject.transform.position.y < -6)
        {
            Destroy(gameObject);
        }

        if (gameObject.transform.position.x > 10)
        {
            Destroy(gameObject);
        }

        if (gameObject.transform.position.x < -10)
        {
            Destroy(gameObject);
        }

    }

}
