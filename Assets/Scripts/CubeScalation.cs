using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScalation : MonoBehaviour
{
    [Range(0.1f, 1.0f)]
    public float scalationFactor = 0.1f;

    [Range(0.01f, 0.1f)]
    public float scalationSpeed = 0.05f;

    float timeCounter = 0;
    Vector3 objectOriginalLocalScale;

    // Start is called before the first frame update
    void Start()
    {
        objectOriginalLocalScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCounter <= 15)
        {
            transform.localScale = new Vector3(transform.localScale.x + scalationFactor * scalationSpeed,
                                               transform.localScale.y + scalationFactor * scalationSpeed,
                                               transform.localScale.z + scalationFactor * scalationSpeed);
            timeCounter += Time.deltaTime;
        }
        else
        {
            this.transform.localScale = objectOriginalLocalScale;
            timeCounter = 0;
        }


        
    }
}