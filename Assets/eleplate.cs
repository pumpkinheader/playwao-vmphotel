﻿using UnityEngine;
using System.Collections;

public class eleplate : MonoBehaviour {


		private SpriteRenderer bs;
	// Use this for initialization
	void Start () {
				bs = gameObject.GetComponent<SpriteRenderer> ();
				bs.GetComponent<Renderer>().enabled = false;
				iTween.ColorTo (gameObject,iTween.Hash("a", 0.0f, "easetype", "easeincirc", "time", 0.01f));

	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void visible(){
				bs.GetComponent<Renderer>().enabled = true;
				iTween.ColorTo (gameObject,iTween.Hash("a", 1.0f, "easetype", "easeincirc", "time", 1.4f));
		}
		void hide(){
				bs.GetComponent<Renderer>().enabled = false;
				iTween.ColorTo (gameObject,iTween.Hash("a", 0.0f, "easetype", "easeincirc", "time", 1.0f));
		}
}
