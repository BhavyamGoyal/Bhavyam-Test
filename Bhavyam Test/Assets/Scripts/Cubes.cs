using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Cubes{

    // Use this for initialization
    public string colour;
    public int score;

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    public string Colour
    {
        get
        {
            return colour;
        }

        set
        {
            colour = value;
        }
    }
}
