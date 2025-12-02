using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    public Rigidbody rb;
    private Transform player;
    
    public virtual void Start()
    { 
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        player = GameObject.FindWithTag("Player").transform;
    }
    
    private void Update() {  }
    
    public void Chase() 
    {
        Move();

        Vector3 lookAtPlayer = player.transform.position;
        lookAtPlayer.y = transform.position.y;
        transform.LookAt(lookAtPlayer);
    }

    public void Move() {
        rb.MovePosition(rb.position + transform.forward * Time.deltaTime * enemy.speed);
    }

    public Enemy GetEnemyStats() 
    {
        return enemy;
    }

    public float GetDistanceBetweenEnemyAndPlayer() 
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }
}
