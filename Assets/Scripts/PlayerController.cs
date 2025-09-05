using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction fireAction;
    public GameObject TankShot;
    public float fireRate = 0.5f;
    public GameObject Barrel;
    





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.currentActionMap.FindAction("Move");
        moveAction.performed += MoveAction_performed;
        moveAction.canceled += MoveAction_performed;
        rb = GetComponent<Rigidbody2D>();
        fireAction = playerInput.currentActionMap.FindAction("Fire");
        fireAction.performed += Shoot;
        
    }

    private void MoveAction_performed(InputAction.CallbackContext obj)
    {
       moveInput = moveAction.ReadValue<Vector2>();
       
    }

    private void Shoot(InputAction.CallbackContext obj)
    {
        Instantiate(TankShot, Barrel.transform.position, Quaternion.identity);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
       
        rb.linearVelocity = new Vector2(moveInput.x * 0, moveInput.y * speed);

    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
