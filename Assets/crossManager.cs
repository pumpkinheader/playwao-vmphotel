using UnityEngine;
using System.Collections;

public class crossManager : MonoBehaviour {

		GameObject cross_r = new GameObject();
		GameObject cross_c = new GameObject();
		SpriteRenderer sr_r= new SpriteRenderer();
		SpriteRenderer sr_c = new SpriteRenderer();


	// Use this for initialization
	void Start () {
				GameSceneManager.gmscript.cross = this.gameObject;
				cross_r = GameObject.Find ("cross_r");
				cross_c = GameObject.Find ("cross_c");
				sr_r = cross_r.GetComponent<SpriteRenderer> ();
				sr_c = cross_c.GetComponent<SpriteRenderer> ();
				sr_c.enabled = false;
				sr_r.enabled = false;
				iTween.ColorTo (cross_r,iTween.Hash("a",0f,"time",0.01f));
				iTween.ColorTo (cross_c,iTween.Hash("a",0f,"time",0.01f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void visible(int type){
				sr_c.enabled = true;
				sr_r.enabled = true;
				//iTween.ColorTo (cross_r,iTween.Hash("a",0.9f,"time",0.6f,"easetype",iTween.EaseType.easeOutExpo));
				//iTween.ColorTo (cross_c,iTween.Hash("a",0.9f,"time",0.6f,"easetype",iTween.EaseType.easeOutExpo));
				//iTween.ColorTo(cross_c,iTween.Hash("a",1f,"delay",0.4f,"looptype","pingpong","easetype","easeincirc","time",0.8f));
				//iTween.ColorTo(cross_r,iTween.Hash("a",1f,"delay",0.4f,"looptype","pingpong","easetype","easeincirc","time",0.8f));
				iTween.ColorTo(cross_c,iTween.Hash("a",1f,"delay",0.4f,"easetype","easeincirc","time",2.6f,"oncompletetarget",gameObject,"oncomplete","hide"));
				iTween.ColorTo(cross_r,iTween.Hash("a",1f,"delay",0.4f,"easetype","easeincirc","time",2.6f,"oncompletetarget",gameObject,"oncomplete","hide"));
				deq ();
		}
		void hide(){
				sr_c.enabled = false;
				sr_r.enabled = false;
				iTween.ColorTo (cross_r,iTween.Hash("a",0f,"time",0.01f));
				iTween.ColorTo (cross_c,iTween.Hash("a",0f,"time",0.01f));
				//deq ();
		}

		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
}
