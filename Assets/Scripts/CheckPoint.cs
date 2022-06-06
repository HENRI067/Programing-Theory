using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public List<Transform> trails;
    public float trailSpeed;
    public float trailTime;
    public float rotateSpeed;

    void Update()
    {
        RenderTrail();

        if (Physics.CheckBox(transform.position + Vector3.up,Vector3.one/2))
        {
            int i = int.Parse(transform.name.Remove(0, 10));
            GameManager.Instance.UnlockBlock(i);
        }


    }


    private void RenderTrail()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        foreach (Transform T in trails)
        {
            float trailtime = trailTime;
            T.position += Vector3.down * trailSpeed * Time.deltaTime;
            if(T.position.y < -1.3f)
            {
                T.position = new Vector3(T.position.x, 3f, T.position.z);
            }
            if (T.position.y < -1.29191f || T.position.y > 2.85f)
            {
                trailtime = 0f;
            }
            foreach (Transform t in T)
            {
                TrailRenderer TR = t.GetComponent<TrailRenderer>();
                TR.time = trailtime;
            }
        }
    }
}
