using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//INHERITANCE
public class Astroid : MovingObject
{
    private float scaleMultiplyer;
    private Vector2 newScale;

    private void Start()
    {
        //ABSRACTION
        AddDownForce();
        RandomizeSize();
        RandomizeRotation();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ship"))
        {
            SoundManager.Instance.PlayShipExplode();
            GameManager.Instance.ResetGame();
            Destroy(other.gameObject);
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
