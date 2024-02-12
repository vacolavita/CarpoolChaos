using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cameraFollow;
    public Vector3 cameraDistance;
    public Vector3 cameraOffset;
    void Start()
    {
        transform.SetPositionAndRotation(new Vector3(cameraFollow.position.x + cameraDistance.x, cameraFollow.position.y + cameraDistance.y, cameraFollow.position.z + cameraDistance.z), transform.rotation);
        transform.LookAt(cameraFollow);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (cameraDistance).normalized;
        float dist = Mathf.Sqrt(Mathf.Pow(cameraDistance.x, 2) + Mathf.Pow(cameraDistance.z, 2));

        transform.SetPositionAndRotation(new Vector3(
cameraFollow.position.x + cameraDistance.x + cameraOffset.x,
cameraFollow.position.y + cameraDistance.y + cameraOffset.y,
cameraFollow.position.z + cameraDistance.z + cameraOffset.z), transform.rotation);
        
    }
}
