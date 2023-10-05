using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverMover : MonoBehaviour
{
    [SerializeField] private float _speed; 

    private void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime); 
    }
}
