using UnityEngine;
using UnityEngine.SceneManagement;

public class MMManager : MonoBehaviour
{

    public void StartGame(){
        SceneManager.LoadScene(sceneName:"Game");
    }

    public void Cheats(){
        PlayerStats.money = 999999999;
    }

    public void Load(){
        PlayerStats.loadGame = true;
    }

    public void Exitmenu(){
        Application.Quit();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
