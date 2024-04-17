using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnIndicatorManager : MonoBehaviour
{
    [SerializeField]
    public GameObject turnIndicator;
    [SerializeField]
    //public Text text;
    //public TextMeshProUGUI text;

    public GameObject playerTurn;
    public GameObject enemyTurn;

    private const float InAnimDuration = 0.5f;
    private const float OutAnimDuration = 0.6f;
    private const float ShowcaseDuration = 2.0f;
    
    public void OnPlayerTurnBegan()
    {
        playerTurn.SetActive(true);
        enemyTurn.SetActive(false);
        var seq = DOTween.Sequence();
        seq.Append(turnIndicator.GetComponent<RectTransform>().DOScale(1f, InAnimDuration));
        seq.AppendInterval(ShowcaseDuration);
        seq.Append(turnIndicator.GetComponent<RectTransform>().DOScale(0.0f, OutAnimDuration));
    }
    
    public void OnEnemyTurnBegan()
    {
        playerTurn.SetActive(false);
        enemyTurn.SetActive(true);
        var seq = DOTween.Sequence();
        seq.Append(turnIndicator.GetComponent<RectTransform>().DOScale(1f, InAnimDuration));
        seq.AppendInterval(ShowcaseDuration);
        seq.Append(turnIndicator.GetComponent<RectTransform>().DOScale(0.0f, OutAnimDuration));
    }
    
}
