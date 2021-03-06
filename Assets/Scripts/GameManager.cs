using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private CardSwap cardSwap;
    [SerializeField] private List<CardInfo> initialCards = new List<CardInfo>();
    [SerializeField] private CardInfo currentCard;
    [Space]
    [Header("UI Elements")]
    [SerializeField] private TMP_Text cardName;
    [SerializeField] private TMP_Text cardQuestionText;
    [SerializeField] private TMP_Text cardOptionText;
    [SerializeField] private SpriteRenderer cardSpriteRenderer;
    public SpriteRenderer bckgRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //Singleton Instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        FirstCardShow();
    }

    void FirstCardShow()
    {
        cardOptionText.alpha = 0;
        cardOptionText.text = "";
        int randIndex = Random.Range(0, initialCards.Count);
        currentCard = initialCards[randIndex];
        ShowCardData(currentCard);
    }

    void ShowCardData(CardInfo card)
    {
        cardName.text = card._cardName;
        cardSpriteRenderer.sprite = card._cardSprite;
        if (card._endingCard) cardSwap.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CardOptionAlpha(float value)
    {
        cardOptionText.alpha = value;
    }
    public void CardOptionText(bool right)
    {
        string textOption;

        if (right)
        {
            textOption = currentCard._optionBText;
        }
        else
        {
            textOption = currentCard._optionAText;
        }
        cardOptionText.text = textOption;
    }

    public void ChooseOptionSide(bool right)
    {
        if (right)
        {
            if(currentCard._optionBCard.Count == 1)
            {
                currentCard = currentCard._optionBCard[0];
            }
            else
            {
                currentCard = currentCard._optionBCard[Random.Range(0, currentCard._optionBCard.Count-1)];
            }
        }
        else
        {
            if (currentCard._optionACard.Count == 1)
            {
                currentCard = currentCard._optionACard[0];
            }
            else
            {
                currentCard = currentCard._optionACard[Random.Range(0, currentCard._optionACard.Count - 1)];
            }
        }
        ShowCardData(currentCard);
    }
}
