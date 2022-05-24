using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pony : MonoBehaviour, IAnimated
{



    public void OnAnimationCompleted()
    {
        GameManager.Instance.actionAvaible = true;
        UIManager.Instance.ActivateFingerImage();
    }

    public void OnEnable()
    {
        Renderer ponyMeshRenderer = transform.Find("Mesh.057").GetComponent<Renderer>();
        Material oldMaterial  = transform.Find("Mesh.057").GetComponent<Renderer>().sharedMaterial;
        Material newMaterial = new Material(oldMaterial);
        newMaterial.SetTexture("_MainTex", PonyTextures.Instance.GetCurrentTexture());
        ponyMeshRenderer.sharedMaterial = newMaterial;
    }
}
