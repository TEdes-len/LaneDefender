using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;
    private bool moveLeft = true;
    private Rigidbody2D rb;
    public int health = 1; 
    private Animator animator;
    [SerializeField] private float Destroydelay = 1f;
    [SerializeField] private float Hitdelay = 0.5f;
    private bool isHit = false;
    public GameObject MissileExplosion;
    public AudioClip EnemyHit;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Missile")
        {
            animator.SetTrigger("HitTrigger");
            Instantiate(MissileExplosion, other.GetContact(0).point, Quaternion.identity);
            AudioSource.PlayClipAtPoint(EnemyHit, transform.position);

            //Stop movement for a brief moment
            StartCoroutine(HitDelay());
            //Lose health
            health -= 1;
            //Destroy the missile
            Destroy(other.gameObject);

            //Check if health is 0 or below. If so, play death animation and destroy after delay
            if (health <= 0)
            {
                animator.SetTrigger("KillTrigger");
                
                StartCoroutine(DestroyAfterAnimation());
            }
            
        }

        
        



    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Wait for the animation to finish (assuming the animation length is 1 second)
        yield return new WaitForSeconds(Destroydelay);
        Destroy(gameObject);
    }

    private IEnumerator HitDelay()
    {
        isHit = true;
        yield return new WaitForSeconds(Hitdelay);
        isHit = false;



    }

    



    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        if(!isHit)
        {
            rb.linearVelocity = new Vector2(-speed, 0);
            
        }
        else
        {
            rb.linearVelocity = new Vector2(0, 0);
        }

    }
}
