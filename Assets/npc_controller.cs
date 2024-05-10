using UnityEngine;

public class NPCChaser : MonoBehaviour
{
    public Transform target; // Player's transform
    public float moveSpeed = 5f; // Speed at which NPC moves

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (target == null)
        {
            // If target is not set, try finding it by tag
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        if (target != null)
        {
            // Calculate direction towards the player
            Vector2 direction = (target.position - transform.position).normalized;

            // Move towards the player
            rb.velocity = direction * moveSpeed;
        }
    }
}
