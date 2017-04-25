using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class TestModalPanel : MonoBehaviour
{

    private ModalPanel modalPanel;
 
    private Movement movement;
  //  private NPCPanel npcPanel;
   // private NPCPanel2 npcPanel2;

    private UnityAction myYesAction;
    private UnityAction myNoAction;
    private UnityAction myCancelAction;
   

    void Awake()
    {
        modalPanel = ModalPanel.Instance();
  
        movement = Movement.Instance();
 

        myYesAction = new UnityAction(TestYesFunction);
        myNoAction = new UnityAction(TestNoFunction);
        myCancelAction = new UnityAction(TestCancelFunction);
    }

    public void TestYNC()
    {
     //   modalPanel.Choice("Would you like to answer?\n Maybe?", myYesAction, myNoAction, myCancelAction);
    }
    public void TestC()
    {
        // modalPanel.Choice("Hello.", myCancelAction);
        ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "Hello." };
        modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Hey.", action = myCancelAction };
        modalPanel.NewChoice(modalPanelDetails);
    }

    public void NPC2()
    {
		
        //  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
        ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "Sup." };
        modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Bye.", action = myYesAction };
        modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "Eww.", action = myNoAction };
        modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "Yo.", action = myCancelAction };
        modalPanel.NewChoice(modalPanelDetails);
    }

    //Send to the modal panel to set up the buttons and functions to call
    //wrapped into unity actions

    void TestYesFunction()
    {
        Camera.main.transform.Translate(0, 15, 0);
        movement.changeYpositionUp();
  
    }
    void TestNoFunction()
    {
        Camera.main.transform.Translate(0, -15, 0);
        movement.changeYposition();
    
    }
    void TestCancelFunction()
    {
       //
    }
}
