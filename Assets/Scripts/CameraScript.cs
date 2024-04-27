using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private int upCamera;
    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y+ upCamera, transform.position.z);
    }
}
