using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text moneyCounter, workHarderLvlCostTxt, workHarderMaxLvlTxt, effLvlCostTxt, effMaxLvlTxt, primaryCostTxt, primaryLvlTxt, secondaryCostTxt, 
                    secondaryLvlTxt, uniEcoLvlTxt, uniEcoCostTxt, uniFoodLvlTxt, uniFoodCostTxt;
    [SerializeField] GameObject main, study, secondaryUI, uniEcoUI, uniFoodUI, cookButton, cookMenu, moneyCounterUI;
    [SerializeField] GameObject story;

    void Start()
    {
        if(PlayerStats.loadGame && PlayerPrefs.HasKey("Save")){
            PlayerStats.money = PlayerPrefs.GetInt("Money", 0);
            PlayerStats.storyProgress = PlayerPrefs.GetInt("StoryProg");
            PlayerStats.workHarderLevel = PlayerPrefs.GetInt("WorkHarderLvl");
            PlayerStats.workHarderCost = PlayerPrefs.GetInt("WorkHarderCost");
            PlayerStats.maxLvl = PlayerPrefs.GetInt("MaxLvl");
            PlayerStats.efficiencyLvl = PlayerPrefs.GetInt("EffLvl");
            PlayerStats.efficiencyCost = PlayerPrefs.GetInt("EffCost");
            PlayerStats.primaryLvl = PlayerPrefs.GetInt("PrimaryLvl");
            PlayerStats.primaryCost = PlayerPrefs.GetInt("PrimaryCost");
            PlayerStats.secondaryCost = PlayerPrefs.GetInt("SecondaryCost");
            PlayerStats.secondaryLvl = PlayerPrefs.GetInt("SecondaryLvl");
            PlayerStats.uniEcoCost = PlayerPrefs.GetInt("UniEcoCost");
            PlayerStats.uniEcoLvl = PlayerPrefs.GetInt("UniEcoLvl");
            PlayerStats.uniFoodCost = PlayerPrefs.GetInt("UniFoodCost");
            PlayerStats.uniFoodLvl = PlayerPrefs.GetInt("UniFoodLvl");
            PlayerStats.efficiencyPower = double.Parse(PlayerPrefs.GetString("EffPower"));
            if(PlayerStats.primaryLvl == 6){
                secondaryUI.SetActive(true);
            }
            if(PlayerStats.secondaryLvl == 6){
                uniEcoUI.SetActive(true);
                uniFoodUI.SetActive(true);
            }
            if(PlayerStats.uniFoodLvl == 4){
                cookButton.SetActive(true);
            }
            if(PlayerPrefs.HasKey("Butter")){
                PlayerStats.butterBought = true;
            }
            if(PlayerPrefs.HasKey("Flour")){
                PlayerStats.flourBought = true;
            }
            if(PlayerPrefs.HasKey("CookPowder")){
                PlayerStats.cookingPowderBought = true;
            }
            if(PlayerPrefs.HasKey("Sugar")){
                PlayerStats.sugarBought = true;
            }
            if(PlayerPrefs.HasKey("Salt")){
                PlayerStats.saltBought = true;
            }
            if(PlayerPrefs.HasKey("Milk")){
                PlayerStats.milkBought = true;
            }
            if(PlayerPrefs.HasKey("Egg")){
                PlayerStats.eggBought = true;
            }
            main.SetActive(true);
            story.SetActive(false);
            study.SetActive(false);
            cookMenu.SetActive(false);
            moneyCounterUI.SetActive(true);
        }else{
            main.SetActive(false);
            story.SetActive(true);
            study.SetActive(false);
            cookMenu.SetActive(false);
        }
        moneyCounter.text = "$" + PlayerStats.money;
        workHarderLvlCostTxt.text = "Coste: $" + PlayerStats.workHarderCost;
        workHarderMaxLvlTxt.text = "Nivel: " + PlayerStats.workHarderLevel + "/" + PlayerStats.maxLvl;
        effLvlCostTxt.text = "Coste: $" + PlayerStats.efficiencyCost;
        effMaxLvlTxt.text = "Nivel: " + PlayerStats.efficiencyLvl + "/" + PlayerStats.maxLvl;
        primaryCostTxt.text = "Coste: $" + PlayerStats.primaryCost;
        secondaryCostTxt.text = "Coste: $" + PlayerStats.secondaryCost;
        primaryLvlTxt.text = "Nivel: " + PlayerStats.primaryLvl + "/6";
        secondaryLvlTxt.text = "Nivel: " + PlayerStats.secondaryLvl + "/6";
        uniEcoLvlTxt.text = "Nivel: " + PlayerStats.uniEcoLvl + "/5";
        uniEcoCostTxt.text = "Coste: $" + PlayerStats.uniEcoCost;
        uniFoodLvlTxt.text = "Nivel: " + PlayerStats.uniFoodLvl + "/4";
        uniFoodCostTxt.text = "Coste: $" + PlayerStats.uniFoodCost;
        
    }

    public void ContinueStory(){
        if(PlayerStats.storyProgress == 0){
            PlayerStats.storyProgress = 1;
            main.SetActive(true);
            story.SetActive(false);
        }
    }
    
    public void MakeMoney(){
        PlayerStats.money += (int)((1 + PlayerStats.workHarderLevel) * PlayerStats.efficiencyPower);
        moneyCounter.text = "$" + PlayerStats.money;
    }

    public void LevelWork(){
        if(PlayerStats.money >= PlayerStats.workHarderCost && PlayerStats.workHarderLevel < PlayerStats.maxLvl){
            PlayerStats.money -= PlayerStats.workHarderCost;
            PlayerStats.workHarderLevel++;
            PlayerStats.workHarderCost += 5 + PlayerStats.workHarderLevel;
            workHarderLvlCostTxt.text = "Coste: $" + PlayerStats.workHarderCost;
            workHarderMaxLvlTxt.text = "Nivel: " + PlayerStats.workHarderLevel + "/" + PlayerStats.maxLvl;
            moneyCounter.text = "$" + PlayerStats.money;
        }
    }

    public void LevelEfficiency(){
        if(PlayerStats.money >= PlayerStats.efficiencyCost && PlayerStats.efficiencyLvl < PlayerStats.maxLvl){
            PlayerStats.money -= PlayerStats.efficiencyCost;
            PlayerStats.efficiencyLvl++;
            PlayerStats.efficiencyPower += 0.1;
            PlayerStats.efficiencyCost += 100 + PlayerStats.efficiencyLvl;
            effLvlCostTxt.text = "Coste: $" + PlayerStats.efficiencyCost;
            effMaxLvlTxt.text = "Nivel: " + PlayerStats.efficiencyLvl + "/" + PlayerStats.maxLvl;
            moneyCounter.text = "$" + PlayerStats.money;
        }
    }

    public void LevelPrimary(){
        if(PlayerStats.money >= PlayerStats.primaryCost && PlayerStats.primaryLvl < 6){
            PlayerStats.money -= PlayerStats.primaryCost;
            PlayerStats.primaryLvl++;
            PlayerStats.maxLvl++;
            PlayerStats.primaryCost += 1000;
            primaryCostTxt.text = "Coste: $" + PlayerStats.primaryCost;
            primaryLvlTxt.text = "Nivel: " + PlayerStats.primaryLvl + "/6";
            moneyCounter.text = "$" + PlayerStats.money;
            workHarderMaxLvlTxt.text = "Nivel: " + PlayerStats.workHarderLevel + "/" + PlayerStats.maxLvl;
            effMaxLvlTxt.text = "Nivel: " + PlayerStats.efficiencyLvl + "/" + PlayerStats.maxLvl;
            if(PlayerStats.primaryLvl == 6){
                secondaryUI.SetActive(true);
                PlayerStats.maxLvl += 10;
                workHarderMaxLvlTxt.text = "Nivel: " + PlayerStats.workHarderLevel + "/" + PlayerStats.maxLvl;
                effMaxLvlTxt.text = "Nivel: " + PlayerStats.efficiencyLvl + "/" + PlayerStats.maxLvl;
            }
            
        }
        
    }

    public void LevelSecondary(){
        if(PlayerStats.money >= PlayerStats.secondaryCost && PlayerStats.secondaryLvl < 6){
            PlayerStats.money -= PlayerStats.secondaryCost;
            PlayerStats.secondaryLvl++;
            PlayerStats.maxLvl++;
            PlayerStats.secondaryCost += 100000;
            secondaryCostTxt.text = "Coste: $" + PlayerStats.secondaryCost;
            secondaryLvlTxt.text = "Nivel: " + PlayerStats.secondaryLvl + "/6";
            moneyCounter.text = "$" + PlayerStats.money;
            workHarderMaxLvlTxt.text = "Nivel: " + PlayerStats.workHarderLevel + "/" + PlayerStats.maxLvl;
            effMaxLvlTxt.text = "Nivel: " + PlayerStats.efficiencyLvl + "/" + PlayerStats.maxLvl;
            if(PlayerStats.secondaryLvl == 6){
                uniEcoUI.SetActive(true);
                uniFoodUI.SetActive(true);
                PlayerStats.maxLvl += 10;
                workHarderMaxLvlTxt.text = "Nivel: " + PlayerStats.workHarderLevel + "/" + PlayerStats.maxLvl;
                effMaxLvlTxt.text = "Nivel: " + PlayerStats.efficiencyLvl + "/" + PlayerStats.maxLvl;
            }
            
        }
        
    }

    public void LevelUniEco(){
        if(PlayerStats.money >= PlayerStats.uniEcoCost && PlayerStats.uniEcoLvl < 5){
            PlayerStats.money -= PlayerStats.uniEcoCost;
            PlayerStats.uniEcoLvl++;
            PlayerStats.maxLvl++;
            uniEcoLvlTxt.text = "Nivel: " + PlayerStats.uniEcoLvl + "/5";
            uniEcoCostTxt.text = "Coste: $" + PlayerStats.uniEcoCost;
            moneyCounter.text = "$" + PlayerStats.money;
            workHarderMaxLvlTxt.text = "Nivel: " + PlayerStats.workHarderLevel + "/" + PlayerStats.maxLvl;
            effMaxLvlTxt.text = "Nivel: " + PlayerStats.efficiencyLvl + "/" + PlayerStats.maxLvl;
            if(PlayerStats.uniEcoLvl == 5){
            PlayerStats.maxLvl += 10;
            workHarderMaxLvlTxt.text = "Nivel: " + PlayerStats.workHarderLevel + "/" + PlayerStats.maxLvl;
            effMaxLvlTxt.text = "Nivel: " + PlayerStats.efficiencyLvl + "/" + PlayerStats.maxLvl;
            }
        }
        
    }

    public void LevelUniFood(){
        if(PlayerStats.money >= PlayerStats.uniFoodCost && PlayerStats.uniFoodLvl < 4){
            PlayerStats.money -= PlayerStats.uniFoodCost;
            PlayerStats.uniFoodLvl++;
            uniFoodLvlTxt.text = "Nivel: " + PlayerStats.uniFoodLvl + "/4";
            uniFoodCostTxt.text = "Coste: $" + PlayerStats.uniFoodCost;
            moneyCounter.text = "$" + PlayerStats.money;
            if(PlayerStats.uniFoodLvl == 4){
            cookButton.SetActive(true);
            PlayerStats.maxLvl += 10;
            workHarderMaxLvlTxt.text = "Nivel: " + PlayerStats.workHarderLevel + "/" + PlayerStats.maxLvl;
            effMaxLvlTxt.text = "Nivel: " + PlayerStats.efficiencyLvl + "/" + PlayerStats.maxLvl;
            }

        }
        
    }

    public void SaveGame(){
        PlayerPrefs.SetInt("Money", PlayerStats.money);
        PlayerPrefs.SetInt("StoryProg", PlayerStats.storyProgress);
        PlayerPrefs.SetInt("WorkHarderLvl", PlayerStats.workHarderLevel);
        PlayerPrefs.SetInt("WorkHarderCost", PlayerStats.workHarderCost);
        PlayerPrefs.SetInt("MaxLvl", PlayerStats.maxLvl);
        PlayerPrefs.SetInt("EffLvl", PlayerStats.efficiencyLvl);
        PlayerPrefs.SetInt("EffCost", PlayerStats.efficiencyCost);
        PlayerPrefs.SetInt("PrimaryLvl", PlayerStats.primaryLvl);
        PlayerPrefs.SetInt("PrimaryCost", PlayerStats.primaryCost);
        PlayerPrefs.SetInt("SecondaryCost", PlayerStats.secondaryCost);
        PlayerPrefs.SetInt("SecondaryLvl", PlayerStats.secondaryLvl);
        PlayerPrefs.SetInt("UniEcoCost", PlayerStats.uniEcoCost);
        PlayerPrefs.SetInt("UniEcoLvl", PlayerStats.uniEcoLvl);
        PlayerPrefs.SetInt("UniFoodLvl", PlayerStats.uniFoodLvl);
        PlayerPrefs.SetInt("UniFoodCost", PlayerStats.uniFoodCost);
        PlayerPrefs.SetString("EffPower", PlayerStats.efficiencyPower.ToString());
        if(PlayerStats.butterBought){
            PlayerPrefs.SetInt("Butter", 1);
        }
        if(PlayerStats.flourBought){
            PlayerPrefs.SetInt("Flour", 1);
        }
        if(PlayerStats.cookingPowderBought){
            PlayerPrefs.SetInt("CookPowder", 1);
        }
        if(PlayerStats.sugarBought){
            PlayerPrefs.SetInt("Sugar", 1);
        }
        if(PlayerStats.saltBought){
            PlayerPrefs.SetInt("Salt", 1);
        }
        if(PlayerStats.milkBought){
            PlayerPrefs.SetInt("Milk", 1);
        }
        if(PlayerStats.eggBought){
            PlayerPrefs.SetInt("Egg", 1);
        }
        PlayerPrefs.SetInt("Save", 1);
    }
    
    public void Exitgame(){
        Application.Quit();
    }

    
}
