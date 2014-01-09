using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class CCMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;
    
    public float speed = 6;
    public float gravity = 10;
    public float jump = 10;
    public float airSpeed = 6;
    

	void Awake()
    {
        controller = GetComponent<CharacterController>();
	}
	
	void Update()
    {
        if(controller.isGrounded)
        {
            movement.x = Input.GetAxis("Horizontal") * speed;
            movement.y = -5;
            
            if(Input.GetButtonDown("Jump"))
            {
                movement.y = jump;
            }
        }
        else
        {
            movement.x += Input.GetAxis("Horizontal") * airSpeed * Time.deltaTime;
            movement.y -= gravity * Time.deltaTime;
        }
        
        var position = transform.position;
        controller.Move(movement * Time.deltaTime);
        movement = (transform.position - position) / (Time.deltaTime == 0 ? 1 : Time.deltaTime);
	}
}













