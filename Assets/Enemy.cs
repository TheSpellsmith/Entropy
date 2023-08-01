using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D enemyRB;
    public float enemySpeed;
    private Vector2 direction;
    void Update()
    {
        Vector3 lookAt = player.transform.position;
        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);
    }
    public void FixedUpdate()
    {
        enemyRB.AddForce(gameObject.transform.up * enemySpeed);
        transform.up = direction;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            Destroy(gameObject);
        }
    }

}
