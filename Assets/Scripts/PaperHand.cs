using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperHand : RPSHand
{
    public override string Judge(string _name)
    {
        return _name switch
        {
            "R:Paper" => "tie",
            "R:Rock" => "lose",
            _ => "win"
        };
    }
}