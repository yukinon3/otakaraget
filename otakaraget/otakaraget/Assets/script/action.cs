using UnityEngine;
using System.Collections;

public class action : MonoBehaviour {

	float speed = 5.0f;

	controller.Move (new Vector3 (5, 2, 5));
	//float x = 5;
	//float y = 2;
	//float z = 5;

	// Use this for initialization
	void Start () {

		Controller = GetComponent<CharacterController> ();

	}
	
	// Update is called once per frame
	void Update () {

		CameraAxisControl ();
		attachMove ();
		attachRotation ();
	}

	void NormalControl(){
		if (Controller.isGrounded) {
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
		}
	}

	void CameraAxisControl() {
		if (ControllerColliderHit.isGrounded) {
			Vector3 foward = Camera.mainCamera.transform.TransformDirection (Vector3.forward);
			Vector3 right = Camera.mainCamera.transform.TransformDirection (Vector3.right);

			moveDirection = Input.GetAxis ("Horizontal") * right + Input.GetAxis ("Vertical") * foward;
			moveDirection *= speed;
		}
	}

	void attachRotation() {
		var moveDirectionYzero = -moveDirection;
		moveDirectionYzero.y = 0;

		if (moveDirectionYzero.sqrMagnitude > 0.001) {
		    
			float    step = rotateSpeed*Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(transform.forward,moveDirectionYzero,step,0f);
			
			transform.rotation = Quaternion.LookRotation(newDir);
		}
			
	}
}
		