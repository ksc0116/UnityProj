using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObj : MonoBehaviour
{
    public float disableTime;

    private void OnEnable()
    {
        StopCoroutine(DisableStart());
        StartCoroutine(DisableStart());
    }
    IEnumerator DisableStart()
    {
        yield return new WaitForSeconds(disableTime);
        Disable();
    }
    void Disable()
    {
        gameObject.SetActive(false);
    }
}
