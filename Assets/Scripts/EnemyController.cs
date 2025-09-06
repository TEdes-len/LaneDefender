using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;
    private bool moveLeft = true;
    private Rigidbody2D rb;
    public int health = 1; 
    private Animator animator;


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
            health -= 1;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                animator.SetTrigger("KillTrigger");
                
                Destroy(gameObject);
            }
            
        }

        

    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Wait for the animation to finish (assuming the animation length is 1 second)
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(-speed, 0);
    }
}
