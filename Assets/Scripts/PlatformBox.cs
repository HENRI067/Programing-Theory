using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBox : Box
{
    bool increaseSize = false;
    float finalSize = 5f;
    float growSpeed = 1f;
    Transform box;
    private void Awake()
    {
        box = transform.Find("Box");
    }
    void Update()
    {
        BoxUpdate(); 

        if (increaseSize)
        {
            IncreaseInSize();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        increaseSize = true;
        Destroy(gameObject.GetComponent<BoxCollider>());
        box.Find("Cube").GetComponent<BoxCollider>().enabled = true;
    }

    void IncreaseInSize()
    {
        if(box.localScale.z < finalSize)
        {
            box.localScale += new Vector3(0, 0, growSpeed * Time.deltaTime);
        }
        else
        {
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

}
