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

	/// <summary>
	/// creates a movement if there is none
	/// </summary>
    public static Movement Instance()
    {
        if (!movement)
        {
            movement = FindObjectOfType(typeof(Movement)) as Movement;
            if (!movement)
            {
                Debug.LogWarning("There needs to be one active Movement script on a GameObject in your Scene");
            }
        }
        return movement;

    }

    void Start()
    {
       
        targetPosition.z = -5;
        targetPosition.x = 0;
        targetPosition.y = -2;
        positionY = -1;
        positionZ = -5;
      
    }


   void Update()
    {
		
		if (!modalPanelObject.activeSelf) {

			if (Input.GetMouseButtonDown (0)) {


				targetPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				targetPosition.z = positionZ;
				targetPosition.y = positionY;
				//  
			}

				if (targetPosition.x != transform.position.x) {
                
					pz = targetPosition - transform.position;   
               
					pz.x = Mathf.Clamp (pz.x, (float)-0.1, (float)0.1);

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
   
    /// <summary>
    /// Determines whether this instance is moving.
    /// </summary>
    /// <returns><c>true</c> if this instance is moving; otherwise, <c>false</c>.</returns>
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
	/// Changes the y position to -17 (room1 nightmare)
    /// </summary>
	public void changeYposition()
    {
        positionY = -16;
        targetPosition.y = positionY;
    }
  
	/// <summary>
	/// Changes the y position to -2. (room1 regular)
	/// </summary>
    public void changeYpositionUp()
    {
        positionY = -1;
        targetPosition.y = positionY;
    }

	/// <summary>
	/// Changes the y position to -32. (room2 regular)
	/// </summary>
    public void changeRoom2()
    {
        positionY = -31;
        targetPosition.y = positionY;

    }

	/// <summary>
	/// Changes the y position to -47. (room2 nightmare)
	/// </summary>
    public void changeRoom2Down()
    {
        positionY = -46;
        targetPosition.y = positionY;
    }

	/// <summary>
	/// Changes the y position to -62. (final room)
	/// </summary>
    public void changeFinal()
    {
        positionY = -61;
        targetPosition.y = positionY;
    }
    /// <summary>
    /// changes y position by -15 to move from start screen to first memory
    /// </summary>
	public void startGame() 
	{
		positionY = -14;
	}
}