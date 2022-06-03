using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> Boxes;

    [SerializeField] LayerMask layers;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform spawnPlacement;
    private float boxcastDistance = 3;


    private void Start()
    {
        boxcastDistance = spawnPosition.position.z;
    }

    private void Update()
    {
        if (Physics.BoxCast(playerCamera.position, Vector3.one / 2f, playerCamera.forward, out RaycastHit hit, playerCamera.rotation, boxcastDistance, layers))
        {
            Vector3 position = playerCamera.position + playerCamera.forward * (hit.distance);
            spawnPlacement.position = position;
        }
        else
        {
            spawnPlacement.position = spawnPosition.position;
        }
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(Boxes[0],spawnPlacement.position,spawnPlacement.rotation);
        }
    }
}
