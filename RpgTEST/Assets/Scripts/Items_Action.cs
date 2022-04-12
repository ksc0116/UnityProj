using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Items_Action : MonoBehaviour,IPointerUpHandler, 
    IPointerDownHandler,IDragHandler
{
    public Image img;

    [Header("Location")]
    public bool inBag;

    private float releasTime;
    private bool dragging;

    public void OnPointerDown(PointerEventData eventData)
    {
        img=GetComponent<Image>();
        Manager.instance.manager_Inven.selectedItem = transform;

        if (inBag)
        {
            StartCoroutine("ReleaseTime");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (inBag)
        {
            StopCoroutine("ReleaseTime");
            transform.localScale = new Vector3(1, 1, 1);

            if (releasTime >= 0.1f)
            {
                transform.SetParent(Manager.instance.manager_Inven.curParent);
                transform.localPosition = Vector3.zero;
                img.raycastTarget = true;
                return;
            }

            if (releasTime < 0.1f)
            {
                // click events
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(inBag && dragging)
            transform.position = eventData.position;
    }

    private IEnumerator ReleaseTime()
    {
        releasTime = 0;
        dragging = false;

        while (true)
        {
            releasTime += Time.deltaTime;

            if(releasTime >= 0.1f)
            {
                transform.localScale = new Vector3(1.3f, 1.3f, 1);

                if (!dragging)
                {
                    Manager.instance.manager_SE.seAudio.PlayOneShot(
                        Manager.instance.manager_SE.drag);

                    dragging = true;
                    Manager.instance.manager_Inven.curParent = transform.parent;
                    transform.SetParent(Manager.instance.manager_Inven.parentOnDrag);

                    img.raycastTarget = false;
                }
            }

            yield return null;
        }
    }
}