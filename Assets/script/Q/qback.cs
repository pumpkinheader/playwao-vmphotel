using UnityEngine;
using System.Collections;

public class qback : MonoBehaviour {

	// Use this for initialization
	void Start () {
				iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0f, "time", 0.01f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}


		void visible(int type){
				if (type==1)
						iTween.ColorTo (this.gameObject, iTween.Hash ("a", 1.0f, "time", 0.8f, "oncompletetarget", this.gameObject, "oncomplete", "next"));
				else
						next ();
						iTween.ColorTo (this.gameObject,iTween.Hash("a",1.0f,"time",0.8f));

		}
		void hide(int type){
				if (type==1)
						iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0f, "time", 0.8f, "oncompletetarget", this.gameObject, "oncomplete", "next"));
				else
						next ();
				iTween.ColorTo (this.gameObject,iTween.Hash("a",0f,"time",0.8f));
		}

		void next(){
				GameSceneManager.gm.SendMessage ("deq");
		}
}
