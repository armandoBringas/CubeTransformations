using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [Range(15.0f, 25.0f)]
    public float rotationSpeed = 20.0f;

    float timeCounter = 0;
    Quaternion objectOriginalLocalRotation;

    // Start is called before the first frame update
    void Start()
    {
        objectOriginalLocalRotation = this.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCounter <= 15)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            timeCounter += Time.deltaTime;
        }
        else
        {
            this.transform.localRotation = objectOriginalLocalRotation;
            timeCounter = 0;
        }
    }
}
