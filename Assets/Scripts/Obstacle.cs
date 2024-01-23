﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script manages the behavior of individual obstacle
public class Obstacle : MonoBehaviour
{
    [SerializeField] private float Speed = 3;
    void Start()
    {

    }
    void Update()
    {
        if (transform.position.x <= -8)
        {
            //GameManager.Score+=1;
            Destroy(gameObject);
        }
            
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * -Speed);
            
        }
            

    }
}
