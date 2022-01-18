using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{   
    [SerializeField]float steerSpeed = 1;
    [SerializeField]float MoveSpeed = 30;
    [SerializeField]float slowSpeed = 20;
    [SerializeField]float boostSpeed = 40;

    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
        transform.Rotate(0,0, -steerAmount);
        transform.Translate(0, speedAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Booster")
        {
            MoveSpeed = boostSpeed;
            ExampleCoroutine();
        }
        else if (other.tag == "Bumper") 
        {
            MoveSpeed = slowSpeed;  
        }
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);

        MoveSpeed = 30;

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
