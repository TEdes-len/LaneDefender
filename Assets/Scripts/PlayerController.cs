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
    [SerializeField] private float shootDelay = 1f;
    private float shootTimer = 0f;
    public GameObject Barrel;
    private Animator FireExplosion;
    [SerializeField] private GameManager gameManager;
    private bool isShooting;
    






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.currentActionMap.FindAction("Move");
        moveAction.performed += MoveAction_performed;
        moveAction.canceled += MoveAction_performed;
        rb = GetComponent<Rigidbody2D>();
        fireAction = playerInput.currentActionMap.FindAction("Fire");
        fireAction.performed += PerformShoot;
        fireAction.canceled += CancelShoot;
        FireExplosion = GetComponent<Animator>();
        

    }

    private void MoveAction_performed(InputAction.CallbackContext obj)
    {
       moveInput = moveAction.ReadValue<Vector2>();
       
    }

    public void Shoot()
    {
        Instantiate(TankShot, Barrel.transform.position, Quaternion.identity);
        FireExplosion.SetTrigger("FireTrigger");
        


    }

    public void PerformShoot(InputAction.CallbackContext obj)
    {
        isShooting = true;
    }

    private void CancelShoot(InputAction.CallbackContext obj)
    {
        if (isShooting)
        {
            isShooting = false;
        }

    }

    void Update()
    {
        

        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f && isShooting)
        {
            Shoot();
            
            shootTimer = shootDelay;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.UpdateLivesText(-1);
            if (gameManager.Lives <= 0)
            {

                
            }
           

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
