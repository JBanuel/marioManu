using UnityEngine;
using UnityEngine.InputSystem;
public class MarioMovement : MonoBehaviour
{
    public float speed = 8f;
    public float jumpForce = 12f;

    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    public float moveInput;
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

void Update()
{
    //Deteccion de suelo con el nombre de el escenario
    Collider2D hit = Physics2D.OverlapCircle(groundCheck.position, checkRadius);

    if (hit != null && hit.gameObject.name == "mapaProps")
    {
        isGrounded = true;
    }
    else
    {
        isGrounded = false;
    }

    //Leer el input horizontal
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

    moveInput = Keyboard.current != null ?
    (Keyboard.current.dKey.isPressed ? 1f :
     Keyboard.current.aKey.isPressed ? -1f : 0f) : 0f;
    
    if ((Keyboard.current.spaceKey.wasPressedThisFrame) && isGrounded)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}

    void FixedUpdate()
    {
        //Aplicar el movimiento en el FixedUpdate
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
        
    }
}