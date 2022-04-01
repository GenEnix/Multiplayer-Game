using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityMysteryBox : MonoBehaviour
{
    public Ability[] abilities;

    private HoldAbility holdAbility;

    void Awake()
    {
        holdAbility = FindObjectOfType<HoldAbility>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<HoldAbility>().currAbility == null)
            {
                RandomAbility();
                Destroy(gameObject);
            }
        }
    }

    public void RandomAbility()
    {
        holdAbility.currAbility = abilities[Random.Range(0, abilities.Length)];
        holdAbility.state = HoldAbility.AbilityState.ready;
    }
}
