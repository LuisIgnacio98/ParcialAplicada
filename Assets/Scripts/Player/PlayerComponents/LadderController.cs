using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour
{
    // Start is called before the first frame update
    private float vertical;
    private float speed = 8f;
    private bool closeLadder;
    private bool playerClimbing;
    private bool ground;

    [SerializeField] private Rigidbody2D rb;
    private Animator anim;

    // Update is called once per frame
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if (closeLadder && Mathf.Abs(vertical) > 0f)
        {
            playerClimbing = true;
            ground = false;
        }

        anim.SetBool("Ground", ground);

    }
    private void FixedUpdate()
    {
        if (playerClimbing)
        {
            anim.SetBool("Climb", playerClimbing);
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            anim.SetBool("Ground", ground);
            anim.SetBool("Climb", playerClimbing);
            rb.gravityScale = 4f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            closeLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            closeLadder = false;
            playerClimbing = false;
            ground = true;
        }
    }
}
