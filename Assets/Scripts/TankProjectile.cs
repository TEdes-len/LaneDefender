using UnityEngine;

public class TankProjectile : MonoBehaviour
{

    private int projectileSpeed = 10;
    private Rigidbody2D rb;
    [SerializeField] public float fireRate = 0.5f;
    [SerializeField] private float nextFire = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody2D>();
         rb.linearVelocity = new Vector2(projectileSpeed, 0);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
