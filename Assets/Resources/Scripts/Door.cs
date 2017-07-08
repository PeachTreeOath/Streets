using UnityEngine;

public class Door : MonoBehaviour, Interactable
{
    public void Interact(PlayerController player)
    {
        // TODO: Connect door to building so building knows to spawn event
        Destroy(gameObject);
    }
}
