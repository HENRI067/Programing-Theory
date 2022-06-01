using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBox : Box
{
    float finalSize;
    float growSpeed;
    private void Awake()
    {
        IncreaseInSize();
    }
    void Update()
    {
        BoxUpdate();
    }

    void IncreaseInSize()
    {
        while(transform.localScale.z < finalSize)
        {
            transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z + growSpeed * Time.deltaTime);
        }
    }

}
