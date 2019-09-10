using UnityEngine;

[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovementController : MonoBehaviour, IMove
{
    [SerializeField]
    private float moveSpeed = 4;
    [SerializeField]
    private float jumpForce = 400;

    private new Rigidbody2D rigidbody;
    private CharacterGrounding characterGrounding;
    private SpriteRenderer spriteRenderer;

    public float Speed { get; private set; }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterGrounding = GetComponent<CharacterGrounding>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (Speed != 0)
        {
            spriteRenderer.flipX = horizontal > 0;
        }

        Vector3 movement = new Vector3(horizontal, 0);

        transform.position += movement * Time.deltaTime * moveSpeed;

        if (Input.GetKeyDown(KeyCode.UpArrow) && characterGrounding.IsGrounded)
        {
            rigidbody.AddForce(Vector2.up * jumpForce);
        }
    }
}