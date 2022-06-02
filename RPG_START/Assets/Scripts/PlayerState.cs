using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int lev;
    public float hp;
    public int atk;
    public int def;
    public float cri;
    public float exp_Max;

    public float exp_Cur;
    public float hp_Cur;

    private void OnEnable()
    {
        hp_Cur = hp;
    }
}
