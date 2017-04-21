using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {
    
    private Button flowerButton;
    private Button paintingButton;
    private Button toySoldierButton;
    private Button abcButton;
    private Movement movement;
    
    public Text itemCounter;
    private static int itemCount;

    // Use this for initialization
    void Start () {
     //  itemCount = 0;
        
        flowerButton = GameObject.Find("FlowerButton").GetComponent<Button>();
        paintingButton = GameObject.Find("PaintingButton").GetComponent<Button>();
        toySoldierButton = GameObject.Find("ToySoldierButton").GetComponent<Button>();
        abcButton = GameObject.Find("ABCButton").GetComponent<Button>();
        itemCounter = GameObject.Find("ItemCounter").GetComponent<Text>();

        flowerButton.onClick.AddListener(() => DestroyItem(flowerButton)); 
        paintingButton.onClick.AddListener(() => DestroyItem(paintingButton));
        toySoldierButton.onClick.AddListener(() => DestroyItem(toySoldierButton));
        abcButton.onClick.AddListener(() => DestroyItem(abcButton));
        
    }
    void Awake()
    {
        movement = Movement.Instance();
    }
	
	// Update is called once per frame
	void Update () {
        itemCounter.text = itemCount + "/4";
        if (itemCount == 4)
        {
            Camera.main.transform.position = new Vector3(0,-32,-10);
            movement.changeRoom2();
        }
	}


    public void DestroyItem(Button item)
    {
        Debug.Log(item + "itemCount" + itemCount);
        if (itemCount < 5)
        {
            itemCount += 1;
        }
        item.interactable = false;
       // GameObject.Destroy(this.gameObject);
    }
}
