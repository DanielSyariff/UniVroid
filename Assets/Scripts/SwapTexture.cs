using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TextureSwapper
{
    public string name;
    public Material mat;
    public Texture texture_1;
    public Texture texture_2;
}

public class SwapTexture : MonoBehaviour
{
    public List<TextureSwapper> textureSwapper;

    public int textureIndex = 1;

    public void SwitchTexture()
    {
        if (textureIndex == 1)
        {
            foreach (var item_swap in textureSwapper)
            {
                item_swap.mat.SetTexture("_MainTex", item_swap.texture_2);
                item_swap.mat.SetTexture("_ShadeTexture", item_swap.texture_2);
            }

            textureIndex = 2;
        }
        else
        {
            foreach (var item_swap in textureSwapper)
            {
                item_swap.mat.SetTexture("_MainTex", item_swap.texture_1);
                item_swap.mat.SetTexture("_ShadeTexture", item_swap.texture_1);
            }

            textureIndex = 1;
        }
    }

    private void OnApplicationQuit()
    {
        if (textureIndex == 2)
        {
            SwitchTexture();
        }
    }
}
