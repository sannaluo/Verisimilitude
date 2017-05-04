using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class NPCPanel2 : MonoBehaviour
{

	private ModalPanel modalPanel;

	private Movement movement;
	private int ikkuna = 0;
	private NPCPanel npcPanel;
	public GameObject npcPanel2Object;
	public GameObject npcPanelObject;
	//  public GameObject movementObject;
	private UnityAction myYesAction;
	private UnityAction myNoAction;
	private UnityAction myCancelAction;
	private PleasantnessMeter meter;

	private static NPCPanel2 npcPanel2;

	/// <summary>
	/// creates a NPCPanel2 instance if there is none
	/// </summary>
	public static NPCPanel2 Instance ()
	{
		if (!npcPanel2) {
			npcPanel2 = FindObjectOfType (typeof(NPCPanel2)) as NPCPanel2;
			if (!npcPanel2) {
				Debug.LogWarning ("There needs to be one active NPCPanel2 script on a GameObject in your Scene");
			}
		}
		return npcPanel2;

	}

	void Awake ()
	{
		modalPanel = ModalPanel.Instance ();
		// modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
		meter = PleasantnessMeter.Instance ();
		movement = Movement.Instance ();
		// movement = FindObjectOfType(typeof(Movement)) as Movement;
		npcPanel = NPCPanel.Instance ();
		//  npcPanel2 = NPCPanel2.Instance();

		myYesAction = new UnityAction (TestYesFunction);
		myNoAction = new UnityAction (TestNoFunction);
		myCancelAction = new UnityAction (TestCancelFunction);
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
	public void NPCTVNightmare ()
	{
		ikkuna = 2;
		npcPanel2Object.SetActive (true);
		//  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "Looking toward the screen you see a twisted version of yourself and he seems to be muttering in some incomprehensible language." };
		modalPanelDetails.button1Details = new EventButtonDetails {
			buttonTitle = "Ask what you can do to help.",
			action = myYesAction
		};
		modalPanelDetails.button2Details = new EventButtonDetails {
			buttonTitle = "Yell 'speak English!' at it.",
			action = myNoAction
		};
		modalPanelDetails.button3Details = new EventButtonDetails {
			buttonTitle = "Listen what he is trying to tell you.",
			action = myCancelAction
		};
		Debug.Log ("Button pressed / NPC3");

		if (movement.IsMoving () == false) {
			Debug.Log ("Moving false");
			modalPanel.NewChoice (modalPanelDetails);
			//  npcPanelObject.SetActive(false);
		} else {
			Debug.Log ("moving not false");
		}
	}

	/// <summary>
	/// Something the npc says and what you can answer
	/// </summary>
	public void NPCTVNightmareContinued ()
	{
		npcPanel2Object.SetActive (true);
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "ph'nglui mglw'nafh Cthulhu R'lyeh wgah'nagl fhtagn" };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Leave.", action = myCancelAction };
		modalPanel.NewChoice (modalPanelDetails);
	}

	/// <summary>
	/// Something the npc says and what you can answer
	/// </summary>
	public void NPCParentNightmare ()
	{
		ikkuna = 1;
		npcPanel2Object.SetActive (true);
		//  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "You see a nightmarish creature looking at where your father used to be. It moans 'Dont you recognize me?'" };
		modalPanelDetails.button1Details = new EventButtonDetails {
			buttonTitle = "Ask 'are you my mother?'",
			action = myYesAction
		};
		modalPanelDetails.button2Details = new EventButtonDetails {
			buttonTitle = "Ask the creature what it did to your parents.",
			action = myNoAction
		};
		modalPanelDetails.button3Details = new EventButtonDetails {
			buttonTitle = "Ask what happened to your father.",
			action = myCancelAction
		};
		Debug.Log ("Button pressed / NPC3");

		if (movement.IsMoving () == false) {
			Debug.Log ("Moving false");
			modalPanel.NewChoice (modalPanelDetails);
			//  npcPanelObject.SetActive(false);
		} else {
			Debug.Log ("moving not false");
		}
	}
	/// <summary>
	/// Something the npc says and what you can answer
	/// </summary>
	public void NPCParentNightmareContinued ()
	{
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "Something BAD has happened to him." };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Leave.", action = myCancelAction };
		modalPanel.NewChoice (modalPanelDetails);
	}

	//Send to the modal panel to set up the buttons and functions to call
	//wrapped into unity actions

	/// <summary>
	/// move the camera to the regular dream stage and enable regular dream's npc buttons 
	/// disable nightmare npc buttons
	/// </summary>
	void TestYesFunction ()
	{
		Camera.main.transform.position = new Vector3 (0, 0, -10);
		movement.changeYpositionUp ();

		//   npcPanelObject.SetActive(true);
		npcPanel2Object.SetActive (false);
		npcPanelObject.SetActive (true);
	}
	/// <summary>
	/// Pleasantness meter goes down by 1
	/// </summary>
	void TestNoFunction ()
	{
		//  Camera.main.transform.Translate(0, -15, 0);
		// movement.changeYposition();
		//    npcPanel.ClosePanel();
		//   npcPanel2.OpenPanel();
		// npcPanel2Object.SetActive(false);
		//tähän mittari --
		npcPanel2Object.SetActive (true);
		movement.StopMoving ();
		MeterDown ();
	}
	/// <summary>
	/// if Parent window is open display ParentContinued panel
	/// if TV window is open display TVContinued panel
	/// </summary>
	void TestCancelFunction ()
	{
		movement.StopMoving ();
		if (ikkuna == 1) {
			NPCParentNightmareContinued ();
		}
		if (ikkuna == 2) {
			NPCTVNightmareContinued ();
		}
		movement.StopMoving ();
	}
	/// <summary>
	/// reduce pleasantness meter by 1
	/// </summary>
	void MeterDown ()
	{
		if (meter.currentLevel > 0) {
			meter.ReduceLevel (1);
		}
	}
}

