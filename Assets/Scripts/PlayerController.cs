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





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.currentActionMap.FindAction("Move");
        moveAction.performed += MoveAction_performed;
        moveAction.canceled += MoveAction_performed;
        rb = GetComponent<Rigidbody2D>();
    }

    private void MoveAction_performed(InputAction.CallbackContext obj)
    {
       moveInput = moveAction.ReadValue<Vector2>();
       
    }

    private void Shoot()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
       
        rb.linearVelocity = new Vector2(moveInput.x * 0, moveInput.y * speed);

    }
}
