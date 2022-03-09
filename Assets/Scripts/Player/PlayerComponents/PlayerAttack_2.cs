using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack_2 : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startSpeed = new Vector3(20, 20);
    Vector3 userInput = new Vector3();
    float currentAngle, delta_y, delta_X;
    public GameObject Munition;
    private Animator anim;
    private PlayerController playercontroller;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playercontroller = GetComponent<PlayerController>();
    }

    void Update()
    {

        //if (Input.GetButtonDown("Fire2"))
        //{
            Attack();
        //}

    }
 
    void Attack()
    {
        userInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        delta_y = userInput.y - gameObject.transform.position.y;
        delta_X = userInput.x - gameObject.transform.position.x;
        currentAngle = Mathf.Atan(delta_y / delta_X);

        if (Input.GetButtonDown("Fire2") && playercontroller.canAttack())
        {
            anim.SetTrigger("Attack");
            Instantiate(Munition, gameObject.transform.position, Quaternion.identity).GetComponent<MunitionController_2>().Shoot(startSpeed, currentAngle);
        }
    }
}
