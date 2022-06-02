using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    [Header("[Player]")]
    /*��*/public PlayerState player;
    public Mesh[] originMesh;
    public SkinnedMeshRenderer[] parts_Player;

    [Header("[Character Info]")]
    public Transform[] slot_Equip;
    public Items_Info[] cur_Equip;

    public void EquipBtn()
    {
        Items_Info item=Manager.instance.manager_Inven.selectedItem.GetComponent<Items_Info>();

        if (slot_Equip[item.equipNum].childCount == 2)
        {
            cur_Equip[item.equipNum].equipped = false;
            cur_Equip[item.equipNum].transform.GetChild(0).gameObject.SetActive(false);
            Destroy(slot_Equip[item.equipNum].GetChild(1).gameObject);

            /*��*/ReduceStats(cur_Equip[item.equipNum]);
        }

        GameObject item_Slot = Instantiate(item.gameObject, slot_Equip[item.equipNum]);
        item_Slot.GetComponent<Items_Action>().enabled = false;

        cur_Equip[item.equipNum] = item;    
        item.equipped = true;
        item.transform.GetChild(0).gameObject.SetActive(true);
        parts_Player[item.equipNum].sharedMesh = item.mesh;

        /*��*/IncreaseStats(cur_Equip[item.equipNum]);

        Manager.instance.manager_Inven.itemInfoFrame.SetActive(false);
        Manager.instance.manager_Inven.itemInfoFrame.SetActive(true);
    }

    public void ReleaseBtn()
    {
        Items_Info item = Manager.instance.manager_Inven.selectedItem.GetComponent<Items_Info>();

        Destroy(slot_Equip[item.equipNum].GetChild(1).gameObject);

        item.equipped = false;
        item.transform.GetChild(0).gameObject.SetActive(false);

        /*��*/ReduceStats(cur_Equip[item.equipNum]);

        cur_Equip[item.equipNum] = null;
        parts_Player[item.equipNum].sharedMesh = originMesh[item.equipNum];

        Manager.instance.manager_Inven.itemInfoFrame.SetActive(false);
        Manager.instance.manager_Inven.itemInfoFrame.SetActive(true);
    }

   /*��*/void IncreaseStats(Items_Info item)
   /*��*/{
   /*��*/    player.hp += item.hpBonus;
   /*��*/    player.hp_Cur+=item.hpBonus;
   /*��*/    player.atk+=item.atkBonus;
   /*��*/    player.def+=item.defBonus;
   /*��*/    player.cri+=item.criBonus;
   /*��*/    
   /*��*/     Manager.instance.manager_Inven.charInfoFrame.SetActive(false);
   /*��*/     Manager.instance.manager_Inven.charInfoFrame.SetActive(true);
   /*��*/}
    
    /*��*/void ReduceStats(Items_Info item)
    /*��*/{
    /*��*/    player.hp -= item.hpBonus;
    /*��*/    player.hp_Cur -= item.hpBonus;
    /*��*/    player.atk -= item.atkBonus;
    /*��*/    player.def -= item.defBonus;
    /*��*/    player.cri -= item.criBonus;
    /*��*/
    /*��*/    Manager.instance.manager_Inven.charInfoFrame.SetActive(false);
    /*��*/    Manager.instance.manager_Inven.charInfoFrame.SetActive(true);
    /*��*/}
}