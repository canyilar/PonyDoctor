using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonyTextures : MonoSingleton<PonyTextures>
{

    [SerializeField]
    Texture[] palettes;

    public int lastChoosenIndex;





    public Texture GetCurrentTexture()
    {
       return palettes[lastChoosenIndex];
    }


    public Texture GetRandomTexture()
    {
        lastChoosenIndex = Random.Range(0, palettes.Length);
        return palettes[lastChoosenIndex];
       
    }
}
