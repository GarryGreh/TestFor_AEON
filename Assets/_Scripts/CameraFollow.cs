using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    [SerializeField]
    private float distance;
    [SerializeField]
    private float height;
    [SerializeField]
    private float angleX;

    private void Update()
    {
        if (FindObjectOfType<BallController>())
        {
            target = FindObjectOfType<BallController>().transform;
            Vector3 posCam = new Vector3(target.position.x, target.position.y + height, target.position.z - distance);
            transform.position = posCam;
            Vector3 rotCam = new Vector3(transform.rotation.x + angleX, transform.rotation.y, transform.rotation.z);
            transform.eulerAngles = rotCam;
        }
    }
}
