using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{
    public float speed = 100f;
    void Start()
    {
        
    }

    // objeyi d�nd�rmeyi sa�l�yor.
    void Update()
    {
        transform.Rotate(new Vector3(0, speed * Time.deltaTime));
    }
}
