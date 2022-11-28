using UnityEngine;

//manages codes for different modes of operation. Functions are called by UI buttons
public class CodeManager : MonoBehaviour
{
    public int code = 0;

    public void Disable()
    {
        code = 0;
    }

    public void Enable()
    {
        code = 1;
    }

    public void Trajectory()
    {
        code = 2;
    }
}