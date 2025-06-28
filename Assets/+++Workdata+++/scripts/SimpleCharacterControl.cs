using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleCharacterControl : MonoBehaviour
{
    public float moveSpeed = 5f;    //Geschwindigkeit
    public float jumpForce = 5f;   //Sprungkraft
    private Rigidbody2D rb;           //Rigidbody Referenz
    private bool isGrounded;        //ist Spieler auf dem Boden ja/nein?

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Holt Rigidbody
    }


    void Update()
    {
        if (!GameManager.Instance.gameStarted) return;  //Spieler kann sich erst nach "Go!" bewegen
        
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y); //definiert die horizontale Geschwindigkeit

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)  //wenn leertaste gedrückt wird und der Spieler am Boden ist...
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);    //...springt er hoch
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f) //wenn eine Kollision von unten kommt
        {
            isGrounded = true;  //ist der Spieler am Boden
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false; //der Spieler ist nicht mehr auf dem Boden
    }

    
}
