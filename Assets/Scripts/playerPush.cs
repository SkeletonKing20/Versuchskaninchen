using UnityEngine;
using System.Collections;

public class playerPush : MonoBehaviour
{

	public float distance = 1f;
	public LayerMask boxMask;

	GameObject box;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		Physics2D.queriesStartInColliders = false;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

		if (hit.collider != null && (hit.collider.gameObject.CompareTag("Box") || hit.collider.gameObject.CompareTag("Turret")) && Input.GetButtonDown("Jump"))
		{


			box = hit.collider.gameObject;
			box.GetComponentInParent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
			box.GetComponentInParent<FixedJoint2D>().enabled = true;
			box.GetComponent<boxPull>().beingPushed = true;

		}
		else if (Input.GetButtonUp("Jump"))
		{
			box.GetComponentInParent<FixedJoint2D>().enabled = false;
			box.GetComponentInParent<boxPull>().beingPushed = false;
		}

	}


	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;

		Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);



	}
}