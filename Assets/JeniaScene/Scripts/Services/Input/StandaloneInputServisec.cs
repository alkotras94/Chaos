using UnityEngine;

public class StandaloneInputServisec : InputServisec
{
    private VariableJoystick _joystick;
    public override Vector2 Axis
    {
        get
        {
            Vector2 axis = SimpleInputAxis();

            if (axis == Vector2.zero)
                axis = UnityAxis();
            return axis;
        }
    }

    private static Vector2 UnityAxis() => new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));

    private static Vector2 SimpleInputAxis() => GameBootstraper.Instance.Joystick
        .Direction; //new Vector2(GameBootstraper.Instance.Joystick.Horizontal, GameBootstraper.Instance.Joystick.Vertical);
}
