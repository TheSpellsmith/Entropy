using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satalite : MovingObject
{
    void Start()
    { 
        AddDownForce();
    }

    void Update()
    {
        ScreenWrap();
        DestroyOnBot();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Astroid>(out Astroid astroid))
        {
            ScoreTracker.Instance.AddScore200();
            Destroy(gameObject);
        }
    }
    public override void ExplodeEffect(Vector2 BombPosition, float ExplosionPower)
    {
        ScoreTracker.Instance.AddScore100();
        Destroy(gameObject);
    }

    public void DestroyOnBot()
    {
        if (gameObject.transform.position.y < -6)
        {
            ScoreTracker.Instance.LoseScore300();
            Destroy(gameObject);
        }

    }
}
