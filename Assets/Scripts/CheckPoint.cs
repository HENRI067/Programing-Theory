using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public List<Transform> trails;
    public float trailSpeed;
    public float trailTime;
    public float trailYdissapearance;
    public float rotateSpeed;
    public LayerMask layermask;

    void Update()
    {
        RenderTrail();

        if (Physics.CheckBox(transform.position + Vector3.up,Vector3.one/2,Quaternion.identity,layermask))
        {
            int i = int.Parse(transform.name.Remove(0, 10));
            GameManager.Instance.UnlockBlock(i);
            GameManager.Instance.ResetBlockMeter();
        }


    }

    void RenderTrail()
    {
        transform.Rotate(new Vector3(0,rotateSpeed * Time.deltaTime,0));
        foreach(Transform trail in trails)
        {
            trail.localPosition += Vector3.down * trailSpeed * Time.deltaTime;
            if(trail.localPosition.y < trailYdissapearance)
            {
                trail.localPosition = new Vector3(trail.localPosition.x, 3, trail.localPosition.z);
            }
            float trailtime = trailTime;
            if (trail.localPosition.y > 2.89f) trailtime = 0f;
            foreach (Transform t in trail)
            {
                t.GetComponent<TrailRenderer>().time = trailtime;
            }

        }
    }
}
