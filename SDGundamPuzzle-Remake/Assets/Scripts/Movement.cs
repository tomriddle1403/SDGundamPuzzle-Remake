using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public bool playerMove;
	// Use this for initialization
	public float speed;
	public float cooldown;

	public float timer;
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//BasicMovement ();
		timer += Time.deltaTime;

		playerMove = CanMoveByPlayer ();
		if (timer > cooldown) { 

			if (playerMove) {
				timer = 0;
				MoveByPlayer ();
			}
		}
	}

	bool CanMoveByPlayer(){
		bool result = false;

		result = result || Input.GetKeyDown (KeyCode.DownArrow);
		result = result || Input.GetKeyDown (KeyCode.LeftArrow);
		result = result || Input.GetKeyDown (KeyCode.RightArrow);

		return result;
	}
	void MoveByPlayer(){

		Debug.Log ( Mathf.Round(transform.position.x) + " " + Mathf.Round(transform.position.y) );

		float x = Mathf.Floor(Input.GetAxis("Horizontal"));
		if (Input.GetAxis ("Horizontal") > 0)
			x = 1f;

		float y = Mathf.Floor(Input.GetAxis("Vertical"));


		transform.position += new Vector3(x, y, 0) * speed; 
	}


}
