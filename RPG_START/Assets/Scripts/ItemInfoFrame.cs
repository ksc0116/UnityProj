using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ItemInfoFrame : MonoBehaviour
{
    public Items_Info item;

    public GameObject statBonus;
    public TextMeshProUGUI name_Item;
    public TextMeshProUGUI info_Item;
    public TextMeshProUGUI resalePrice;
    public TextMeshProUGUI hpBonus;
    public TextMeshProUGUI atkBonus;
    public TextMeshProUGUI defBonus;
    public TextMeshProUGUI criBonus;

    /*��*/[Header("[Button]")]
    /*��*/public GameObject equipBtn;
    /*��*/public GameObject releaseBtn;

    private void OnEnable()
    {
        statBonus.SetActive(false);
        name_Item.text = item.name_Item;
        info_Item.text = item.info_Item;
        resalePrice.text = string.Format("Used Price : {0}",item.resalePrice);

        if(item.type == "Equipment")
        {
            hpBonus.text = string.Format("HP +{0}",item.hpBonus);
            atkBonus.text = string.Format("Atk +{0}", item.atkBonus);
            defBonus.text = string.Format("Def +{0}", item.defBonus);
            criBonus.text = string.Format("Cri +{0}", item.criBonus);
            statBonus.SetActive(true);

            /*��*/if (item.equipped == true)
            /*��*/{
            /*��*/    releaseBtn.SetActive(true);
            /*��*/}
            /*��*/else if(item.equipped == false)
            /*��*/{
            /*��*/    equipBtn.SetActive(true);
            /*��*/}
        }
    }
    /*��*/private void OnDisable()
    /*��*/{
    /*��*/    releaseBtn.SetActive(false);
    /*��*/    equipBtn.SetActive(false);
    /*��*/}
}