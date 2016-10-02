using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		CheckInput (); 	
	}

	void CheckInput() {
		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement = Input.GetAxis ("Vertical");

		if (horizontalMovement > 0) {
			animator.SetBool ("Run", true);
			StartCoroutine (MoveOverSeconds (this, transform.position + Vector3.right, 0.25f));
			transform.rotation = Quaternion.Euler (0, 90, 0);
		}
		if (horizontalMovement < 0) {
			animator.SetBool ("Run", true);
			StartCoroutine (MoveOverSeconds (this, transform.position + Vector3.left, 0.25f));
			transform.rotation = Quaternion.Euler (0, 270, 0);
		}
		if (verticalMovement > 0) {
			animator.SetBool ("Run", true);
			StartCoroutine (MoveOverSeconds (this, transform.position + Vector3.forward, 0.25f));
			transform.rotation = Quaternion.identity;
		}
		if (verticalMovement < 0) {
			animator.SetBool ("Run", true);
			StartCoroutine (MoveOverSeconds (this, transform.position + Vector3.back, 0.25f));
			transform.rotation = Quaternion.Euler (0, 180, 0);
		}
	}
		
	public IEnumerator MoveOverSeconds (PlayerManager objectToMove, Vector3 end, float seconds)
	{
		float elapsedTime = 0;
		Vector3 startingPos = objectToMove.transform.position;
		while (elapsedTime < seconds)
		{
			objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		objectToMove.animator.SetBool ("Run", false);
		objectToMove.transform.position = end;
	}
}
