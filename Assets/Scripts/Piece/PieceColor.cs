using UnityEngine;

public class PieceColor : MonoBehaviour
{
    [SerializeField]
    public int colorInt;
    [SerializeField]
    public Sprite[] brickColor;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        colorInt = UnityEngine.Random.Range(0, 6);
        ChooseColor();
    }

    private void ChooseColor()
    {
        //TODO
        // set spriteRenderer.sprite to a random sprite that is present above

        //spriteRenderer.sprite = ???;

        spriteRenderer.sprite = brickColor[colorInt];

    }
}
