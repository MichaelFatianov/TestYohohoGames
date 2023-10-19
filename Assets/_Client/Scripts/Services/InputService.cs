using UnityEngine;

public class InputService
{
    public Vector3 GetInput()
    {
        return JoystickInput.JInput;
    }
}
