using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{
    public float speed = 10;
    public float jump = 20;

	
	void FixedUpdate()
    {
        if(networkView && !networkView.isMine) return;
    
        var input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        input = Vector3.ClampMagnitude(input, 1);
        
        rigidbody.AddForce(input * speed);
        
        
        bool isGrounded = Physics.Raycast(transform.position, -Vector3.up, 0.5f + 0.05f);
        
        
        if(isGrounded && Input.GetButton("Jump"))
        {
            var v = rigidbody.velocity;
            v.y = Mathf.Max(v.y, jump);
            rigidbody.velocity = v;
        }
	}
    
    [RPC]
    private void SetColor(Vector3 color)
    {
        renderer.material.color = new Color(color.x, color.y, color.z);
    }
}













