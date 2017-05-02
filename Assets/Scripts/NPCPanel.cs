using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class NPCPanel : MonoBehaviour
{

	private ModalPanel modalPanel;
	private Movement movement;
	private PleasantnessMeter meter;

	//public GameObject modalPanelObject;

	private NPCPanel2 npcPanel2;
	public GameObject npcPanelObject;

	private UnityAction myYesAction;
	private UnityAction myNoAction;
	private UnityAction myCancelAction;
	private int ikkuna = 0;
	private static NPCPanel npcPanel;
	public GameObject npcPanel2Object;

	/*
    private Button flowerButton;
    private Button paintingButton;

    private Item item; */

	public static NPCPanel Instance ()
	{
		if (!npcPanel) {
			npcPanel = FindObjectOfType (typeof(NPCPanel)) as NPCPanel;
			if (!npcPanel) {
				Debug.LogError ("There needs to be one active NPCPanel script on a GameObject in your Scene");
			}
		}
		return npcPanel;

	}
	/*
    void Start()
    {

        flowerButton.onClick.AddListener(() => item.DestroyItem(flowerButton));
        paintingButton.onClick.AddListener(() => item.DestroyItem(paintingButton));
    }
    */

	void Awake ()
	{
		modalPanel = ModalPanel.Instance ();
		movement = Movement.Instance ();
		npcPanel = NPCPanel.Instance();
		npcPanel2 = NPCPanel2.Instance ();

		meter = PleasantnessMeter.Instance ();

		myYesAction = new UnityAction (TestYesFunction);
		myNoAction = new UnityAction (TestNoFunction);
		myCancelAction = new UnityAction (TestCancelFunction);


		/*
        flowerButton = GameObject.Find("FlowerButton").GetComponent<Button>();
        paintingButton = GameObject.Find("PaintingButton").GetComponent<Button>();
        */
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
	/// after clicking a button sets the panel inactive.
	/// </summary>
	public void NPCTV ()
	{

		npcPanelObject.SetActive (true);
		ikkuna = 2;
		//  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "Looking at the screen you see something zip across it. The creature returns and you recognize it as your younger self. 'What would you like to watch?' echoes across the room." };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Do nothing.", action = myYesAction };
		modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "Choose a scary channel.", action = myNoAction };
		modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "Choose your favorite childhood channel.", action = myCancelAction };
		Debug.Log ("Button pressed / NPC3");
		if (movement.IsMoving () == false) {
			Debug.Log ("Moving false");
			modalPanel.NewChoice (modalPanelDetails);
			//  npcPanelObject.SetActive(false);
		} else {
			Debug.Log ("moving not false");
		}

	}
	public void NPCTVContinued ()
	{

		npcPanelObject.SetActive (true);
		//ikkuna = 2;
		//  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "You see a commercial of a brand new set of toy soldiers" };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Leave", action = myCancelAction };
		Debug.Log ("Button pressed / NPC3");
		if (movement.IsMoving () == false) {
			Debug.Log ("Moving false");
			modalPanel.NewChoice (modalPanelDetails);
			//  npcPanelObject.SetActive(false);
		} else {
			Debug.Log ("moving not false");
		}

	}
	public void NPCParentNormal ()
	{
		ikkuna = 1;
		npcPanelObject.SetActive (true);

		//  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "Looking at your parents you see they look younger. They seem haunted and uncomfortable." };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Leave", action = myYesAction };
		modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "Tell them to go away.", action = myNoAction };
		modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "Ask where we are?", action = myCancelAction };
		Debug.Log ("Button pressed / NPC3");
		if (movement.IsMoving () == false) {
			Debug.Log ("Moving false");
			modalPanel.NewChoice (modalPanelDetails);
			//  npcPanelObject.SetActive(false);
		} else {
			Debug.Log ("moving not false");
		}

	}
	public void NPCParentNormalcontinued ()
	{
		//ikkuna = 2;
		npcPanelObject.SetActive (true);

		//  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "your parents compliment how well furnished the room is. Your father exclaims that the painting was a steal" };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "leave", action = myCancelAction };

		Debug.Log ("Button pressed / NPC3");
		if (movement.IsMoving () == false) {
			Debug.Log ("Moving false");
			modalPanel.NewChoice (modalPanelDetails);
			//  npcPanelObject.SetActive(false);
		} else {
			Debug.Log ("moving not false");
		}

	}


	//Send to the modal panel to set up the buttons and functions to call
	//wrapped into unity actions

	void TestYesFunction ()
	{
		movement.StopMoving ();
		//  Camera.main.transform.Translate(0, 15, 0);
		// movement.changeYpositionUp();
		// npcPanel2.ClosePanel();
		//npcPanel.OpenPanel();
		//   npcPanelObject.SetActive(true);



	}

	/// <summary>
	/// close the npcPanel
	/// moves the camera and player to the next room and reduce pleasantness meter by 1
	/// </summary>
	void TestNoFunction ()
	{
		
		Camera.main.transform.position = new Vector3 (0, -15, -10);
		movement.changeYposition ();

		npcPanel2Object.SetActive (true);
		npcPanelObject.SetActive (false);

			MeterDown ();



	}

	void TestCancelFunction ()
	{
		movement.StopMoving ();
		if (ikkuna == 1) {
			NPCParentNormalcontinued ();
		}
		if (ikkuna == 2) {
			NPCTVContinued ();
		}
	}

	/// <summary>
	/// reduce Pleasantness meter by 1
	/// </summary>
	void MeterDown ()
	{
		if (meter.currentLevel > 0) {
			meter.ReduceLevel (1);
		}
	}

}

