using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTranslation : MonoBehaviour
{

    [Range(0.1f, 1.0f)]
    public float translationSpeed = 0.5f;

    float timeCounter = 0;
    Vector3 objectOriginalLocalPosition;

    // Start is called before the first frame update
    void Start()
    {
        objectOriginalLocalPosition = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCounter <= 15)
        {
            this.transform.Translate(0.5f * Time.deltaTime * Vector3.up);
            timeCounter += Time.deltaTime;
        }
        else
        {
            this.transform.localPosition = objectOriginalLocalPosition;
            timeCounter = 0;
        }
    }
}
