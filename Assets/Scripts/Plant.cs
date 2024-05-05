using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int growInterval = 20;
    public Sprite[] levels;
    public int currentLevel;
    public string type;

    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (currentLevel < levels.Length)
            sprite.sprite = levels[currentLevel];
        StartCoroutine(Grow());
    }
    IEnumerator Grow()
    {
        while (currentLevel < levels.Length - 1)
        {
            yield return new WaitForSeconds(growInterval + Random.Range(-5f, 5f));
            if (currentLevel < levels.Length - 1)
            {
                currentLevel += 1;
                sprite.sprite = levels[currentLevel];
            }
        }
    }

    public void OnInteract(PlayerController player)
    {
        if (player.fertilizerType == type)
        {
            if (currentLevel < levels.Length - 1)
            {
                currentLevel += 1;
                sprite.sprite = levels[currentLevel];
            }
        }
        else if (player.fertilizerType != "" && player.fertilizerType != type)
        {
            if (currentLevel > 0)
            {
                currentLevel -= 1;
                sprite.sprite = levels[currentLevel];
            }
        }
        else
        {
            player.AddScore(currentLevel * 5, type);
            Destroy(gameObject);
        }
    }
}