using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items_Info : MonoBehaviour
{
    [Header("[Commom Info]")]
    public string type;
    public string name_Item;
    public string info_Item;
    public int resalePrice;
    public int count;

    [Header("[Equipment Info]")]
    public int hpBonus;
    public int atkBonus;
    public int defBonus;
    public float criBonus;

    public bool equipped;
    /*¡Ü*/public Mesh mesh;
    /*¡Ü*/public int equipNum;
}