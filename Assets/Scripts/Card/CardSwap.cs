using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSwap : MonoBehaviour
{
    public Animator animatorCard;

    [SerializeField]
    float cardReturnSpeed = 1.0f;
    [SerializeField]
    float cardSideMargin = 0.5f;
    [SerializeField]
    float cardMarginTrigger = 1.5f;
    [SerializeField]
    float rotationAmount = 1.5f; 

    SpriteRenderer spr;
    bool isMouseOver = false;
    Vector2 initialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        animatorCard = GetComponent<Animator>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.CardOptionAlpha(Mathf.Min(Mathf.Sqrt(Mathf.Abs((transform.position.x+cardSideMargin) / 2)), 1));
        if (Input.GetMouseButton(0) && isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(pos.x, transform.position.y);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, initialPosition, cardReturnSpeed);
            GameManager.Instance.CardOptionAlpha(0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (transform.position.x > cardSideMargin)
        {
            //GameManager.Instance.CardOptionAlpha(Mathf.Min(transform.position.x, 1));
            GameManager.Instance.CardOptionText(0);
        }
        else if(transform.position.x < -cardSideMargin)
        {
            //GameManager.Instance.CardOptionAlpha(Mathf.Min(-transform.position.x, 1));
            GameManager.Instance.CardOptionText(1);
        }
        else if(transform.position.x < cardSideMargin && transform.position.x > -cardSideMargin)
        {
            GameManager.Instance.CardOptionText(2);
        }

        //CHANGE BG COLOR
        //if (transform.position.x > cardMarginTrigger) GameManager.Instance.bckgRenderer.color = Color.red;
        //else if (transform.position.x < -cardMarginTrigger) GameManager.Instance.bckgRenderer.color = Color.green;
        //else GameManager.Instance.bckgRenderer.color = Color.blue;

        //ROTATING CARD
        transform.eulerAngles = new Vector3(0, 0, transform.position.x * rotationAmount);
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

    public void ResetPosition()
    {
        transform.position = initialPosition;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public void TurnOffAnimator()
    {
        animatorCard.enabled = false;
    }

    public void PlayFlipAnimation()
    {
        animatorCard.enabled = true;
        animatorCard.SetTrigger("flip");
    }
}
