using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Controller _controller;
    Movement _movement;
    Jump _jump;
    Reload _reload;
    

    [SerializeField] float _speed;
    [SerializeField] float _force;


    [SerializeField] Animator _playerAnimator;

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();

        _movement = new Movement(transform, _speed,GetComponent<Rigidbody>(),_force,this,_playerAnimator);

        _controller = new Controller(_movement);

        
        
    }

    
    void Update()
    {
        _controller.ArtificialUpDate(); // Llamo constantemente a la funcion para que sea como un update en controller.
    }


}
