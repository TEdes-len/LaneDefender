using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    private Vector2 moveInput;
    private Rigidbody2D rb; 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * speed;
    }
}
