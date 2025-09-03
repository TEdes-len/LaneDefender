using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;
    private bool moveLeft = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2();
    }
}
