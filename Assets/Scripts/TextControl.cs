using UnityEngine;

public class TextControl : MonoBehaviour
{
    //declaring variables
    public Transform target;

    Vector3 thetaAxis = Vector3.back;

    float phi;
    float theta;

    public bool active = false;

    //toggle this control mode using UI buttons
    public void SetActive()
    {
        active = true;
    }

    public void SetInactive()
    {
        active = false;
    }

    //rotate object and theta axis of rotation around target object and global y axis by phi degrees. Called on end edit of phy UI input field
    public void SetPhi(string phiInput)
    {
        if (active)
        {
            if (!float.TryParse(phiInput, out phi)) phi = 0.0f;
            transform.RotateAround(target.position, Vector3.down, phi);
            thetaAxis = Quaternion.AngleAxis(phi, Vector3.down) * thetaAxis;
        }
    }

    //rotate object around target object and theta axis by theta degrees. Called on end edit of theta UI input field
    public void SetTheta(string thetaInput)
    {
        if (active)
        {
            if (!float.TryParse(thetaInput, out theta)) theta = 0.0f;
            transform.RotateAround(target.position, thetaAxis, theta);
        }
    }
}