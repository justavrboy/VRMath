using UnityEngine;
using System.Collections;

public class VRMPoint : MonoBehaviour {
    [SerializeField]
    private Renderer meshRenderer;
    [SerializeField]
    private LineRenderer lineRenderer;

    private GameObject controller;

    public GameObject LinkedController {
        set { controller = value; }
    }

    private bool isPlaced = false;

    public Color startColor;
    public Color endColor;

    public void PlacePoint() {
        lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);

        isPlaced = true;
    }

    public void SetLinePos(Vector3 pos) {
        lineRenderer.SetPosition(1, pos);
    }

    public void SetStartColor(Color color) {
        startColor = color;
        meshRenderer.material.SetColor("_Color", color);
        lineRenderer.SetColors(color, color);
    }

    public void SetEndColor(Color color) {
        endColor = color;
        lineRenderer.SetColors(startColor, endColor);
    }



    // TODO: move this somewhere in a util class
    public static Color RandColor() {
        return new Color(Random.Range(0.0f, 0.8f),
                         Random.Range(0.0f, 0.8f),
                         Random.Range(0.0f, 0.8f),
                         0.65f);
    }
}
