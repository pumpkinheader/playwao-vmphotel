using UnityEngine;
using System.Collections;

public class keys : MonoBehaviour {


		private GameObject gsm;
	// Use this for initialization
	void Start () {
				gsm = GameObject.Find ("GameSceneManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void touched(){
				gsm.SendMessage ("touchth",name);
		}
}
