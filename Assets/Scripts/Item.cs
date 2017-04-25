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
    private Movement movement;
    private NPCPanel2 npcPanel2;
    private NPCPanel3 npcPanel3;
    private Canvas canvas;
    //bool level = false;

    public GameObject npcPanel3Object;
    public GameObject npcPanel2Object;
    public GameObject npcPanel4Object;

    public Text itemCounter;
    private static int itemCount;
    private static int itemCount2;
    private int count;
    // Use this for initialization
    void Start()
    {
        //  itemCount = 0;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();


        flowerButton = GameObject.Find("FlowerButton").GetComponent<Button>();
        paintingButton = GameObject.Find("PaintingButton").GetComponent<Button>();
        toySoldierButton = GameObject.Find("ToySoldierButton").GetComponent<Button>();
        abcButton = GameObject.Find("ABCButton").GetComponent<Button>();
        itemCounter = GameObject.Find("ItemCounter").GetComponent<Text>();

        flowerButton.onClick.AddListener(() => DestroyItem(flowerButton));
        paintingButton.onClick.AddListener(() => DestroyItem(paintingButton));
        toySoldierButton.onClick.AddListener(() => DestroyItem(toySoldierButton));
        abcButton.onClick.AddListener(() => DestroyItem(abcButton));

        flowerButton2 = GameObject.Find("FlowerButton2").GetComponent<Button>();
        paintingButton2 = GameObject.Find("PaintingButton2").GetComponent<Button>();
        toySoldierButton2 = GameObject.Find("ToySoldierButton2").GetComponent<Button>();
        abcButton2 = GameObject.Find("ABCButton2").GetComponent<Button>();


        flowerButton2.onClick.AddListener(() => DestroyItem2(flowerButton2));
        paintingButton2.onClick.AddListener(() => DestroyItem2(paintingButton2));
        toySoldierButton2.onClick.AddListener(() => DestroyItem2(toySoldierButton2));
        abcButton2.onClick.AddListener(() => DestroyItem2(abcButton2));

    }
    void Awake()
    {
        movement = Movement.Instance();
       npcPanel2 = NPCPanel2.Instance();
        npcPanel3 = NPCPanel3.Instance();
    }

    // Update is called once per frame




    void Update()
    {
        if (itemCount != 4)
        {
            count = itemCount;
        }
        if (itemCount == 4)
        {
            count = itemCount2;
        }
        itemCounter.text = count + "/4";

    }
	/// <summary>
	/// moves camera and player model to next room
	/// disables npcPanel2
	/// activates npcPanel3
	/// </summary>
    void changeRoom()
    {
        if (itemCount == 4)
        {
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
            Camera.main.transform.position = new Vector3(0, -30, -10);
            movement.changeRoom2();
            npcPanel2Object.SetActive(false);
            npcPanel3Object.SetActive(true);
            //  itemCount = 0;
            //  level = true;
            Debug.Log("ItemCount is 4");
            //  itemCounter.text = itemCount2 + "/4";
            Debug.Log("itemCount2 " + itemCount2);
        }
    }
        
    

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
	/// <summary>
	/// Disables the canvas.
	/// </summary>
    void DisableCanvas()
    {
        canvas.GetComponent<Canvas>().enabled = false;
    }
}
