using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text moneyCounter, workHarderLvlCostTxt, workHarderMaxLvlTxt, effLvlCostTxt, effMaxLvlTxt;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
