using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSwap : MonoBehaviour
{
    [SerializeField]
    float cardReturnSpeed = 1.0f;

    SpriteRenderer spr;
    bool isMouseOver = false;
    Vector2 initialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(pos.x, transform.position.y);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, initialPosition, cardReturnSpeed);
        }
    }

    private void OnMouseOver()
    {
        isMouseOver = true;
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
    }
}
