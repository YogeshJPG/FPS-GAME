using UnityEngine;

public class AlienAI : MonoBehaviour
{
    public Transform target; // Main character's transform
    public float moveSpeed = 3f; // Speed at which the alien moves
    public float stoppingDistance = 2f; // Distance at which the alien stops moving

    private Animator animator; // Animator component for animation control

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
        {
            // Calculate direction to move towards the target
            Vector3 direction = (target.position - transform.position).normalized;
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            // Stop if the alien is close enough to the target
            if (distanceToTarget <= stoppingDistance)
            {
                animator.SetFloat("Speed", 0f); // Stop the animation
                return; // Don't move further
            }

            // Move the alien towards the target
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

            // Rotate the alien to face the target
            transform.LookAt(target);

            // Set animation parameter for movement
            animator.SetFloat("Speed", moveSpeed);
        }
    }
}
