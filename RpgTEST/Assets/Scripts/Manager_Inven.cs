using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager_Inven : MonoBehaviour
{
    [Header("Frame")]
    public GameObject charInfoFrame;
    public GameObject bagFrame;

    [Header("Bag")]
    public int gold;
    public TextMeshProUGUI goldAmount;

    public void OpenBag()
    {
        goldAmount.text=gold.ToString();
        bagFrame.SetActive(true);
    }
}