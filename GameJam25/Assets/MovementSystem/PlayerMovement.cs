using UnityEngine;

public class PlayerWaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 2f;
    private int currentWaypointIndex = 0;
    public float currentSpeed;

    void Start()
    {
        currentSpeed = speed;
    }

    public void OnPausePress()
    {
        currentSpeed = 0f;
    }

    public void OnPlayPress()
    {
        currentSpeed = speed;
    }  

    void Update()
    {
        
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];

        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, currentSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }

}