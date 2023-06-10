using System.Collections;
using System.Collections.Generic;
using NRKernal;
using NRKernal.NRExamples;
using UnityEngine;

public class CarrotSpawner : MonoBehaviour
{
    public CarrotBehaviour carrot;

    public GameObject carrotPrefab;

    public ReticleBehaviour reticle;

    public static Vector3 RandomInTriangle(Vector3 v1, Vector3 v2)
    {
        float u = Random.Range(0.0f, 1.0f);
        float v = Random.Range(0.0f, 1.0f);
        if (v + u > 1)
        {
            v = 1 - v;
            u = 1 - u;
        }

        return (v1 * u) + (v2 * v);
    }

    public Vector3 FindRandomLocation(GameObject plane)
    {
        var mesh = plane.GetComponent<PolygonPlaneVisualizer>().m_PlaneMesh;
        var triangles = mesh.triangles;
        var triangle = triangles[(int)Random.Range(0, triangles.Length - 1)] / 3 * 3;
        var vertices = mesh.vertices;
        var randomInTriangle = RandomInTriangle(vertices[triangle], vertices[triangle+1]);
        var randomPoint = plane.transform.TransformPoint(randomInTriangle);
        randomPoint.y = reticle.currentPlane.GetComponent<NRTrackableBehaviour>().Trackable.GetCenterPose().position.y;
        return randomPoint;
    }

    public void SpawnGem(GameObject plane)
    {
        var gemClone = Instantiate(carrotPrefab);
        gemClone.transform.position = FindRandomLocation(plane);

        carrot = gemClone.GetComponent<CarrotBehaviour>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (reticle.currentPlane != null)
        {
            if (carrot == null)
            {
                SpawnGem(reticle.currentPlane);
            }
        }
    }
}
