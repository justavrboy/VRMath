using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour {
    public TextMesh textMesh;

	// Use this for initialization
	void Start() {
       textMesh = GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update() {
       textMesh.transform.LookAt(Camera.main.transform.position);
       textMesh.text = "Text";
    }
}
