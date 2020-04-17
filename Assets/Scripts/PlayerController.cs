using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // This script will control the player

    public int m_PlayerNumber = 1;                      // Used to identify the player
    public float m_Speed = 10f;                         // How fast the player moves forward and back
    public float m_TurnSpeed = 180f;                    // How fast the player turns in degrees per second
    public float m_RotationSmoothTime = 1.2f;
    public float m_RotationSmoothVelocity = 0.2f;
    public float m_JumpForce = 50f;

    public bool m_OnFloor;

    private float m_MovementInputValue;                 // The current value of the movement input
    private Rigidbody m_RigidBody;                      // Reference used to move the tank

    private Transform m_CameraTransform;                // Reference used to move the tank in the direction of the main camera

    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        m_MovementInputValue = 0f;

        m_CameraTransform = Camera.main.transform;
        m_OnFloor = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Store the value of the moving forward axis
        m_MovementInputValue = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // Adjust the rigidbodies position in FixedUpdate
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
        m_RigidBody.MovePosition(m_RigidBody.position + movement);

        Jump();
    }

    private void Turn()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + m_CameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref m_RotationSmoothVelocity, m_RotationSmoothTime);
        }
    }

    private void Jump()
    {
        if (Input.GetButton("Jump") && m_OnFloor)
        {
            m_RigidBody.AddForce(transform.up * m_JumpForce, ForceMode.Impulse); ;
            m_OnFloor = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            m_OnFloor = true;
        }
    }
}
