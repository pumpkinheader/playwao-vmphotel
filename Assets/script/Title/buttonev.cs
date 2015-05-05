using UnityEngine;
using System.Collections;

public class buttonev : MonoBehaviour {
	
		private GameObject gm;
		//private string thisname;
		private bool touchable;
	// Use this for initialization
	void Start () {
				touchable = true;
				name = this.gameObject.name;
				Debug.Log (name);
				if (name == "continue" && !titleManager.continuable) 
				{
						//Debug.Log ("in");
						touchable = false;
						Color c = this.gameObject.GetComponent<Renderer>().material.color;
						this.gameObject.GetComponent<Renderer>().material.color = new Color (c.r,c.g,c.b,0.4f);
				}
	}
	
	// Update is called once per frame
	void Update () {
				if (touchable) {
						switch (name) {
						case "continue":
								iTween.ColorTo(this.gameObject,iTween.Hash("a",0,"looptype","loop","easetype","easeincirc","time",1.6f));
								break;
						case "start":
								iTween.ColorTo(this.gameObject,iTween.Hash("a",0.2f,"looptype","pingpong","easetype","easeincirc","time",0.8f));
								break;
						}
				}
	
	}

		void move(int type){
				if (type == 1)
						iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0f, "easetype", "easeincirc", "time", 0.8f, "oncompletetarget", this.gameObject, "oncomplete", "deq"));
				else {
						deq ();
						iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0f, "easetype", "easeincirc", "time", 0.8f));
				}
		}
	void touched(){
				if(touchable)titleManager.gm.SendMessage (name+"Ev");
	}

		void deq(){
				this.gameObject.GetComponent<Renderer>().enabled = false;
				this.gameObject.GetComponent<Collider2D>().enabled = false;
				titleManager.gm.SendMessage ("deq");
		}
}
