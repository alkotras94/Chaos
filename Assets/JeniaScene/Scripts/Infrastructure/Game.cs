using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game 
{
    public static IInputServices InputServisec;

    public Game()
    {
        RegisterInputServise();
    }

    private void RegisterInputServise()
    {
        if (Application.isEditor)
            InputServisec = new StandaloneInputServisec();
    }
}
