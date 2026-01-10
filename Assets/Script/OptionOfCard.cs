using System;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OptionOfCard : MonoBehaviour
{
    private Animator _anim;
    
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void Excute(int card)
    {
        switch (card)
        {
            case 0:
            {
                _anim.SetTrigger("Attack");
                break;
            }
            case 1:
            {
                _anim.SetTrigger("Health");
                break;
            }
            case 2:
            {
                _anim.SetTrigger("Coint");
                break;
            }
        }
        //_currentCard = card;
    }
    
    public void Reset()
    {
        _anim.SetTrigger("Reset");
    }
}
