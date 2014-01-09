using UnityEngine;
using System.Collections;

public class SimpleFollow : MonoBehaviour
{
    private Transform me;
    public Transform target;
	
    
    void Awake()
    {
        me = transform;
    }
    
	void LateUpdate()
    {
        me.position = target.position;
	}
}