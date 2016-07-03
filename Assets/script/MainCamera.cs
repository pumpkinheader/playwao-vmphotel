using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	
		private Camera c;
	// Use this for initialization
	void Start () {
				GameSceneManager.gmscript.MainCamera = this.gameObject;
				c = gameObject.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


		void th(int type){
				iTween.ValueTo (gameObject,iTween.Hash("from",1f,"to",0f,"time",4.2f,"onupdate","colorupdate"/*,"oncomplete","deq","oncompletetarget",gameObject*/));
				deq ();
		}
		void th2(int type){
				iTween.ValueTo (gameObject,iTween.Hash("from",0f,"to",1f,"time",4.2f,"onupdate","colorupdate"/*,"oncomplete","deq","oncompletetarget",gameObject*/));
				deq ();
		}
		void colorupdate(float f){
				c.backgroundColor = new Color (f,f,f);
		}
		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
}
