using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    [SerializeField]
    private BoxCollider collider;

    public void ColliderState()
    {
        StartCoroutine("OnOff");
    }

    private IEnumerator OnOff()
    {
        collider.enabled=true;

        yield return new WaitForSeconds(0.1f);

        collider.enabled = false;
    }
}