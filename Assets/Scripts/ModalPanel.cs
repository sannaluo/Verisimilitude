using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalPanel : MonoBehaviour {

    public Text npc;
    public Button yesButton;
    public Button noButton;
    public Button cancelButton;
    public GameObject modalPanelObject;

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

    public void Choice(string npc, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent)
    {
        yesButton.onClick.RemoveAllListeners();
    }

}
