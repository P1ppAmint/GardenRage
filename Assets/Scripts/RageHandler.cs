using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;

public class RageHandler : MonoBehaviour
{
    enum RagingObject
    {
        Player,
        MeleeEnemy,
        RangedEnemy,
        Object,
        PostProcessing
    }

    

    // defining what type the object is that has the script hanging on it
    // needs to be set from outside so the script knows how to handle (we tell script 'this is player' from outside and script acts accordingly)
    private EntityStats stats;

    [SerializeField]
    private RagingObject entityType;

    [SerializeField]
    private Sprite normalmodeSprite;
    [SerializeField]
    private Sprite ragemodeSprite;


    public void Start()
    {
         //sets stats and logs if stats 
        if(!TryGetComponent<EntityStats>(out stats) && entityType != RagingObject.Object )    Debug.Log($"No Stats Script found in {gameObject.name} ");        

        switch (entityType)
        {
            case RagingObject.Player:
                GameManager.onEnterRageMode.AddListener(PlayerRageEnter);
                GameManager.onExitRageMode.AddListener(PlayerRageExit);
                break;
            case RagingObject.MeleeEnemy:
                // wait for onrageEvent events
                GameManager.onEnterRageMode.AddListener(MeleeRageEnter);
                GameManager.onExitRageMode.AddListener(MeleeRageExit);
                break;
            case RagingObject.RangedEnemy:
                GameManager.onEnterRageMode.AddListener(RangedRageEnter);
                GameManager.onExitRageMode.AddListener(RangedRageExit);
                break;
            case RagingObject.Object:
                GameManager.onEnterRageMode.AddListener(ObjectRageEnter);
                GameManager.onExitRageMode.AddListener(ObjectRageExit);
                break;
            case RagingObject.PostProcessing:
                GameManager.onEnterRageMode.AddListener(PostProcessingRageEnter);
                GameManager.onExitRageMode.AddListener(PostProcessingRageExit);
                break;
            default:
                break;
        }
    }

    
    void PlayerRageEnter()
    {
        // activates weapon
        // get list of weapons
        //Debug.Log("Executes RageEnterScript");
        if (TryGetComponent<Animator>(out Animator animator)) animator.SetBool("isRaging", true);

        for (int index=0; index < transform.childCount; index++)
        {
            Debug.Log(transform.GetChild(index).name);
            transform.GetChild(index).gameObject.SetActive(true);
        }
    }
    void PlayerRageExit()
    {
        
        if (TryGetComponent<Animator>(out Animator animator)) animator.SetBool("isRaging", false);
        // deactivate weapons of player
        for (int index = 0; index < transform.childCount; index++)
        {
            transform.GetChild(index).gameObject.SetActive(false);
        }
    }

    void MeleeRageEnter()
    {
        // set damage?        
        if (TryGetComponent<Animator>(out Animator animator)) animator.SetBool("isRaging", true);
    }
    void MeleeRageExit()
    {
        // set damage?
        if (TryGetComponent<Animator>(out Animator animator))  animator.SetBool("isRaging", false);        
    }

    void RangedRageEnter()
    {
        if (TryGetComponent<Animator>(out Animator animator)) animator.SetBool("isRaging", true);
        // deactivate weapons of ranged enemies
        for (int index = 0; index < transform.childCount; index++)
        {
            transform.GetChild(index).gameObject.SetActive(true);
        }
    }
    void RangedRageExit()
    {
        // deactivate weapons of ranged enemies
        if (TryGetComponent<Animator>(out Animator animator)) animator.SetBool("isRaging", false);

        for (int index = 0; index < transform.childCount; index++)
        {
            transform.GetChild(index).gameObject.SetActive(false);
        }
    }

    void ObjectRageEnter()
    {
        if (TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer)) spriteRenderer.sprite = ragemodeSprite;
    }
    
    void ObjectRageExit()
    {
        if (TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer)) spriteRenderer.sprite = normalmodeSprite;
    }

    //TODO
    void PostProcessingRageEnter() 
    {
        //if (TryGetComponent<Volume>(out Volume volume))
        //{
        //    (volume.sharedProfile.
            
            
            
        //}
    }

    void PostProcessingRageExit()
    {

    }



    // Update is called once per frame
    //void Update()
    //{
    //    // if global variable enemycoutner > threshold (10 for the start) trigger rage mode
    //    // -> change enemy homing to player
    //    // -> switch back to ragemode adter enemy coutner drops below 
    //    // want to have a weapon actvated with the ranged, melee dont have a weapon
    //}

    // define 6 methods, becuse of performance reasones
    // method paramters in addlistener method is complicated and overengineered for this project



}
