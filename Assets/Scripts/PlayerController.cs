using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondsLeft = 30;
    private int initialTime = 30;
    public bool takingAway = false;

    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;

    private float verticalInput;
    private float horizontalInput;

    Vector3 spawnPoint;

    void Start() 
    {
        spawnPoint = gameObject.transform.position;
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
    }


    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (Mathf.Abs(verticalInput) > 0)
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);


        if (gameObject.transform.position.y < -20f || (takingAway == false && secondsLeft == 0))
        {
            gameObject.transform.position = spawnPoint;
            textDisplay.GetComponent<Text>().text = "00:" + initialTime;
            secondsLeft = initialTime;
            StartCoroutine(TimerTake());
        }

        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
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
            secondsLeft = initialTime;
            textDisplay.GetComponent<Text>().text = "00:" + initialTime;
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        takingAway = false;
    }
}
