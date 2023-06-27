using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;
    private SpriteRenderer _spriteRenderer;
    private Selectable _selectable;
    private Solitaire _solitaire;
    private UserInput _userInput;

    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = Solitaire.GenerateDeck();
        _solitaire = FindObjectOfType<Solitaire>();
        _userInput = FindObjectOfType<UserInput>();

        int i = 0;
        foreach (var card in deck)
        {
            if (this.name == card)
            {
                cardFace = _solitaire.cardFaces[i];
                break;
            }

            i++;
        }

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _selectable = GetComponent<Selectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_selectable.faceUp)
        {
            _spriteRenderer.sprite = cardFace;
        }
        else
        {
            _spriteRenderer.sprite = cardBack;
        }

        if (_userInput.slot1)
        {
            if (name == _userInput.slot1.name)
            {
                _spriteRenderer.color = Color.cyan;
            }
            else
            {
                _spriteRenderer.color = Color.white;
            }
        }
    }
}
