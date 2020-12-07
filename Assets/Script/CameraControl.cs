using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform playerCam;


    private void Update()
    {
        transform.position = new Vector3(playerCam.position.x, playerCam.position.y, transform.position.z);
    }
}
