using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class NPCPanel2 : MonoBehaviour
{

    private ModalPanel modalPanel;
 
    private Movement movement;

     private NPCPanel npcPanel;
    public GameObject npcPanel2Object;
    public GameObject npcPanelObject;
    private UnityAction myYesAction;
    private UnityAction myNoAction;
    private UnityAction myCancelAction;

    private static NPCPanel2 npcPanel2;

    public static NPCPanel2 Instance()
    {
        if (!npcPanel2)
        {
            npcPanel2 = FindObjectOfType(typeof(NPCPanel2)) as NPCPanel2;
            if (!npcPanel2)
            {
                Debug.LogError("There needs to be one active NPCPanel2 script on a GameObject in your Scene");
            }
        }
        return npcPanel2;

    }

    void Awake()
    {
        modalPanel = ModalPanel.Instance();
   
        movement = Movement.Instance();
          npcPanel = NPCPanel.Instance();
        //  npcPanel2 = NPCPanel2.Instance();

        myYesAction = new UnityAction(TestYesFunction);
        myNoAction = new UnityAction(TestNoFunction);
        myCancelAction = new UnityAction(TestCancelFunction);
    }
    /*
    public void TestYNC()
    {
        npcPanel2Object.SetActive(true);
    //    modalPanel.Choice("Would you like to answer?\n Maybe?", myYesAction, myNoAction, myCancelAction);
    }
    public void TestC()
    {
        npcPanel2Object.SetActive(true);
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
      //  npcPanel2Object.SetActive(true);
        //  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
        ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "OMG help me!" };
        modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Nah.", action = myYesAction };
        modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "ERHMAHGERD totally.", action = myNoAction };
        modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "Sure.", action = myCancelAction };
        modalPanel.NewChoice(modalPanelDetails);
        //  npcPanelObject.SetActive(false);
        
    }

    //Send to the modal panel to set up the buttons and functions to call
    //wrapped into unity actions

    void TestYesFunction()
    {
        Camera.main.transform.Translate(0, 15, 0);
        movement.changeYpositionUp();
        
        //   npcPanelObject.SetActive(true);
        npcPanel2Object.SetActive(false);
        npcPanelObject.SetActive(true);
    }
    void TestNoFunction()
    {
      //  Camera.main.transform.Translate(0, -15, 0);
       // movement.changeYposition();
        //    npcPanel.ClosePanel();
        //   npcPanel2.OpenPanel();
       // npcPanel2Object.SetActive(false);
       //tähän mittari --
    }
    void TestCancelFunction()
    {
        
    }
}

