using System;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private PlayerHPSystem playerHP;

    void Update()
    {
        healthBar.fillAmount = (float) playerHP.GetHP() / playerHP.GetMaxHP(); ;
    }
}
