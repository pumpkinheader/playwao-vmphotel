using UnityEngine;
using System.Collections;

public class backfogMoveAssist : MonoBehaviour {

		GameObject[] fogs = new GameObject[2];
		private float pos_0,pos_1;
	// Use this for initialization
	void Start () {
				fogs [0] = this.gameObject.transform.GetChild (0).gameObject;
				fogs [1] = this.gameObject.transform.GetChild (1).gameObject;
				pos_0 = fogs [0].transform.position.x;
				pos_1 = fogs [1].transform.position.x;
	}
	
		float time = 0f;
	// Update is called once per frame
	void Update () {
				time++;
				if (time > 500) {
						float pos = fogs [1].transform.position.x;
						time = 0;
						if ((int)pos == pos_0) {
								fogs [0].transform.position = new Vector3 (pos_1,fogs [0].transform.position.y,fogs [0].transform.position.z);
								GameObject tmp = fogs[1];
								fogs[1] = fogs[0];
								fogs[0] = tmp;
						}
				}
	}

		void changeLayer(int l){
				fogs [0].layer = l;
				fogs [1].layer = l;
		}
}
