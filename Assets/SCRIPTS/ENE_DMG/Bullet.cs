using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifetime;

    private float remaingLife;

    private IPool<Bullet> pool;
    private void OnEnable()
    {
        remaingLife = lifetime;
    }

    public void Initialized(IPool<Bullet> pool)
    {
        this.pool = pool;
    }

    private void Update()
    {

        transform.position += transform.forward * speed * Time.deltaTime;
        remaingLife -= Time.deltaTime;
        if (remaingLife <= 0)
        {
            gameObject.SetActive(false);
            pool.Return(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>(); 
        if(damageable!=null)
        {
            damageable.GetDamage();
        }
    }

  // todo con lo que colisione y tenga implementado la interfaz IDamageable guardalo en damageable
  //llama al metodo de la interfaz, para que el enemigo que contenga la interfaz llame al metodo y aplique logica interna propia del enemigo.
}
