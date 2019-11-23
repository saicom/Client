using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 脚本挂载到每个可拖拽的Item上面即可
/// </summary>
public class ItemOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ScrollRect mScrollRect;

    public void OnBeginDrag(PointerEventData eventData)
    {
        mScrollRect.OnBeginDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        mScrollRect.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        mScrollRect.OnEndDrag(eventData);
    }


}
