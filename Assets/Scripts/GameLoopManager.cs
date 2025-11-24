using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    private static Queue<int> EnemyIDsToSummon;

    public bool LoopShouldEnd;

    void Start()
    {
        EnemyIDsToSummon = new Queue<int>();
        EntitySummoner.Init();

        StartCoroutine(GameLoop());
        InvokeRepeating("SummonTest", 0f, 1f);
        InvokeRepeating("RemoveTest", 0f, 0.5f);
    }

    void RemoveTest()
    {
        if (EntitySummoner.EnemiesInGame.Count > 0)
        {
            EntitySummoner.RemoveEnemy(EntitySummoner.EnemiesInGame[1]);
        }
    }

    void SummonTest()
    {
        EnqueueEnemyIdToSummon(1);
    }

    IEnumerator GameLoop()
    {
        while(LoopShouldEnd == false)
        {
            //spawn Enemies

            if (EnemyIDsToSummon.Count > 0)
            {
                for (int i = 0; i < EnemyIDsToSummon.Count; i++)
                {
                    EntitySummoner.SummonEnemy(EnemyIDsToSummon.Dequeue());
                }
            }

            //

            yield return null;
        }
    }

    public static void EnqueueEnemyIdToSummon(int ID)
    {
        EnemyIDsToSummon.Enqueue(ID);
    }
}
