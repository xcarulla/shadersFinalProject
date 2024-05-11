using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotar : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 45, 0);

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}

