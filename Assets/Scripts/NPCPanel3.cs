using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class NPCPanel3 : MonoBehaviour
{
	private int ikkuna = 0;
	private ModalPanel modalPanel;
	private Movement movement;
	private PleasantnessMeter meter;

	private NPCPanel4 npcPanel4;
	public GameObject npcPanel3Object;

	private UnityAction myYesAction;
	private UnityAction myNoAction;
	private UnityAction myCancelAction;

	private static NPCPanel3 npcPanel3;
	public GameObject npcPanel4Object;


	/// <summary>
	/// Creates a NPCPanel 3 instance if there is none
	/// </summary>
	public static NPCPanel3 Instance ()
	{
		if (!npcPanel3) {
			npcPanel3 = FindObjectOfType (typeof(NPCPanel3)) as NPCPanel3;
			if (!npcPanel3) {
				Debug.LogWarning ("There needs to be one active NPCPanel3 script on a GameObject in your Scene");
			}
		}
		return npcPanel3;

	}


	void Awake ()
	{
		modalPanel = ModalPanel.Instance ();
		movement = Movement.Instance ();

		npcPanel4 = NPCPanel4.Instance ();

		meter = PleasantnessMeter.Instance ();

		myYesAction = new UnityAction (TestYesFunction);
		myNoAction = new UnityAction (TestNoFunction);
		myCancelAction = new UnityAction (TestCancelFunction);

	}


	/// <summary>
	/// Something the npc says and what you can answer.
	/// Then sets the panel inactive.
	/// </summary>
	public void NPCBullyNormal ()
	{
		npcPanel3Object.SetActive (true);
		ikkuna = 1;

		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "As you approach this kid you recognize him as your childhood bully. He yells 'Where is the essay you were supposed to write for me!?'" };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Do nothing.", action = myYesAction };
		modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "Say 'I'm not gonna write anything for you!'", action = myNoAction };
		modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "Say 'You don't scare me'.", action = myCancelAction };
		Debug.Log ("Button pressed / NPC3");
		if (movement.IsMoving () == false) {
			Debug.Log ("Moving false");
			modalPanel.NewChoice (modalPanelDetails);

		} else {
			Debug.Log ("moving not false");
		}

	}
	/// <summary>
	/// Something the npc says and what you can answer.
	/// Then sets the panel inactive.
	/// </summary>
	public void NPCBullyNormalContinued ()
	{
		npcPanel3Object.SetActive (true);

		//  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "The oldest and strongest emotion of mankind is fear, and the oldest and strongest kind of fear is fear of the unknown." };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Leave.", action = myCancelAction };
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
	/// Something the npc says and what you can answer.
	/// Then sets the panel inactive.
	/// </summary>
	public void NPCTeacherNormal ()
	{
		npcPanel3Object.SetActive (true);
		ikkuna = 2;

		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "As you stop in front of the teacher she says 'Class is starting, better get in or you're going to be late. I will not accept papers that are returned too late'." };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Do nothing.", action = myYesAction };
		modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "Say 'I didn't enjoy your classes'.", action = myNoAction };
		modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "Ask 'what was the subject of the assignment?'", action = myCancelAction };
		Debug.Log ("Button pressed / NPC3");
		if (movement.IsMoving () == false) {
			Debug.Log ("Moving false");
			modalPanel.NewChoice (modalPanelDetails);

		} else {
			Debug.Log ("moving not false");
		}


	}

	/// <summary>
	/// Something the npc says and what you can answer.
	/// Then sets the panel inactive.
	/// </summary>
	public void NPCTeacherNormalContinued ()
	{
		npcPanel3Object.SetActive (true);


		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "The teacher thinks for a while and then her eyes glaze over and she starts quoting in a hollow voice 'Yog-Sototh knows the gate. Yog-Sothoth is the gate. Yog-Sototh is the key and guardian of the gate. Past, present, future, all are one in Yog-Sototh. He knows where the Old Ones broke through of old, and where They shall break through again. He knows where They have trod earth's fields, and where They still tread them, and why no one can behold Them as They tread'." };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "...", action = myCancelAction };
		Debug.Log ("Button pressed / NPC3");
		if (movement.IsMoving () == false) {
			Debug.Log ("Moving false");
			modalPanel.NewChoice (modalPanelDetails);

		} else {
			Debug.Log ("moving not false");
		}
		//Send to the modal panel to set up the buttons and functions to call
		//wrapped into unity actions
	}

	void TestYesFunction ()
	{
		movement.StopMoving ();

	}

	/// <summary>
	/// moves the player and camera down to nightmare, switches npcpanel3object off and switches npcPanel4Object on 
	/// </summary>
	void TestNoFunction ()
	{
		Camera.main.transform.position = new Vector3 (0, -45, -10);
		movement.changeRoom2Down ();

		npcPanel4Object.SetActive (true);
		npcPanel3Object.SetActive (false);
		//tähän mittari --
		MeterDown ();
	}
	/// <summary>
	/// if the preious dialogue was bully this continues with NPCBullyNormalContinued()
	/// if the previous dialogue was teacher this continues with NPCTeacherNormalContinued()
	/// </summary>
	void TestCancelFunction ()
	{
		movement.StopMoving ();
		if (ikkuna == 1) {
			NPCBullyNormalContinued ();
		}
		if (ikkuna == 2) {
			NPCTeacherNormalContinued ();
		}
	}
	/// <summary>
	/// pleasantness meter goes down by 1
	/// </summary>
	void MeterDown ()
	{
		if (meter.currentLevel > 0) {
			meter.ReduceLevel (1);
		}
	}
}

