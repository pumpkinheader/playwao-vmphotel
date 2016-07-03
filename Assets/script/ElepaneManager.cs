using UnityEngine;
using System.Collections;

public class ElepaneManager : MonoBehaviour {


		public GameObject[] buttons = new GameObject[15];
		public static bool crosson = false;
	// Use this for initialization
	void Start () {
				GameSceneManager.gmscript.elepanel = this.gameObject;

				for (int i = 0; i < buttons.Length; i++) {
						buttons[i] = GameObject.Find (i.ToString());
				}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void visible(int type){
				foreach (GameObject go in buttons)
						go.SendMessage ("visible");
				deq ();
		}

		void hide(int type){
				foreach (GameObject go in buttons)
						go.SendMessage ("hide");
				deq ();
		}
		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}

		void checkbutton(int type){
				if ( crosson
//						elepanebutton.onbutton [3] &&
//				    elepanebutton.onbutton [11] &&
//				    elepanebutton.onbutton [5] &&
//						elepanebutton.onbutton [6] &&
//						elepanebutton.onbutton [7] &&
//						elepanebutton.onbutton [8]
				) {
								if (elepanebutton.onbutton [0])
										GameSceneManager.gelepanel = GameSceneManager.endElevator.TOUNDERGROUND;
								else
										GameSceneManager.gelepanel = GameSceneManager.endElevator.TOONE;

				} else
						GameSceneManager.gelepanel = GameSceneManager.endElevator.NOCROSS;
				deq ();
		}
}

