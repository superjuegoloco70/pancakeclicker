using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text moneyCounter, workHarderLvlCostTxt, workHarderMaxLvlTxt, effLvlCostTxt, effMaxLvlTxt, primaryCostTxt, primaryLvlTxt, secondaryCostTxt, 
                    secondaryLvlTxt;
    [SerializeField] GameObject main, study;
    [SerializeField] GameObject story;

    void Start()
    {
        moneyCounter.text = "$" + PlayerStats.money;
        main.SetActive(false);
        story.SetActive(true);
        study.SetActive(false);
        workHarderLvlCostTxt.text = "Coste: $" + PlayerStats.workHarderCost;
        workHarderMaxLvlTxt.text = "Nivel: " + PlayerStats.workHarderLevel + "/" + PlayerStats.maxLvl;
        effLvlCostTxt.text = "Coste: $" + PlayerStats.efficiencyCost;
        effMaxLvlTxt.text = "Nivel: " + PlayerStats.efficiencyLvl + "/" + PlayerStats.maxLvl;
        primaryCostTxt.text = "Coste: $" + PlayerStats.primaryCost;
        secondaryCostTxt.text = "Coste: $" + PlayerStats.secondaryCost;
        primaryLvlTxt.text = "Nivel: " + PlayerStats.primaryLvl + "/6";
        secondaryLvlTxt.text = "Nivel: " + PlayerStats.secondaryLvl + "/6";
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
