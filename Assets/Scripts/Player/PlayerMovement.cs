using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0,100f)] private float movementSpeed = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerHealth health;
    private Vector2 direction
    {
        get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //rb.AddForce(direction * (movementSpeed*100f) * Time.deltaTime, ForceMode2D.Force);
        if (health.isDead) return;
        rb.velocity = direction * (movementSpeed*100f) * Time.deltaTime;
        animator.SetFloat("X", rb.velocity.x);
        animator.SetFloat("Y", rb.velocity.y);
    }

}
