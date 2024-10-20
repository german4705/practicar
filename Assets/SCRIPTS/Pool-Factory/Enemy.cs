using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private BulletFactoryManager.BulletTypes bulletType;

    [SerializeField]
    private Transform shootingPoint;
    
    private IFactory<Bullet,Vector3,Quaternion> bulletfactory;
    private IPool<Bullet> bulletpool;

    private void Start()
    {
        bulletfactory = BulletFactoryManager.GetFactoryOf(bulletType);
        bulletpool = BulletFactoryManager.GetPool(bulletType);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if(bulletpool.TryRent(out Bullet bullet))
            {
                bullet.gameObject.SetActive(true);
                bullet.transform.position = shootingPoint.position;
                bullet.transform.rotation = shootingPoint.rotation;


            }
            else
            {
               bullet= bulletfactory.Create(shootingPoint.position, shootingPoint.rotation);

            }
            bullet.Initialized(bulletpool);
        }
    }
}
