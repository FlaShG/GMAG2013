using UnityEngine;
using System.Collections;

public class SpaceBallPlayer : MonoBehaviour
{
    private Planet myPlanet;
	public float speed = 10;
	
	void FixedUpdate()
    {
        if(!myPlanet) return;
        
        var input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        var normal = rigidbody.position - myPlanet.transform.position;
        var q = Quaternion.LookRotation(Vector3.forward, normal);
        var v = q * input * speed;
    
        rigidbody.AddForce(v);
	}
    
    void OnCollisionEnter(Collision c)
    {
        var p = c.collider.GetComponent<Planet>();
        if(p)
        {
            myPlanet = p;
        }
    }
}
