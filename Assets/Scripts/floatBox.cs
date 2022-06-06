using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class floatBox : Box
{
    [SerializeField] float timeFlying = 4f;
    [SerializeField] float upSpeed = 1f;

    bool flyUp = false;
    private Rigidbody RB;
     
    private IEnumerator Start()
    {
        
        yield return new WaitForSeconds(1f);
        RB = GetComponent<Rigidbody>();
        RB.constraints = RigidbodyConstraints.None;
        RB.constraints = RigidbodyConstraints.FreezeRotation;
        flyUp = true;
        yield return new WaitForSeconds(timeFlying);
        flyUp = false;
        RB.constraints = RigidbodyConstraints.None;
        MeshRenderer MR = GetComponent<MeshRenderer>();
        MR.material = GameObject.Find("White").GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        if (flyUp)RB.velocity = Vector3.up * upSpeed;
    }

}
