using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class markerManager : MonoBehaviour
{
    // Start is called before the first frame update

    public NavMeshAgent agent;
    public Transform car;
    public Vector3 dest;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.enabled = true;
        NavMeshPath path = new NavMeshPath();
        transform.localPosition = new Vector3(0, 0, 0);
        agent.CalculatePath(dest, path);
        agent.enabled = false;
        Debug.Log(dest);
        if (path.corners.Length > 1)
        {
            Vector3 nextPoint = new Vector3(path.corners.ElementAt(1).x, transform.position.y, path.corners.ElementAt(1).z);
            transform.LookAt(nextPoint);
        }
    }
}
