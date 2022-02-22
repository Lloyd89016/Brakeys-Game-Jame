using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowX : MonoBehaviour
{
	private float interpVelocity;

	//the object(player) that the camrea is following
	public GameObject target;

	//the camera offset
	public Vector3 offset;

	//the speed of the camera
	public float speed = 15f;

	//the position that the camera is moving to
	Vector3 targetPos;

	void Start()
	{
		target = GameObject.Find("Player");

		targetPos = transform.position;
	}

	// Update is called once per frame

	private void LateUpdate()
	{

		Vector3 posNoZ = transform.position;
		posNoZ.z = target.transform.position.z;

		Vector3 posNoy = transform.position;
		posNoZ.y = target.transform.position.y;

		Vector3 targetDirection = (target.transform.position - posNoZ);

		interpVelocity = targetDirection.magnitude * speed;

		targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

		transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
	}
}
