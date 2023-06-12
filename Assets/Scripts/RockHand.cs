using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHand : RPSHand
{
    public override string Judge(string _name)
    {
        return _name switch
        {
            "R:Paper" => "win",
            "R:Rock" => "tie",
            _ => "lose"
        };
    }
}
