using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float smoothInputTime = 0.2f;
    [SerializeField]
    private float jumpStrength = 5f;
    [SerializeField]
    private LayerMask groundLayerMask;


    private PlayerController playerInputActions;

    private InputAction movement;
    private InputAction jump;

    private Rigidbody2D rb;

    private Vector2 currentInputVector;
    private Vector2 smoothInputVelocity;

    private int jumpStatus;

    private void Awake()
    {
        playerInputActions = new PlayerController();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        playerInputActions.Enable();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        Vector2 input = playerInputActions.PlayerControls.Move.ReadValue<Vector2>();
        currentInputVector = Vector2.SmoothDamp(currentInputVector, input, ref smoothInputVelocity, smoothInputTime);    


        if(playerInputActions.PlayerControls.Jump.triggered && jumpStatus > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength * jumpStatus);
            jumpStatus -= 1;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(currentInputVector.x * moveSpeed, rb.velocity.y);
    }

    private void OnDisable()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(1 << other.gameObject.layer);
        Debug.Log(groundLayerMask.value);
        if(1 << other.gameObject.layer == groundLayerMask.value)
        {
            jumpStatus = 2;
        }
    }

}
