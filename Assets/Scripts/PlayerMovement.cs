using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float baseSpeed;
    public float mouseSens;
    public Camera playerCamera;
    public float groundCheckExtends;
    public LayerMask groundLayer;
    public LayerMask targetLayer;
    public float jumpForce;
    
    public float linearDamping;
    public float linearDampingAirborne;
    public float AirbourneSpeedMultiplier;

    private bool jumpRequest = false;
    private bool HorizontalMoveRequest = false;
    private bool VerticalMoveRequest = false;
    private float airborneSpeed;
    private float currentSpeed;

    private float verticalAxis;
    private float horizontalAxis;
    private bool canJump;
    [SerializeField] private Transform camPivot;
    float camRotation;
    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        currentSpeed = baseSpeed;
        airborneSpeed = baseSpeed * AirbourneSpeedMultiplier;
    }



    // Update is called once per frame
    void Update()
    {
        //movement Input
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        //player rotation  
        transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSens, 0);

        //vertical cam rotation
        camRotation -= Input.GetAxis("Mouse Y");
        camRotation = Mathf.Clamp(camRotation, -20f, 45f);
        playerCamera.transform.localRotation = Quaternion.Euler(camRotation, 0, 0);

        //movement requests
        if (horizontalAxis != 0)
        {
            HorizontalMoveRequest = true;
        }
        if (verticalAxis != 0)
        {
            VerticalMoveRequest = true;
        }

        //jumping
        if (Input.GetKeyDown("space") && IsGrounded())
        {
            jumpRequest = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            //shoot
        }


        //adjust damping for when midair
        if (!IsGrounded())
        {
            rb.linearDamping = linearDampingAirborne;
            currentSpeed = airborneSpeed;
        }
        if (IsGrounded())
        {
            rb.linearDamping = linearDamping;
            currentSpeed = baseSpeed;
        }

    }

    private void FixedUpdate()
    {
        //execute jump
        if (jumpRequest)
        {
            canJump = false;
            jumpRequest = false;
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        //execute movement
        if (VerticalMoveRequest)
        {
            rb.AddForce(transform.forward * verticalAxis * currentSpeed, ForceMode.Acceleration);
            VerticalMoveRequest = false;
        }
        if (HorizontalMoveRequest)
        {
            rb.AddForce(transform.right * horizontalAxis * currentSpeed, ForceMode.Acceleration);
            HorizontalMoveRequest = false;
        }
    }

    private bool IsGrounded()
    {
        //Grounded check
        return Physics.Raycast(transform.GetComponent<Collider>().bounds.center, -transform.up, transform.GetComponent<Collider>().bounds.extents.y + groundCheckExtends, groundLayer);
    }

    public void Die()
    {
        //Die?
    }
}
