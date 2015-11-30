using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

    private bool gameStarted = false;
    [SerializeField]
    private Text gameStateText;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private BirdMovement birdMovement;
    [SerializeField]
    private FollowCamera followCamera;
    private float restartDelay = 3f;
    private float restartTimer;
    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
        // Cursor.visible = false;

        playerMovement = player.GetComponent<PlayerMovement>();
        playerHealth = player.GetComponent<PlayerHealth>();

        // Prevent the player from moving at the start of the game
        playerMovement.enabled = false;

        // Prevent the bird from moving at the start of the game
        birdMovement.enabled = false;

        // Prevent the follow camera from moving to its game position
        followCamera.enabled = false;


	}
	
	// Update is called once per frame
	void Update () {
        
        // If the game is not started and the player presses the space bar...
        if (gameStarted == false && Input.GetKeyUp(KeyCode.Space))
        {
            
            // ...start the game.
            StartGame();
        }

        // If the player is no longer alive...
        if (playerHealth.alive == false)
        {

            // ...end the game...
            EndGame();

            // ...increment a timer to count up restarting...
            restartTimer = restartTimer + Time.deltaTime;

            // ...and if it reaches the restart delay...
            if (restartTimer >= restartDelay)
            {

                // ...then reload the currently loaded level.
                Application.LoadLevel(Application.loadedLevel);

            }
        }
	}

    private void StartGame()
    {

        // Set the game state
        gameStarted = true;

        // Hide the start text by making it transparent
        gameStateText.color = Color.clear;

        // Allow the player to move
        playerMovement.enabled = true;

        // Allow the bird to move
        birdMovement.enabled = true;

        // Allow the camera to move
        followCamera.enabled = true;

    }

    private void EndGame()
    {
        // Set the game state
        gameStarted = false;

        // Show the game over text
        gameStateText.text = "Game Over!";
        gameStateText.color = Color.white;

        // Remove the player from the game
        player.SetActive(false);

        // Show the Cursor again so the developer can click the Play button to stop looping...
        Cursor.visible = true;

    }





















}
