using System;
using UnityEngine;

public class PersonajeMana : MonoBehaviour
{
    [SerializeField] private float manaInicial;
    [SerializeField] private float manaMax;
    [SerializeField] private float regeneracionPorSegundo;

    public float ManaActual { get; private set; }

    private PersonajeVida _personajeVida;

    private void Awake()
    {
        _personajeVida = GetComponent<PersonajeVida>();
    }

    private void Start()
    {
        ManaActual = manaInicial;
        ActualizarBarraMana();

        InvokeRepeating(nameof(RegenerarMana), 1, 1);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            UsarMana(10f);
        }
    }

    public void UsarMana(float cantidad)
    {
        if (ManaActual >= cantidad) //Si tenemos mana
        {
            ManaActual -= cantidad;
            ActualizarBarraMana();
        }
    }

    private void RegenerarMana()
    {
        if (_personajeVida.Salud > 0f && ManaActual < manaMax) //Si tenemos vida
        {
            ManaActual += regeneracionPorSegundo;
            ActualizarBarraMana();
        }
    }

    public void RestablecerMana()//Cunado muere que no siga regenerando mana
    {
        ManaActual = manaInicial;
        ActualizarBarraMana();
    }



    private void ActualizarBarraMana()
    {
        UIManager.Instance.ActualizarManaPersonaje(ManaActual, manaMax);
    }
}
