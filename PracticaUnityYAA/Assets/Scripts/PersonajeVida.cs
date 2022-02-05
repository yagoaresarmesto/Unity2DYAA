using System;
using UnityEngine;

public class PersonajeVida : VidaBase //Que hereda de vidaBase
{


    public static Action EventoPersonajeDerrotado;
    public bool PuedeSerCurado => Salud < saludMax;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) //Para probar, si pulsamos la tecla T recibimos daño
        {
            RecibirDaño(10);
        }

        if (Input.GetKeyDown(KeyCode.R)) //Para probar, si pulsamos la tecla T recibimos daño
        {
            RestaurarSalud(10);
        }
    }

    public void RestaurarSalud(float cantidad)
    {

        if (PuedeSerCurado)
        {
            Salud += cantidad;
            if (Salud > saludMax)
            {
                Salud = saludMax;
            }
            ActualizarBarraVida(Salud, saludMax);
        }
    }
    protected override void PersonajeDerrotado()
    {
        EventoPersonajeDerrotado?.Invoke(); //Si el evento del personaje no es nulo, se invoca
    }


    protected override void ActualizarBarraVida(float vidaActual, float vidaMax)
    {

    }
}
