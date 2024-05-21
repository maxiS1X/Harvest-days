using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public int MoneyValue = 0;
    [SerializeField] private TMP_Text MoneyText;
    
    
    private void Awake()
    {
        MoneyValue = PlayerPrefs.GetInt("Money", 0);
        UpdateMoneyText();
    }
   // private void Start()
   // {
       // UpdateMoneyText();
   // }
    public void UpdateMoneyText()
    {
        PlayerPrefs.SetInt("Money", MoneyValue);
        MoneyText.text = MoneyValue.ToString();
    }


}
