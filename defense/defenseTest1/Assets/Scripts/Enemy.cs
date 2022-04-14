using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private MeshRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("ChangeColor");
        }
    }

    public void TakeDamage(int dmg)
    {
        Debug.Log(dmg);
    }

    private IEnumerator ChangeColor()
    {
        Color color=renderer.material.color;
        renderer.material.color = Color.red;

        yield return new WaitForSeconds(0.1f);
        renderer.material.color = color;
    }
}
