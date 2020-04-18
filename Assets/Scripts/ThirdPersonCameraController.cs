using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    // This script will control a camera that is attached to a player

    public GameObject player;
    public bool m_LockCursor;
    public float m_DistanceFromTarget = 2f;
    public float m_MouseSensitivity = 10f;
    public float m_RotationSmoothTime = 1.2f;
    public Vector2 m_PitchMinMax = new Vector2(-40, 80);

    private Vector3 m_RotationSmoothVelocity;
    private Vector3 m_CurrentRotation;

    private float m_Yaw;
    private float m_Pitch;

    // Start is called before the first frame update
    void Start()
    {
        m_Yaw = 0f;
        m_Pitch = 0f;

        if (m_LockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void Update()
    {
        m_Yaw += Input.GetAxis("Mouse X") * m_MouseSensitivity;
        m_Pitch -= Input.GetAxis("Mouse Y") * m_MouseSensitivity;
        m_Pitch = Mathf.Clamp(m_Pitch, m_PitchMinMax.x, m_PitchMinMax.y);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        m_CurrentRotation = Vector3.SmoothDamp(m_CurrentRotation, new Vector3(m_Pitch, m_Yaw), ref m_RotationSmoothVelocity, m_RotationSmoothTime);
        transform.eulerAngles = m_CurrentRotation;

        transform.position = player.transform.position - transform.forward * m_DistanceFromTarget;
    }
}
