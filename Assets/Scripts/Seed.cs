using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public GameObject seedPrefab;
    public void OnInteract(PlayerController player)
    {
        player.Equip(transform);
        player.seedType = seedPrefab;
    }
}
