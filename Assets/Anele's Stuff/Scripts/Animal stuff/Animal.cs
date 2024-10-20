using UnityEngine;

public class Animal : MonoBehaviour
{
    public float moveSpeed = 2f;             // How fast the animal moves
    public float roamRadius = 10f;           // Max distance to roam from the current position
    public float detectionRadius = 5f;       // How close the player can get before the animal runs away
    public float runAwayDistance = 15f;      // Distance to run when the player is near
    public LayerMask obstacleLayer;          // LayerMask to detect obstacles (e.g., trees, houses)

    private Vector3 roamPosition;
    private bool isRunningAway = false;
    private Transform player;

    void Start()
    {
        roamPosition = GetRandomRoamingPosition();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player by tag
    }

    void Update()
    {
        if (isRunningAway)
        {
            RunAway();
        }
        else
        {
            DetectPlayer();
            Roam();
        }
    }

    // Detect if the player is within the detection radius
    void DetectPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < detectionRadius)
        {
            isRunningAway = true;
        }
    }

    // Move the animal in a random direction within its roam radius
    void Roam()
    {
        // Check if there's an obstacle in the direction of movement
        if (Vector3.Distance(transform.position, roamPosition) < 0.5f || IsObstacleAhead())
        {
            roamPosition = GetRandomRoamingPosition(); // Get a new position to roam to
        }

        MoveTowards(roamPosition);
    }

    // Detect obstacles ahead using raycasting
    bool IsObstacleAhead()
    {
        // Cast a ray forward to detect obstacles
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, obstacleLayer))
        {
            Debug.Log("Obstacle detected: " + hit.collider.name); // Print obstacle name for debugging
            return true;
        }

        return false;
    }

    // Run away from the player in the opposite direction
    void RunAway()
    {
        Vector3 runDirection = (transform.position - player.position).normalized * runAwayDistance;
        Vector3 runPosition = transform.position + runDirection;

        MoveTowards(runPosition);

        if (Vector3.Distance(transform.position, player.position) > runAwayDistance)
        {
            isRunningAway = false; // Stop running once far enough from the player
            roamPosition = GetRandomRoamingPosition(); // Reset to roam after running away
        }
    }

    // Move the animal towards a given position
    void MoveTowards(Vector3 targetPosition) 
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Optionally rotate the animal towards the target position
        transform.LookAt(new Vector3(targetPosition.x, transform.position.y, targetPosition.z));
    }

    // Get a random position to roam to within the roam radius
    Vector3 GetRandomRoamingPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
        randomDirection += transform.position;
        randomDirection.y = Terrain.activeTerrain.SampleHeight(randomDirection); // Ensure it stays on terrain

        // Ensure the random position is not inside an obstacle
        while (Physics.CheckSphere(randomDirection, 0.5f, obstacleLayer))
        {
            randomDirection = Random.insideUnitSphere * roamRadius;
            randomDirection += transform.position;
            randomDirection.y = Terrain.activeTerrain.SampleHeight(randomDirection);
        }

        return randomDirection;
    }

}

