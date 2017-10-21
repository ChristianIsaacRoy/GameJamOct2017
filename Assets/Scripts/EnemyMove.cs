using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

    NavMeshAgent agent;
    Transform target;
	// Use this for initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
		if(target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
	}

    public void Follow(GameObject newTarget)
    {

        agent.stoppingDistance =  0.8f;
        agent.updateRotation = false;
        target = newTarget.transform;

    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0;
        agent.updateRotation = true;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
