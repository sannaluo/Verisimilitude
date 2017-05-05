using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class StartPanel : MonoBehaviour
{

	private ModalPanel modalPanel;
	private Movement movement;
	private PleasantnessMeter meter;
	private Canvas canvas;



	private NPCPanel npcPanel;
	public GameObject startPanelObject;

	private UnityAction myYesAction;
	private UnityAction myNoAction;
	private UnityAction myCancelAction;

	private static StartPanel startPanel;
	public GameObject npcPanelObject;



	/// <summary>
	/// creates a StartPanel instance if there is none already
	/// </summary>
	public static StartPanel Instance ()
	{
		Debug.Log ("Startpanel created");
		if (!startPanel) {
			startPanel = FindObjectOfType (typeof(StartPanel)) as StartPanel;
			if (!startPanel) {
				Debug.LogWarning ("There needs to be one active NPCPanel script on a GameObject in your Scene");
			}
		}
		return startPanel;

	}

    void Start()
    {
		canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
		canvas.GetComponent<Canvas>().enabled = false;
		Debug.Log (canvas);

    }
    

	void Awake ()
	{
		modalPanel = ModalPanel.Instance ();
		movement = Movement.Instance ();
		startPanel = StartPanel.Instance ();
		npcPanel = NPCPanel.Instance ();

		meter = PleasantnessMeter.Instance ();

		myYesAction = new UnityAction (TestYesFunction);
		myNoAction = new UnityAction (TestNoFunction);
		myCancelAction = new UnityAction (TestCancelFunction);



	}


	/// <summary>
	/// dialog panel you see when you press the help button on the start screen
	/// </summary>
	public void NPCTutorial ()
	{
		Debug.Log ("NPCTutorial openend");
		startPanelObject.SetActive (true);

		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "Click to interact with people and objects in the memory (NPCs may need you to stand near them to start a dialogue)\n The slider in the bottom left corner is your Pleasantness. Every time you are rude to someone the meter goes down by one. There is no way to replenish lost pleasantness, and if the meter reaches zero it's game over. The 0/4 counter at the bottom right corner is how many items you have collected from the memory. When you have collected 4/4 items you will progress to the next memory." };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Back.", action = myYesAction };


		modalPanel.NewChoice (modalPanelDetails);
			

	}


	/// <summary>
	/// dialog panel you see when you press the start button on the start screen
	/// </summary>
	public void StartGame() {
		Debug.Log ("startgame called");
		startPanelObject.SetActive (true);

		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "From this point onward you will be trapped in an endless cycle and there is only one way to end the cycle.\n Do you want to start?" };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "I wish to start this endless cycle.", action = myNoAction };
		modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "I wish to start this endless cycle.", action = myNoAction  };
		modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "I wish to start this endless cycle.", action = myNoAction  };

		modalPanel.NewChoice (modalPanelDetails);
		
	}

	//Send to the modal panel to set up the buttons and functions to call
	//wrapped into unity actions

	void TestYesFunction ()
	{
		movement.StopMoving ();






	}

	/// <summary>
	/// close the npcPanel
	/// moves the camera and player to the next room and reduce pleasantness meter by 1
	/// </summary>
	void TestNoFunction ()
	{

		Camera.main.transform.position = new Vector3 (0, 0, -10);

		canvas.GetComponent<Canvas>().enabled = true;
		npcPanelObject.SetActive (true);
		startPanelObject.SetActive (false);







	}

	void TestCancelFunction ()
	{
		movement.StopMoving ();


	}



}

