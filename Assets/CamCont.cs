using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCont : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    public float zoommulti;
    private Camera Cam;

    void Start()
    {
        Cam = GetComponent<Camera>();
    }
    void LateUpdate()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = newPosition;

        float newZoom = Mathf.Lerp(20, 90, GetDist() / zoommulti);

        Cam.fieldOfView = newZoom;
    }

    float GetDist()
    {

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        if (bounds.size.x > bounds.size.z)
        {
            return bounds.size.x; 
        }
        else return bounds.size.z;
        
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }

}
