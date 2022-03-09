using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Bounds")]
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool isMovingLeft;

    [Header("Idle Enemy")]
    [SerializeField] private float idleTime;
    private float idleTimer;

    [Header("Enemy Animator")]
    private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
        anim = GetComponent<Animator>();
        isMovingLeft = true;
    }
    private void OnDisable()
    {
        anim.SetBool("Moving", false);
    }

    private void Update()
    {
        if (isMovingLeft)
        {
            if (enemy.position.x >= leftBound.position.x)
            {
                Flip(1);
                Move(-1);
            }
            else
                MoveDirection();
        }
        else
        {
            if (enemy.position.x <= rightBound.position.x)
            {
                Flip(-1);
                Move(1);
            }
            else
                MoveDirection();
        }
    }

    private void MoveDirection()
    {
        anim.SetBool("Moving", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleTime)
            isMovingLeft = !isMovingLeft;
    }

    private void Move(int direction)
    {
        idleTimer = 0;
        anim.SetBool("Moving", true);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed,
            enemy.position.y, enemy.position.z);
    }

    private void Flip(int direction)
    {
        enemy.localScale = new Vector3(initScale.x * direction,
            initScale.y, initScale.z);
    }
}
