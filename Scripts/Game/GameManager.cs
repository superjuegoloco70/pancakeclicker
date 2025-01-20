using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text moneyCounter;
    [SerializeField] GameObject main, story;

    void Start()
    {
        this.moneyCounter.text = "$" + PlayerStats.money.ToString();
        if(PlayerStats.storyProgress == 0){
            main.SetActive(false);
            story.SetActive(true);
        }
    }

    public void ContinueStory(){
        if(PlayerStats.storyProgress == 0){
            PlayerStats.storyProgress = -1;
            main.SetActive(true);
            story.SetActive(false);
        }
    }

    
    public void MakeMoney(){
        PlayerStats.money += 1;
        moneyCounter.text = "$" + PlayerStats.money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
