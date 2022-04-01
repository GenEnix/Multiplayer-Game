using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player_Move : MonoBehaviour
{
    [Header("Movement Parameters")]
    public float walkSpeed;
    public float runSpeed;

    [HideInInspector]
    public float currentSpeed = 2;

    [HideInInspector]
    public float speedMultiplier = 1;
    [HideInInspector]
    public float speedMultiplierTarget = 1;

    private Vector3 movePos;

    public enum RunType
    {
        toggle,
        hold
    }

    public RunType runType;

    public bool running;

    [HideInInspector]
    public bool isDart;

    public CharacterController controller;

    
    
    [Header("Look Parameters")]
    public float sens;
    [HideInInspector]
    public float xRot;
    public GameObject playerCam;



    [Header("Heabob Parameters")]
    public bool useHeabob;
    private float bobSpeed;
    public float bobAmount;
    float timer;
    float defultYPos;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        defultYPos = playerCam.transform.localPosition.y;

        bobSpeed = currentSpeed * 2;
    }

    void Update()
    {
        HandleLook();
        HandleMovement();
        HandleHeadbob();
    }

    void HandleLook()
    {
        float x = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;

        xRot -= y;
        xRot = Mathf.Clamp(xRot, -90, 75);

        playerCam.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        transform.Rotate(transform.up * x);
    }

    void HandleMovement()
    {
        float mV;
        float mH;

        if (isDart)
        {
            mV = 1;
            mH = Input.GetAxis("Horizontal");

            currentSpeed = runSpeed;
        }
        else
        {
            mV = Input.GetAxis("Vertical");
            mH = Input.GetAxis("Horizontal");

            if (runType == RunType.hold)
            {
                if (Input.GetButton("Run") && controller.velocity.magnitude > 0 && mV > 0)
                {
                    running = true;
                }
                else
                {
                    running = false;
                }
            }
            else
            {
                if (controller.velocity.magnitude > 0 && mV > 0)
                {
                    if (Input.GetButtonDown("Run") && runType == RunType.toggle)
                    {
                        running = !running;
                    }
                }
                else
                {
                    running = false;
                }
            }
        }

        currentSpeed = Mathf.Lerp(currentSpeed, (running ? runSpeed : walkSpeed), 5f * Time.deltaTime);
        speedMultiplier = Mathf.Lerp(speedMultiplier, speedMultiplierTarget, 5 * Time.deltaTime);

        movePos = transform.right * mH + transform.forward * mV;

        controller.Move(movePos * Time.deltaTime * currentSpeed * speedMultiplier);
    }

    void HandleHeadbob()
    {
        if (!useHeabob)
            return;

        if (Mathf.Abs(movePos.x) > 0.1f || Mathf.Abs(movePos.z) > 0.1f)
        {
            timer += Time.deltaTime * bobSpeed * (speedMultiplier * 0.75f);
            playerCam.transform.localPosition = new Vector3(
                playerCam.transform.localPosition.x, 
                defultYPos + Mathf.Sin(timer) * bobAmount, 
                playerCam.transform.localPosition.z
                );
        }
        else
        {
            timer += Time.deltaTime * bobSpeed * (speedMultiplier * 0.75f);
            playerCam.transform.localPosition = new Vector3(
                playerCam.transform.localPosition.x, 
                defultYPos, 
                playerCam.transform.localPosition.z
                );
        }
    }
}
