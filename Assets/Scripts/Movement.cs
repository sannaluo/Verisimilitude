using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public GameObject movementObject;
    private static Movement movement;
    public float movementSpeed = 1.0f;
    private Vector3 targetPosition;

    public GameObject modalPanelObject;

    public int positionY;
    public int positionZ;
    private Vector3 pz;

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
        targetPosition.y = -2;
        positionY = -2;
        positionZ = -5;
      
    }


   void Update()
    {
         if (!modalPanelObject.activeSelf)
      
        {

            if (Input.GetMouseButtonDown(0))
            {


                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = positionZ;
                targetPosition.y = positionY;
                //  
            }

            if (targetPosition.x != transform.position.x)
            {
                
                pz = targetPosition - transform.position;   
               
                pz.x = Mathf.Clamp(pz.x, (float)-0.1, (float)0.1);
                gameObject.transform.position += pz;         

            }
        } 
        }
    /// <summary>
    /// sets target position as current position
    /// </summary>
   public void StopMoving()
    {

        targetPosition = transform.position;
    }
   
    
    public bool IsMoving()
    {
        //  if (pz.x < 10)
        targetPosition.z = transform.position.z;
        targetPosition.y = transform.position.y;
      if (targetPosition != transform.position)
        {
            Debug.Log("isMoving true");
            return true;
        }
        else
        {
            Debug.Log("IsMoving false");
            return false;
        }
    }

    /// <summary>
    /// Changes the y position to -18
    /// </summary>
   public void changeYposition()
    {
        positionY = -17;
        targetPosition.y = positionY;
    }
  
    public void changeYpositionUp()
    {
        positionY = -2;
        targetPosition.y = positionY;
    }

    public void changeRoom2()
    {
        positionY = -32;
        targetPosition.y = positionY;

    }
    public void changeRoom2Down()
    {
        positionY = -47;
        targetPosition.y = positionY;
    }
    public void changeFinal()
    {
        positionY = -62;
        targetPosition.y = positionY;
    }
    }

