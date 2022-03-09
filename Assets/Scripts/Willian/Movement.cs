using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 movSpeed = new Vector3(20, 20);
    private Vector3 deltaPos = new Vector3();
    private const float maxLimitY = 1000f;
    private const float minLimitY = -1000f;
    private const float maxLimitX = 1000f;
    private const float minLimitX = -1000f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        deltaPos.x = Input.GetAxis("Horizontal") * movSpeed.y;
        deltaPos.y = Input.GetAxis("Vertical") * movSpeed.y;
        deltaPos *= Time.deltaTime;

        gameObject.transform.Translate(deltaPos);
        gameObject.transform.position = new Vector3(
            Mathf.Clamp(gameObject.transform.position.x, minLimitX, maxLimitX),
            Mathf.Clamp(gameObject.transform.position.y, minLimitY, maxLimitY),
            gameObject.transform.position.z);
    }
}

