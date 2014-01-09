using UnityEngine;
using System.Collections;

public class LoseTrigger : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
    {
        //other.Reset();
        
        var rod = other.GetComponent<ResetOnDeath>();
        
        if(rod != null)
        {
            rod.OnDeath();
        }
	}
}
