using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionCenterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20;
    public Rigidbody2D rb;
    public GameObject bull;
    void Start()
    {
        Instantiate(bull, gameObject.transform.position, Quaternion.identity).GetComponent<MunitionController>().Shoot(gameObject, 0.5f);
        rb.velocity = transform.right * speed; //* Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("He");
        if (collision.gameObject.tag == "Ground")
        {
            //bull.GetComponent<ShieldController>().Des();
            Destroy(gameObject);
        }
    }
}
