using UnityEngine;
using System.Collections;

public class TeleportAction : Action
{
	public GameObject objectToMove;
	public Vector3 newPosition;
	public bool stopMovements = true;



	// Moves the gameObject instantly to a custom position
	public override bool ExecuteAction(GameObject dataObject)
	{
		Rigidbody2D rb2D;

		if(objectToMove != null)
		{
			//moves the specified object
			objectToMove.transform.position = newPosition;
			rb2D = objectToMove.GetComponent<Rigidbody2D>();
		}
		else
		{
			//moves this object
			transform.position = newPosition;
			rb2D = transform.GetComponent<Rigidbody2D>();
		}


		//bring the object to an halt
		if(stopMovements
			&& rb2D != null)
		{
			rb2D.velocity = Vector3.zero;
			rb2D.angularVelocity = 0f;
		}

		return true;
	}
}
