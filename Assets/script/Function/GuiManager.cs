using UnityEngine;
using System.Collections;

public class GuiManager : MonoBehaviour {
		public static string textFieldString = "PLEASE TAP";
		public bool ongui;
		public GUISkin cinema;
	// Use this for initialization
	void Start () {
				GameSceneManager.gmscript.gui = this.gameObject;
				cinema.textField.fontSize = Screen.height / 32;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


		void hide(int type){
				ongui = false;
				deq ();
		}
		void visible(int type){
				ongui = true;
				deq ();
		}
		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
				
		void OnGUI(){
				cinema.textField.fontSize = Screen.height / 32;
				GUI.skin = cinema;
				if (ongui) {
						textFieldString = GUI.TextField (new Rect ((float)(Screen.width / 2 - Screen.width/6), 3*Screen.height/4, Screen.width/3, Screen.height/24), textFieldString);
				}
		}
}
