using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillianBehaviour : MonoBehaviour
{

    private float attackDistance = 1f; //minimum range to attack
    private float moveSpeed = 11f;
    private float atkCooldownTimer = 1f;
    private float currentSpeed;

    private Animator animator;
    private GameObject target;
    private float distance; //dintance between enemy and player
    private bool attackMode;
    private static bool inRange;
    private float internalAtkTimer;

    Vector2 position = new Vector2();
    Vector2 startingPos = new Vector2();

    void Awake()
    {
        startingPos = transform.gameObject.transform.position;
        inRange = false;
        internalAtkTimer = atkCooldownTimer;
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            print("in range for some reason");
            MoveToTarget();
        }else if(!inRange)
        {
            StopAttacking();
            ReturnToSpawn();
        }
    }

    private void MoveToTarget()
    {
        
        position.x = Time.deltaTime * moveSpeed;
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (/*Vector3.Distance(transform.position, target.transform.position)*/distance >= attackDistance)
        {
            print("Moving towards the player");
            StopAttacking();
            currentSpeed = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, currentSpeed);
            /*transform.position += transform.forward * moveSpeed * Time.deltaTime;*/
            animator.SetFloat("speed", Mathf.Abs(moveSpeed));
        }
        if (/*Vector3.Distance(transform.position, target.transform.position)*/distance <= attackDistance)
        {
            if (!Cooldown())
            {
                Attack();
            }
            else
            {
                StopAttacking();
            }
            
        }
    }

    private void Attack()
    {
        //Here Call any function U want Like Shoot at here or something
        attackMode = true;
        animator.SetBool("isAttacking", attackMode);
        SetAtkTimer();
    }

    private void SetAtkTimer()
    {
        internalAtkTimer += Time.deltaTime;
        print("TIME: " + internalAtkTimer);
    }

    private void StopAttacking()
    {
        attackMode = false;
        animator.SetBool("isAttacking", attackMode);
        internalAtkTimer = 0;
    }

    private void ReturnToSpawn()
    {
        transform.position = startingPos;
        currentSpeed = 0;
        animator.SetFloat("speed", 0);
    }

    private bool Cooldown()
    {
        return internalAtkTimer > atkCooldownTimer;
    }

    public static void PlayerInSight()
    {
        inRange = true;
        print("Player is in range");
    }

    public static void PlayerNotInSight()
    {
        inRange = false;
        print("Player is not in range");
    }

}
