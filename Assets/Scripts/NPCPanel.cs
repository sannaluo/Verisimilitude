﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class NPCPanel : MonoBehaviour
{

    private ModalPanel modalPanel;
    private Movement movement;
 
   private NPCPanel2 npcPanel2;
    public GameObject npcPanelObject;

    private UnityAction myYesAction;
    private UnityAction myNoAction;
    private UnityAction myCancelAction;

    private static NPCPanel npcPanel;
    public GameObject npcPanel2Object;

    public static NPCPanel Instance()
    {
        if (!npcPanel)
        {
           npcPanel = FindObjectOfType(typeof(NPCPanel)) as NPCPanel;
            if (!npcPanel)
            {
                Debug.LogError("There needs to be one active NPCPanel script on a GameObject in your Scene");
            }
        }
        return npcPanel;

    }

    void Awake()
    {
        modalPanel = ModalPanel.Instance();
        movement = Movement.Instance();
     //   npcPanel = NPCPanel.Instance();
     npcPanel2 = NPCPanel2.Instance();

        myYesAction = new UnityAction(TestYesFunction);
        myNoAction = new UnityAction(TestNoFunction);
        myCancelAction = new UnityAction(TestCancelFunction);
    }
    /*
    public void TestYNC()
    {
        npcPanelObject.SetActive(true);
    //    modalPanel.Choice("Would you like to answer?\n Maybe?", myYesAction, myNoAction, myCancelAction);
    }
    public void TestC()
    {
        npcPanelObject.SetActive(true);
        // modalPanel.Choice("Hello.", myCancelAction);
        ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "Hello." };
        modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Hey.", action = myCancelAction };
        modalPanel.NewChoice(modalPanelDetails);
    }
    */

    /// <summary>
    /// Something the npc says and what you can answer.
    /// Then sets the panel inactive.
    /// </summary>
    public void NPC2()
    {
        npcPanelObject.SetActive(true);
        //  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
        ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "Hey you." };
        modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Bye.", action = myYesAction };
        modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "Hey.", action = myNoAction };
        modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "Sup?", action = myCancelAction };
        modalPanel.NewChoice(modalPanelDetails);
      //  npcPanelObject.SetActive(false);
    }

    //Send to the modal panel to set up the buttons and functions to call
    //wrapped into unity actions

    void TestYesFunction()
    {
      //  Camera.main.transform.Translate(0, 15, 0);
       // movement.changeYpositionUp();
        // npcPanel2.ClosePanel();
        //npcPanel.OpenPanel();
     //   npcPanelObject.SetActive(true);
    }
    void TestNoFunction()
    {
        Camera.main.transform.Translate(0, -15, 0);
        movement.changeYposition();
        npcPanel2Object.SetActive(true);
        npcPanelObject.SetActive(false);
       //tähän mittari --
    }
    void TestCancelFunction()
    {
      
    }
}

