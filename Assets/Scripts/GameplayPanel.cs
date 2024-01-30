using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayPanel : MonoBehaviour
{
    [SerializeField] private Image healthFillImage;
    [SerializeField] private Image manaFillImage;


    private void Start()
    {
        FindObjectOfType<PlayerController>().healthChanged += UpdateHealth;
        FindObjectOfType<PlayerController>().manaChanged += UpdateMana;
    }

    public void UpdateHealth(float healthValue)
    {
        float fillAmount = Mathf.Clamp(healthValue, 0f, 100) / 100;
        healthFillImage.fillAmount = fillAmount;
    }
    public void UpdateMana(int manaValue)
    {
        float fillAmount = Mathf.Clamp(manaValue, 0f, 100) / 100;
        manaFillImage.fillAmount = fillAmount;
    }
}
