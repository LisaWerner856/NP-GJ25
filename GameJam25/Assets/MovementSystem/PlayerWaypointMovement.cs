using UnityEngine;

public class PlayerWaypointMovement : MonoBehaviour
{
    public RoundManager roundManager;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 2f;
    public int currentWaypointIndex = 0;
    public float currentSpeed;

    //Voor het pauseren van de player//
    public BattleSystem battleSystem;
    void Start()
    {
        currentSpeed = speed;
    }

    public void MoventStops()
    {
        currentSpeed = 0f;
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
        if (battleSystem.normalCanvas == false)
        {
            MoventStops();
        }

        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];

        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, currentSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
                roundManager.StartNewRound();
            }
        }
    }

}