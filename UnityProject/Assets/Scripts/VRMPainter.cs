using UnityEngine;
using System.Collections;
using VRTK;

public class VRMPainter : MonoBehaviour {

    public VRTK_ControllerEvents controller = null;

	// Use this for initialization
	void Start() {
	
	}

    protected void OnEnable() {
        controller.TriggerClicked += new ControllerInteractionEventHandler(CreatePoint);

    }

    protected void OnDisable() {
        controller.TriggerUnclicked -= new ControllerInteractionEventHandler(CreatePoint);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void CreatePoint(object sender, ControllerInteractionEventArgs e) {
        GameObject point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        point.transform.position = controller.transform.position;
        point.transform.localScale /= 4f;
    }
}
