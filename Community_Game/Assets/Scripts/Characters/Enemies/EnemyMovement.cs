using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    /************ENEMIE(S)************/

    private PlayerSelect AllPlayerDetails;

    //private Rigidbody2D rigidBody;

    private Transform mainTarget;
    private Transform switchTarget;
    private Transform[] Targets;

    private Vector2 lookDirection;
 
    private float seekRadius = 4f;
    //private float attackRadius = 3f;

    private State currentState;

    private enum State
    {    
        ChasingMain,
        ChasingPlayer,
        
    }


    // Start is called before the first frame update
    void Start()
    {
        //rigidBody = this.GetComponent<Rigidbody2D>();
        mainTarget = GameObject.Find("House").transform;
        AllPlayerDetails = GameObject.Find("GameManager").GetComponent<PlayerSelect>();

        setTargets();

        currentState = State.ChasingMain;
        lookDirection = (Vector2)mainTarget.position.normalized;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(Vector2.Distance(transform.position, mainTarget.position) > 50f){
            //respawn
        }

        SwitchTargetPriority();

        switch (currentState)
        {
            default:
            
            case State.ChasingMain:

                Debug.Log("Chase target");

                

                lookDirection.x = mainTarget.position.x;
                lookDirection.y = mainTarget.position.y;

                break;

            case State.ChasingPlayer:

                Debug.Log("Chase Player(s)");

                //SwitchTargetPriority();

                lookDirection.x = switchTarget.position.x;
                lookDirection.y = switchTarget.position.y;

                break;
        }

        transform.position = Vector2.MoveTowards(transform.position, lookDirection, 2f * Time.deltaTime);
        //directionToFace = new Vector2(lookDirection.x - transform.position.x, lookDirection.y - transform.position.y);
    }

    /************HELPER FUNCTIONS************/
    void SwitchTargetPriority()
    {
        //Switch target from array/the base, based on distance
        bool found = false;

        Debug.Log("target : " + Targets);
        for(int i =0; i < Targets.Length; i++)
        {
            if (Targets[i] == null)
            {
                setTargets();
                return;
            }

            if (Vector2.Distance((Vector2)transform.position, (Vector2)Targets[i].position) < seekRadius)
            {
                found = true;
                switchTarget = Targets[i];
                currentState = State.ChasingPlayer;
            }
        }

        if(found == false)
        {
            currentState = State.ChasingMain;
        }
    }

    void setTargets()
    {
        //get targets from playerselect manager

        Targets = new Transform[AllPlayerDetails.NumberOFPlayers];
        GameObject[] tempTargets = AllPlayerDetails.getPlayers();

        for (int i =0; i< tempTargets.Length; i++)
        {
            Targets[i] = tempTargets[i].transform;
        }
        
        /*Targets[0] = GameObject.Find("PlayerOne (Gunner)").transform;
        Targets[1] = GameObject.Find("PlayerTwo (Melee)").transform;*/
    }
}
