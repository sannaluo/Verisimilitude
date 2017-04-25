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
 
	private NPCPanel2 npcPanel2;
	public GameObject npcPanelObject;

	private UnityAction myYesAction;
	private UnityAction myNoAction;
	private UnityAction myCancelAction;

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
		//   npcPanel = NPCPanel.Instance();
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
	public void NPC2 ()
	{
		npcPanelObject.SetActive (true);
       
		//  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "Hey you." };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Hey.", action = myYesAction };
		modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "Bye.", action = myNoAction };
		modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "Sup?", action = myCancelAction };
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
		//tähän mittari --
		MeterDown ();
	}

	void TestCancelFunction ()
	{
		movement.StopMoving ();
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

