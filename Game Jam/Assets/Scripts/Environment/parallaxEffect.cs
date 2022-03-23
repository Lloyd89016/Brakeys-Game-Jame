using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
	[Header("Fall Camera")]
	private Vector3 target;
	public Vector3 cameraOffset;
	public Transform camera;

	void Awake()
	{

		target = camera.transform.position + cameraOffset;

		transform.position = target;
	}

	void Update()
	{
		target = camera.transform.position + cameraOffset;

		transform.position = target;
	}
}
