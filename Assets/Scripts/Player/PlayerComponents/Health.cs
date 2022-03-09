using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    private int playerLives;
    private Animator anim;
    private bool isDead;

    // Update is called once per frame
    private void Awake()
    {
        playerLives = GameManager.vidaJugador;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
    }

    public void Damage(int damage)
    {
        anim.SetTrigger("Hurt");
        playerLives -= damage;
        /*if (playerLives > 0)
        {
            
        } else
        {
            if (!isDead)
            {
                anim.SetTrigger("Die");
                GetComponent<PlayerController>().enabled = false;
                isDead = true;
            }
        }*/
    }
    
}
