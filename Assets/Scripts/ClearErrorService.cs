using RosMessageTypes.Messages;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;

public class ClearErrorService : MonoBehaviour
{
    //declaring variables
    ROSConnection ros;

    public string serviceName = "clear_error_srv";

    //connect to ROS and register service caller
    private void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterRosService<EmptyRequest, EmptyResponse>(serviceName);
    }

    //call clear_error_srv service. On service call, print "Service Called" on callback, print "Clearing Errors" to console
    public void OnButtonPress()
    {
        EmptyRequest positionServiceRequest = new EmptyRequest();
        ros.SendServiceMessage<EmptyResponse>(serviceName, positionServiceRequest, Callback);
        Debug.Log("Service Called");
    }

    void Callback(EmptyResponse response)
    {
        Debug.Log("Clearing Errors");
    }
}