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
    [SerializeField] private string optionAText;
    public string _optionAText { get { return optionAText; } }
    [SerializeField] private string optionBText;
    public string _optionBText { get { return optionBText; } }
    [SerializeField] private List<CardInfo> optionACard = new List<CardInfo>();
    public List<CardInfo> _optionACard { get { return optionACard; } }
    [SerializeField] private List<CardInfo> optionBCard = new List<CardInfo>();
    public List<CardInfo> _optionBCard { get { return optionBCard; } }
    [SerializeField] private bool endingCard;
    public bool _endingCard { get { return endingCard; } }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
