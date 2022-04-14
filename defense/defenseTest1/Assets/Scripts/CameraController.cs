using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float sensitivity = 500f;
    [SerializeField]
    private float xAxisMin = -10f;
    [SerializeField]
    private float xAxisMax = 80f;
    [SerializeField]
    private float minDistance = 0.5f;
    [SerializeField]
    private float maxDistance = 5f;
    [SerializeField]
    private float finalDistance;
    [SerializeField]
    private float rotX,rotY;
    private Vector3 rayVector;
    private float mouseWheelSpeed = 500f;
    [SerializeField]
    private float zoomDistance;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        finalDistance = Vector3.Distance(transform.position, target.position);

        rotX = transform.rotation.eulerAngles.x;
        rotY = transform.rotation.eulerAngles.y;


        zoomDistance = maxDistance / 2.0f;
    }

    private void Update()
    {
        rotX -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        rotY+=Input.GetAxis("Mouse X")*sensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, xAxisMin, xAxisMax);

        Quaternion rot = Quaternion.Euler(rotX, rotY, 0);

        transform.rotation = rot;

        zoomDistance-=Input.GetAxis("Mouse ScrollWheel")*mouseWheelSpeed*Time.deltaTime;
        zoomDistance = Mathf.Clamp(zoomDistance,minDistance,maxDistance);
    }
    private void LateUpdate()
    {
        RaycastHit hit;
        rayVector = transform.position - target.position;
        Debug.DrawRay(target.position, rayVector.normalized * finalDistance, Color.black);
        if (Physics.Raycast(target.position, rayVector, out hit, layerMask))
        {
            finalDistance = Mathf.Clamp(hit.distance, minDistance, zoomDistance);
        }
        else
        {
            finalDistance = zoomDistance;
        }
        transform.position = transform.rotation * new Vector3(0, 0, -finalDistance) + target.position;
    }
}
