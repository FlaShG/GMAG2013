using UnityEngine;
using System.Collections.Generic;

public class Planet : MonoBehaviour
{
    private static List<Planet> planets = new List<Planet>();
    public float mass = 100;

    
    public static Vector3 GetGravitationForPosition(Vector3 position)
    {
        var v = Vector3.zero;
        
        foreach(var planet in planets)
        {
            var dir = planet.transform.position - position;
            dir = dir.normalized * (1/Mathf.Pow(dir.magnitude, 2)) * planet.mass;
            
            v += dir;
        }
        
        return v;
    }

	
	void Awake()
    {
        planets.Add(this);
	}
    
    void OnDestroy()
    {
        planets.Remove(this);
    }
}
