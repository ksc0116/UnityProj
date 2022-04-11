using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour, IPointerClickHandler
{
    [Header("Camera")]
    public Camera cam;
    public GameObject touchEffect;   
    private RaycastHit hit;

    [Header("Player")]
    public Transform player;
    public float moveSpeed;
    public float ratateSpeed;
    private NavMeshAgent playerNav;
    private Animator playerAnim;

    private void Start()
    {
        playerNav = player.GetComponent<NavMeshAgent>();
        playerNav.speed = moveSpeed;
        playerNav.angularSpeed = ratateSpeed;
        playerAnim = player.GetComponent<Animator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Ray ray = cam.ScreenPointToRay(eventData.position);
        Physics.Raycast(ray, out hit);

        if (hit.transform != null)
        {
            touchEffect.SetActive(false);
            touchEffect.transform.position=cam.WorldToScreenPoint(hit.point);
            touchEffect.SetActive(true);

            if (hit.transform.gameObject.tag == "Land")
                playerNav.SetDestination(hit.point);

            if (hit.transform.gameObject.tag == "Player")
            {
                Manager.instance.manager_SE.seAudio.PlayOneShot(
                    Manager.instance.manager_SE.btnA);

                Manager.instance.manager_Inven.charInfoFrame.SetActive(true);

                Manager.instance.manager_Inven.OpenBag();
            }
        }
    }
    private void Update()
    {
        playerAnim.SetBool("Walk", playerNav.velocity != Vector3.zero);
    }
}