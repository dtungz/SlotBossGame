using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class Casino : MonoBehaviour
{
    [SerializeField] private CasinoAction _action;
    [SerializeField] private List<OptionOfCard> _optionOfCard = new List<OptionOfCard>();
    WaitForSeconds delayTime = new WaitForSeconds(1f);
    Coroutine RollCoroutine;
    //public bool CanRoll = true;
    int AttackSlot = 0, HealthSlot = 0, CointSlot = 0;
    public void Rolling()
    {
        if (RollCoroutine == null)
        {
            RollCoroutine = StartCoroutine(RollSlot());
        }
    }

    IEnumerator RollSlot()
    {
        for (int i = 0; i < _optionOfCard.Count; i++)
        {
            int SlotOption = Random.Range(0, 3);
            _optionOfCard[i].Excute(SlotOption);
            switch (SlotOption)
            {
                case 0:
                {
                    AttackSlot++;
                    break;
                }
                case 1:
                {
                    HealthSlot++;
                    break;
                }
                case 2:
                {
                    CointSlot++;
                    break;
                }
            }
            yield return delayTime;
        }
        _action.Casino(AttackSlot, HealthSlot, CointSlot);
        RollCoroutine = null;
        AttackSlot = 0; HealthSlot = 0;  CointSlot = 0;
        foreach (var opt in _optionOfCard)
        {
            opt.Reset();         
        }
    }
    
}
