using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Card")]
public class CardInfo : ScriptableObject
{
    [SerializeField] private string cardName;
    public string _cardName { get { return cardName; } }
    [SerializeField] private Sprite cardSprite;
    public Sprite _cardSprite { get { return cardSprite; } }
    [SerializeField] private string option1Text;
    [SerializeField] private string option2Text;
    [SerializeField] private CardInfo option1Card;
    [SerializeField] private CardInfo option2Card;
    [SerializeField] private bool endingCard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
