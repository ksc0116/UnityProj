using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject dashEffect;
    [SerializeField]
    private float moveSpeed = 2f;
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private PlayerAnimatorController player;


    private Vector3 moveDirection;

    private Movement movement;
    private Rigidbody rigid;

    private float hAxis;
    private float vAxis;

    private bool isRoll;
    public bool IsRoll { get { return isRoll; } set { isRoll = value; } }

    private bool isDash;
    public float defaultTime;

    private bool isJump;

    private void Awake()
    {
        movement=GetComponent<Movement>();
        player=GetComponentInChildren<PlayerAnimatorController>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputManager();

        SetMoveDirection();

        Move();

        Attack();

        Jump();


        Dash();
    }

    private void InputManager()
    {
        if (isRoll == false)
        {
            hAxis = Input.GetAxisRaw("Horizontal");
            vAxis = Input.GetAxisRaw("Vertical");
        }
    }

    private void SetMoveDirection()
    {
        moveDirection = new Vector3(hAxis, 0, vAxis);
    }
    private void Move()
    {
        Quaternion tempRot = cameraTransform.rotation;
        tempRot.eulerAngles = new Vector3(50, cameraTransform.eulerAngles.y, 0);
        movement.MoveTo(tempRot * moveDirection);
        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

        player.MoveAni(hAxis, vAxis);
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            player.AttackAni();
        }
    }


    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDash)
        {
            isJump = true;
            Manager.instance.soundManager.Audio.PlayOneShot(Manager.instance.soundManager.Jump);
            movement.JumpTo();
            StartCoroutine("JumpOut");
            player.JumpAni();
        }
    }
    private IEnumerator JumpOut()
    {
        yield return new WaitForSeconds(0.85f);
        isJump = false;
    }
    private void Dash()
    {
        if (Input.GetMouseButtonDown(1) && !isJump)
        {
            StartCoroutine("DashStart");
        }
    }
    private IEnumerator DashStart()
    {
        isDash = true;
        dashEffect.SetActive(true);
        movement.MoveSpeed = 30f;

        yield return new WaitForSeconds(0.3f);
        isDash = false;
        dashEffect.SetActive(false);
        movement.MoveSpeed = 5f;
    }
}