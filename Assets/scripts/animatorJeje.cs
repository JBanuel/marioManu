using UnityEngine;

public class animatorJeje : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteR;
    private MarioMovement marioMove;

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>();
        marioMove = GetComponent<MarioMovement>();
    }

    void Update()
    {
        //Animación de Correr
        //Si moveInput es -1 (izquierda) o 1 (derecha), Speed siempre recibirá 1.
        anim.SetFloat("Speed", Mathf.Abs(marioMove.moveInput));

        //Animación de Salto
        //Si isGrounded es falso entonces IsJumping es verdadero
        anim.SetBool("IsJumping", !marioMove.isGrounded);

        //Voltear el Sprite visualmente
        if (marioMove.moveInput > 0)
        {
            spriteR.flipX = false; //derecha
        }
        else if (marioMove.moveInput < 0)
        {
            spriteR.flipX = true;  //izquierda
        }
    }
}