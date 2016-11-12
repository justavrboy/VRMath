using UnityEngine;

public class FaceCamera : MonoBehaviour {
    private TextMesh textMesh;

	void Start() {
       textMesh = GetComponent<TextMesh>();
    }
	
	void Update() {
       textMesh.transform.LookAt(Camera.main.transform.position);
    }
}
