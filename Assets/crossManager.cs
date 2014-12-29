using UnityEngine;
using System.Collections;

public class crossManager : MonoBehaviour {

		GameObject cross_s;
		SpriteRenderer sr_s;


		void Awake(){
				cross_s = new GameObject ();
				cross_s = GameObject.Find ("cross_s");
		}
	// Use this for initialization
	void Start () {
				sr_s = new SpriteRenderer ();
				GameSceneManager.gmscript.cross = this.gameObject;
				sr_s = cross_s.GetComponent<SpriteRenderer> ();
				sr_s.enabled = false;
				iTween.ColorTo (cross_s,iTween.Hash("a",0f,"time",0.01f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void visible(int type){
				sr_s.enabled = true;
				if(type == 1){
						iTween.ColorTo(cross_s,iTween.Hash("a",1f,"delay",0.4f,"easetype","easeincirc","time",2.6f,"oncompletetarget",gameObject,"oncomplete","deq"));
				}else{
						iTween.ColorTo(cross_s,iTween.Hash("a",1f,"delay",0.4f,"easetype","easeincirc","time",2.6f));
						deq ();
				}
		}
		void hide(int type){
				if (type == 1) {
						iTween.ColorTo (cross_s, iTween.Hash ("a", 0f, "time", 1.8f,"oncompletetarget",gameObject,"oncomplete","disable","oncompleteparams",type));
				} else {
						deq ();
						iTween.ColorTo (cross_s, iTween.Hash ("a", 0f, "time", 1.8f,"oncompletetarget",gameObject,"oncomplete","disable","oncompleteparams",type));
				}		
		}
		void disable(int type){
				sr_s.enabled = false;
				if(type==1)deq ();
		}
		void pingpong(int type){
				iTween.ColorTo (cross_s, iTween.Hash ("a", 0f, "time", 0.8f,"looptype",iTween.LoopType.pingPong));
				deq ();
		}
		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
}
