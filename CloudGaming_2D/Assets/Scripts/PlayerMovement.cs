using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public bool isJumping;
    public float jumpForce;
    public bool isGrounded;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private Vector3 velocity = Vector3.zero;

    private float horizontalMovement = 0f;

    void Update(){
        if (Input.GetButtonDown("Jump") && isGrounded){
        isJumping = true;
        }
    }
    void FixedUpdate(){
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position,groundCheckLeft.position);
        this.horizontalMovement = Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
        MovePlayer(this.horizontalMovement);

        float characterVelocity = Mathf.Abs(rb.velocity.x);

        Flip(rb.velocity.x);
        animator.SetFloat("Speed",characterVelocity);
    }
    void MovePlayer(float _horizontalMovement){
        Vector3 targetVelocity = new Vector2(_horizontalMovement,rb.velocity.y); 
        rb.velocity = Vector3.SmoothDamp(rb.velocity,targetVelocity,ref velocity, .05f);
        if (isJumping == true){
            rb.AddForce(new Vector2(0f,jumpForce));
            isJumping = false;
        }
    }
    void Flip(float _velocity){
        if (_velocity > 0.1f){
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f){
            spriteRenderer.flipX = true;
        }
    }
}
