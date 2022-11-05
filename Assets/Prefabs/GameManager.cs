using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{

    public bool isRaging;

    [SerializeField]
    private int rageActivationLimit;

    UnityEvent onEnterRageMode;
    UnityEvent onExitRageMode;

    //TODO remove
    public GameObject testtarget;

    private static List<GameObject> enemyList;

    public static List<GameObject> EnemyList { get => enemyList; private set => enemyList = value; }

    void Awake()
    {
        EnemyList = new List<GameObject>();
        isRaging = false;

        //TODO remove
        EnemyList.Add(testtarget);
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

    public void AddEnemyToList(GameObject enemy)
    {
        if (enemy == null) Debug.Log("Enemy you're trying to add is null");

        EnemyList.Add(enemy);
        ChangeRageMode();
    }


    public void ChangeRageMode()
    {
        if(EnemyList.Count >= rageActivationLimit)
        {
            if (isRaging == true) return;
            isRaging = true;
            onExitRageMode.Invoke();
        }
        else
        {
            if (isRaging == false) return;
            isRaging = false;
            onExitRageMode.Invoke();
        }
    }   


}
