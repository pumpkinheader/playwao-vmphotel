using UnityEngine;
using System.Collections;

public class testtenmetsu : MonoBehaviour {

	// Use this for initialization
	void Start () {
				iTween.ColorTo (gameObject,iTween.Hash("a",0f,"time",1.2f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
