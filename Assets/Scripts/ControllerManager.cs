using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public static bool isInteracting()
    {
        return Input.GetButtonDown("Submit");  
    }
    public static bool isReturning()
    {
        return Input.GetButtonDown("Return");
    }
}
