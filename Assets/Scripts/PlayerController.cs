using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// OnEquip, OnUnequip�� ����� ������ ����/���� �̺�Ʈ ����
// �������� ����ϰ� ������ OnInteract ��� OnUseItem �̺�Ʈ ���

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