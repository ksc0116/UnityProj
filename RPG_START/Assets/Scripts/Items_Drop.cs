using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Items_Drop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Manager.instance.manager_SE.seAudio.PlayOneShot(Manager.instance.manager_SE.drag);
        if (transform.childCount != 0)
        {
            Transform item=transform.GetChild(0);
            item.SetParent(Manager.instance.manager_Inven.curParent);
            item.localPosition = Vector3.zero;
        }

        Manager.instance.manager_Inven.selectedItem.SetParent(transform);
        Manager.instance.manager_Inven.selectedItem.localPosition=Vector3.zero;
    }
}
