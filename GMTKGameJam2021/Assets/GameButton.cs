using UnityEngine;
using Services;

[RequireComponent(typeof(BoxCollider))]
public abstract class GameButton : MonoBehaviour
{
    public Sprite notPressedSprite;
    public Sprite pressedSprite;
    public SpriteRenderer rend;

    protected virtual void Start()
    {
        rend.sprite = notPressedSprite;
    }


    public virtual void Pressed()
    {
        rend.sprite = pressedSprite;
        //ServiceLocator.GetService<IAudioService>().PlaySFX("button_pressed", this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pressed();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rend.sprite = notPressedSprite;
            // ServiceLocator.GetService<IAudioService>().PlaySFX("button_up", this.gameObject);
        }
    }

}