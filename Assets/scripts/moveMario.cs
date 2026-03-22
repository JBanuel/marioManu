using UnityEngine;
using UnityEngine.InputSystem; // ← Agregar este using arriba
public class MarioMovement : MonoBehaviour
{
    [Header("Ajustes de Movimiento")]
    public float speed = 8f;
    public float jumpForce = 12f;

    [Header("Detección de Suelo")]
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;

    void Start()
    {
        // Obtenemos el componente físico al iniciar
        rb = GetComponent<Rigidbody2D>();
    }

void Update()
{
    // 1. Detectamos el suelo (la parte que ya pusiste)
    Collider2D hit = Physics2D.OverlapCircle(groundCheck.position, checkRadius);

    if (hit != null && hit.gameObject.name == "mapaProps")
    {
        isGrounded = true;
    }
    else
    {
        isGrounded = false;
    }

    // 2. Leer el input horizontal (¡Lo que faltaba para moverse!)
    // ✅ Con LayerMask para solo detectar el suelo real
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

    moveInput = Keyboard.current != null ?
    (Keyboard.current.dKey.isPressed ? 1f :
     Keyboard.current.aKey.isPressed ? -1f : 0f) : 0f;
    Debug.Log($"isGrounded: {isGrounded} | Space: {Keyboard.current.spaceKey.wasPressedThisFrame}");
    
    if ((Keyboard.current.spaceKey.wasPressedThisFrame) && isGrounded)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}

    void FixedUpdate()
    {
        // 4. Aplicar el movimiento en el FixedUpdate (mejor para físicas)
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
        
    }
}