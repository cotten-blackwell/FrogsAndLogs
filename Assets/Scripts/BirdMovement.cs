using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

    [SerializeField]
    private Transform target;
    private NavMeshAgent birdAgent;
    private Animator birdAnimator;
    [SerializeField]
    private RandomSoundPlayer birdFootsteps;

	// Use this for initialization
	void Start () {
        birdAgent = GetComponent<NavMeshAgent> ();
        birdAnimator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
        // Set the bird's destination
        birdAgent.SetDestination(target.position);

        // Measure the magnitude of the NavMeshAgent's velocity
        float speed = birdAgent.velocity.magnitude;

        // Pass the velocity to the animator component
        birdAnimator.SetFloat("Speed", speed);

        if (speed > 0)
        {
            birdFootsteps.enabled = true;
        } else
        {
            birdFootsteps.enabled = false;
        }
	}
}
