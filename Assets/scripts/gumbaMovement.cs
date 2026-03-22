using UnityEngine;

public class WalkLeftAndFlip : MonoBehaviour
{
    [Header("Ajustes de Movimiento")]
    public float speed = 3f; // Velocidad hacia la izquierda

    [Header("Ajustes de Animación (Voltear Sprite)")]
    public float intervaloFlipping = 0.3f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float temporizador;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        temporizador = 0f; 
    }

    void Update()
    {
        // Incrementar el temporizador con el tiempo que pasa en cada frame
        temporizador += Time.deltaTime;

        // Si el temporizador llega o supera el intervalo definido voltea el sprite
        if (temporizador >= intervaloFlipping)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;

            temporizador = 0f;
        }
    }

    void FixedUpdate()
    {
        // Aplica una velocidad constante hacia la izquierda
        rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
    }
}