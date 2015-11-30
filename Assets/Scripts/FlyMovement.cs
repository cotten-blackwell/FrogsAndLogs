using UnityEngine;
using System.Collections;

public class FlyMovement : MonoBehaviour {

    [SerializeField]
    private Transform center;

    private float flySpeed;

	// Use this for initialization
	void Start () {
        flySpeed = Random.Range(300f, 700f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(center.position, Vector3.up, flySpeed * Time.deltaTime);
	}
}
