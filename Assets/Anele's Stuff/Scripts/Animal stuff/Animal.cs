using UnityEngine;

public class Animal : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;          // How fast the animal moves
    public float roamRadius = 10f;        // Max distance to roam from the current position

    [Header("Player Interaction")]
    public float detectionRadius = 5f;    // How close the player can get before the animal runs
    public float runAwayDistance = 15f;   // Distance to run when the player is near

    [Header("Environment")]
    public LayerMask obstacleLayer;       // LayerMask to detect obstacles (e.g., trees, houses)

    private Vector3 roamPosition;         // Current roam target
    private bool isRunningAway = false;   // Are we fleeing right now?
    private Transform player;             // Cached player reference

    //--------------------------------------------------
    // INITIALISATION
    //--------------------------------------------------
    void Start()
    {
        Vector3 pos = transform.position;
        SnapToTerrain(ref pos);
        transform.position = pos;

        roamPosition = GetRandomRoamingPosition();

        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;
        else Debug.LogWarning("Player tag not found!");
    }

    //--------------------------------------------------
    // MAIN UPDATE LOOP
    //--------------------------------------------------
    void Update()
    {
        if (player == null) return;

        if (isRunningAway)
            RunAway();
        else
        {
            DetectPlayer();
            Roam();
        }
    }

    //--------------------------------------------------
    // PLAYER DETECTION
    //--------------------------------------------------
    void DetectPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < detectionRadius)
            isRunningAway = true;
    }

    //--------------------------------------------------
    // ROAMING BEHAVIOUR
    //--------------------------------------------------
    void Roam()
    {
        if (Vector3.Distance(transform.position, roamPosition) < 0.5f || IsObstacleAhead())
            roamPosition = GetRandomRoamingPosition();

        MoveTowards(roamPosition);
    }

    //--------------------------------------------------
    // OBSTACLE AVOIDANCE
    //--------------------------------------------------
    bool IsObstacleAhead()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, obstacleLayer))
        {
            Debug.Log("Obstacle detected: " + hit.collider.name);
            return true;
        }
        return false;
    }

    //--------------------------------------------------
    // FLEEING FROM THE PLAYER
    //--------------------------------------------------
    void RunAway()
    {
        Vector3 runDir = (transform.position - player.position).normalized;
        Vector3 runPos = transform.position + runDir * runAwayDistance;

        SnapToTerrain(ref runPos);
        MoveTowards(runPos);

        if (Vector3.Distance(transform.position, player.position) > runAwayDistance)
        {
            isRunningAway = false;
            roamPosition = GetRandomRoamingPosition();
        }
    }

    //--------------------------------------------------
    // MOVEMENT TOWARD TARGET
    //--------------------------------------------------
    void MoveTowards(Vector3 targetPosition)
    {
        Vector3 adjustedTarget = targetPosition;
        SnapToTerrain(ref adjustedTarget);

        Vector3 dir = (adjustedTarget - transform.position).normalized;
        Vector3 newPos = transform.position + dir * moveSpeed * Time.deltaTime;

        SnapToTerrain(ref newPos);
        transform.position = newPos;

        Vector3 lookPos = new Vector3(adjustedTarget.x, transform.position.y, adjustedTarget.z);
        transform.LookAt(lookPos);
    }

    //--------------------------------------------------
    // RANDOM ROAMING POSITION (TERRAIN-CLAMPED)
    //--------------------------------------------------
    Vector3 GetRandomRoamingPosition()
    {
        Vector3 randomDir = Random.insideUnitSphere * roamRadius;
        randomDir += transform.position;

        SnapToTerrain(ref randomDir);

        int attempts = 0;
        while (Physics.CheckSphere(randomDir, 0.5f, obstacleLayer) && attempts < 10)
        {
            randomDir = Random.insideUnitSphere * roamRadius + transform.position;
            SnapToTerrain(ref randomDir);
            attempts++;
        }
        return randomDir;
    }

    //--------------------------------------------------
    // HELPER: SNAP Y COORDINATE TO TERRAIN HEIGHT
    //--------------------------------------------------
    void SnapToTerrain(ref Vector3 pos)
{
    RaycastHit hit;
    Vector3 rayOrigin = new Vector3(pos.x, pos.y + 50f, pos.z); // Start well above
    if (Physics.Raycast(rayOrigin, Vector3.down, out hit, 100f))
    {
        pos.y = hit.point.y + 0.1f; // Slight lift to avoid clipping
    }
}

}
