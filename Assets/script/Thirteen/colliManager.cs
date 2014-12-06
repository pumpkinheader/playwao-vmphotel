using UnityEngine;
using System.Collections;

public class colliManager : MonoBehaviour {

		private GameObject[] collis = new GameObject[7];

	// Use this for initialization
	void Start () {
				int i = 0;
				GameSceneManager.gmscript.colli = this.gameObject;
				collis [i] = GameObject.Find ("HIKIDASHI");i++;
				collis [i] = GameObject.Find ("DOZO");i++;
				collis [i] = GameObject.Find ("SHELF");i++;
				collis [i] = GameObject.Find ("ILL");i++;
				collis [i] = GameObject.Find ("TABLE");i++;
				collis [i] = GameObject.Find ("TSUBO");i++;
				collis [i] = GameObject.Find ("TOKEI");i++;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void visible(int type){
				foreach (GameObject g in collis)
						g.SendMessage ("visible");
				deq ();
		}
		void hide(int type){
				foreach (GameObject g in collis)
						g.SendMessage ("hide");
				deq ();
		}


		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
}
