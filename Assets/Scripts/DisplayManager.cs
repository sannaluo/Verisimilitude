using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{

    public Text displayText;
    public float displayTime;
    public float fadeTime;

    private IEnumerator fadeAlpha;

    private static DisplayManager displayManager;

	/// <summary>
	/// Creates a DisplayManager instance if there is none
	/// </summary>
    public static DisplayManager Instance()
    {
        if (!displayManager)
        {
            displayManager = FindObjectOfType(typeof(DisplayManager)) as DisplayManager;
        }
        if (!displayManager)
        {
            Debug.LogWarning("There needs to be one active display manager script on a game object in your scene");

        }
        return displayManager;
    }

	/// <summary>
	/// displays a message
	/// </summary>
	/// <param name="message">Message.</param>
    public void DisplayMessage(string message)
    {
        displayText.text = message;
        SetAlpha();
    }

	/// <summary>
	/// Sets the alpha.
	/// </summary>
    void SetAlpha()
    {
        if (fadeAlpha != null)
        {
            StopCoroutine(fadeAlpha);
        }
        fadeAlpha = FadeAlpha();
        StartCoroutine(fadeAlpha);
    }
	/// <summary>
	/// Fades the alpha.
	/// </summary>
	/// <returns>The alpha.</returns>
    IEnumerator FadeAlpha()
    {
        Color resetColor = displayText.color;
        resetColor.a = 1;
        displayText.color = resetColor;

        yield return new WaitForSeconds(displayTime);

        while (displayText.color.a > 0)
        {
            Color displayColor = displayText.color;
            displayColor.a -= Time.deltaTime / fadeTime;
            displayText.color = displayColor;
            yield return null;
        }
        yield return null;
    }
}