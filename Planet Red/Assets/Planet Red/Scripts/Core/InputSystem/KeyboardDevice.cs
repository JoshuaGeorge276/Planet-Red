using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class KeyboardDevice : IInputDevice
{
    private TwoAxisInput keyboardAxis;
    private TwoAxisInput mouseAxis;
    private OneAxisInput mouseWheelAxis;

    private float[] axisValues;
    private sbyte[] buttonValues;
    private Dictionary<InputAxisValue, string> axisLookup;
    private Dictionary<InputButtonValue, KeyCode> keyLookup;

    private Bindings currentBindings;

    public KeyboardDevice(Bindings a_bindings)
    {
        currentBindings = a_bindings;

        int axisCount = (int) InputAxisValue.COUNT;
        int buttonCount = (int) InputAxisValue.COUNT;

        axisValues = new float[axisCount];
        buttonValues = new sbyte[buttonCount];
        
        axisLookup = new Dictionary<InputAxisValue, string>(axisCount);
        keyLookup = new Dictionary<InputButtonValue, KeyCode>(buttonCount);

        axisLookup[InputAxisValue.LeftX] = currentBindings.LeftXAxis;
        axisLookup[InputAxisValue.LeftY] = currentBindings.LeftYAxis;
        axisLookup[InputAxisValue.RightX] = currentBindings.RightXAxis;
        axisLookup[InputAxisValue.RightY] = currentBindings.RightYAxis;

        keyLookup[InputButtonValue.Action1] = currentBindings.Action1;
        keyLookup[InputButtonValue.Action1] = currentBindings.Action2;
        keyLookup[InputButtonValue.Action1] = currentBindings.Action3;
        keyLookup[InputButtonValue.Action1] = currentBindings.Action4;

        keyLookup[InputButtonValue.DPadDown] = currentBindings.DPadDown;
        keyLookup[InputButtonValue.DPadUp] = currentBindings.DPadUp;
        keyLookup[InputButtonValue.DPadLeft] = currentBindings.DPadLeft;
        keyLookup[InputButtonValue.DPadRight] = currentBindings.DPadRight;
        keyLookup[InputButtonValue.LeftTrigger] = currentBindings.LeftTrigger;
        keyLookup[InputButtonValue.RightTrigger] = currentBindings.RightTrigger;
        keyLookup[InputButtonValue.LeftBumper] = currentBindings.LeftBumper;
        keyLookup[InputButtonValue.RightBumper] = currentBindings.RightBumper;
        keyLookup[InputButtonValue.LeftStickButton] = currentBindings.LeftStickButton;
        keyLookup[InputButtonValue.RightStickButton] = currentBindings.RightStickButton;
        keyLookup[InputButtonValue.Start] = currentBindings.Start;
        keyLookup[InputButtonValue.Select] = currentBindings.Select;
        keyLookup[InputButtonValue.Menu] = currentBindings.Menu;
        keyLookup[InputButtonValue.Return] = currentBindings.Return;
        keyLookup[InputButtonValue.Pause] = currentBindings.Pause;
        keyLookup[InputButtonValue.Options] = currentBindings.Options;

    }

    public void UpdateAxis()
    {
        keyboardAxis.UpdateAxis();
        mouseAxis.UpdateAxis();
        mouseWheelAxis.UpdateAxis();
    }

    public void UpdateButtons()
    {
        for (int i = 0; i < (int)InputButtonValue.COUNT; ++i)
        {
            switch (buttonValues[i])
            {
                case (int)InputButtonState.None:

                    if (Input.GetKeyDown(keyLookup[(InputButtonValue) i]))
                    {
                        buttonValues[i] = (int)InputButtonState.Down;
                    }

                    break;
                case (int)InputButtonState.Down:

                    if (Input.GetKey(keyLookup[(InputButtonValue) i]))
                    {
                        buttonValues[i] = (int)InputButtonState.Pressed;
                        break;
                    }

                    buttonValues[i] = (int)InputButtonState.Up;

                    break;
                case (int)InputButtonState.Pressed:

                    if (Input.GetKeyUp(keyLookup[(InputButtonValue) i]))
                    {
                        buttonValues[i] = (int) InputButtonState.Up;
                    }

                    break;
                case(int)InputButtonState.Up:

                    buttonValues[i] = (int) InputButtonState.None;
                    break;
            }
        }
    }

    public void LateUpdateAxis()
    {
        throw new NotImplementedException();
    }

    public void LateUpdateButtons()
    {
        throw new NotImplementedException();
    }

    public void ResetDevice()
    {
        throw new NotImplementedException();
    }

    public float GetAxis(InputButtonValue a_value)
    {

        Input.GetAxis()
    }

    public float GetValue(InputButtonValue a_value)
    {
        throw new NotImplementedException();
    }
}
