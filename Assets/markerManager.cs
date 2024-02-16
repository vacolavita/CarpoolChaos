using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Progress;

public class markerManager : MonoBehaviour
{
    // Start is called before the first frame update

    public NavMeshAgent agent;
    public Transform car;
    public Vector3 dest;
    public Color color;
    public GameObject pyramid;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        color.a = 0.7f;
        pyramid.GetComponent<MeshRenderer>().material.color = color;
        color.a = 1;
        pyramid.GetComponents<MeshRenderer>()[0].material.SetColor("_EmissionColor", color);

        agent.enabled = true;
        NavMeshPath path = new NavMeshPath();
        transform.localPosition = new Vector3(0, 0, 0);
        agent.CalculatePath(dest, path);
        agent.enabled = false;
        Debug.Log(color);
        if (path.corners.Length > 1)
        {
            Vector3 nextPoint = new Vector3(path.corners.ElementAt(1).x, transform.position.y, path.corners.ElementAt(1).z);
            transform.LookAt(nextPoint);
        }

    }

}
