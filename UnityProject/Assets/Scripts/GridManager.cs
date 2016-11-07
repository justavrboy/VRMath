using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {
    [SerializeField]
    private GameObject VRController;
    [SerializeField]
    private GameObject GuidanceGrid;

    private GridAlphaController[] gridControllers;

    private const float SQRT_OF_TWO = 1.414213562371f;
    private const float SQRT_OF_THREE = 1.7320508076f;

	void Start() {
        gridControllers = new GridAlphaController[transform.childCount];

        // Cache references to the controllers
        int cacheIndex = 0;
        foreach (Transform child in transform) {
            gridControllers[cacheIndex++] = child.GetComponent<GridAlphaController>();
        }
	}
	
	void Update() {
        transform.position = FloorVector(VRController.transform.position);

        foreach (GridAlphaController gridController in gridControllers) {
            float distance = Vector3.Distance(gridController.transform.position,
                    VRController.transform.position);
            gridController.SetGridAlpha(1.6f - distance);
        }
	}

    private Vector3 FloorVector(Vector3 originalPos) {
        float x = (Mathf.Floor(originalPos.x));
        float y = (Mathf.Floor(originalPos.y));
        float z = (Mathf.Floor(originalPos.z));
        return new Vector3(x, y, z);
    }
}
