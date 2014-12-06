using UnityEngine;
using System.Collections;

public class nowLoadingManager : SingletonMonoBehaviour<nowLoadingManager>  {
		private GameObject[] loads = new GameObject[3];
		GameObject gm;

		public void Awake()
		{
				if (this != Instance) {
						Destroy (this);
						return;
				}
				DontDestroyOnLoad (this.gameObject);
		}
	// Use this for initialization
	void Start () {
				loads[0] = GameObject.Find ("loadbg");
				loads[1] = GameObject.Find ("loadicon");
				loads[2] = GameObject.Find ("loadword");
				gm = GameObject.Find ("GameManager");
				//foreach(GameObject g in loads)DontDestroyOnLoad (g);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void visible(int type){
				foreach(GameObject obj in loads){obj.SendMessage ("visible");}
				deq ();
		}
		void hide(int type){
				//foreach(GameObject obj in loads){obj.SendMessage ("hide");}
				deq ();
		}
		void deq(){
				gm.SendMessage ("deq");
		}


}
