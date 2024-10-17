using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactoryManager : MonoBehaviour
{
    private static BulletFactoryManager Instance;
    [SerializeField]
    private BulletFactory RegularFactory;
    private Pool<Bullet> RegularPool = new Pool<Bullet>();

    [SerializeField]
    private BulletFactory FireFactory;
    private Pool<Bullet> FirePool = new Pool<Bullet>();

    private void Awake()
    {
        Instance = this;

    }
    public enum BulletTypes
    {
        Regular,
        Fire
    }

    public static IFactory<Bullet, Vector3, Quaternion> GetFactoryOf(BulletTypes type)
    {
        switch (type)
        {
            case BulletTypes.Regular:
                return Instance.RegularFactory;
            case BulletTypes.Fire:
                return Instance.FireFactory;
            default: return null;
        }
    }

    public static IPool<Bullet> GetPool(BulletTypes type)
    {
        switch (type)
        {
            case BulletTypes.Regular:
                return Instance.RegularPool;
            case BulletTypes.Fire:
                return Instance.FirePool;
            default: return null;
        }
    }
}
