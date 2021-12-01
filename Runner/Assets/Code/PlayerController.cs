using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Audio sound;

    private CharacterController controller;
    public GameObject deadPanel;
    public GameObject[] skinPlayer;
    private Animator anim;
    private Vector3 vec3;
    public enum ControlType { Andorid, PC};
    public ControlType controlType;

    public int speed;
    public int jumpPower;
    private int numLine = 1;
    public float lineDistance = 4;
    public float gravity;
    void Start()
    {      
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        sound = FindObjectOfType<Audio>();
        deadPanel.SetActive(false);
        Wear(Store.skin);
    }
    private void Update()
    {
        if(controlType == ControlType.Andorid)
        {
            if (SwitchController.swipeRight)
            {
                if (numLine < 2)
                    numLine++;
            }
            if (SwitchController.swipeLeft)
            {
                if (numLine > 0)
                    numLine--;
            }
            if (SwitchController.swipeUp)
            {
                if (controller.isGrounded)
                    Jump();
            }
        }

        else if(controlType == ControlType.PC)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (numLine < 2)
                    numLine++;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (numLine > 0)
                    numLine--;
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                if (controller.isGrounded)
                    Jump();
            }
        }


        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (numLine == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (numLine == 2)
            targetPosition += Vector3.right * lineDistance;

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vec3.z = speed;
        vec3.y += gravity * Time.fixedDeltaTime;
        controller.Move(vec3 * Time.fixedDeltaTime);
    }
    private void Jump()
    {
        sound.Effects(3);
        vec3.y = jumpPower;
    }

    public void Dead()
    {
        sound.Effects(2);
        anim.SetTrigger("dead");
        deadPanel.SetActive(true);
    }
    private void Wear(int color)
    {
        for (int i = 0; i < skinPlayer.Length; i++)
        {
            skinPlayer[i].SetActive(false);
        }
        skinPlayer[color].SetActive(true);
        Store.skin = color;
    }
}
