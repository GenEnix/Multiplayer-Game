using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;

[CreateAssetMenu(menuName = "Abilities/Cloak")]
public class CloakAbility : Ability
{
    [Space(40)]
    public bool cloaked;

    public Material cloakMat;

    public override void Activate(GameObject parent)
    {
        cloakMat.SetInt("_Display", 1);
        cloaked = true;
    }

    public override void DisableAbility(GameObject parent)
    {
        cloakMat.SetInt("_Display", 0);
        cloaked = false;
    }
}
