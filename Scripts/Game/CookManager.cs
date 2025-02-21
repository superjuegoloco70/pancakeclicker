using UnityEngine;
using TMPro;

public class CookManager : MonoBehaviour
{
    int ingCost = 500000;

    [SerializeField] TMP_Text butterTxt, flourTxt, cookingPowderTxt, sugarTxt, saltTxt, milkTxt, eggTxt, moneyTxt;
    [SerializeField] GameObject cookButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        butterTxt.text = "Coste: $"+ingCost+"/Comprado: NO";
        flourTxt.text = "Coste: $"+ingCost+"/Comprado: NO";
        cookingPowderTxt.text = "Coste: $"+ingCost+"/Comprado: NO";
        sugarTxt.text = "Coste: $"+ingCost+"/Comprado: NO";
        saltTxt.text = "Coste: $"+ingCost+"/Comprado: NO";
        milkTxt.text = "Coste: $"+ingCost+"/Comprado: NO";
        eggTxt.text = "Coste: $"+ingCost+"/Comprado: NO";
        if(PlayerStats.butterBought){
            butterTxt.text = "Coste: $"+ingCost+"/Comprado: SI";
        }
        if(PlayerStats.flourBought){
            flourTxt.text = "Coste: $"+ingCost+"/Comprado: SI";
        }
        if(PlayerStats.cookingPowderBought){
            cookingPowderTxt.text = "Coste: $"+ingCost+"/Comprado: SI";
        }
        if(PlayerStats.sugarBought){
            sugarTxt.text = "Coste: $"+ingCost+"/Comprado: SI";
        }
        if(PlayerStats.saltBought){
            saltTxt.text = "Coste: $"+ingCost+"/Comprado: SI";
        }
        if(PlayerStats.milkBought){
            milkTxt.text = "Coste: $"+ingCost+"/Comprado: SI";
        }
        if(PlayerStats.eggBought){
            eggTxt.text = "Coste: $"+ingCost+"/Comprado: SI";
        }
    }

    public void BuyButter(){
        if(PlayerStats.money >= ingCost && !PlayerStats.butterBought){
            PlayerStats.butterBought = true;
            PlayerStats.money -= ingCost;
            butterTxt.text = "Coste: $"+ingCost+"/Comprado: SI";
            moneyTxt.text = "$" + PlayerStats.money;
        }
    }

    public void BuyFlour(){
        if(PlayerStats.money >= ingCost && !PlayerStats.flourBought){
            PlayerStats.flourBought = true;
            PlayerStats.money -= ingCost;
            flourTxt.text = "Coste: $"+ingCost+"/Comprado: SI";
            moneyTxt.text = "$" + PlayerStats.money;
        }
    }

    public void BuyCookingPowder(){
        if(PlayerStats.money >= ingCost && !PlayerStats.cookingPowderBought){
            PlayerStats.cookingPowderBought = true;
            PlayerStats.money -= ingCost;
            cookingPowderTxt.text = "Coste: $"+ingCost+"/Comprado: SI";
            moneyTxt.text = "$" + PlayerStats.money;
        }
    }

    public void BuySugar(){
        if(PlayerStats.money >= ingCost && !PlayerStats.sugarBought){
            PlayerStats.sugarBought = true;
            PlayerStats.money -= ingCost;
            sugarTxt.text = "Coste: $"+ingCost+"/Comprado: SI";
            moneyTxt.text = "$" + PlayerStats.money;
        }
    }

    public void BuySalt(){
        if(PlayerStats.money >= ingCost && !PlayerStats.saltBought){
            PlayerStats.saltBought = true;
            PlayerStats.money -= ingCost;
            saltTxt.text = "Coste: $"+ingCost+"/Comprado: SI";
            moneyTxt.text = "$" + PlayerStats.money;
        }
    }

    public void BuyMilk(){
        if(PlayerStats.money >= ingCost && !PlayerStats.milkBought){
            PlayerStats.milkBought = true;
            PlayerStats.money -= ingCost;
            milkTxt.text = "Coste: $"+ingCost+"/Comprado: SI";
            moneyTxt.text = "$" + PlayerStats.money;
        }
    }

    public void BuyEgg(){
        if(PlayerStats.money >= ingCost && !PlayerStats.eggBought){
            PlayerStats.eggBought = true;
            PlayerStats.money -= ingCost;
            eggTxt.text = "Coste: $"+ingCost+"/Comprado: SI";
            moneyTxt.text = "$" + PlayerStats.money;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.butterBought && PlayerStats.flourBought && PlayerStats.cookingPowderBought && PlayerStats.sugarBought && PlayerStats.saltBought && PlayerStats.milkBought && PlayerStats.eggBought){
            cookButton.SetActive(true);
        }
    }
}
