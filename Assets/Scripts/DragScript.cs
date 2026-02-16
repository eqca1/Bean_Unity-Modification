using UnityEngine;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour, 
    IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    SFX_Script sfxScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sfxScript = FindFirstObjectByType<SFX_Script>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("Izdarīts klikšķis uz velkamā objekta");
        sfxScript.PlaySFX(2);
    }

    public void OnBeginDrag(PointerEventData data)
    {
        Debug.Log("Sākts vilkšanas process");
    }

    public void OnDrag(PointerEventData data)
    {
        Debug.Log("Notiek vilkšana");
        Vector2 mousePosition = data.position;
        mousePosition.x = Mathf.Clamp(mousePosition.x, 
            0 + rectTransform.rect.width / 2, 
            Screen.width - rectTransform.rect.width / 2);

        mousePosition.y = Mathf.Clamp(mousePosition.y,
           0 + rectTransform.rect.height / 2,
           Screen.height - rectTransform.rect.height / 2);

        rectTransform.position = mousePosition;
    }

    public void OnEndDrag(PointerEventData data)
    {
        Debug.Log("Beidzies vilkšanas process");
    }
}
