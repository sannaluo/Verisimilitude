using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EventButtonDetails
{
    public string buttonTitle;
    public Sprite buttonBackground;
    public UnityAction action;
}

public class ModalPanelDetails
{
    public string title;
    public string npc;
    public Sprite panelBackgroundImage;
    public EventButtonDetails button1Details;
    public EventButtonDetails button2Details;
    public EventButtonDetails button3Details;
}

public class ModalPanel : MonoBehaviour {

    public Text npc;
    public Button button1;
    public Button button2;
    public Button button3;
    public GameObject modalPanelObject;
    private Movement movement;
    public Text button1Text;
    public Text button2Text;
    public Text button3Text;

    private bool active=false;

    private static ModalPanel modalPanel;

    public static ModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
            {
                Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your Scene");
            }
            }
            return modalPanel;
        
    }
    void Awake()
    {
        movement = Movement.Instance();
    }
    /*
        public void Choice(string npc, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent)
        {
           modalPanelObject.SetActive(true);
           button1.onClick.RemoveAllListeners();
            button1.onClick.AddListener(yesEvent);
            button1.onClick.AddListener(ClosePanel);
           modalPanelObject.SetActive(true);
            button2.onClick.RemoveAllListeners();
            button2.onClick.AddListener(noEvent);
            button2.onClick.AddListener(ClosePanel);

            modalPanelObject.SetActive(true);
            button3.onClick.RemoveAllListeners();
            button3.onClick.AddListener(cancelEvent);
            button3.onClick.AddListener(ClosePanel);

            this.npc.text = npc;
            button1.gameObject.SetActive(true);
            button2.gameObject.SetActive(true);
            button3.gameObject.SetActive(true);
        }
        */

    public void NewChoice(ModalPanelDetails details)
    {
        // movement.StopMoving();
        
            modalPanelObject.SetActive(true);

            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);
            button3.gameObject.SetActive(false);
            this.npc.text = details.npc;
            //  StopTime();

            button1.onClick.RemoveAllListeners();
            button1.onClick.AddListener(details.button1Details.action);
            button1.onClick.AddListener(ClosePanel);
            //  button1.onClick.AddListener(StartTime);
            button1Text.text = details.button1Details.buttonTitle;
            button1.gameObject.SetActive(true);

            if (details.button2Details != null)
            {
                button2.onClick.RemoveAllListeners();
                button2.onClick.AddListener(details.button2Details.action);
                button2.onClick.AddListener(ClosePanel);
                //  button2.onClick.AddListener(StartTime);
                button2Text.text = details.button2Details.buttonTitle;
                button2.gameObject.SetActive(true);
            }
            if (details.button3Details != null)
            {
                button3.onClick.RemoveAllListeners();
                button3.onClick.AddListener(details.button3Details.action);
                button3.onClick.AddListener(ClosePanel);
                //  button3.onClick.AddListener(StartTime);
                button3Text.text = details.button3Details.buttonTitle;
                button3.gameObject.SetActive(true);
            }
        }
   // }
    /*
    //cancel
    public void Choice(string npc, UnityAction cancelEvent)
    {
        modalPanelObject.SetActive(true);

        modalPanelObject.SetActive(true);
        button3.onClick.RemoveAllListeners();
        button3.onClick.AddListener(cancelEvent);
        button3.onClick.AddListener(ClosePanel);

        this.npc.text = npc;
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(true);
    }
    */
        void ClosePanel()
    {
       
        modalPanelObject.SetActive(false);
        //   StartTime();
        active = false;
    }

    void StopTime()
    {
        Time.timeScale = 0f;
    }

    void StartTime()
    {
        Time.timeScale = 1f;
    }


  public bool Active()
    {
        return active;
    }
}
