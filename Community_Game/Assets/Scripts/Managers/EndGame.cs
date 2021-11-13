using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    /************MANAGER************/

    bool GameHasEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void GameOver()
    {
        if(GameHasEnded == false)
        {
            GameHasEnded = true;
            //Invoke("Restart", 1f);

            ShowOverMenu();
        }
    }

    /************HELPER FUNCTIONS************/
    void ShowOverMenu()
    {
        SceneManager.LoadScene(2);
    }
}
