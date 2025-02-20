using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text moneyCounter, workHarderLvlCostTxt, workHarderMaxLvlTxt, effLvlCostTxt, effMaxLvlTxt, primaryCostTxt, primaryLvlTxt, secondaryCostTxt, 
                    secondaryLvlTxt, uniEcoLvlTxt, uniEcoCostTxt, uniFoodLvlTxt, uniFoodCostTxt;
    [SerializeField] GameObject main, study, secondaryUI, uniEcoUI, uniFoodUI, cookButton, cookMenu;
    [SerializeField] GameObject story;

    void Start()
    {
        moneyCounter.text = "$" + PlayerStats.money;
        main.SetActive(false);
        story.SetActive(true);
        study.SetActive(false);
        cookMenu.SetActive(false);
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

    
}
