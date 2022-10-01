using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    //kamera hareketi için
    public Transform hedef;
    public Vector3 offset;
    [Range(1, -10)]
    public float smoothFactor;

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 hedefPosition = hedef.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, hedefPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = hedefPosition;

    }


}
