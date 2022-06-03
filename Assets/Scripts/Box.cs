using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool surfaceTouched;

    //the white box uses this script that why this is here
    private void Update() { BoxUpdate(); }




    private void Awake()
    {
        surfaceTouched = false;
    }
    protected void BoxUpdate()
    {
        if (transform.position.y < -50f) Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
    }


}
