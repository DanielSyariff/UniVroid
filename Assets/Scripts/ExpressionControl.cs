using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpressionControl : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Slider sliderBlend;
    
    public void ChangeExpression(string trigger)
    {
        anim.SetTrigger(trigger);
    }

    private void Update()
    {
        anim.SetFloat("Blend", sliderBlend.value);
    }
}
