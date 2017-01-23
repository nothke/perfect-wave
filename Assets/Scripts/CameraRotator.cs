using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public bool xAxis;
    public bool yAxis;

    void Update()
    {
        float x = xAxis ? Input.GetAxis("Vertical") : 0;
        float y = yAxis ? Input.GetAxis("Horizontal") : 0;

        Vector3 diff = new Vector3(x, -y);

        transform.Rotate(diff, Space.Self);


        if (xAxis)
        {
            //float xClamped = Mathf.Clamp(transform.localEulerAngles.x, -45f, +30);

            float xClamped = ClampAngle(transform.localEulerAngles.x, -45, 30);

            transform.localEulerAngles = new Vector3(xClamped, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
    }


    float ClampAngle(float angle, float min, float max)
    {
        if (angle < 90 || angle > 270)
        {       // if angle in the critic region...
            if (angle > 180) angle -= 360;  // convert all angles to -180..+180
            if (max > 180) max -= 360;
            if (min > 180) min -= 360;
        }
        angle = Mathf.Clamp(angle, min, max);
        if (angle < 0) angle += 360;  // if angle negative, convert to 0..360
        return angle;
    }
}
