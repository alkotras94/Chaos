using UnityEngine;

public class GameBootstraper : MonoBehaviour
{
    public VariableJoystick Joystick;
    private Game _game;
    public static GameBootstraper Instance;

    private void Awake()
    {
        _game = new Game();

        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }
}
