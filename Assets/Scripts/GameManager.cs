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
    [SerializeField] private bool endGame;
    [Space]
    [Header("UI Elements")]
    [SerializeField] private TMP_Text cardName;
    [SerializeField] private TMP_Text cardQuestionText;
    [SerializeField] private TMP_Text cardOptionText;
    [SerializeField] private SpriteRenderer cardSpriteRenderer;
    public SpriteRenderer bckgRenderer;
    [SerializeField] private List<Color> backgroundColors;
    [SerializeField] private List<Color> textColors;

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
        endGame = false;
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
        cardQuestionText.text = card._cardQuestion;
        cardSpriteRenderer.sprite = card._cardSprite;
        cardQuestionText.color = textColors[0];

        switch (card._cardColor)
        {
            case CardColor.GREEN:
                bckgRenderer.color = backgroundColors[0];
                break;
            case CardColor.YELLOW:
                bckgRenderer.color = backgroundColors[1];
                break;
            case CardColor.ORANGE:
                bckgRenderer.color = backgroundColors[2];
                break;
            case CardColor.RED:
                bckgRenderer.color = backgroundColors[3];
                cardQuestionText.color = textColors[1];
                break;
        }
        FlipCard();
        if (card._endingCard) {
            FinishGame();
        } 
    }

    void FinishGame()
    {
        endGame = true;
        cardSwap.ResetPosition();
        //cardSwap.enabled = false;
        cardOptionText.text = "Reiniciar Jogo";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CardOptionAlpha(float value)
    {
        cardOptionText.alpha = value;
    }
    public void CardOptionText(int id)
    {
        string textOption = "";

        if (id == 0)
        {
            textOption = currentCard._optionBText;
            cardOptionText.alignment = TextAlignmentOptions.Left;
        }
        else if (id == 1)
        {
            textOption = currentCard._optionAText;
            cardOptionText.alignment = TextAlignmentOptions.Right;
        }
        else if (id == 2)
        {
            textOption = "";
        }
            cardOptionText.text = textOption;
    }

    public void ChooseOptionSide(bool right)
    {
        if (endGame)
        {
            ScenesManager.Instance.StartGame();
        } 

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

    void FlipCard()
    {
        cardSwap.PlayFlipAnimation();
    }
}
