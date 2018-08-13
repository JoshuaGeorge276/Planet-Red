using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IInputDevice
{
    void UpdateAxis();
    void UpdateButtons();

    void LateUpdateAxis();
    void LateUpdateButtons();
    void ResetDevice();

    float GetAxis(InputButtonValue a_value);
    float GetValue(InputButtonValue a_value);
}

public enum InputAxisValue
{
    LeftX,
    LeftY,
    RightX,
    RightY,
    COUNT
}

public enum InputButtonValue
{
    LeftStickXAxis,
    LeftStickYAxis,
    LeftStickButton,
    RightStickXAxis,
    RightStickYAxis,
    RightStickButton,
    DPadUp,
    DPadDown,
    DPadLeft,
    DPadRight,
    Action1,
    Action2,
    Action3,
    Action4,
    LeftTrigger,
    RightTrigger,
    LeftBumper,
    RightBumper,
    Start,
    Return,
    Select,
    Pause,
    Menu,
    Options,
    COUNT
}

public enum InputButtonState
{
    None,
    Down,
    Pressed,
    Up,
    COUNT
}