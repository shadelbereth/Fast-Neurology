using UnityEngine;
using System.Collections;

[RequireComponent(typeof (NavMeshAgent))]

public class HeroMove : MonoBehaviour {

    private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
	   agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	   if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            agent.destination = hit.point;
       }
	}
}
