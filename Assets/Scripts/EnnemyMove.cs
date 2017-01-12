using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]

public class EnnemyMove : MonoBehaviour {

    private Vector3 startPosition;
    private NavMeshAgent agent;
    public Transform hero;
    public float actionRay;

	// Use this for initialization
	void Start () {
	   startPosition = transform.position;
       agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
	   if (Physics.Raycast(transform.position, hero.transform.position - transform.position, out hit, actionRay) && hit.collider.tag == "Player") {
            agent.destination = hit.point;
       }
       else {
            agent.destination = startPosition;
       }
	}
}
