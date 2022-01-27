using System;
using UnityEngine;

public class PersonajeAnimaciones : MonoBehaviour
{
    private Animator _animator;
    private PersonajeMovimiento _personajeMovimiento;

    private readonly int direccionX = Animator.StringToHash("x");
    private readonly int direccionY = Animator.StringToHash("y");
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _personajeMovimiento = GetComponent<PersonajeMovimiento>(); //Accedemos a la propiedad de la clase publica de personaje movimiento
    }


    private void Update()
    {
        if (_personajeMovimiento.EnMovimiento == false) //Si nuestro personaje no se mueve
        {
            return;
        }

        _animator.SetFloat(direccionX, _personajeMovimiento.DireccionMovimiento.x);
        _animator.SetFloat(direccionY, _personajeMovimiento.DireccionMovimiento.y);
    }
}

