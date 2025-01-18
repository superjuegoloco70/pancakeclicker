using UnityEngine;
using UnityEngine.SceneManagement;

public class MMManager : MonoBehaviour
{

    public void StartGame(){
        SceneManager.LoadScene(sceneName:"Game");
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
