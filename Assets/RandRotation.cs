using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake(){
        
        float randomYRotation = Random.Range(0f, 360f); 
        transform.rotation = Quaternion.Euler(-90, randomYRotation, 0f);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}