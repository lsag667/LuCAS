using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    Rigidbody2D rb;
    bool isGrounded;
    Animator animationPlayer;
    private bool bajoAtaque = false;
    private int vidas = 3;
    [SerializeField] private VidaUIControlador controladorVida = null;
 

    public int getVida()
   {
       return vidas; 
   } 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animationPlayer = GetComponent<Animator>();
        If (!controladorVida)
        controladorVida = GetComponentInChildren<VidaUIControlador>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!bajoAtaque) {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
                rb.linearVelocityY = 5f;
                isGrounded = false;
            } else if (Input.GetAxis("Horizontal") != 0 && Input.GetAxisRaw("Horizontal") != 0) {
                rb.linearVelocityX = 5f * Input.GetAxis("Horizontal");

                transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
                GetComponent<SpriteRenderer>().FlipX = Input.GetAxisRaw("Horizontal") == -1;
            }
        }
        animationPlayer.SetFloat("movement", Mathf.Abs(Input.GetAxis("Horizontal")));
        animationPlayer.SetBool("isGrounded", isGrounded);
    }

    // Detecta si el jugador esta tocando el suelo
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.name == "Plataforma") // Asegarate de que el suelo tenga el tag "Ground"
        {
            isGrounded = true;
            bajoAtaque = false;
        }
    }

    public void serAtacado(Vector2 empuje) {
        bajoAtaque = true;
        rb.linearVelocity = empuje;
        vidas--;
        if (vidas <=0) {
            Destroy(gameObject);
        } 
        controladorVida.Actualizarvida(vidas);
    }
}