using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{

    public bool isRaging;

    [SerializeField]
    private  int rageActivationLimit;

    public UnityEvent onEnterRageMode;
    public UnityEvent onExitRageMode;
    private List<GameObject> enemyList;
    private Animator[] animList;

    public List<GameObject> EnemyList { get => enemyList; private set => enemyList = value; }

    void Awake()
    {
        EnemyList = new List<GameObject>();
        isRaging = false;
        animList = FindObjectsOfType<Animator>();
    }

    private void Update()
    {
        //For Debug Purpose
        //Debug.Log($"Raging: {isRaging}");
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        if (enemy == null) Debug.Log("Enemy you're trying to remove is null");

        EnemyList.Remove(enemy);
        ChangeRageMode();
    }

    public  void AddEnemyToList(GameObject enemy)
    {
        if (enemy == null) Debug.Log("Enemy you're trying to add is null");

        EnemyList.Add(enemy);
        ChangeRageMode();
    }


    private  void ChangeRageMode()
    {
        if(EnemyList.Count >= rageActivationLimit)
        {
            if (isRaging == true) return;
            isRaging = true;
            foreach (Animator anim in animList)
            {
                anim.SetBool("isRaging", true);
            }
            onEnterRageMode.Invoke();
            Debug.Log("Invoked EnterRageMode");

        }
        else
        {
            if (isRaging == false) return;
            isRaging = false;
            foreach (Animator anim in animList)
            {
            anim.SetBool("isRaging", false);
            }
            onExitRageMode.Invoke();
        }
    }   


}
