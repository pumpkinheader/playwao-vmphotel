using UnityEngine;
using System.Collections;

public class Butnum : MonoBehaviour {
		public Sprite[] nums = new Sprite[12];
		private SpriteRenderer sr;
	// Use this for initialization
	void Start () {
				//GameSceneManager.gmscript.batnum = gameObject;
				sr = gameObject.GetComponent<SpriteRenderer> ();

	}
	// Update is called once per frame
	void Update () {
	
	}
		void init(int i){
				setnum (i);
		}

		void setnum(int i){
				if (i > 12||i < 1)
						sr.renderer.enabled = false; 
				else
						sr.sprite = nums [i-1];
		}
}
