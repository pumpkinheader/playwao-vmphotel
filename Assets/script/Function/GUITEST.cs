using UnityEngine;
using System.Collections;

public class GUITEST : MonoBehaviour {
	private string textFieldString = "text field";
	private string textAreaString = "text Area";
		private string text;
	public bool ongui = false;
	// Use this for initialization
	void Start () {
				//TouchManager touch;
				text = this.gameObject.renderer.bounds.ToString();
	}
	
	// Update is called once per frame
	void Update () {
				textAreaString = text;
	}

	void getSize(){
				textAreaString = Screen.width + "&" + Screen.height;
	}

	void OnGUI(){
		if (ongui) {
						//getSize ();
						textFieldString = GUI.TextField (new Rect ((float)(Screen.width / 2 - 50), 125, 100, 30), textFieldString+TouchManager.tests);
			textAreaString = GUI.TextArea (new Rect (10, 10, 100, 100), textAreaString);
		}
	}
}
