using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private GameManager solitaire;
    private UserInput userInput;

    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = GameManager.GenerateDeck();
        solitaire = FindObjectOfType<GameManager>();
        userInput = FindObjectOfType<UserInput>();

        int i = 0;
        foreach (string card in deck)
        {
            if (this.name == card)
            {
                cardFace = solitaire.cardFaces[i];
                break;
            }
            i++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectable.faceUp == true)
        {
            spriteRenderer.sprite = cardFace;
        }
        else
        {
            spriteRenderer.sprite = cardBack;
        }

        if (userInput.slot1)
        {
            if (name == userInput.slot1.name)
            {
                // 카드 클릭 시 점멸하는 색상
                spriteRenderer.color = (Color)(new Color32(234, 255, 184, 255));
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
        }

    }
}
