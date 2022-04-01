using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealthBar : MonoBehaviour
{
    [Header("Stats")]
    public new string name;
    [Space(10)]
    public float currentHealth;
    public float maxHealth;
    
    private GameObject playerCam;


    [Header("UI")]
    public Image healthBarFill;
    public TMP_Text nameText;

    void Start()
    {
        nameText.text = name;

        //currentHealth = maxHealth;
    }

    private void Awake()
    {
        playerCam = FindObjectOfType<Player_Move>().playerCam;
    }

    private void OnValidate()
    {
        nameText.text = name;
        DisplayHealth();
    }

    void Update()
    {
        DisplayHealth();

        transform.LookAt(playerCam.transform);
    }

    public void DisplayHealth()
    {
        healthBarFill.fillAmount = currentHealth / maxHealth;
    }
}
