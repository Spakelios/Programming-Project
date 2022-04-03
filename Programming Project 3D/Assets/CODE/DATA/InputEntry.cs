using System;

[Serializable]
public class InputEntry
{
    public static string playerName;
    public int points;

    public InputEntry(string name, int points)
    {
        playerName = name;
        this.points = points;
    }
}
