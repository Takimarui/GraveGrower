using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        moveInput.x = (int)Input.GetAxisRaw("Horizontal");
        moveInput.y = (int)Input.GetAxisRaw("Vertical");

        if (moveInput.magnitude > 1)
            moveInput.Normalize();

        anim.SetInteger("Horizontal", (int)moveInput.x);
        anim.SetInteger("Vertical", (int)moveInput.y);  
        anim.SetFloat("Speed", moveInput.sqrMagnitude); 

        Debug.Log($"Horizontal: {moveInput.x}, Vertical: {moveInput.y}, Speed: {moveInput.sqrMagnitude}");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}
