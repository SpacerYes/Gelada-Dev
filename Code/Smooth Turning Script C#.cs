using UnityEngine;

public class OculusTurningScript : MonoBehaviour
{
	public float turningSpeed = 1.0f;
	public string thumbstickHorizontalAxisName = "OculusThumbstickHorizontal";
	void Update()
	{
		float turnInput = Input.GetAxis(thumbstickHorizontalAxisName);

		//Your favorite turning logic >:)
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.y += turnInput * turningSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotation);
	}
}