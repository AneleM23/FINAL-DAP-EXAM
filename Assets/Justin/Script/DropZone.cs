using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public string correctPhrase;

    public void OnDrop(PointerEventData eventData)
    {
        DragDrop draggable = eventData.pointerDrag.GetComponent<DragDrop>();

        if (draggable != null)
        {
            // Check if the dropped item matches the correct phrase
            if (eventData.pointerDrag.name == correctPhrase)
            {
                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.transform.position = transform.position;
                Debug.Log("Correct match!");
            }
            else
            {
                eventData.pointerDrag.transform.position = draggable.startPosition;
                Debug.Log("Incorrect match.");
            }
        }
    }
}
