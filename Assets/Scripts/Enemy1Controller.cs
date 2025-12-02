using System.Collections;
using UnityEngine;

public class Enemy1Controller : EnemyController
{
    private bool enemy1Finished = false;
    public GameObject location1;
    public GameObject location2;
    public GameObject door2;
    private EnemyController enemyController;
    private IdleState idleState;

    public override void Start() {
        base.Start();
        enemyController = GetComponent<EnemyController>();
        idleState = GetComponent<IdleState>();
        StartCoroutine(MoveThroughDoor());
    }

    IEnumerator MoveThroughDoor() { 
        while (Vector3.Distance(transform.position, location1.transform.position) >= 1) 
        {
            transform.LookAt(location1.transform.position);
            Move();
            if (!idleState.enabled) 
            {
                yield break;
            }
            yield return null;
        }
        StartCoroutine(MoveThroughDoor2());      
    }
    
    IEnumerator MoveThroughDoor2() {
        door2.GetComponent<DoorController>().OpenDoor();
        while (Vector3.Distance(transform.position, location2.transform.position) >= 1) {
            transform.LookAt(location2.transform.position);
            Move();
            if (!idleState.enabled) 
            {
                yield break;
            }
            yield return null;
        }
    }
}
