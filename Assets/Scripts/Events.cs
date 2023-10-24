using System;
using UnityEngine;

public class Events 
{
    public static Action UpdateScore;
    public static Action GoToMainMenu;
    public static Action GameEnded;
    public static Action<int> CurrentScoreUpdate;
    public static Action<int> HighScoreUpdate;

}