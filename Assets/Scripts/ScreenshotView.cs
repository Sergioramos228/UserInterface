using Assets.Scripts.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScreenshotView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _date;

    private Transform _dragingParent;
    private Transform _previousParent;

    public void Init(Transform dragingParent)
    {
        _dragingParent = dragingParent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = _dragingParent;
        _previousParent = transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.parent = _previousParent;
        DropContainer container = EventSystem.current.GetFirstComponentUnderPointer<DropContainer>(eventData);

        if (container != null)
            transform.parent = container.Container;
        else
            transform.parent = _previousParent;
    }

    public void Render(Screenshot screenshot)
    {
        _image.sprite = screenshot.Image;
        _date.text = screenshot.CreationTime.ToString();
    }
}
