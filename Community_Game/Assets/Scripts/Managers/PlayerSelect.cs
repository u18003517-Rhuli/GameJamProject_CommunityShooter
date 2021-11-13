using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    /************MANAGER************/

    public int NumberOFPlayers;
    GameObject[] Players;
    GameObject currentPlayer;
    CameraMovement camMove;
    EndGame gameEnder;

    // Start is called before the first frame update
    void Start()
    {
        camMove = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        gameEnder = this.GetComponent<EndGame>();

        NumberOFPlayers = 2;

        Players = new GameObject[NumberOFPlayers];

        Players[0] = GameObject.Find("PlayerOne (Gunner)");
        Players[1] = GameObject.Find("PlayerTwo (Melee)");

        ChangePlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangePlayer(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangePlayer(1);
        }

        /*if ((NumberOFPlayers == 0) || (Players.Length <= 0) )
        {
            gameEnder.GameOver();
        }*/
    }


    /************HELPER FUNCTIONS************/
    public void ChangePlayer(int index)
    {
        for (int i = 0; i < Players.Length; i++)
        {
            if (i != index)
            {
                //Debug.Log(i + " checking here nots...");
                Players[i].GetComponent<PlayerMovement>().enabled = false;
                //Players[i].GetComponent<PlayerAI>().enabled = true;
                //setAttributes(Players[i],i, false);
            }
            else
            {
                //Debug.Log(i + " checking here is...");
                Players[i].GetComponent<PlayerMovement>().enabled = true;
                //Players[i].GetComponent<PlayerAI>().enabled = false;
                camMove.SwitchPlayer(Players[i].transform);
                //setAttributes(Players[i],i, true);
            }
        }
    }

    public void removePlayer(GameObject playerObject)
    {
        /*if(Players.Length == 1)
        {
            if(Players[0] == playerObject)
            {
                gameEnder.GameOver();
            }
        }*/

        int index = -1;
        GameObject[] temp = Players;
        NumberOFPlayers = NumberOFPlayers - 1;



        for (int i = 0; i < Players.Length; i++)
        {
            if (Players[i] == playerObject)
            {
                index = i;
            }
        }

        Players = new GameObject[NumberOFPlayers];

        for (int i = 0; i < Players.Length; i++)
        {
            if (i < index)
            {
                Players[i] = temp[i];
            }
            else if (i >= index)
            {
                Players[i] = temp[i + 1];
            }
        }

        if ((NumberOFPlayers <= 0) || (Players.Length <= 0))
        {
            camMove.Reset();
            gameEnder.GameOver();
        }
        else
        {
            ChangePlayer(0);
        }
    }


    public GameObject[] getPlayers()
    {
        return Players;
    }


    private void setAttributes(GameObject Player,int index , bool flag)
    {
        switch (index)
        {
            default:

            case 0:
                Player.GetComponent<PlayerShooting>().enabled = flag;
               
                break;
            case 1:
                //Player.GetComponent<PlayerMelee>().enabled = flag;
                break;

        }
    }


}
