using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	public Texture2D fadeTexture;		//Hinh anh fade
	public float fadeSpeed = 1.0f;		//Toc do fade

	private int drawDepth = -1000;		//Bien lamf cho fade duoc thuc hien sau cung
	private float alpha = 1.0f;		//Do mo cua anh, 0 la trong suot
	private int fadeDirection = -1;		//Huong fade

	private void OnGUI()
	{
		alpha += fadeDirection * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height, fadeTexture));
	}

	public float BeginFade(int direction)
	{
		fadeDirection = direction;
		return (fadeSpeed);
	}
	private void OnLevelWasLoaded ()
	{
		BeginFade (-1);
	}
}
