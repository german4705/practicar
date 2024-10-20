using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private LifeHandle lifeHandle;

    public int CurrentHealth => lifeHandle.CurrentHealth;

    public int MaxHealth => lifeHandle.MaxHealth;

    public IObserved LifeHandle => lifeHandle;


    public void Start()
    {
        lifeHandle.Initialize();
    }
   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            lifeHandle.TakeDamage(5);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            lifeHandle.TakeHealing(5);
        }

    }
}
