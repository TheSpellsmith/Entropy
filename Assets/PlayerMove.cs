using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController player;

    public float playerSpeed;
    
    private float xInput;
    private float yInput;

    private Vector3 moveDir;
    void Update()
    {
        PlayerInput();
    }
    void FixedUpdate()
    {
        MovePlayer();
    }
    private void PlayerInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }
    private void MovePlayer()
    {
        moveDir = new Vector3(xInput, yInput, 0f);
        player.Move(moveDir * playerSpeed);
    }
}
