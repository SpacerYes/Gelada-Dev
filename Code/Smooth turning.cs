using UnityEngine;
using UnityEngine.XR;

public class SmoothTurn : MonoBehaviour
{
    public float turningSpeed = 1.0f;

    void Update()
    {
        float turnInput = Input.GetAxis("OculusThumbstickHorizontal");

        // Apply turning logic here
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.y += turnInput * turningSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
