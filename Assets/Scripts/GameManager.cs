using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private List<CardInfo> initialCards = new List<CardInfo>();
    [SerializeField] CardInfo currentCard;

    // Start is called before the first frame update
    void Start()
    {
        //Singleton Instance
        if(Instance == null)
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
        int randIndex = Random.Range(0, initialCards.Count);
        currentCard = initialCards[randIndex];
        ShowCardData(currentCard);
    }

    void ShowCardData(CardInfo card)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
