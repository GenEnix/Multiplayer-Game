using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Abilities/Shock")]
public class Shock_Ability : Ability
{
    [Space(40)]
    public float shockDist;
    public LayerMask enemyLayerMask;

    public Material shockMat;

    public GameObject shockEffectPrefab;
    GameObject currhockEffectPrefab;

    public override void Activate(GameObject parent)
    {
        Vector3 instantiatePos = new Vector3(parent.GetComponentInChildren<Camera>().gameObject.transform.position.x, parent.GetComponentInChildren<Camera>().gameObject.transform.position.y - 0.73f, parent.GetComponentInChildren<Camera>().gameObject.transform.position.z);
        currhockEffectPrefab = (GameObject) Instantiate(shockEffectPrefab, instantiatePos, parent.transform.rotation);

        shockMat.SetInt("_Display", 1);

        RaycastHit hit;
        if (Physics.Raycast(instantiatePos, parent.transform.forward, out hit, shockDist))
        {
            Debug.Log("Stunded");
        }
        Debug.DrawRay(instantiatePos, parent.transform.forward * shockDist, Color.yellow, 5);
    }

    public override void DisableAbility(GameObject parent)
    {
        Destroy(currhockEffectPrefab);

        shockMat.SetInt("_Display", 0);
    }
}
