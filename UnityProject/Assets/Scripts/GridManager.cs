using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {
    [SerializeField]
    private GameObject vrController;
    [SerializeField]
    private GameObject guidanceGrid;
    [SerializeField]
    private GameObject xAxisLabeler;
    [SerializeField]
    private GameObject yAxisLabeler;
    [SerializeField]
    private GameObject zAxisLabeler;

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
        transform.position = FloorVector(vrController.transform.position);

        // Set alpha of all grids, while keeping track of the one closest to the hand
        GridAlphaController closestGrid = gridControllers[0];
        float shortestDistance = float.MaxValue;
        foreach (GridAlphaController gridController in gridControllers) {
            float distance = Vector3.Distance(gridController.transform.position,
                    vrController.transform.position);
            gridController.SetGridAlpha(1.6f - distance);

            if (distance > shortestDistance) {
                closestGrid = gridController;
                shortestDistance = distance;
            }
        }

        // Label the grid closest to the hand
        xAxisLabeler.transform.position = closestGrid.transform.position;
        yAxisLabeler.transform.position = closestGrid.transform.position;
        zAxisLabeler.transform.position = closestGrid.transform.position;

        foreach (Transform child in xAxisLabeler.transform) {
            child.GetComponent<TextMesh>().text = child.transform.position.x.ToString("0.0");
        }

        foreach (Transform child in yAxisLabeler.transform) {
            child.GetComponent<TextMesh>().text = child.transform.position.y.ToString("0.0");
        }

        foreach (Transform child in zAxisLabeler.transform) {
            child.GetComponent<TextMesh>().text = child.transform.position.z.ToString("0.0");
        }
	}

    private Vector3 FloorVector(Vector3 originalPos) {
        float x = (Mathf.Floor(originalPos.x));
        float y = (Mathf.Floor(originalPos.y));
        float z = (Mathf.Floor(originalPos.z));
        return new Vector3(x, y, z);
    }
}
