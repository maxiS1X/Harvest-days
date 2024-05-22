using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public int MoneyValue = 0;
    [SerializeField] private TMP_Text MoneyText;


    private void Start()
    {
        MoneyValue = PlayerPrefs.GetInt("Money", 0);
        UpdateMoneyText();
    }

    public void UpdateMoneyText()
    {
        PlayerPrefs.SetInt("Money", MoneyValue);
        MoneyText.text = MoneyValue.ToString();
    }
}
