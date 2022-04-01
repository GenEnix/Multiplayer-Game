using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldAbility : MonoBehaviour
{
    public Ability currAbility;
    float activeTime;

    public enum AbilityState
    {
        ready,
        active,
        uesed
    }
    public AbilityState state;

    [Header("UI")]
    public Sprite defaultIcon;
    public Image abilityIcon;
    public Image abilityFillImg;



    [Space(20)]
    public Color iconReadyColor;
    public Color iconActiveColor;
    public Color iconUesedColor;

    [Space(20)]
    public Color fillReadyColor;
    public Color fillActiveColor;
    public Color fillUesedColor;

    private void OnValidate()
    {
        if (currAbility == null)
            return;

        switch(state)
        {
            case AbilityState.ready:
                abilityIcon.sprite = currAbility.icon;
                abilityIcon.color = iconReadyColor;
                abilityFillImg.color = fillReadyColor;
            break;

            case AbilityState.active:
                abilityIcon.color = iconActiveColor;
                abilityFillImg.color = fillActiveColor;
            break;

            case AbilityState.uesed:
                abilityIcon.color = iconUesedColor;
                abilityFillImg.color = fillUesedColor;
                abilityIcon.sprite = defaultIcon;
            break;
        }

        if (currAbility == null)
            state = AbilityState.uesed;
    }

    private void Start()
    {
        abilityIcon.color = iconUesedColor;
        abilityFillImg.color = fillUesedColor;
        abilityIcon.sprite = defaultIcon;

        currAbility = null;
    }
    
    void Update()
    {
        if (currAbility == null)
            return;

        if (currAbility != null)
            abilityIcon.sprite = currAbility.icon;

        if (currAbility == null)
            state = AbilityState.uesed;

        switch(state)
        {
            case AbilityState.ready:
                abilityIcon.sprite = currAbility.icon;
                abilityFillImg.fillAmount = 1;

                abilityIcon.color = iconReadyColor;
                abilityFillImg.color = fillReadyColor;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currAbility.Activate(gameObject);
                    state = AbilityState.active;
                    activeTime = currAbility.activeTime;
                }
            break;

            case AbilityState.active:
                abilityFillImg.fillAmount = activeTime / currAbility.activeTime;

                abilityIcon.color = iconActiveColor;
                abilityFillImg.color = fillActiveColor;

                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.uesed;
                    currAbility.DisableAbility(gameObject);
                    abilityFillImg.fillAmount = 0;
                }
            break;

            case AbilityState.uesed:
                abilityIcon.color = iconUesedColor;
                abilityFillImg.color = fillUesedColor;
                abilityIcon.sprite = defaultIcon;

                currAbility = null;
            break;
        }
    }
}
