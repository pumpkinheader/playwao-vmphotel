using UnityEngine;
using System.Collections;

public class crossManager : MonoBehaviour {

		GameObject cross_s = new GameObject();
		SpriteRenderer sr_s= new SpriteRenderer();



	// Use this for initialization
	void Start () {
				GameSceneManager.gmscript.cross = this.gameObject;
				cross_s = GameObject.Find ("cross_r");
				sr_s = cross_s.GetComponent<SpriteRenderer> ();
				sr_s.enabled = false;
				iTween.ColorTo (cross_s,iTween.Hash("a",0f,"time",0.01f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void visible(int type){
				sr_s.enabled = true;
				//iTween.ColorTo (cross_r,iTween.Hash("a",0.9f,"time",0.6f,"easetype",iTween.EaseType.easeOutExpo));
				//iTween.ColorTo (cross_c,iTween.Hash("a",0.9f,"time",0.6f,"easetype",iTween.EaseType.easeOutExpo));
				//iTween.ColorTo(cross_c,iTween.Hash("a",1f,"delay",0.4f,"looptype","pingpong","easetype","easeincirc","time",0.8f));
				//iTween.ColorTo(cross_r,iTween.Hash("a",1f,"delay",0.4f,"looptype","pingpong","easetype","easeincirc","time",0.8f));
				iTween.ColorTo(cross_s,iTween.Hash("a",1f,"delay",0.4f,"easetype","easeincirc","time",2.6f,"oncompletetarget",gameObject,"oncomplete","hide"));
				deq ();
		}
		void hide(){
				sr_s.enabled = false;
				iTween.ColorTo (cross_s,iTween.Hash("a",0f,"time",0.01f));
				//deq ();
		}

		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
}
