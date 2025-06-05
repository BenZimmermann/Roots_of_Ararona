//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class DragManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
//{
//    Transform origialParent;
//    public void OnBeginDrag(PointerEventData eventData)
//    {

//        Debug.Log("Drag started on: " + gameObject.name);
//        origialParent = transform.parent; // Store the original parent
//        transform.SetParent(transform.root); // Move the item to the root of the canvas or UI hierarchy
//        transform.localPosition = eventData.position; // Set the position to the current mouse position
//    }

//    public void OnDrag(PointerEventData eventData)
//    {
//        transform.localPosition = eventData.position; // Update the position of the item as it is dragged
//    }

//    public void OnEndDrag(PointerEventData eventData)
//    {
//        transform.SetParent(origialParent); // Return the item to its original parent
//        // Hande the end of the drag
//    }
//}

