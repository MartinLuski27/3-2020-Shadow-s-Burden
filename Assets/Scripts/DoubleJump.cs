using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public float Velocidad = 10f;
    public float FuerzaSalto = 2;
    public int ExtraSaltos = 1;
    [SerializeField] LayerMask ColisionLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform pies;

    int ContadorSaltos = 0;
    bool isGrounded;
    float mx;
    float jumpCooldown;
    private void Update()
    {
        mx = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        CheckGrounded();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx * Velocidad, rb.velocity.y);
    }
    void Jump ()
    {
        if (isGrounded || ContadorSaltos < ExtraSaltos)
        {
            rb.velocity = new Vector2(rb.velocity.x, FuerzaSalto);
            ContadorSaltos++;
        }
    }
    void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(pies.position, 0.5f, ColisionLayer))
        {
            isGrounded = true;
            ContadorSaltos = 0;
            jumpCooldown = Time.time + 0.2f;
        }
        else if (Time.time < jumpCooldown)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}