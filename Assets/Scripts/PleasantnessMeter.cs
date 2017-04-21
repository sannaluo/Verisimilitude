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
    private Canvas canvas;

    public GameObject n1;
    public GameObject n2;
    public GameObject n3;
    public GameObject n4;



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
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
      /*  n1 = NPCPanel.Instance();
        n2 = NPCPanel2.Instance();
        n3 = NPCPanel3.Instance();
        n4 = NPCPanel4.Instance();*/
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


        canvas.GetComponent<Canvas>().enabled = false;
        /*
         n1.GetComponent<NPCPanel>().enabled = false;
         n2.GetComponent<NPCPanel2>().enabled = false;
         n3.GetComponent<NPCPanel3>().enabled = false;
         n4.GetComponent<NPCPanel4>().enabled = false;
         */
        n1.SetActive(false);
        n2.SetActive(false);
        n3.SetActive(false);
        n4.SetActive(false);
    }
    }

