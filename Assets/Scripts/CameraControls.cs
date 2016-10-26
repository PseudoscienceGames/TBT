using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour
{
	public float moveSpeed;
	public float rotSpeed;

	void Update()
	{
		transform.Translate(Input.GetAxis("Horizontal") * moveSpeed, 0, Input.GetAxis("Vertical") * moveSpeed);
		transform.Rotate(-Vector3.up * Input.GetAxis("Rotate") * rotSpeed);
	}
}
