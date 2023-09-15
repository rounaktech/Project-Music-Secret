using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public CharacterController Controller;
    [SerializeField] public float speed = 12f;
    bool isMoving = false;

    [Header("Gravity and Ground Check")]
    [SerializeField] float gravity = -9.81f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] float idleGravity = -2f;
    public LayerMask GroundMask;
    bool isGrounded;
    Vector3 velocity;

    [Header("Jump")]
    [SerializeField] float jump = 4f;

    [Header("Raycast")]
    [SerializeField] float rayLenght;
    [SerializeField] Material highlightMaterial;
    [SerializeField] Material defaultMaterial;
    Transform _selection;
    void Update()
    {
        //Checking whether player is grounded or not. 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, GroundMask);
        //Applying idle gravity and stopping its continuous y decrement
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = idleGravity;
        }
        else
        {
            movement();
            jumping();
            gravityApply();
            pianoPlay();
        }
    }

    void movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (move.magnitude != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        Controller.Move((move * speed) * Time.deltaTime); //Using Brackets for efficiency - Always multiply only 2 variables at ones
    }

    void gravityApply()
    {
        velocity.y += gravity * Time.deltaTime;
        Controller.Move(velocity * Time.deltaTime);
    }

    void jumping()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = 0;
            velocity.y = Mathf.Sqrt(jump);
        }
    }

    void pianoPlay()
    {
        if (_selection != null)
        {
            var SelectionRenderer = _selection.GetComponent<Renderer>();
            SelectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, rayLenght))
        {
            var selection = hit.transform;
            if (selection.CompareTag(GlobalConstants.TAG_KEY))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                defaultMaterial = selectionRenderer.material;
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }
                _selection = selection;

            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, rayLenght))
            {
                hit.collider.gameObject.GetComponent<AudioSource>().Play();
            }
        }

    }

    public void LerperStarter(Transform restartposition)
    {
        StartCoroutine(Lerper(restartposition));
    }

    IEnumerator Lerper(Transform restartpos)
    {
        transform.position = Vector3.Lerp(transform.position, restartpos.position, 10f * Time.deltaTime);
        yield return new WaitForSeconds(1f);
    }
}
