using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimatorController : MonoBehaviour, 
                                        IPointerEnterHandler, 
                                        IPointerExitHandler 
{
    private Animator animator;
    private const string IS_HOVERING_PARAM = "IsHovering"; 
    public string pulseClipName = "Button_Pulse"; 

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on the button.");
            return;
        }

        // animator.Play(pulseClipName);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (animator != null)
        {
            animator.SetBool(IS_HOVERING_PARAM, true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (animator != null)
        {
            animator.SetBool(IS_HOVERING_PARAM, false);
        }
    }
}