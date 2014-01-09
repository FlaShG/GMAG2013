using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour
{
    private bool won = false;
    public string message;

	void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            won = true;
        }
	}
	
	void OnGUI()
    {
        if(won)
        {
            GUI.Box(new Rect(10,10,200,25), message);
        }
        
        if(GUI.Button(new Rect(10,40,200,25), "Klick mich"))
        {
            won = false;
        }
	}
}
