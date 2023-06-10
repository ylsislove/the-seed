using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;

namespace TheSeed
{
    public class TrackingImageVisualizer2 : MonoBehaviour
    {
        public NRTrackableImage Image;

        public GameObject cube;
        
        // Update is called once per frame
        void Update()
        {
            if (Image == null)
            {
                cube.SetActive(false);
                return;
            }

            var center = Image.GetCenterPose();
            transform.position = center.position;
            transform.rotation = center.rotation;
            cube.SetActive(true);
        }
    }
}