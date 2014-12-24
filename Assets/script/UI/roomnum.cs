using UnityEngine;
using System.Collections;

public class roomnum : MonoBehaviour {


		SpriteRenderer roomnumrender;
		int now=0;
		public Sprite[] roomnums = new Sprite[12];
	// Use this for initialization
	void Start () {
				roomnumrender = this.gameObject.GetComponent<SpriteRenderer> ();
				roomnumrender.sprite = roomnums [0];
				roomnumrender.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void changenum(int floor){
				roomnumrender.enabled = true;
				Debug.Log ("ChangeRoomNum to " + floor);
				if (floor == 13) {
						roomnumrender.enabled = false;
						return;
				}
				if (now == floor)
						return;
				else {
						now = floor;
						if (roomnumrender == null)
								Debug.Log ("FIND THE NULL OBJECT");
						roomnumrender.sprite = roomnums [now-1];
				}
		}
}
