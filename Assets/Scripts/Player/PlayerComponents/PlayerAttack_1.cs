using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack_1 : MonoBehaviour
{
    [SerializeField] private GameObject munition;
    private Animator anim;
    private PlayerController playercontroller;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playercontroller = GetComponent<PlayerController>();
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && playercontroller.canAttack())
        {
            Attack();
        }

    }

    void Attack()
    {
        anim.SetTrigger("Attack");
        Instantiate(munition, gameObject.transform.position, gameObject.transform.rotation);
    }
}
