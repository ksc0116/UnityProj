using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharInfoFrame : MonoBehaviour
{
    public PlayerState player;

    // 정보창이 활성화 될 때 동기화할 요소들을 선언한다.
    public TextMeshProUGUI lev;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI atk;
    public TextMeshProUGUI def;
    public TextMeshProUGUI cri;
    public Image expBar;

    private void OnEnable()
    {
        lev.text = player.lev.ToString();
        hp.text = player.hp.ToString();
        atk.text = player.atk.ToString();
        def.text = player.def.ToString();
        cri.text = string.Format("{0:0.00}",player.cri);

        expBar.fillAmount = player.exp_Cur / player.exp_Max;
    }
}