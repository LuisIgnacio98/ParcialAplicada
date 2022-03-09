using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillianTargetRange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            WillianBehaviour.PlayerInSight();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            WillianBehaviour.PlayerNotInSight();
        }
        
    }
}
