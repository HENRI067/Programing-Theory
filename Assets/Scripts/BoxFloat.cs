using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFloat : Box
{
    float distance;
    float speed;
    private void Update()
    {
        BoxUpdate();
    }
}
