using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//INHERITANCE
public class PlayerShip : MovingObject
{
    //EMCAPSULATION
    private Vector2 mouseScreenPos;
    private Vector2 direction;
    [SerializeField] private Rigidbody2D shipRB;
    private float shipSpeed = 27;
    [SerializeField] private GameObject bomb;
    private Vector3 bombSpawn;

    public void Update()
    {
        //ABSRACTION
        RotateShip();
        ScreenWrap();
        PlayerBomb();
    }
    public void FixedUpdate()
    {
        MoveShip();
    }

    private void RotateShip() 
    {
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookAt = mouseScreenPosition;
        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);
    }

    private void MoveShip()
    {
        shipRB.AddForce(gameObject.transform.up * shipSpeed);
        transform.up = direction;
    }

    private void PlayerBomb()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bombSpawn = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
            Instantiate(bomb, bombSpawn, gameObject.transform.rotation);
        }
    }
}
