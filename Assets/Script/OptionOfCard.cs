using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OptionOfCard : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Excute(int card)
    {
        switch (card)
        {
            default:
                //Debug.Log("This Option has been updated yet!!!");
                break;
            case 0:
            {
                Attack();
                break;
            }
            case 1:
            {
                Health();
                break;
            }
            case 2:
            {
                Coin();
                break;
            }
        }
    }
    
    void Attack()
    {
        _spriteRenderer.color = Color.blue;
    }

    void Health()
    {
        _spriteRenderer.color = Color.red;
    }

    void Coin()
    {
        _spriteRenderer.color = Color.yellow;
    }

    public void Reset()
    {
        _spriteRenderer.color = Color.white;
    }
}
