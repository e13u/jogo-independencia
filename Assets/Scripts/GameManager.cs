using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private List<CardInfo> initialCards = new List<CardInfo>();
    [SerializeField] private CardInfo currentCard;
    [Space]
    [Header("UI Elements")]
    [SerializeField] private TMP_Text cardName;
    [SerializeField] private TMP_Text cardOptionText;
    [SerializeField] private SpriteRenderer cardSpriteRenderer;
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
        if (right) currentCard = currentCard._optionBCard;
        else currentCard = currentCard._optionACard;

        ShowCardData(currentCard);
    }
}
