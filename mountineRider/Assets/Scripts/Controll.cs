﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controll : MonoBehaviour
{

    public float maxSpeed = 5f;

    bool facingRight = false;
    public float currentSpeed;

    public int points = 0;
    public Text pointText;


    //bool pullAvaliable = false;
    //public LayerMask Pull;
    //public Transform pullCheck;
    //public float pullRadius = 0.5f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        currentSpeed = maxSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {





        if (currentSpeed > 0 && !facingRight)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            facingRight = true;
           // Flip();
        }
        else if (currentSpeed < 0 && facingRight)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            facingRight = false;
            //Flip();
        }



    }


    void Update()
    {

        if (Time.timeScale != 0)
        {
            if (points < 2500)
            {
                points = points + 3;
            }
            else
            {
                points = points + 2;
            }
        }

        pointText.text = (points / 10).ToString();

        if (Input.GetMouseButtonDown(0))
        {
            currentSpeed = -currentSpeed;
            Debug.Log("Pressed left click.");
        }

        rb.velocity = new Vector2(currentSpeed, 0);

       // CamShake();
    }

    public void GrowScale()
    {
       
        Time.timeScale = 1.2f + (Mathf.Sqrt(points / 10)) / 100;
        PlayerPrefs.SetFloat("GameScale", Time.timeScale);
        Debug.Log(Time.timeScale);
    }


    void Flip()
    {
        GetComponent<SpriteRenderer>().flipX = true;
        //facingRight = !facingRight;
        //Vector3 theScale = transform.localScale;
        //theScale.x *= -1;
        //transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.transform.tag == "Enemy")
        {
            
            Application.LoadLevel(0);
            if (GameObject.FindGameObjectsWithTag("Audio").Length > 0)
            {
                Destroy(GameObject.Find("mainMusic"));
            }

            // score_death.text = "YOURE SCORE: " + (points / 10).ToString();
            // score_death.gameObject.SetActive(true);




            //AudioSource RIPaudio = gameover.GetComponent<AudioSource>();
            //RIPaudio.Play();

        }
    }


   
}