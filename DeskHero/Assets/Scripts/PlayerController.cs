using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public enum playerDirection
{
    Down  = 0,
    Up    = 1, 
    Left  = 2, 
    Right = 3

}

public class PlayerController : MonoBehaviour
{

    public InputAction MoveAction;
    public playerDirection direction;
    public Animator animator;

    public bool isMoving;



    // Start is called before the first frame update
    void Start()
    {

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        MoveAction.Enable();
        isMoving = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = MoveAction.ReadValue<Vector2>();

        if (move != Vector2.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }


        if (move == Vector2.down)
        {
            direction = playerDirection.Down;
        }
        else if (move == Vector2.up)
        {
            direction = playerDirection.Up;
        }
        else if (move == Vector2.left)
        {
            direction = playerDirection.Left;
        }
        else if (move == Vector2.right)
        {
            direction = playerDirection.Right;
        }

        animator.SetInteger("Direction", (int)direction);
        animator.SetBool("isMoving", isMoving);

        Debug.Log(move);
        Vector2 position = (Vector2)transform.position + move * 4.0f * Time.deltaTime;
        transform.position = position;        

    }
}