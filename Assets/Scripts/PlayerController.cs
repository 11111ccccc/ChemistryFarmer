using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// OnEquip, OnUnequip을 만들어 아이템 착용/해제 이벤트 만듬
// 아이템을 장비하고 있을시 OnInteract 대신 OnUseItem 이벤트 사용

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public TMP_Text SeedText;
    public TMP_Text PotatoText;
    public TMP_Text TomatoText;
    public Interactable interactTarget;

    public Transform grabbingPoint;
    public string fertilizerType;

    int seedScore;
    int potatoScore;
    int tomatoScore;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (!SeedText)
            SeedText = GameObject.Find("SeedText").GetComponent<TMP_Text>();
        if (!PotatoText)
            PotatoText = GameObject.Find("PotatoText").GetComponent<TMP_Text>();
        if (!TomatoText)
            TomatoText = GameObject.Find("TomatoText").GetComponent<TMP_Text>();
    }

    void Update()
    {
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        rb.velocity = moveDir.normalized * speed;
        if (interactTarget && Input.GetKeyDown(KeyCode.LeftShift))
        {
            interactTarget.Interact(this);
        }
    }

    public void AddScore(int score, string type)
    {
        seedScore += score;
        SeedText.text = "Seed: " + seedScore.ToString("D5");

        if (type == "Potato")
            potatoScore += score;

        if (type == "Tomato")
            tomatoScore += score;

        PotatoText.text = "Potato: " + potatoScore.ToString("D5");
        TomatoText.text = "Tomato: " + tomatoScore.ToString("D5");
    }

    public void Equip(Transform item)
    {
        item.SetParent(grabbingPoint);
        item.localPosition = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactTarget = collision.GetComponent<Interactable>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (interactTarget && collision.gameObject == interactTarget.gameObject)
        {
            interactTarget = null;
        }
    }
}
