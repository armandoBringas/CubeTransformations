using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTransformations : MonoBehaviour
{ 
    [Range(0, 20)]
    public int timePerTransformation = 10;

    [Range(0.1f, 1.0f)]
    public float translationSpeed = 0.5f;

    [Range(0.1f, 1.0f)]
    public float scalationFactor = 0.1f;

    [Range(0.01f, 0.1f)]
    public float scalationSpeed = 0.05f;

    [Range(15.0f, 25.0f)]
    public float rotationSpeed = 20.0f;

    Vector3 objectOriginalLocalPosition;
    Vector3 objectOriginalLocalScale;
    Quaternion objectOriginalLocalRotation;
    float timeCounter = 0;
    private int[] timePerTransformations;
    private enum transformationTypes { Translation, Rotation, Scalation };
    private transformationTypes transformationType = transformationTypes.Translation;

    // Start is called before the first frame update
    void Start()
    {
        objectOriginalLocalPosition = this.transform.localPosition;
        objectOriginalLocalRotation = this.transform.localRotation;
        objectOriginalLocalScale = this.transform.localScale;
        timePerTransformations = new int[] { timePerTransformation, timePerTransformation * 2, timePerTransformation * 3 };

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            this.transform.localPosition = objectOriginalLocalPosition;
            this.transform.localRotation = objectOriginalLocalRotation;
            this.transform.localScale = objectOriginalLocalScale;


            if (transformationType == transformationTypes.Translation)
            {
                timeCounter = timePerTransformations[0];
            }
            else if (transformationType == transformationTypes.Rotation)
            {
                timeCounter = timePerTransformations[1];
            }
            else if (transformationType == transformationTypes.Scalation)
            {
                timeCounter = 0;
            }

        }
        else
        {
            if (timeCounter < timePerTransformations[0])
            {
                this.transform.Translate(translationSpeed * Time.deltaTime * Vector3.up);
                transformationType = transformationTypes.Translation;
                timeCounter += Time.deltaTime;
            }
            else if ((int)timeCounter == timePerTransformations[0])
            {
                this.transform.localPosition = objectOriginalLocalPosition;
                transformationType = transformationTypes.Rotation;
                timeCounter += Time.deltaTime;
            }
            else if (timeCounter > timePerTransformations[0] && timeCounter < timePerTransformations[1])
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                transformationType = transformationTypes.Rotation;
                timeCounter += Time.deltaTime;
            }
            else if ((int)timeCounter == timePerTransformations[1])
            {
                this.transform.localRotation = objectOriginalLocalRotation;
                transformationType = transformationTypes.Scalation;
                timeCounter += Time.deltaTime;
            }
            else if (timeCounter > timePerTransformations[1] && timeCounter < timePerTransformations[2])
            {
                transform.localScale = new Vector3(transform.localScale.x + scalationFactor * scalationSpeed,
                                                   transform.localScale.y + scalationFactor * scalationSpeed,
                                                   transform.localScale.z + scalationFactor * scalationSpeed);
                transformationType = transformationTypes.Scalation;
                timeCounter += Time.deltaTime;
            }
            else
            {
                this.transform.localScale = objectOriginalLocalScale;
                transformationType = transformationTypes.Translation;
                timeCounter = 0;
            }
        }
    }
}
