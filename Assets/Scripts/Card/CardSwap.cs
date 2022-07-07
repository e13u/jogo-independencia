using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSwap : MonoBehaviour
{
    [SerializeField]
    float cardReturnSpeed = 1.0f;
    [SerializeField]
    float cardSideMargin = 0.5f;
    [SerializeField]
    float cardMarginTrigger = 1.5f;

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
        GameManager.Instance.CardOptionAlpha(Mathf.Min(Mathf.Abs(transform.position.x / 2), 1));
        if (Input.GetMouseButton(0) && isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(pos.x, transform.position.y);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, initialPosition, cardReturnSpeed);
            GameManager.Instance.CardOptionAlpha(0);
        }

        if (transform.position.x > cardSideMargin)
        {
            //GameManager.Instance.CardOptionAlpha(Mathf.Min(transform.position.x, 1));
            GameManager.Instance.CardOptionText(true);
        }
        else if(transform.position.x < -cardSideMargin)
        {
            //GameManager.Instance.CardOptionAlpha(Mathf.Min(-transform.position.x, 1));
            GameManager.Instance.CardOptionText(false);
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

    private void OnMouseUp()
    {
        if (!Input.GetMouseButton(0) && transform.position.x > cardMarginTrigger)
        {
            GameManager.Instance.ChooseOptionSide(true);
        }
        else if(!Input.GetMouseButton(0) && transform.position.x < -cardMarginTrigger)
        {
            GameManager.Instance.ChooseOptionSide(false);
        }
    }
}
