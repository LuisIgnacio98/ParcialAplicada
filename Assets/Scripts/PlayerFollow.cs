using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject target;
    private Vector3 offset;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        /*+ offset para que sea 3ra persona*/
        transform.position = target.transform.position + offset;
    }
}
