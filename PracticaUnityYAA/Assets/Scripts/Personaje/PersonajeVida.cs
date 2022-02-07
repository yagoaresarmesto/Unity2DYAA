using System;
using UnityEngine;

public class PersonajeVida : VidaBase //Que hereda de vidaBase
{

    public static Action EventoPersonajeDerrotado;
    public bool Derrotado { get; private set; } //Solo se modificara dentro de esta clase
    public bool PuedeSerCurado => Salud < saludMax;
    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }
    protected override void Start()
    {
        base.Start();
        ActualizarBarraVida(Salud, saludMax);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) //Para probar, si pulsamos la tecla T recibimos daño
        {
            RecibirDaño(10);
        }

        if (Input.GetKeyDown(KeyCode.Y)) //Para probar, si pulsamos la tecla T recibimos daño
        {
            RestaurarSalud(10);
        }
    }

    public void RestaurarSalud(float cantidad)
    {
        if (Derrotado)
        {
            return;
        }
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
        _boxCollider2D.enabled = false;
        Derrotado = true;
        EventoPersonajeDerrotado?.Invoke(); //Si el evento del personaje no es nulo, se invoca
    }

    public void RestaurarPersonaje()
    {
        _boxCollider2D.enabled = true; //Activar collider
        Derrotado = false;
        Salud = saludInicial; //Resetear salud
        ActualizarBarraVida(Salud, saludInicial);
    }

    protected override void ActualizarBarraVida(float vidaActual, float vidaMax)
    {
        UIManager.Instance.ActualizarVidaPersonaje(vidaActual, vidaMax);
    }
}
