using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    int a = 1;
    public float fXpo1 = -0.5f;
    public float fXpo2 = 0.5f;
    void Update()
    {
        if (transform.localPosition.x < fXpo1)
        {
            a = -1;
        }
        else if (transform.localPosition.x > fXpo2)
        {
            a = 1;
        }

        transform.Translate(Vector3.left * 0.5f * Time.deltaTime * a);
    }
} 




