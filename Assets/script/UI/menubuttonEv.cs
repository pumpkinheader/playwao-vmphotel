using UnityEngine;
using System.Collections;

public class menubuttonEv : MonoBehaviour {

		private bool touchable= true;
		private GameObject gsm;
	// Use this for initialization
	void Start () {
				gsm = GameObject.Find ("GameSceneManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		void touched(){
				if (touchable)
						gsm.SendMessage ("touch",name);
		}
}
