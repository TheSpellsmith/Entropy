using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public Vector2 knockbackDirection;
    public Vector2 objectPos;
    public Rigidbody2D objectRB;
    public float fallSpeed;
    public void ScreenWrap()
    {
        if (gameObject.transform.position.x > 10)
        {
            gameObject.transform.position = new Vector2(-10, gameObject.transform.position.y);
        }

        if (gameObject.transform.position.x < -10)
        {
            gameObject.transform.position = new Vector2(10, gameObject.transform.position.y);
        }

    }
    public void OnExplode(Vector2 BombPosition, float ExplosionRange, float ExplosionPower)
    {
        objectPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        if (Vector2.Distance(BombPosition, objectPos) < ExplosionRange)
        {
            ExplodeEffect(BombPosition, ExplosionPower);
        }
    }

    public void RandomizeRotation()
    {
        gameObject.transform.rotation = Quaternion.AngleAxis(Random.Range(1, 360), Vector3.forward);
    }

    public virtual void ExplodeEffect(Vector2 BombPosition, float ExplosionPower)
    {
        knockbackDirection = objectPos - BombPosition;
        objectRB.AddForce(knockbackDirection * ExplosionPower, ForceMode2D.Impulse);
    }

    public void AddDownForce()
    {
        objectRB.AddForce(Vector2.down * GameManager.Instance.objectSpeed, ForceMode2D.Force);
    }
}
