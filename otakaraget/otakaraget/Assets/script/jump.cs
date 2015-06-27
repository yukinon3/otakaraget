using UnityEngine;
using System.Collections;

public class jump : MonoBehaviour {

	private int restJumps = 2;
	public float power = 500f;
	private Rigidbody _rigidbody;
		
	// Use this for initialization
	void Start () {
		_rigidbody = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (restJumps > 0) {
				this._rigidbody.AddForce (Vector3.up * power);
				restJumps--;
				Debug.Log (restJumps);
			}
		}
	}

		void OnCollisionEnter (Collision collision) {
			if (collision.gameObject.tag == "Floor" )
			{
						restJumps = 2;
					}
		Debug.Log (restJumps);
				}
			
}



