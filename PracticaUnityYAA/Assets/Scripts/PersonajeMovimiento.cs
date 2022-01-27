using System;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    [SerializeField] private float velocidad;

    public bool EnMovimiento => _direccionMovimiento.magnitude > 0f;
    public Vector2 DireccionMovimiento => _direccionMovimiento;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _direccionMovimiento;
    private Vector2 _input;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        // X
        if (_input.x > 0.1f) //Si me muevo como siempre va ser mayor que 1
        {
            _direccionMovimiento.x = 1f; //Sera positivo, por lo tanto derecha
        }
        else if (_input.x < 0f)
        {
            _direccionMovimiento.x = -1f; //Negativo, es decir izquierda
        }
        else
        {
            _direccionMovimiento.x = 0f; //No se mueve
        }
        
        // Y
        if (_input.y > 0.1f)
        {
            _direccionMovimiento.y = 1f; //Positivo Arriba
        }
        else if (_input.y < 0f)
        {
            _direccionMovimiento.y = -1f; //Negativo abajo
        }
        else
        {
            _direccionMovimiento.y = 0f;//No se mueve
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direccionMovimiento * velocidad * Time.fixedDeltaTime);
    }
}
