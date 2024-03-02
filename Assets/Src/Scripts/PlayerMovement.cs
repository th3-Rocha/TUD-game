using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rgb;
    public float moveAcel = 1f;
    public float maxSpeed = 5f; // Maximum speed limit
    public Camera cam;

    public GameObject RenderClounds;
    float horizontalInput;
    float verticalInput;
    public Material material;

    public float CloudSpeed = 1;
    void Start()
    {

        cam = Camera.main;
        rgb = gameObject.GetComponent<Rigidbody>();
        Renderer renderer = RenderClounds.GetComponent<Renderer>();
        material = renderer.material;
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

    }
    void FixedUpdate()
    {

        Move(horizontalInput, verticalInput);
    }

    void Move(float HInput, float VInput)
    {
        Vector3 movement = new Vector3(HInput, 0f, VInput).normalized;
        rgb.AddForce(movement * moveAcel, ForceMode.Impulse);

        // Limit the maximum speed
        if (rgb.velocity.magnitude > maxSpeed)
        {
            rgb.velocity = rgb.velocity.normalized * maxSpeed;
        }
        //art
         
        float XDirToAdd = material.GetFloat("_XDir");
        float YDirToAdd = material.GetFloat("_YDir");

        XDirToAdd -= CloudSpeed * rgb.velocity.x;
        YDirToAdd -= CloudSpeed * rgb.velocity.z;
        material.SetFloat("_XDir", XDirToAdd);
        material.SetFloat("_YDir", YDirToAdd);
    }
}
