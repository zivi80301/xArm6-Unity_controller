using UnityEngine;
using TMPro;

public class CoordinatesToText : MonoBehaviour
{
    //declaring variables
    public Transform target;
    public Transform controller;

    [SerializeField] TextMeshProUGUI text;

    float r;
    float t;
    float p;

    //calculates cartesian and spherical coordinates of controller object with origin in target object.
    //The coordinates are printed to UI text object
    void Update()
    {
        float realX = controller.position.x - target.position.x;
        float realY = controller.position.y - target.position.y;
        float realZ = controller.position.z - target.position.z;

        r = Mathf.Sqrt(Mathf.Pow(realX, 2.0f) + Mathf.Pow(realY, 2.0f) + Mathf.Pow(realZ, 2.0f));
        t = -(Mathf.Acos(realY / r) * 180.0f / Mathf.PI - 90);
        p = (Mathf.Acos(realX / Mathf.Sqrt(Mathf.Pow(realX, 2.0f) + Mathf.Pow(realZ, 2.0f))) - Mathf.PI) * Mathf.Sign(realZ) * 180.0f / Mathf.PI;

        text.text = "radius = " + Mathf.Round(r*100.0f)/100.0f + ", theta = " + Mathf.Round(t*10.0f)/10.0f + ", phi = " + Mathf.Round(p*10.0f)/10.0f;
    }
}