using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public int MoneyValue = 0;
    [SerializeField] private TMP_Text MoneyText;

    private void Start()
    {
        UpdateMoneyText();
    }
    public void UpdateMoneyText()
    {
        MoneyText.text = MoneyValue.ToString();
    }
}
