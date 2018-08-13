using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class KeyboardHandler : IDeviceHandler
{

    public Bindings _bindings = Presets.GetKeyboardBindings();
    private KeyboardDevice keyboardDevice;

    public KeyboardHandler(Bindings? a_bindings)
    {
        if (a_bindings.HasValue)
        {
            _bindings = a_bindings.GetValueOrDefault();
        }

        keyboardDevice = new KeyboardDevice();

        keyboardAxis = new TwoAxisInput(_bindings.LeftXAxis, _bindings.LeftYAxis);
        mouseAxis = new TwoAxisInput(_bindings.RightXAxis, _bindings.RightYAxis);
        mouseWheelAxis = new OneAxisInput("");
    }

    public void UpdateDevice()
    {
        
    }

    public void LateUpdateDevice()
    {
        throw new NotImplementedException();
    }
}
