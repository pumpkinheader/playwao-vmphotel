using UnityEngine;
using System.Collections;

public class titleManager : MonoBehaviour {
		public static GameObject gm;
		public static GameManager gmscript;
		public static bool continuable;
	// Use this for initialization
	void Start () {
				continuable = false;
				gm = GameObject.Find ("GameManager");
				gmscript = gm.GetComponent<GameManager> ();
				gmscript.startlogo = GameObject.Find ("start");
				gmscript.continuelogo = GameObject.Find ("continue");
				gmscript.zklogo = GameObject.Find ("zerokit");
				gmscript.pwlogo = GameObject.Find ("playwao");
				gmscript.titlelogo = GameObject.Find ("logo");
				gmscript.intr = GameObject.Find ("intro");
				gmscript.titleManager = this.gameObject;
				load ();
	}
	
	// Update is called once per frame
	void Update () {
	}


		void load(){
				int floornum;
				floornum = PlayerPrefs.GetInt ("floornum",-99);
				if (floornum != 99)
						continuable = true;
		}

		void toGame(){
				Debug.Log ("toGameSene");
				Application.LoadLevel ("GameScene");
		}
}
