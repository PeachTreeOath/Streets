using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public void Interact(PlayerController player)
    {
        // TODO: Connect door to building so building knows to spawn event
        Destroy(gameObject);
    }
}
