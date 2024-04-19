using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private float speedRun;
    [SerializeField] private float speedCurrent;
    [Range(0, 10)] [SerializeField] private float smoothSpeed;
    public float jump;
    public float gravity;
    float xMove;
    float zMove;
    CharacterController player;
    Vector3 moveDirection;

    private void Start()
    {
        player = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }
    
    private void Move()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        if (player.isGrounded)
        {
            moveDirection = new Vector3(xMove, 0f, zMove);
            moveDirection = transform.TransformDirection(moveDirection);
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y += jump;
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                player.height = 1f;
            }
            else player.height = 1.8f;
            
        }
       moveDirection.y -= gravity;
        //Бег
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedCurrent = Mathf.Lerp(speedCurrent, speedRun, Time.deltaTime * smoothSpeed );
        }
        else
        {
            speedCurrent = Mathf.Lerp(speedCurrent, speedMove, Time.deltaTime * smoothSpeed);
            
        }
        player.Move(moveDirection * speedCurrent * Time.deltaTime);
    }
}
