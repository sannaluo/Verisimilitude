using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class NPCPanel4 : MonoBehaviour
{

    private ModalPanel modalPanel;

    private Movement movement;

    private NPCPanel3 npcPanel3;
    public GameObject npcPanel4Object;
    public GameObject npcPanel3Object;
    //  public GameObject movementObject;
    private UnityAction myYesAction;
    private UnityAction myNoAction;
    private UnityAction myCancelAction;

    private static NPCPanel4 npcPanel4;

	/// <summary>
	/// creates NPCPanel4 Instance if there is none
	/// </summary>
    public static NPCPanel4 Instance()
    {
        if (!npcPanel4)
        {
            npcPanel4 = FindObjectOfType(typeof(NPCPanel4)) as NPCPanel4;
            if (!npcPanel4)
            {
				Debug.LogWarning("There needs to be one active NPCPanel4 script on a GameObject in your Scene");
            }
        }
        return npcPanel4;

    }

    void Awake()
    {
        modalPanel = ModalPanel.Instance();
        // modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;

        movement = Movement.Instance();
        // movement = FindObjectOfType(typeof(Movement)) as Movement;
        npcPanel3 = NPCPanel3.Instance();
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
	public void NPCBullyNightmare()
    {
        npcPanel4Object.SetActive(true);
        //  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
        ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "A twisted creature is standing where the school bully used to be. As you approach an eerie whisper echoes 'if you want to leave, find the missing pages of the Necronomicon'" };
        modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "I will help you", action = myYesAction };
        modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "tell the creature to sod off", action = myNoAction };
        modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "ask 'why do you need the pages?'", action = myCancelAction };
        Debug.Log("Button pressed / NPC3");

        if (movement.IsMoving() == false)
        {
            Debug.Log("Moving false");
            modalPanel.NewChoice(modalPanelDetails);
            //  npcPanelObject.SetActive(false);
        }
        else { Debug.Log("moving not false"); }
    }
	/// <summary>
    /// NPCs the bully nightmare continued.
    /// </summary>
	public void NPCBullyNightmareContinued()
	{
		npcPanel4Object.SetActive(true);
		//  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "They worshipped, so they said, the Great Old Ones who lived ages before there were any men, and who came to the young world out of the sky" };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "...", action = myCancelAction };

		Debug.Log("Button pressed / NPC3");

		if (movement.IsMoving() == false)
		{
			Debug.Log("Moving false");
			modalPanel.NewChoice(modalPanelDetails);
			//  npcPanelObject.SetActive(false);
		}
		else { Debug.Log("moving not false"); }
	}
	/// <summary>
	/// Something the teacher says in the nightmare and what you can answer.
	/// Then sets the panel inactive.
	/// </summary>
	public void NPCTeacherNightmare()
	{
		npcPanel4Object.SetActive(true);
		//  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "This creature seems to resemble the teacher. It screams 'Reforge the Necronomicon!'" };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "what are you supposed to be?", action = myYesAction };
		modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "Decline to help", action = myNoAction };
		modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "Ask 'Why do you need to reforge it?'", action = myCancelAction };
		Debug.Log("Button pressed / NPC3");

		if (movement.IsMoving() == false)
		{
			Debug.Log("Moving false");
			modalPanel.NewChoice(modalPanelDetails);
			//  npcPanelObject.SetActive(false);
		}
		else { Debug.Log("moving not false"); }
	}
	/// <summary>
	/// teachers reply
	/// </summary>
	public void NPCTeacherNightmareContinued()
	{
		npcPanel4Object.SetActive(true);
		//  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "The creature mutters in an incomprehensible language, but in your head echoes 'That is not dead which can eternal lie. And with strange aeons even death may die'" };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "...", action = myCancelAction };

		Debug.Log("Button pressed / NPC3");

		if (movement.IsMoving() == false)
		{
			Debug.Log("Moving false");
			modalPanel.NewChoice(modalPanelDetails);
			//  npcPanelObject.SetActive(false);
		}
		else { Debug.Log("moving not false"); }
	}

    //Send to the modal panel to set up the buttons and functions to call
    //wrapped into unity actions

	/// <summary>
	/// moves camera and player to room2 regular
	/// turns npcpanel3 on
	/// turns npcpanle4 off
	/// </summary>
    void TestYesFunction()
    {
        Camera.main.transform.position = new Vector3(0, -30, -10);
        movement.changeRoom2();

        //   npcPanelObject.SetActive(true);
        npcPanel4Object.SetActive(false);
        npcPanel3Object.SetActive(true);
    }
    void TestNoFunction()
    {
        // Camera.main.transform.Translate(0, -15, 0);
        // movement.changeYposition();
        // npcPanel.ClosePanel();
        // npcPanel2.OpenPanel();
        // npcPanel2Object.SetActive(false);
        // tähän mittari --
        movement.StopMoving();
    }
    void TestCancelFunction()
    {
        movement.StopMoving();
    }
}

