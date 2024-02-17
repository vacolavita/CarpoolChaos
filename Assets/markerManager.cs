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
    public float depth = 0;
    public NavMeshPath path;
    public LayerMask mask;
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
        
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        if (agent.isOnNavMesh)
        {
            path = new NavMeshPath();
            agent.CalculatePath(dest, path);
        }

        transform.localPosition = new Vector3(0, depth, 0);
        agent.enabled = false;
        
        if (path.corners.Length > 1)
        {
            Vector3 nextPoint = new Vector3(path.corners.ElementAt(1).x, transform.position.y, path.corners.ElementAt(1).z);
            bool straightShot = true;
            for (int i = 1; i < path.corners.Length; i++) {
                if (!Physics.Linecast(transform.position, new Vector3(path.corners.ElementAt(i).x, transform.position.y, path.corners.ElementAt(i).z),mask))
                {
                    nextPoint = new Vector3(path.corners.ElementAt(i).x, transform.position.y, path.corners.ElementAt(i).z);
                    Debug.DrawLine(transform.position, new Vector3(path.corners.ElementAt(i).x, transform.position.y, path.corners.ElementAt(i).z), Color.green);
                }
                else {
                    Debug.DrawLine(transform.position, new Vector3(path.corners.ElementAt(i).x, transform.position.y, path.corners.ElementAt(i).z), Color.red);
                    straightShot = false;
                    break;
                }
               
            }
            if (straightShot)
            {
                pyramid.transform.localScale = new Vector3(0.1f,1.6f,1.2f);
                pyramid.transform.localPosition = new Vector3(0, 0, 4);
            }
            else {
                pyramid.transform.localScale = new Vector3(0.1f, 1.2f, 1.2f);
                pyramid.transform.localPosition = new Vector3(0, 0, 3.5f);
            }
            
            transform.LookAt(nextPoint);

        }

    }

}
