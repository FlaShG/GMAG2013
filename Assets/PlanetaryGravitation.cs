using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlanetaryGravitation : MonoBehaviour
{
	void Start()
    {
        rigidbody.useGravity = false;
	}
	
	void FixedUpdate()
    {
        rigidbody.AddForce(Planet.GetGravitationForPosition(rigidbody.position), ForceMode.Acceleration);
	}
}
