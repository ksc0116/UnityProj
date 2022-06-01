using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerContoller : MonoBehaviour, IPointerDownHandler
{
    [Header("[Camera]")]
    public Camera cam;
    public GameObject touchEffect;
    RaycastHit hit;

    [Header("[Player]")]
    public Transform player;
    public float moveSpeed;
    public float rotateSpeed;
    NavMeshAgent playerNav;
    Animator playerAni;

    private void Awake()
    {
        playerNav = player.GetComponent<NavMeshAgent>();
        playerNav.speed = moveSpeed;
        playerNav.angularSpeed = rotateSpeed;
        playerAni = player.GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Ray ray = cam.ScreenPointToRay(eventData.position);
        Physics.Raycast(ray, out hit);

        if (hit.transform != null)
        {
            touchEffect.SetActive(false);
            touchEffect.transform.position=cam.WorldToScreenPoint(hit.point);
            touchEffect.SetActive(true);

            if (hit.transform.tag == "Land")
            {
                playerNav.SetDestination(hit.point);
            }
        }
    }

    private void Update()
    {
        playerAni.SetBool("isWalk",playerNav.velocity!=Vector3.zero);
    }
}
