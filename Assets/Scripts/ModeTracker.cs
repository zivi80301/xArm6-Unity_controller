using UnityEngine;
using TMPro;

public class ModeTracker : MonoBehaviour
{
    //declaring variables
    int prevCode;

    [SerializeField] TextMeshProUGUI text;

    string[] codeTexts = new string[] { "Disabled", "Enabled", "Trajectory"};
    
    //print codeTexts[code] to UI text object
    void OutputMode(int code)
    {
        text.text = codeTexts[code];
    }

    //print "Disabled" to UI text object on launch
    void Start()
    {
        prevCode = 0;
        text.text = codeTexts[0];
    }

    //update UI object text when mode of operation is changed
    void Update()
    {
        int code = GameObject.Find("Code").GetComponent<CodeManager>().code;
        if (code != prevCode) OutputMode(code);
        prevCode = code;
    }
}