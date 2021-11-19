using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;

    private float verticalInput;
    private float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (Mathf.Abs(verticalInput) > 0)
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
