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
	public bool start = true;
	public bool start1 = true;
	private bool active=false;

	private static ModalPanel modalPanel;

	/// <summary>
	/// creates a ModalPanel instance if there is none.
	/// </summary>
	public static ModalPanel Instance()
	{
		if (!modalPanel)
		{
			modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
			if (!modalPanel)
			{
				Debug.LogWarning("There needs to be one active ModalPanel script on a GameObject in your Scene");
			}
		}
		return modalPanel;

	}
	void Awake()
	{
		movement = Movement.Instance();
	}


	/// <summary>
	/// creates a modal panel interface with up to 3 different buttons
	/// </summary>
	/// <param name="details">Details.</param>
	public void NewChoice(ModalPanelDetails details)
	{
		// movement.StopMoving();

		modalPanelObject.SetActive(true);

		button1.gameObject.SetActive(false);
		button2.gameObject.SetActive(false);
		button3.gameObject.SetActive(false);
		this.npc.text = details.npc;


		button1.onClick.RemoveAllListeners();
		button1.onClick.AddListener(details.button1Details.action);

		button1Text.text = details.button1Details.buttonTitle;
		button1.gameObject.SetActive (true);
		button1.onClick.AddListener(ClosePanel);

		



		if (details.button2Details != null)
		{
			button2.onClick.RemoveAllListeners();
			button2.onClick.AddListener(details.button2Details.action);

			button2.onClick.AddListener(ClosePanel);

			button2Text.text = details.button2Details.buttonTitle;
			button2.gameObject.SetActive(true);
		}
		if (details.button3Details != null)
		{
			button3.onClick.RemoveAllListeners();
			button3.onClick.AddListener(details.button3Details.action);
			if (start) {
			button3.onClick.AddListener(ClosePanel);
				start = false;
			}

			button3Text.text = details.button3Details.buttonTitle;
			button3.gameObject.SetActive(true);
		}
	}

	/// <summary>
	/// Closes the modalpanel.
	/// </summary>
	void ClosePanel()
	{

		modalPanelObject.SetActive(false);
		//   StartTime();
		active = false;
	}



	/// <summary>
	/// returns active variable value.
	/// </summary>
	public bool Active()
	{
		return active;
	}
}
