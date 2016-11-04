using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextFader : MonoBehaviour
{
    /* TextFader is only used on the realm notification at the beginning of the game.
     * text is removed from the screen after the given amount of read time.
     * 
     * Goal was to have the text actually fade out by changing the alpha value
     * over time in the color spectrum. Unfortunately I did not get that to work so this
     * will have to do.
     */
    public float readTime;
    public Text text;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Fading());
	}
	
	// Update is called once per frame
	IEnumerator Fading ()
    {
        yield return new WaitForSeconds(readTime);
        text.canvasRenderer.SetAlpha(0.0f);
	}
}
