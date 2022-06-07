using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Variable")]
    [SerializeField]private float OBoxAmmount;
    [SerializeField]private float BBoxAmmount;
    [SerializeField]private float WBoxAmmount;

    [Header("Components")]
    public List<GameObject> Boxes;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform spawnPlacement;
    [SerializeField] LayerMask layers;

    private float boxcastDistance = 3;
    private int boxSelected;


    private void Start()
    {
        boxcastDistance = spawnPosition.localPosition.z;
    }

    private void Update()
    {
        int boxesUnlocked = GameManager.Instance.boxUnlucked;
        if (boxesUnlocked > 0)
        {
            //
            spawnPlacement.gameObject.SetActive(true);
            if (Physics.BoxCast(playerCamera.position, Vector3.one / 2, playerCamera.transform.forward, out RaycastHit hit, playerCamera.rotation, boxcastDistance, layers))
            {
                spawnPlacement.position = playerCamera.position + playerCamera.forward * hit.distance;
            }
            else
            {
                spawnPlacement.position = spawnPosition.position;
            }

            if(boxSelected == 0)
            {
                foreach(Transform T in spawnPlacement)
                {
                    T.GetComponent<MeshRenderer>().material = GameObject.Find("WhiteTransparent").GetComponent<MeshRenderer>().material;
                }
            }
            if (boxSelected == 1)
            {
                foreach (Transform T in spawnPlacement)
                {
                    T.GetComponent<MeshRenderer>().material = GameObject.Find("BlueTransparent").GetComponent<MeshRenderer>().material;
                }
            }
            if (boxSelected == 2)
            {
                foreach (Transform T in spawnPlacement)
                {
                    T.GetComponent<MeshRenderer>().material = GameObject.Find("OrangeTransparent").GetComponent<MeshRenderer>().material;
                }
            }
        }
        else
        {
            spawnPlacement.gameObject.SetActive(false);
        }

        //
        if (Input.GetKeyDown(KeyCode.Alpha1) && boxesUnlocked >= 1) boxSelected = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2) && boxesUnlocked >= 2) boxSelected = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3) && boxesUnlocked >= 3) boxSelected = 2;

        if (Input.GetMouseButtonDown(0) && boxesUnlocked > 0 && GameManager.Instance.GetSlider(boxSelected).value > 0)
        {
            GameManager.Instance.RemoveBlock(boxSelected);
            Instantiate(Boxes[boxSelected], spawnPlacement.position, spawnPlacement.rotation);
        }

    }

}
