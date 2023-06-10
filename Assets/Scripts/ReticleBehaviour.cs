using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;

public class ReticleBehaviour : MonoBehaviour
{
    public GameObject child;

    public GameObject currentPlane;
    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var handControllerAnchor = NRInput.DomainHand == ControllerHandEnum.Left
            ? ControllerAnchorEnum.LeftLaserAnchor
            : ControllerAnchorEnum.RightLaserAnchor;
        var laserAnchor = NRInput.AnchorsHelper.GetAnchor(NRInput.RaycastMode == RaycastModeEnum.Gaze ? ControllerAnchorEnum.GazePoseTrackerAnchor : handControllerAnchor);

        RaycastHit hitResult;
        if (Physics.Raycast(new Ray(laserAnchor.transform.position, laserAnchor.transform.forward), out hitResult, 10))
        {
            var hit = hitResult.collider.gameObject;
            if (hit != null && hit.GetComponent<NRTrackableBehaviour>()?.Trackable.GetTrackableType() ==
                TrackableType.TRACKABLE_PLANE)
            {
                currentPlane = hit;
                transform.position = hitResult.point;
                child.SetActive(true);
            }
            else
            {
                child.SetActive(false);
            }
        }
    }
}
