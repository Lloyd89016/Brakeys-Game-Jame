using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
	[Header("Fall Camera")]
	private Vector3 target;
	public Vector3 cameraOffset;
	public Transform Camera;

	void Awake()
	{

		target = Camera.transform.position + cameraOffset;

		transform.position = target;
	}

	void Update()
	{
		target = Camera.transform.position + cameraOffset;

		transform.position = target;
	}
}
