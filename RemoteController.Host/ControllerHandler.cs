using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.Xbox360;

namespace RemoteController.Host
{
    public class ControllerHandler
    {
        private ViGEmClient client;

        Dictionary<string, IXbox360Controller> controllerList = new();

        public ControllerHandler()
        {
            client = new ViGEmClient();
        }

        public void HandleMessage(MessageDto message)
        {
            var controllerInputState = message.Controller;
            var id = message.Id;
            System.Console.WriteLine($"Id: {id}");
            System.Console.WriteLine($"Controller: {controllerInputState}");

            if (!controllerList.ContainsKey(id))
            {
                var controller = client.CreateXbox360Controller();
                controller.Connect();

                controllerList.Add(id, controller);

                UpdateController(controller, controllerInputState);
            }
            else
            {
                var controller = controllerList[id];
                UpdateController(controller, controllerInputState);
            }
        }

        public void DisconnectById(string id)
        {
            if (controllerList.ContainsKey(id))
            {
                var controller = controllerList[id];
                controller.Disconnect();
                controllerList.Remove(id);
            }
        }

        public void DisconnectAll()
        {
            //foreach (var item in controllerList)
            //{
            //    item.Value.Disconnect();
            //}
        }

        private void UpdateController(IXbox360Controller xbox_controller, XboxController new_state)
        {
            xbox_controller.SetButtonState(Xbox360Button.LeftThumb, new_state.thumb_stick_left);
            xbox_controller.SetButtonState(Xbox360Button.RightThumb, new_state.thumb_stick_right);

            xbox_controller.SetButtonState(Xbox360Button.Y, new_state.y);
            xbox_controller.SetButtonState(Xbox360Button.X, new_state.x);
            xbox_controller.SetButtonState(Xbox360Button.B, new_state.b);
            xbox_controller.SetButtonState(Xbox360Button.A, new_state.a);

            xbox_controller.SetButtonState(Xbox360Button.Start, new_state.start);
            xbox_controller.SetButtonState(Xbox360Button.Back, new_state.back);
            xbox_controller.SetButtonState(Xbox360Button.Guide, new_state.guide);

            xbox_controller.SetButtonState(Xbox360Button.Up, new_state.dpad_up);
            xbox_controller.SetButtonState(Xbox360Button.Right, new_state.dpad_right);
            xbox_controller.SetButtonState(Xbox360Button.Down, new_state.dpad_down);
            xbox_controller.SetButtonState(Xbox360Button.Left, new_state.dpad_left);

            xbox_controller.SetButtonState(Xbox360Button.LeftShoulder, new_state.shoulder_left);
            xbox_controller.SetButtonState(Xbox360Button.RightShoulder, new_state.shoulder_right);

            /// <summary>
            ///     Changes the value of an axis identified by <see cref="Xbox360Axis" />.
            /// </summary>
            /// <param name="axis">The <see cref="Xbox360Axis" /> to change.</param>
            /// <param name="value">
            ///     The 16-bit signed value of the axis where 0 represents centered. The value is expected to stay
            ///     between -32768 and 32767.
            /// </param> -32768 and 32767.
            /// </param>
            xbox_controller.SetAxisValue(Xbox360Axis.LeftThumbX, new_state.axis_left_x);
            xbox_controller.SetAxisValue(Xbox360Axis.LeftThumbY, new_state.axis_left_y);
            xbox_controller.SetAxisValue(Xbox360Axis.RightThumbX, new_state.axis_right_x);
            xbox_controller.SetAxisValue(Xbox360Axis.RightThumbY, new_state.axis_right_y);

            /// <summary>
            ///     Changes the value of a slider identified by <see cref="Xbox360Slider" />.
            /// </summary>
            /// <param name="slider">The <see cref="Xbox360Slider" /> to change.</param>
            /// <param name="value">
            ///     The 8-bit unsigned value of the slider. A value of 0 represents lowest (released) while 255
            ///     represents highest (engaged).
            /// </param>
            xbox_controller.SetSliderValue(Xbox360Slider.LeftTrigger, new_state.trigger_left);
            xbox_controller.SetSliderValue(Xbox360Slider.RightTrigger, new_state.trigger_right);

            //xbox_controller.SubmitReport();
        }
    }
}
