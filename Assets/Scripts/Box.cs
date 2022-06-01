using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private bool mouseOver;


    private void Update() { BoxUpdate(); }

    protected void BoxUpdate()
    {
        if (transform.position.y < -50f) Destroy(this.gameObject);
        if (mouseOver) transform.Find("Indicator").gameObject.SetActive(true); 
        else transform.Find("Indicator").gameObject.SetActive(false);
    }

    private void OnMouseOver()
    {
        mouseOver = true;
    }
    private void OnMouseExit()
    {
        mouseOver = false;
    }
}
