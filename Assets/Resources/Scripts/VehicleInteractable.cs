using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleInteractable : MonoBehaviour, IInteractable
{

    private CarController vehicle;

    void Start()
    {
        vehicle = GetComponentInChildren<CarController>();
    }

    public void Interact(PlayerController player)
    {
        vehicle.ToggleOn(true);
        player.EnterVehicle(this);
    }

    public void ExitVehicle(PlayerController player)
    {
        vehicle.ToggleOn(false);
        player.ExitVehicle();
    }
}
