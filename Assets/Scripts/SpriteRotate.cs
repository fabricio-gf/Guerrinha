using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotate : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		transform.forward = new Vector3 (Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);
    }
}
