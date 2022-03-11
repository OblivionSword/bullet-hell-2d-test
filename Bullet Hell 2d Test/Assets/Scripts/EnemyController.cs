using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] waypoints;
    private int randomSpots;
    
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpots = Random.Range(0, waypoints.Length);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, 
                                                        waypoints[randomSpots].position,
                                                        speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints[randomSpots].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpots = Random.Range(0, waypoints.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    
}
