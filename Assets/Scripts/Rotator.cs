using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool rotating = false;
    public Vector3 speed;

    
    void Start()
    {
        
    }
    
    void Update()
    {
        if(rotating)
        {
            transform.Rotate(speed * Time.deltaTime);
        }
        
        //rigidbody.AddForce();
    }
    
    void OnMouseDown()
    {
        rotating = !rotating;
    }
}
