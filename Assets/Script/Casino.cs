using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class Casino : MonoBehaviour
{
    [SerializeField] private CasinoAction action;
    [SerializeField] private List<OptionOfCard> optionOfCard = new List<OptionOfCard>();
    private WaitForSeconds _delayTime = new WaitForSeconds(1f);
    private Coroutine _rollCoroutine;
    private int _attackSlot = 0, _healthSlot = 0, _cointSlot = 0;

    private void Awake()
    {
        if (action == null)
        {
            action = GetComponent<CasinoAction>();
        }
    }

    public void Rolling()
    {
        if (_rollCoroutine == null)
        {
            _rollCoroutine = StartCoroutine(RollSlot());
        }
    }

    IEnumerator RollSlot()
    {
        for (int i = 0; i < optionOfCard.Count; i++)
        {
            int slotOption = Random.Range(0, 3);
            optionOfCard[i].Excute(slotOption);
            switch (slotOption)
            {
                case 0:
                {
                    _attackSlot++;
                    break;
                }
                case 1:
                {
                    _healthSlot++;
                    break;
                }
                case 2:
                {
                    _cointSlot++;
                    break;
                }
            }
            yield return _delayTime;
        }
        action.Casino(_attackSlot, _healthSlot, _cointSlot);
        _rollCoroutine = null;
        _attackSlot = 0; _healthSlot = 0;  _cointSlot = 0;
        foreach (var opt in optionOfCard)
        {
            opt.Reset();         
        }
    }
    
}
