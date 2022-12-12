using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapController : MonoBehaviour
{
    public Animator anim;
    public SwapTexture swapTexture;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10,10,200,50), "SwitchPose"))
        {
            anim.SetTrigger("SwitchPose");
            swapTexture.Invoke("SwitchTexture", 0.3f);
        }
    }

    public void AnimationEventSwapTexture()
    {
        anim.SetTrigger("SwitchPose");
        swapTexture.Invoke("SwitchTexture", 0.3f);
    }
}
