using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Tire _tireTemplate;

    private List<Tire> _tires = new List<Tire>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_tires.Count < value) 
        {
            int createHealth = value - _tires.Count;

            for (int i = 0; i < createHealth; i++)
            {
                CreatedTire();
            }
        }
        else if(_tires.Count> value)
        {
            int deleteHealth = _tires.Count - value;    
            for (int i = 0; i < deleteHealth; i++)
            {
                DestroyTire(_tires[_tires.Count - 1]);
            }

        }
    }

    private void DestroyTire( Tire tire)
    { 
        _tires.Remove(tire);
        tire.ToEmpty();
    }

    private void CreatedTire()
    {
        Tire newTire = Instantiate(_tireTemplate, transform);
        _tires.Add(newTire.GetComponent<Tire>());
        newTire.ToFill();
    }

}
