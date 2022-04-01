using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Abilities/Dart")]
public class DartAbility : Ability
{
    [Space(40)]
    public float speedMultiplier;

    public Material dartMat;

    public override void Activate(GameObject parent)
    {
        Player_Move move = parent.GetComponent<Player_Move>();
        move.speedMultiplierTarget = speedMultiplier;
        move.isDart = true;

        dartMat.SetInt("_Display", 1);
    }

    public override void DisableAbility(GameObject parent)
    {
        Player_Move move = parent.GetComponent<Player_Move>();
        move.speedMultiplierTarget = 1;
        move.isDart = false;

        dartMat.SetInt("_Display", 0);
    }
}
