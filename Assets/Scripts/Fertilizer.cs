using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fertilizer : MonoBehaviour
{
    public string type;
    public void OnInteract(PlayerController player)
    {
        player.fertilizerType = type;
        player.interactTarget = null;
        player.Equip(transform);
    }
}
