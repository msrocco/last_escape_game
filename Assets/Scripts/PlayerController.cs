using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;

    private float verticalInput;
    private float horizontalInput;

    public GameObject policeCar;
    Vector3 spawnPoint;

    void Start() 
    {
        spawnPoint = gameObject.transform.position;
    }


    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (Mathf.Abs(verticalInput) > 0)
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);


        if (gameObject.transform.position.y < -20f)
        {
            gameObject.transform.position = spawnPoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.gameObject.CompareTag("police"))
        {
            gameObject.transform.position = spawnPoint;
        }
    }
}
