using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorHand : RPSHand
{
    public override string Judge(string _name)
    {
        return _name switch
        {
            "R:Paper" => "lose",
            "R:Rock" => "win",
            _ => "tie"
        };
    }
}
