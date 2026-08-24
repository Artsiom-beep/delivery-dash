using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerCurrentSpeed = 200f;

    [SerializeField] float normalSteer = 200f;
    [SerializeField] float currentSpeed = 5f;

    [SerializeField] float boostSpeed = 10f;

    [SerializeField] float normalSpeed = 5f;


    [SerializeField] TMP_Text boostText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boostText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        float move = 0f;
        float steer = 0f;
        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        else if(Keyboard.current.sKey.isPressed)
        {
            move = -1f;

        }

        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;

        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;

        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerCurrentSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Boost"))
        {
            currentSpeed *= 2;
            steerCurrentSpeed += steerCurrentSpeed * 0.5f;
            boostText.gameObject.SetActive(true);
            Destroy(collision.gameObject);

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            currentSpeed = normalSpeed;
        steerCurrentSpeed = normalSteer;
        boostText.gameObject.SetActive(false);

    }


}
