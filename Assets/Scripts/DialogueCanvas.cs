using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCanvas : MonoBehaviour {
    public GameObject dialogueCanvas;

    void Start() {
        
        
         dialogueCanvasActive();
    }

    public void dialogueCanvasActive()
    {
        dialogueCanvas.SetActive(true);
    }
}


