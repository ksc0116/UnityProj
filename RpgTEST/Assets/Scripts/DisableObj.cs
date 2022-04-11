using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObj : MonoBehaviour
{
    public float disableTime;       // 비활성화 될 시간

    private void OnEnable()
    {
        // 오브젝트가 활성화되면 실행중인 Invoke를 취소
        CancelInvoke();

        Invoke("Disable", disableTime);
    }

    // 오브젝트를 끄는 기능
    void Disable()
    {
        gameObject.SetActive(false);
    }
}