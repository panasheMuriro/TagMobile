using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FishNet.Object;
using FishNet.Connection;
using FishNet.Object.Synchronizing;

public class PlayerMovement : NetworkBehaviour
{

    // Start is called before the first frame update
    private Rigidbody2D rb;
    public Button jumpButton;
    public Button leftButton;
    public Button rightButton;

    public Button upButton;
    public Button downButton;


    // private Vector2 targetPosition;
    public float jumpHeight = 5f;
    // public float moveSpeed = 2f;

    private Vector2 movement;


    private Vector2 targetPosition;
    public float moveSpeed = 0.5f;
    public float lerpSpeed = 5f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = rb.position;
    }



    public override void OnStartClient()
    {

        base.OnStartClient();

        if (IsOwner)
        {

            // rb.MovePosition(Vector2.Lerp(rb.position, targetPosition, Time.fixedDeltaTime * moveSpeed));
            // Find buttons by name
            // jumpButton = GameObject.Find("JumpButton").GetComponent<Button>();
            leftButton = GameObject.Find("LeftButton").GetComponent<Button>();
            rightButton = GameObject.Find("RightButton").GetComponent<Button>();

            upButton = GameObject.Find("UpButton").GetComponent<Button>();
            downButton = GameObject.Find("DownButton").GetComponent<Button>();

            // if (jumpButton != null)
            //     jumpButton.onClick.AddListener(OnJumpButtonClick);

            if (leftButton != null)
                leftButton.onClick.AddListener(OnLeftButtonClick);

            if (rightButton != null)
                rightButton.onClick.AddListener(OnRightButtonClick);

            if (upButton != null)
                upButton.onClick.AddListener(OnUpButtonClick);

            if (downButton != null)
                downButton.onClick.AddListener(OnDownButtonClick);
        }

        //   if (!IsOwner)
        //     return;

        // Smoothly move to the target position

    }

    private void FixedUpdate()
    {
        if (!IsOwner) return;

        // Smoothly move to the target position using Lerp
        rb.MovePosition(Vector2.Lerp(rb.position, targetPosition, Time.fixedDeltaTime * lerpSpeed));
    }

    public void OnLeftButtonClick()
    {
        targetPosition = new Vector2(rb.position.x - moveSpeed, rb.position.y);
    }

    public void OnRightButtonClick()
    {
        targetPosition = new Vector2(rb.position.x + moveSpeed, rb.position.y);
    }

    public void OnUpButtonClick()
    {
        targetPosition = new Vector2(rb.position.x, rb.position.y + moveSpeed);
    }

    public void OnDownButtonClick()
    {
        targetPosition = new Vector2(rb.position.x, rb.position.y - moveSpeed);
    }






    // public void OnLeftButtonClick()
    // {
    //     targetPosition = new Vector2(rb.position.x - moveSpeed, rb.position.y);
    // }

    // public void OnRightButtonClick()
    // {
    //     targetPosition = new Vector2(rb.position.x + moveSpeed, rb.position.y);
    // }


    // public void OnUpButtonClick()
    // {
    //     targetPosition = new Vector2(rb.position.x, rb.position.y + moveSpeed);
    // }

    // public void OnDownButtonClick()
    // {
    //     targetPosition = new Vector2(rb.position.x, rb.position.y - moveSpeed);
    // }

}
