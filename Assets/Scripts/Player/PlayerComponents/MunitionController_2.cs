using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionController_2 : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 currentSpeed = new Vector3();

    Vector3 position = new Vector3();
    bool shooted;
    // Start is called before the first frame update
    void Start()
    {
        shooted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!shooted)
        {
            position = currentSpeed * Time.deltaTime + Physics.gravity * Mathf.Pow(Time.deltaTime, 2) / 2;
            gameObject.transform.Translate(position);
            currentSpeed += Physics.gravity * Time.deltaTime;
        }
    }

    public void Shoot(Vector3 startingSpeed, float shootingAngle)
    {
        currentSpeed = new Vector3(startingSpeed.x * Mathf.Cos(shootingAngle), startingSpeed.y * Mathf.Sin(shootingAngle));
        shooted = true;
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
