using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent<PlayerController> onInteract;

    public void Interact(PlayerController player)
    {
        onInteract.Invoke(player);
    }
}
