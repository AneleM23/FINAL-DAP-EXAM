using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 startPosition;
    public Transform parentTransform;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        parentTransform = transform.parent;
        transform.SetParent(parentTransform.root);  // Move to root level
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentTransform);
        transform.position = startPosition;  // Reset if not dropped correctly
    }
}
