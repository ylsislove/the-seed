using System.Collections;
using System.Collections.Generic;
using NRKernal;
using NRKernal.NRExamples;
using UnityEngine;

public class GestureRPSTip : GestureSimpleTip
{
    public class GestureRPSName
    {
        public const string Gesture_Point = "Point";
        public const string Gesture_Rock = "Rock";
        public const string Gesture_Scissor = "Scissor";
        public const string Gestrue_Paper = "Paper";
    }

    public override void UpdateGestureTip()
    {
        var handState = NRInput.Hands.GetHandState(handEnum);
        if (handState == null)
            return;
        switch (handState.currentGesture)
        {
            case HandGesture.Point:
                gestureTxt.text = string.Empty;
                break;
            case HandGesture.Grab:
                gestureTxt.text = GetHandEnumLabel() + GestureRPSName.Gesture_Rock;
                break;
            case HandGesture.Victory:
                gestureTxt.text = GetHandEnumLabel() + GestureRPSName.Gesture_Scissor;
                break;
            case HandGesture.OpenHand:
                gestureTxt.text = GetHandEnumLabel() + GestureRPSName.Gestrue_Paper;
                break;
            default:
                gestureTxt.text = string.Empty;
                break;
        }

        if (handState.isTracked)
        {
            Pose palmPose;
            if(handState.jointsPoseDict.TryGetValue(HandJointID.Palm, out palmPose))
            {
                UpdateAnchorTransform(palmPose.position);
            }
            tipAnchor.gameObject.SetActive(!string.IsNullOrEmpty(gestureTxt.text));
        }
        else
        {
            tipAnchor.gameObject.SetActive(false);
        }
    }
}
