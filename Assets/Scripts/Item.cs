using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
	
	private Button flowerButton;
	private Button paintingButton;
	private Button toySoldierButton;
	private Button abcButton;
	private Button flowerButton2;
	private Button paintingButton2;
	private Button toySoldierButton2;
	private Button abcButton2;
    private Button page1Button;
    private Button page2Button;
    private Button page3Button;
    private Button page4Button;

    private Movement movement;
	private NPCPanel2 npcPanel2;
	private NPCPanel3 npcPanel3;
	private Canvas canvas;

	private SpriteRenderer abcblocks;
	private SpriteRenderer flower;
	private SpriteRenderer painting;
	private SpriteRenderer toysoldier;

    private SpriteRenderer page1;
    private SpriteRenderer page2;
    private SpriteRenderer page3;
    private SpriteRenderer page4;
    
    //bool level = false;


    public GameObject npcPanel3Object;
	public GameObject npcPanel2Object;
	public GameObject npcPanel4Object;

	public Text itemCounter;
	private static int itemCount;
	private static int itemCount2;
	private int count;
	// Use this for initialization
	void Start ()
	{
		//  itemCount = 0;
		canvas = GameObject.Find ("Canvas").GetComponent<Canvas> ();


		flowerButton = GameObject.Find("FlowerButton").GetComponent<Button>();
		paintingButton = GameObject.Find ("PaintingButton").GetComponent<Button> ();
		toySoldierButton = GameObject.Find ("ToySoldierButton").GetComponent<Button> ();
		abcButton = GameObject.Find ("ABCButton").GetComponent<Button> ();
		itemCounter = GameObject.Find ("ItemCounter").GetComponent<Text> ();

		abcblocks = GameObject.Find ("abcblocks").GetComponent<SpriteRenderer> ();
		flower = GameObject.Find ("flower").GetComponent<SpriteRenderer> ();
		toysoldier = GameObject.Find ("toysoldier").GetComponent<SpriteRenderer> ();
		painting = GameObject.Find ("painting").GetComponent<SpriteRenderer> ();
        

        page1Button = GameObject.Find("Page1Button").GetComponent<Button>();
        page2Button = GameObject.Find("Page2Button").GetComponent<Button>();
        page3Button = GameObject.Find("Page3Button").GetComponent<Button>();
        page4Button = GameObject.Find("Page4Button").GetComponent<Button>();
        

        page1 = GameObject.Find("page1").GetComponent<SpriteRenderer>();
        page2 = GameObject.Find("page2").GetComponent<SpriteRenderer>();
        page3 = GameObject.Find("page3").GetComponent<SpriteRenderer>();
        page4 = GameObject.Find("page4").GetComponent<SpriteRenderer>();
        /*
        flowerButton.onClick.AddListener(() => DestroyItem(flowerButton));
        paintingButton.onClick.AddListener(() => DestroyItem(paintingButton));
        toySoldierButton.onClick.AddListener(() => DestroyItem(toySoldierButton));
        */

        abcButton.onClick.AddListener (() => AddCount (abcButton));
		abcButton.onClick.AddListener (() => DestroyItem3 (abcblocks));
		flowerButton.onClick.AddListener (() => AddCount (flowerButton));
		flowerButton.onClick.AddListener (() => DestroyItem3 (flower));
		paintingButton.onClick.AddListener (() => AddCount (paintingButton));
		paintingButton.onClick.AddListener (() => DestroyItem3 (painting));
		toySoldierButton.onClick.AddListener (() => AddCount (toySoldierButton));
		toySoldierButton.onClick.AddListener (() => DestroyItem3 (toysoldier));

        page1Button.onClick.AddListener(() => AddCount(page1Button));
        page1Button.onClick.AddListener(() => DestroyItem3(page1));
        page2Button.onClick.AddListener(() => AddCount(page2Button));
        page2Button.onClick.AddListener(() => DestroyItem3(page2));
        page3Button.onClick.AddListener(() => AddCount(page3Button));
        page3Button.onClick.AddListener(() => DestroyItem3(page3));
        page4Button.onClick.AddListener(() => AddCount(page4Button));
        page4Button.onClick.AddListener(() => DestroyItem3(page4));
        /*
        //toySoldierButton.onClick.AddListener(() => DestroyItem(toySoldierButton));
        //paintingButton.onClick.AddListener(() => DestroyItem(paintingButton));
        //flowerButton.onClick.AddListener(() => DestroyItem(flowerButton));
        */
        /*
        flowerButton2 = GameObject.Find("FlowerButton2").GetComponent<Button>();
        paintingButton2 = GameObject.Find("PaintingButton2").GetComponent<Button>();
        toySoldierButton2 = GameObject.Find("ToySoldierButton2").GetComponent<Button>();
        abcButton2 = GameObject.Find("ABCButton2").GetComponent<Button>();


        flowerButton2.onClick.AddListener(() => DestroyItem2(flowerButton2));
        paintingButton2.onClick.AddListener(() => DestroyItem2(paintingButton2));
        toySoldierButton2.onClick.AddListener(() => DestroyItem2(toySoldierButton2));
        abcButton2.onClick.AddListener(() => DestroyItem2(abcButton2));
		*/
    }

	void Awake ()
	{
		movement = Movement.Instance ();
		npcPanel2 = NPCPanel2.Instance ();
		npcPanel3 = NPCPanel3.Instance ();
	}

	// Update is called once per frame




	void Update ()
	{
		if (itemCount != 4) {
			count = itemCount;
		}
		if (itemCount == 4) {
			count = itemCount2;
		}
		itemCounter.text = count + "/4";

	}

	/// <summary>
	/// moves camera and player model to next room
	/// disables npcPanel2
	/// activates npcPanel3
	/// </summary>
	void changeRoom ()
	{
		if (itemCount == 4) {
			/*if (level == true)
            {
                Camera.main.transform.position = new Vector3(0, -60, -10);
                movement.changeFinal();
                if (npcPanel4Object.activeSelf)
                {
                    npcPanel4Object.SetActive(false);
                }
                if (npcPanel3Object.activeSelf)
                {
                    npcPanel3Object.SetActive(false);
                }
                Canvas.Destroy(canvas);
            }
            if (level == false)
            {
            */
			Camera.main.transform.position = new Vector3 (0, -30, -10);
			movement.changeRoom2 ();
			npcPanel2Object.SetActive (false);
			npcPanel3Object.SetActive (true);
			//  itemCount = 0;
			//  level = true;
			Debug.Log ("ItemCount is 4");
			//  itemCounter.text = itemCount2 + "/4";
			Debug.Log ("itemCount2 " + itemCount2);
		}
	}
	/// <summary>
	/// Adds 1 to itemCount and makes item uninteractable. 
	/// When item count = 4 changes room.
	/// </summary>
	/// <param name="item">Item.</param>
	public void AddCount (Button item)
	{
		Debug.Log ("itemCount" + itemCount);
		if (itemCount < 5) {
			itemCount += 1;
		}
		item.interactable = false;
		// GameObject.Destroy(this.gameObject);
		if (itemCount == 4) {
			changeRoom ();
           // itemCount = 0;
		}
	}

    public void AddCount2(Button item)
    {
        Debug.Log("itemCount" + itemCount2);
        if (itemCount2 < 5)
        {
            itemCount2 += 1;
        }
        if (itemCount2 == 4)
        {
            item.interactable = false;
            Camera.main.transform.position = new Vector3(0, -60, -10);
           // movement.changeFinal();
            if (npcPanel4Object.activeSelf)
            {
                npcPanel4Object.SetActive(false);
            }
            if (npcPanel3Object.activeSelf)
            {
                npcPanel3Object.SetActive(false);
            }
            DisableCanvas();
        }
    }

    /*
	/// <summary>
	/// adds 1 to room1 itemcount and turns off button interactablility
	/// changes room if itemcount reacheas 4
	/// </summary>
	/// <param name="item">Item.</param>
    public void DestroyItem(Button item)
    {
        Debug.Log(item + "itemCount" + itemCount);
        if (itemCount < 5)
        {
            itemCount += 1;
        }
        item.interactable = false;
        // GameObject.Destroy(this.gameObject);
        if (itemCount == 4)
        {
            changeRoom();
        }
    }
    */
    /// <summary>
    /// destroys the sprite attatched to the button. Adds one to itemCount.
    /// If itemCount is 4, changes room.
    /// </summary>
    /// <param name="item"></param>
    public void DestroyItem3 (SpriteRenderer item)
	{
        /*
		if (itemCount2 < 5) {
			itemCount2 += 1;
		}*/
		SpriteRenderer.Destroy (item);
		/*if (itemCount2 == 4) {
			Camera.main.transform.position = new Vector3 (0, -60, -10);
			movement.changeFinal ();
			if (npcPanel4Object.activeSelf) {
				npcPanel4Object.SetActive (false);
			}
			if (npcPanel3Object.activeSelf) {
				npcPanel3Object.SetActive (false);
			}
			DisableCanvas ();*
		}*/
	}
	/*
	/// <summary>
	/// adds 1 to room2 itemcount and turns off button interactability.
	/// </summary>
	/// <param name="item">Item.</param>
    public void DestroyItem2(Button item)
    {
        if (itemCount2 < 5)
        {
            itemCount2 += 1;
        }
        item.interactable = false;


        if (itemCount2 == 4)
        {
            Camera.main.transform.position = new Vector3(0, -60, -10);
            movement.changeFinal();
            if (npcPanel4Object.activeSelf)
            {
                npcPanel4Object.SetActive(false);
            }
            if (npcPanel3Object.activeSelf)
            {
                npcPanel3Object.SetActive(false);
            }
            DisableCanvas();
        }
    }
    */
	/// <summary>
	/// Disables the canvas.
	/// </summary>
	void DisableCanvas ()
	{
		canvas.GetComponent<Canvas> ().enabled = false;
	}
	/// <summary>
	/// Enables the canvas.
	/// </summary>
	public void EnableCanvas ()
	{
		canvas.GetComponent<Canvas> ().enabled = true;
	}

}