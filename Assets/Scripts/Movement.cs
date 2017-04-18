﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{

    public float movementSpeed = 1.0f;
    private Vector3 targetPosition;
    
    


    void Start()
    {
       
        targetPosition.z = -5;
        targetPosition.x = 0;
        targetPosition.y = -3;

        
    }


   void Update()
    {
       

            if (Input.GetMouseButtonDown(0))
            {
          

                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = -5;
                targetPosition.y = -3;
                //  
            }
            if (targetPosition != transform.position)
            {
                Vector3 pz = targetPosition - transform.position;

           
                pz.x = Mathf.Clamp(pz.x, (float)-0.1, (float)0.1);
                gameObject.transform.position += pz;


            }

        }
    }

