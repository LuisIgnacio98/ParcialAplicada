using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionController : MonoBehaviour
{
    GameObject centerObject;
    Vector3 position = new Vector3();
    Vector3 speed = new Vector3(10, 10);
    Vector3 angle = new Vector3();
    float distance, acceleration = 3f, shootingTime;
    /*void Start()
    {
       
    }*/

    // Update is called once per frame
    void Update()
    {
        if (centerObject != null)
        {
            angle = speed * (Time.time - shootingTime) / distance;
            position.x = centerObject.transform.position.x + distance * Mathf.Cos(angle.x);
            position.y = centerObject.transform.position.y + distance * Mathf.Sin(angle.y);

            gameObject.transform.position = position;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Shoot(GameObject center, float playerDistance)
    {
        centerObject = center;
        distance = playerDistance;
        shootingTime = Time.time;
    }
}
