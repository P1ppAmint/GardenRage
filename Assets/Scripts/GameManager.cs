using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    

    private const bool V = false;
    private static bool isRaging = V;

    private static List<GameObject> enemyList = new List<GameObject>();

    [SerializeField]
    private int rageActivationLimit;

    
    public static UnityEvent onEnterRageMode = new();
    public static UnityEvent onExitRageMode = new();


    public static bool IsRaging { get => isRaging; private set => isRaging = value; }
    public static List<GameObject> EnemyList { get => enemyList; private set => enemyList = value; }
    public static int RageActivationLimit { get; set; }


    private void Awake()
    {
        RageActivationLimit = rageActivationLimit;
    }

    public static void RemoveEnemyFromList(GameObject enemy)
    {
        if (enemy == null)
        {
            Debug.Log("Enemy you're trying to remove is null");
            return;
        }

        EnemyList.Remove(enemy);
        ChangeRageMode();
    }

    public static void AddEnemyToList(GameObject enemy)
    {
        if (enemy == null)
        {
            Debug.Log("Enemy you're trying to add is null");
            return;
        }        

        EnemyList.Add(enemy);
        ChangeRageMode();
    }


    private static void ChangeRageMode()
    {
        if(EnemyList.Count >= RageActivationLimit)
        {
            if (IsRaging == true) return;
            IsRaging = true;            
            onEnterRageMode.Invoke();
            //Debug.Log("Invoked EnterRageMode");
        }
        else
        {
            if (IsRaging == false) return;
            IsRaging = false;
            onExitRageMode.Invoke();
        }
    }   


}
