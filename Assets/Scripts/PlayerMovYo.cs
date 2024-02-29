using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public float jumpForce;

    public bool isJumping;
    public bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    private void Update()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            // Activer l'animation de saut dans l'Animator
            animator.SetBool("IsJumping", true);
            // Appliquer la force de saut
            rb.AddForce(new Vector2(0f, jumpForce));
        }

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);

        // Gérer la chute (animation ou logique de code)
        if (!isGrounded && rb.velocity.y < 0)
        {
            // Activer l'animation de chute dans l'Animator
            animator.SetBool("IsFalling", true);
        }
        else
        {
            // Désactiver l'animation de chute si le personnage est au sol
            animator.SetBool("IsFalling", false);
        }
        // Revenir à l'état "idle" lorsque le personnage touche le sol et a fini de sauter
        if (isGrounded && !isJumping) // Ajoutez !isJumping pour vérifier que le personnage n'est pas en train de sauter
        {
            animator.SetBool("IsJumping", false); // Désactiver l'animation de saut dans l'Animator
        }
        // Réinitialiser isJumping une fois que le saut est terminé
        if (isGrounded && isJumping)
        {
            isJumping = false;
        }
    }

    void FixedUpdate()
    {
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

       // if(isJumping == true){rb.AddForce(new Vector2(0f, jumpForce)); isJumping = false;}
    }
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
