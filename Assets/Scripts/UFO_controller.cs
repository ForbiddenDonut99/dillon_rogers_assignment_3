using UnityEngine;
using System.Collections;

public class UFO_controller : MonoBehaviour {

	public float moveSpeed = 1f;

	Vector3 moveDirection;

	CharacterController playerController;
	Transform playerTransform;
	Transform cameraTransform;
	
	void Start () {
	
		playerController = GetComponent<CharacterController> ();
		playerTransform = GetComponent<Transform> ();
		cameraTransform = transform.GetChild (0).GetComponent<Transform> ();


		Screen.showCursor = true;
	}

	
	void Update () {

		// UFO constant spinning
		//transform.Rotate (0f, 0f, 0.5f);

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
						moveDirection += playerTransform.up.normalized * Time.deltaTime * moveSpeed * .6f;
				} else if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.UpArrow)) {
						moveDirection += -playerTransform.up.normalized * Time.deltaTime * moveSpeed * .6f;
			}

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.UpArrow)) {
						moveDirection += playerTransform.right.normalized * Time.deltaTime * moveSpeed * .6f;
		} else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.UpArrow)) {
						moveDirection += -playerTransform.right.normalized * Time.deltaTime * moveSpeed * .6f;
		}
		playerController.Move(moveDirection);
	}
}
