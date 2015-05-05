using UnityEngine;
using System.Collections;

public class elevenObj : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


		void renderfalse(){
				this.gameObject.GetComponent<Renderer>().enabled = false;
		}

		void touched(){}
}
