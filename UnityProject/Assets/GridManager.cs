using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {
    [SerializeField]
    private GameObject VRController;
    [SerializeField]
    private GameObject GuidanceGrid;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GuidanceGrid.transform.position = FloorVector(VRController.transform.position);
	}

    private Vector3 FloorVector(Vector3 originalPos) {
        float x = (Mathf.Floor(originalPos.x));
        float y = (Mathf.Floor(originalPos.y));
        float z = (Mathf.Floor(originalPos.z));
        return new Vector3(x, y, z);
    }
}
