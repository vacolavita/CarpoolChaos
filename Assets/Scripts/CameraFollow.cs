using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cameraFollow;
    public Vector3 cameraDistance;
    public Vector3 cameraOffset;
    public Vector2 xBorders;
    public Vector2 yBorders;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (cameraFollow != null)
        {
            transform.SetPositionAndRotation(new Vector3(cameraFollow.position.x + cameraDistance.x, cameraFollow.position.y + cameraDistance.y, cameraFollow.position.z + cameraDistance.z), transform.rotation);
            transform.LookAt(cameraFollow);
        }

        Vector3 dir = (cameraDistance).normalized;
        float dist = Mathf.Sqrt(Mathf.Pow(cameraDistance.x, 2) + Mathf.Pow(cameraDistance.z, 2));

        transform.SetPositionAndRotation(new Vector3(
Mathf.Clamp(cameraFollow.position.x + cameraDistance.x + cameraOffset.x, xBorders.x, xBorders.y),
cameraFollow.position.y + cameraDistance.y + cameraOffset.y,
Mathf.Clamp(cameraFollow.position.z + cameraDistance.z + cameraOffset.z, yBorders.x, yBorders.y)), transform.rotation);

    }
}
