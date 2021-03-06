﻿using UnityEngine;
using System.Collections;
using System;

public class elepanebutton : MonoBehaviour {

		public Sprite[] buttons = new Sprite[2];
		private SpriteRenderer bs;
		private BoxCollider2D bb;
		private int num = 0;
		public static bool[] onbutton = new bool[14];
		private int iam;
	// Use this for initialization
	void Start () {
				iam = Convert.ToInt32 (name);
				onbutton [iam] = false;
				bs = gameObject.GetComponent<SpriteRenderer> ();
				bb = gameObject.GetComponent<BoxCollider2D>();
				bs.sprite = buttons [0];
				bs.GetComponent<Renderer>().enabled = false;
				bb.enabled = false;
				iTween.ColorTo (gameObject,iTween.Hash("a", 0.0f, "easetype", "easeincirc", "time", 0.01f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void touched(){
				num++;
				num = num % 2;
				bs.sprite = buttons [num];
				if (num == 1)
						onbutton [iam] = true;
				else if (num == 0)
						onbutton [iam] = false;
				if (!ElepaneManager.crosson) {
						if (onbutton [3] &&
						 onbutton [11] &&
						 onbutton [5] &&
						 onbutton [6] &&
						 onbutton [7] &&
						 onbutton [8]) {
								if (onbutton [1] || onbutton [2] || onbutton [4] || onbutton [9] || onbutton [10] || onbutton [12]) {

								} else {

										ElepaneManager.crosson = true;
										GameSceneManager.gm.SendMessage ("crossEv");
								}
						}
				}
		}

		void visible(){
//				Debug.Log ("button visible");
				bs.GetComponent<Renderer>().enabled = true;
				bb.enabled = true;
				iTween.ColorTo (gameObject,iTween.Hash("a", 1.0f, "easetype", "easeincirc", "time", 1.4f));
		}
		void hide(){
				bs.GetComponent<Renderer>().enabled = false;
				bb.enabled = false;
				iTween.ColorTo (gameObject,iTween.Hash("a", 0.0f, "easetype", "easeincirc", "time", 1.0f));
		}
}