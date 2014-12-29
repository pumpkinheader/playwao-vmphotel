using UnityEngine;
using System.Collections;

public class option : MonoBehaviour {
		private bool touchable= true;
		private GameObject gsm;
		private GameObject[] options = new GameObject[2];

		// Use this for initialization
		void Start () {
				gsm = GameObject.Find ("GameSceneManager");
				GameSceneManager.gmscript.option = this.gameObject;
				options [0] = GameObject.Find ("backtop");
				options [1] = GameObject.Find ("log");
		}
	
	// Update is called once per frame
	void Update () {
	
	}

		//あまり良くない実装。たかだか２つなのでsendmessageでなくこっちで管理しても良かったかも
		//追記 SendMessage は 関数のオーバーロードに対応していない 20141002
		void hide(int type){
				int i = 0;
				foreach(GameObject g in options)
				{
						i++;
						if(i==1)
								g.SendMessage ("hide", type);
						if (i == 2)
								g.SendMessage ("hidenodeq");

				}
		}
		void visible(int type){
				foreach(GameObject g in options)
				{
						g.SendMessage ("visible");
				}
				deq ();
		}
		void goalcal(int type){
				deq ();
		}


		void touched(){
				if (touchable)
						gsm.SendMessage ("touch", name);
				else
						Debug.Log ("option Disabled");
		}
		void disable(int type){
				touchable = false;
				deq ();
		}
		void enable(int type){
				touchable = true;
				deq ();
		}

		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
}
