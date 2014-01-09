using UnityEngine;
using System.Collections;

public class ResetOnDeath : MonoBehaviour
{
    private Vector3 startPosition;

	void Awake()
    {
        startPosition = transform.position;
	}
	
	public void OnDeath()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
	}
}
