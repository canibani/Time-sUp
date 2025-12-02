using UnityEngine;

[CreateAssetMenu (fileName = "New Enemy", menuName = "ScriptableObjects/Enemy")]
public class Enemy : ScriptableObject
{
    public float maxChasingDistance;
    public float attackRange;
    public float speed;
    public int lives;
}
