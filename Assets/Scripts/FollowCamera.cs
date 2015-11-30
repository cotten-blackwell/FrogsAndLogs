using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector3 offset;
    private float cameraFollowSpeed = 5f;


	// Update is called once per frame
	void Update () {
        Vector3 newPosition = player.position + offset;

        transform.position = Vector3.Lerp(transform.position, newPosition, cameraFollowSpeed * Time.deltaTime);
	}
}
