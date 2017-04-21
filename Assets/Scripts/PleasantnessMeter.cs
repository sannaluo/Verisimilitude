using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PleasantnessMeter : MonoBehaviour {

    public int startingLevel = 5;
    public int currentLevel;
    public Slider pleasantnessSlider;
    bool isDead;
    private Movement movement;
    private static PleasantnessMeter pleasantnessMeter;
    private Vector3 death;
    


    public static PleasantnessMeter Instance()
    {
        if (!pleasantnessMeter)
        {
            pleasantnessMeter = FindObjectOfType(typeof(PleasantnessMeter)) as PleasantnessMeter;
            if (!pleasantnessMeter)
            {
                Debug.LogError("There needs to be one active PleasantnessMeter script on a GameObject in your Scene");
            }
        }
        return pleasantnessMeter;

    }

    void Awake()
    {
        currentLevel = startingLevel;
        movement = Movement.Instance();
    }

    public void ReduceLevel(int amount)
    {
        currentLevel -= amount;
        pleasantnessSlider.value = currentLevel;

        if (currentLevel <= 0 && !isDead){
            Death();
        }
    }
   

        void Death(){
            isDead = true;
        death.x = 100;
        death.y = 100;
        death.z = -10;
            movement.StopMoving();
        Camera.main.transform.position = death;
        }
    }

