using UnityEngine;
using System.Collections;

public abstract class Ability : ScriptableObject
{
    public new string name;
    public Sprite icon;
    public float activeTime;

    public virtual void Activate(GameObject parent) {}
    public virtual void DisableAbility(GameObject parent) {}
}
