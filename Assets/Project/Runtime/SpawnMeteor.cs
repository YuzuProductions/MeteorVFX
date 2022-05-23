using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    public GameObject vfx;
    public Transform startPoint;
    public Transform endPoint;
    public float fireRatecd = 0.25f;
    public float timeToFire = 0;
    public CameraLookAt mainCameraLookAt;
    // Start is called before the first frame update
    void Start()
    {
        mainCameraLookAt = mainCameraLookAt.GetComponent<CameraLookAt>();
        SpawnNewMeteor();
    }
    private void Update()
    {
        timeToFire = timeToFire + Time.deltaTime;
        if (Input.GetButton("Fire1") && timeToFire >= fireRatecd)
        {
            timeToFire = 0;
            SpawnNewMeteor();
        }
    }

    private void SpawnNewMeteor()
    {
        var startPos = startPoint.position;
        GameObject objVfx = Instantiate(vfx, startPos, Quaternion.identity) as GameObject;

        var endPos = endPoint.position;
        RotateTo(objVfx, endPos);
        mainCameraLookAt.CameraLookAtSet(objVfx.transform);
    }

    private void RotateTo(GameObject obj, Vector3 destination)
    {
        var direction = destination - obj.transform.position;
        var rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }

    // Update is called once per frame

}
