using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class NiceBUTTons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{


    private Button but;
    private ColorBlock old;
    public ColorBlock neww;
    public float HowBig = 0.1f;

    void Start()
    {
        but = this.GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale += new Vector3(HowBig, HowBig, HowBig);
        Debug.Log("+++");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale += new Vector3(-HowBig, -HowBig, -HowBig);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        transform.localScale -= new Vector3(HowBig, HowBig, HowBig);
    }
}
