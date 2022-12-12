using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapController : MonoBehaviour
{
    public Animator anim;
    public SwapTexture swapTexture;
    public SwapTextureShader swapTextureShader;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10,10,200,50), "SwitchPose"))
        {
            anim.SetTrigger("SwitchPose");
            swapTexture.Invoke("SwitchTexture", 0.3f);
        }

        if (GUI.Button(new Rect(10, 80, 200, 50), "Switch Shader Texture"))
        {
            swapTextureShader.SwitchTexture();
        }
    }

    public void AnimationEventSwapTexture()
    {
        anim.SetTrigger("SwitchPose");
        swapTexture.Invoke("SwitchTexture", 0.3f);
    }
}
