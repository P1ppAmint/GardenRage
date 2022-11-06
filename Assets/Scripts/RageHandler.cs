using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class RageHandler : MonoBehaviour
{
    enum RagingObject
    {
        Player,
        MeleeEnemy,
        RangedEnemy
    }

    // defining what type the object is that has the script hanging on it
    // needs to be set from outside so the script knows how to handle (we tell script 'this is player' from outside and script acts accordingly)
    [SerializeField]
    private RagingObject entityType;
    [SerializeField]
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        switch (entityType)
        {
            case RagingObject.Player:
                gameManager.onEnterRageMode.AddListener(PlayerRageEnter);
                gameManager.onExitRageMode.AddListener(PlayerRageExit);
                break;
            case RagingObject.MeleeEnemy:
                // wait for onrageEvent events
                gameManager.onEnterRageMode.AddListener(MeleeRageEnter);
                gameManager.onExitRageMode.AddListener(MeleeRageExit);
                break;
            case RagingObject.RangedEnemy:
                gameManager.onEnterRageMode.AddListener(RangedRageEnter);
                gameManager.onExitRageMode.AddListener(RangedRageExit);
                break;
            default:
                break;
        }
    }

    
    void PlayerRageEnter()
    {
        // activates weapon
        // get list of weapons
        for (int index=0; index < transform.childCount; index++)
        {
            transform.GetChild(index).gameObject.SetActive(true);
        }
    }
    void PlayerRageExit()
    {
        // deactivate weapons of player
        for (int index = 0; index < transform.childCount; index++)
        {
            transform.GetChild(index).gameObject.SetActive(false);
        }
    }

    void MeleeRageEnter()
    {
        // set damage?
    }
    void MeleeRageExit()
    {
        // set damage?
    }

    void RangedRageEnter()
    {
        // deactivate weapons of ranged enemies
        for (int index = 0; index < transform.childCount; index++)
        {
            transform.GetChild(index).gameObject.SetActive(true);
        }
    }
    void RangedRageExit()
    {
        // deactivate weapons of ranged enemies
        for (int index = 0; index < transform.childCount; index++)
        {
            transform.GetChild(index).gameObject.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        // if global variable enemycoutner > threshold (10 for the start) trigger rage mode
        // -> change enemy homing to player
        // -> switch back to ragemode adter enemy coutner drops below 
        // want to have a weapon actvated with the ranged, melee dont have a weapon
    }

    // define 6 methods, becuse of performance reasones
    // method paramters in addlistener method is complicated and overengineered for this project

  

}
