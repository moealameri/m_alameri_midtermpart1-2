using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public enum PatrolAxis { XAxis, ZAxis }

    [Header("Axis Settings")]
    public PatrolAxis patrolAxis = PatrolAxis.XAxis; // Choose whether they patrol Left/Right (X) or Forward/Back (Z)

    [Header("Movement & Chase Settings")]
    public float patrolSpeed = 3f;
    public float chaseSpeed = 4.5f;
    public float moveDistance = 5f;
    public float detectionRange = 7f;

    private Vector3 startPosition;
    private bool movingForwardOrRight = true;
    private Transform playerTransform;

    void Start()
    {
        startPosition = transform.position;

        // Find the player automatically in the scene
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        // Continuously check for player if not found initially
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null) playerTransform = player.transform;
        }

        // Check if player is close enough to chase
        if (playerTransform != null && Vector3.Distance(transform.position, playerTransform.position) <= detectionRange)
        {
            // CHASE MODE: Smoothly move toward the player across the floor
            Vector3 targetDirection = (playerTransform.position - transform.position).normalized;
            targetDirection.y = 0f; // Keep movement flat on the floor

            transform.position += targetDirection * chaseSpeed * Time.deltaTime;

            if (targetDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), 15f * Time.deltaTime);
            }
        }
        else
        {
            // PATROL MODE: Moves back and forth based on your chosen axis
            Vector3 currentPos = transform.position;

            if (patrolAxis == PatrolAxis.XAxis)
            {
                // Left and Right Patrol
                float leftLimit = startPosition.x - moveDistance;
                float rightLimit = startPosition.x + moveDistance;

                if (movingForwardOrRight)
                {
                    currentPos.x += patrolSpeed * Time.deltaTime;
                    transform.position = currentPos;
                    transform.rotation = Quaternion.Euler(0, 90, 0);

                    if (transform.position.x >= rightLimit) movingForwardOrRight = false;
                }
                else
                {
                    currentPos.x -= patrolSpeed * Time.deltaTime;
                    transform.position = currentPos;
                    transform.rotation = Quaternion.Euler(0, -90, 0);

                    if (transform.position.x <= leftLimit) movingForwardOrRight = true;
                }
            }
            else
            {
                // Forward and Backward Patrol
                float backLimit = startPosition.z - moveDistance;
                float frontLimit = startPosition.z + moveDistance;

                if (movingForwardOrRight)
                {
                    currentPos.z += patrolSpeed * Time.deltaTime;
                    transform.position = currentPos;
                    transform.rotation = Quaternion.Euler(0, 0, 0);

                    if (transform.position.z >= frontLimit) movingForwardOrRight = false;
                }
                else
                {
                    currentPos.z -= patrolSpeed * Time.deltaTime;
                    transform.position = currentPos;
                    transform.rotation = Quaternion.Euler(0, 180, 0);

                    if (transform.position.z <= backLimit) movingForwardOrRight = true;
                }
            }
        }
    }
}