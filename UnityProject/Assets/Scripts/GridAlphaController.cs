using UnityEngine;
using System.Collections;

public class GridAlphaController : MonoBehaviour {
    [SerializeField]
    private Renderer xyRenderer;
    [SerializeField]
    private Renderer xzRenderer;
    [SerializeField]
    private Renderer yzRenderer;

    public void SetGridAlpha(float alpha) {
        xyRenderer.material.SetFloat("_Alpha", alpha);
        xzRenderer.material.SetFloat("_Alpha", alpha);
        yzRenderer.material.SetFloat("_Alpha", alpha);
    }
}
