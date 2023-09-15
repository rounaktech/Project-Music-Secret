using UnityEngine;
public class MouseLook : MonoBehaviour
{
    public float MouseSensitivity = 100f;
    public float JoystickYSensitivity = 1000f;

    [SerializeField] Transform playerBody;
    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseintEnable();
    }

    void mouseintEnable()
    {
        //Getting Mouse Input
        float mouseX = Input.GetAxisRaw("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * MouseSensitivity * Time.deltaTime;

        //Standard Statement for x rotation
        xRotation -= mouseY;

        //Clamping Y rotation so that head cannot go above 90 degree, i.e., Humanly, your neck will break when looking up and trying to forcefull rotate more 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotating in y
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Rotating in x according to the direction of player (for moving camera with body)
        playerBody.Rotate(Vector3.up * mouseX);
    }
    
    }
