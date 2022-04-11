using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObj : MonoBehaviour
{
    public float disableTime;       // ��Ȱ��ȭ �� �ð�

    private void OnEnable()
    {
        // ������Ʈ�� Ȱ��ȭ�Ǹ� �������� Invoke�� ���
        CancelInvoke();

        Invoke("Disable", disableTime);
    }

    // ������Ʈ�� ���� ���
    void Disable()
    {
        gameObject.SetActive(false);
    }
}