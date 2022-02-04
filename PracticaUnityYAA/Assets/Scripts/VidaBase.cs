using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBase : MonoBehaviour
{
    [SerializeField] protected float saludInicial; //La salud base
    [SerializeField] protected float saludMax; 

    public float Salud { get; protected set; } //Es una propiedad que permite que se pueda modificar
    
    protected virtual void Start()
    {
        Salud = saludInicial;
    }

    public void RecibirDaño(float cantidad) //La cantidad que vamos a recibir
    {
        if (cantidad <= 0) //Si recibe daño = 0, no continuar con el código
        {
            return;
        }

        if (Salud > 0f) //Si tenemos salud
        {
            Salud -= cantidad;
            ActualizarBarraVida(Salud, saludMax);
            if (Salud <= 0f) //Si somos derrotados
            {
                ActualizarBarraVida(Salud, saludMax);
                PersonajeDerrotado();
            }
        }
    }

    protected virtual void ActualizarBarraVida(float vidaActual, float vidaMax)
    {
        
    }

    protected virtual void PersonajeDerrotado()
    {
        
    }
}
