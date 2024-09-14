using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;
    public float upDownRange = 60f;
    public float gravity = -9.81f;  // Gravedad en metros por segundo al cuadrado
    public float jumpForce = 8f;   // Fuerza del salto
    public float groundCheckDistance = 0.1f; // Distancia para verificar si está en el suelo

    private float yaw = 0f;
    private float pitch = 0f;
    private Vector3 moveDirection;
    private Vector3 velocity;
    private CharacterController characterController;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Verificar si está en el suelo
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance + 0.1f);

        // Movimiento
        float moveDirectionY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveDirectionX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        moveDirection = new Vector3(moveDirectionX, 0, moveDirectionY);
        moveDirection = transform.TransformDirection(moveDirection);

        // Aplicar la gravedad
        if (isGrounded)
        {
            velocity.y = -0.5f; // Pequeña fuerza para asegurar que el personaje se quede en el suelo
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpForce; // Aplicar la fuerza del salto
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime; // Aplicar la gravedad
        }

        characterController.Move(moveDirection + velocity * Time.deltaTime);

        // Rotación del ratón
        yaw += lookSpeed * Input.GetAxis("Mouse X");
        pitch -= lookSpeed * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -upDownRange, upDownRange);

        transform.eulerAngles = new Vector3(pitch, yaw, 0);
    }
}