using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    /************CAMERA************/

    private Transform targetPlayer; //Player to switch too
    private Transform ZeroPos; //(0,0,0)

    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.Find("PlayerOne (Gunner)").transform;
        ZeroPos = GameObject.Find("ZeroPosition").transform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = new Vector3(targetPlayer.position.x, targetPlayer.position.y, transform.position.z); //follow player
    }

    /************HELPER FUNCTIONS************/
    public void SwitchPlayer(Transform _transform)
    {
        targetPlayer = _transform; 
    }

    public void Reset()
    {
        targetPlayer = ZeroPos;
    }
}
