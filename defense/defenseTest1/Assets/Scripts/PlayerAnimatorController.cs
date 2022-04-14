using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void MoveAni(float hAxis, float vAxis)
    {
        anim.SetFloat("horizontal", hAxis);
        anim.SetFloat("vertical", vAxis);
    }
    public void AttackAni()
    {
        anim.SetTrigger("onAttack");
    }
    public void JumpAni()
    {
        anim.SetTrigger("onJump");
    }
}