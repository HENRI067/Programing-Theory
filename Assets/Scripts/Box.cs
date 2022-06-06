using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    
    private void Update() 
    {
        BoxUpdate();

    }
    protected void BoxUpdate()
    {
        if (transform.position.y < -50f) Destroy(this.gameObject);
    }



}
