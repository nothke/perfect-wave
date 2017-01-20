using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenfController : MonoBehaviour
{

    public Transform bottle;

    void Start()
    {

    }

    void Update()
    {
        Vector3 pos = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));

        bottle.transform.position += pos * 1;
    }
}