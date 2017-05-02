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
    /*
    private Button flowerButton;
    private Button paintingButton;

    private Item item; */

    public static NPCPanel3 Instance()
    {
        if (!npcPanel3)
        {
            npcPanel3 = FindObjectOfType(typeof(NPCPanel3)) as NPCPanel3;
            if (!npcPanel3)
            {
                Debug.LogError("There needs to be one active NPCPanel3 script on a GameObject in your Scene");
            }
        }
        return npcPanel3;

    }
    /*
    void Start()
    {

        flowerButton.onClick.AddListener(() => item.DestroyItem(flowerButton));
        paintingButton.onClick.AddListener(() => item.DestroyItem(paintingButton));
    }
    */

    void Awake()
    {
        modalPanel = ModalPanel.Instance();
        movement = Movement.Instance();
        //   npcPanel = NPCPanel.Instance();
        npcPanel4 = NPCPanel4.Instance();

        meter = PleasantnessMeter.Instance();

        myYesAction = new UnityAction(TestYesFunction);
        myNoAction = new UnityAction(TestNoFunction);
        myCancelAction = new UnityAction(TestCancelFunction);
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
    /// Then sets the panel inactive.
    /// </summary>
    public void NPCBullyNormal()
    {
        npcPanel3Object.SetActive(true);
		ikkuna = 1;
        //  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
        ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "Hey you." };
        modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Hey.", action = myYesAction };
        modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "Bye.", action = myNoAction };
        modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "Sup?", action = myCancelAction };
        Debug.Log("Button pressed / NPC3");
        if (movement.IsMoving() == false)
        {
            Debug.Log("Moving false");
            modalPanel.NewChoice(modalPanelDetails);
            //  npcPanelObject.SetActive(false);
        }
        else { Debug.Log("moving not false"); }

    }
	public void NPCBullyNormalContinued()
	{
		npcPanel3Object.SetActive(true);

		//  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "Bully hint" };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Hey.", action = myCancelAction };
		Debug.Log("Button pressed / NPC3");
		if (movement.IsMoving() == false)
		{
			Debug.Log("Moving false");
			modalPanel.NewChoice(modalPanelDetails);
			//  npcPanelObject.SetActive(false);
		}
		else { Debug.Log("moving not false"); }

	}
	public void NPCTeacherNormal()
	{
		npcPanel3Object.SetActive(true);
		ikkuna = 2;
		//  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "Hey you." };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Hey.", action = myYesAction };
		modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "Bye.", action = myNoAction };
		modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "Sup?", action = myCancelAction };
		Debug.Log("Button pressed / NPC3");
		if (movement.IsMoving() == false)
		{
			Debug.Log("Moving false");
			modalPanel.NewChoice(modalPanelDetails);
			//  npcPanelObject.SetActive(false);
		}
		else { Debug.Log("moving not false"); }


	}
	public void NPCTeacherNormalContinued()
	{
		npcPanel3Object.SetActive(true);

		//  modalPanel.Choice("Lol hey let's party!", myYesAction, myNoAction, myCancelAction);
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails { npc = "teacher hint" };
		modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Hey.", action = myCancelAction };
		Debug.Log("Button pressed / NPC3");
		if (movement.IsMoving() == false)
		{
			Debug.Log("Moving false");
			modalPanel.NewChoice(modalPanelDetails);
			//  npcPanelObject.SetActive(false);
		}
		else { Debug.Log("moving not false"); }
    //Send to the modal panel to set up the buttons and functions to call
    //wrapped into unity actions
	}
    void TestYesFunction()
    {
        movement.StopMoving();
        //  Camera.main.transform.Translate(0, 15, 0);
        // movement.changeYpositionUp();
        // npcPanel2.ClosePanel();
        //npcPanel.OpenPanel();
        //   npcPanelObject.SetActive(true);
    }
    /// <summary>
    /// moves the player and camera down to nightmare, changes panel
    /// </summary>
    void TestNoFunction()
    {
        Camera.main.transform.position = new Vector3(0, -45, -10);
        movement.changeRoom2Down();

        npcPanel4Object.SetActive(true);
        npcPanel3Object.SetActive(false);
        //tähän mittari --
        MeterDown();
    }
    void TestCancelFunction()
    {
        movement.StopMoving();
		if (ikkuna == 1) {
			NPCBullyNormalContinued ();
		}
		if (ikkuna == 2) {
			NPCTeacherNormalContinued ();
		}
    }

    void MeterDown()
    {
        if (meter.currentLevel > 0)
        {
            meter.ReduceLevel(1);
        }
    }
}

