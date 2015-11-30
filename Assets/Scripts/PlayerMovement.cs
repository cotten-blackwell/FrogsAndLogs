using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Animator playerAnimator;
    private float moveHorizontal;
    private float moveVertical;
    private Vector3 movement;
    private float turningSpeed = 20f;
    private Rigidbody playerRigidBody;
    [SerializeField]
    private RandomSoundPlayer playerFootsteps;

    // Use this for initialization
    void Start () {

        //gather the components from the Player GameObject
        playerAnimator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        
        //gather input from the keyboard
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    }

    void FixedUpdate()
    {
        // If the player's movement vector does not equal zero...
        if (movement != Vector3.zero) {

            // ...then create a target rotation based on the movement vector...
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);

            // ...and create another rotation that moves from the current rotation to the target rotation...
            Quaternion newRotation = Quaternion.Lerp(playerRigidBody.rotation, targetRotation, turningSpeed * Time.deltaTime);

            // ...and change the player's rotation to the new incremental rotation...
            playerRigidBody.MoveRotation(newRotation);
            
            // ... then play the jump animation...
            playerAnimator.SetFloat("Speed", 3f);

            // ...play footstep sounds.
            playerFootsteps.enabled = true;

        }
        else {
            // Otherwise, don't play the jump animation.
            playerAnimator.SetFloat("Speed", 0f);

            // Don't play footsetp sounds
            playerFootsteps.enabled = false;

        }
    }

}
