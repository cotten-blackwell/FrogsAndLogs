using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public bool alive;

    [SerializeField]
    private GameObject pickupPrefab;

	// Use this for initialization
	void Start () {
        alive = true;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && alive == true) {
            alive = false;

            // Create the pickup particles
            Instantiate(pickupPrefab, transform.position, Quaternion.identity);

        }
    }
}
