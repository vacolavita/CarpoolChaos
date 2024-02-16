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
    public Movement car1;
    private GameObject pyramid;
    void Start()
    {
        pyramid = GameObject.Find("pyramid");
        agent = GetComponent<NavMeshAgent>();
        car1 = GameObject.Find("Car").GetComponent<Movement>();
    }


    // Update is called once per frame
    void Update()
    {
        UpdateColor();
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

    void UpdateColor()
    {
        if (car1.select == 0)
        {
            pyramid.GetComponent<MeshRenderer>().material.color = Color.green;
        }

        if (car1.select == 1)
        {
            pyramid.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (car1.select == 2)
        {
            pyramid.GetComponent<MeshRenderer>().material.color = new Color(0.50f, 0.92f, 1.00f);
        }
    }
}
