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
    public Vector3[] dest;
    public Color color;
    public GameObject pyramid;
    public float depth = 0;
    public NavMeshPath path;
    public LayerMask mask;
    float motion;
    public int numDests = 0;
    public bool pointStops = false;
    public stageManager stage;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stage = GameObject.Find("StageManager").GetComponent<stageManager>();
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
            int i = 0;
            float length = 99999;
            int pathnum = 0;
            foreach (var item in dest)
            {
                
                if (item != null && i < numDests && (!pointStops || pointStops && stage.clumps[i].GetComponent<Clump>().passengers > 0))
                {

                    agent.CalculatePath(item, path);
                    float tlength = 0;
                    for (int j = 0; j < path.corners.Length-1; j++) {
                        tlength += Vector3.Distance(path.corners.ElementAt(j), path.corners.ElementAt(j + 1));
                    }
                    if (tlength < length) {
                        length = tlength;
                        pathnum = i;

                    }
                    

                }
                i++;

            }
            agent.CalculatePath(dest[pathnum], path);
        }

        transform.localPosition = new Vector3(0, depth, 0);
        agent.enabled = false;

        if (path.corners.Length > 1)
        {
            Vector3 nextPoint = new Vector3(path.corners.ElementAt(1).x, transform.position.y, path.corners.ElementAt(1).z);
            bool straightShot = true;
            for (int i = 1; i < path.corners.Length; i++)
            {
                if (!Physics.Linecast(transform.position, new Vector3(path.corners.ElementAt(i).x, transform.position.y, path.corners.ElementAt(i).z), mask))
                {
                    nextPoint = new Vector3(path.corners.ElementAt(i).x, transform.position.y, path.corners.ElementAt(i).z);
                    Debug.DrawLine(transform.position, new Vector3(path.corners.ElementAt(i).x, transform.position.y, path.corners.ElementAt(i).z), Color.green);
                }
                else
                {
                    Debug.DrawLine(transform.position, new Vector3(path.corners.ElementAt(i).x, transform.position.y, path.corners.ElementAt(i).z), Color.red);
                    straightShot = false;
                    break;
                }

            }


            motion += Time.deltaTime * 8;
            if (straightShot)
            {
                motion += Time.deltaTime * 4;
            }

            pyramid.transform.localPosition = new Vector3(0, 0, 4f + Mathf.Sin(motion) / 2);
            transform.LookAt(nextPoint);

        }

    }

}
