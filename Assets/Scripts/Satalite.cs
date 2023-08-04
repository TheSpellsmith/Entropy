using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satalite : MovingObject
{
    void Start()
    { 
        AddDownForce();
        RandomizeRotation();
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
            GameManager.Instance.AddScore200();
            SoundManager.Instance.PlaySataliteExplosion();
            Destroy(gameObject);
        }
    }

    public override void ExplodeEffect(Vector2 BombPosition, float ExplosionPower)
    {
        GameManager.Instance.AddScore100();
        SoundManager.Instance.PlaySataliteExplosion();
        Destroy(gameObject);
    }

    public void DestroyOnBot()
    {
        if (gameObject.transform.position.y < -6)
        {
            GameManager.Instance.LoseScore300();
            SoundManager.Instance.PlaySataliteEscape();
            Destroy(gameObject);
        }

    }
}
