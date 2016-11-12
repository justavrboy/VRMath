using UnityEngine;
using System.Collections;
using VRTK;

public class VRMPainter : MonoBehaviour {

    public VRTK_ControllerEvents controller = null;

    [SerializeField]
    private GameObject vrPointPrefab;

    private VRMPoint currPoint = null;
    private VRMPoint prevPoint = null;
    private Color prevPointColor;

	void Start() {
        prevPointColor = VRMPoint.RandColor();
        CreatePointCallback();
	}

    protected void OnEnable() {
        controller.TriggerClicked += new ControllerInteractionEventHandler(CreatePoint);
        controller.GripPressed += new ControllerInteractionEventHandler(BreakOffPoint);

    }

    protected void OnDisable() {
        controller.TriggerClicked -= new ControllerInteractionEventHandler(CreatePoint);
        controller.GripPressed -= new ControllerInteractionEventHandler(BreakOffPoint);
    }
	
	void Update () {
        if (prevPoint) {
            prevPoint.SetLinePos(controller.transform.position);
        }
        if (currPoint) {
            currPoint.transform.position = controller.transform.position;
        }
	}

    protected void CreatePoint(object sender, ControllerInteractionEventArgs e) {
        CreatePointCallback();
    }

    private void CreatePointCallback() {
        if (currPoint) {
            currPoint.PlacePoint();
            prevPoint = currPoint;
            prevPointColor = VRMPoint.RandColor();
            prevPoint.SetEndColor(prevPointColor);
        }

        GameObject vrPointObj = (GameObject)Instantiate(vrPointPrefab, 
                    controller.transform.position,
                    Quaternion.identity);
        currPoint = vrPointObj.GetComponent<VRMPoint>();
        currPoint.LinkedController = gameObject;
        currPoint.SetStartColor(prevPointColor);
    }

    protected void BreakOffPoint(object sender, ControllerInteractionEventArgs e) {
        if (prevPoint) {
            prevPoint.SetLinePos(prevPoint.transform.position);
            prevPoint = null;
        }
        if (currPoint) {
            Destroy(currPoint.gameObject);
            CreatePointCallback();
        }

    }
}
