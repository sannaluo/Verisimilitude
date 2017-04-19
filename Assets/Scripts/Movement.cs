using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public GameObject movementObject;
    private static Movement movement;
    public float movementSpeed = 1.0f;
    private Vector3 targetPosition;

    public int positionY;
    public int positionZ;

    public static Movement Instance()
    {
        if (!movement)
        {
            movement = FindObjectOfType(typeof(Movement)) as Movement;
            if (!movement)
            {
                Debug.LogError("There needs to be one active Movement script on a GameObject in your Scene");
            }
        }
        return movement;

    }
    void Start()
    {
       
        targetPosition.z = -5;
        targetPosition.x = 0;
        targetPosition.y = -3;
        positionY = -3;
        positionZ = -5;
        
    }


   void Update()
    {
       

            if (Input.GetMouseButtonDown(0))
            {
          

                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = positionZ;
                targetPosition.y = positionY;
                //  
            }
            if (targetPosition != transform.position)
            {
                Vector3 pz = targetPosition - transform.position;

           
                pz.x = Mathf.Clamp(pz.x, (float)-0.1, (float)0.1);
                gameObject.transform.position += pz;


            }

        }
    /// <summary>
    /// Changes the y position to -18
    /// </summary>
   public void changeYposition()
    {
        positionY = -18;
        targetPosition.y = positionY;
    }
  
    }

