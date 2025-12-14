using UnityEngine;

public class obstacule : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;   
        }

        
        Movimiento respawn = collision.gameObject.GetComponent<Movimiento>();
        if (respawn != null)
        {
            respawn.Reaparecer();
        }
    }

}