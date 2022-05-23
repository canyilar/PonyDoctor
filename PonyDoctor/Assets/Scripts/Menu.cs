using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Menu : MonoBehaviour
{
    int wallet = 0;
    int day = 1;

    [SerializeField]
    Image flash;

    [SerializeField]
    Texture[] palettes;

    int lastChoosenIndex;

    [SerializeField]
    TMP_Text scoreText;

    [SerializeField]
    GameObject stablePrefab;

    float stableWidthMultiplier = 3.373f;
    [SerializeField]
    GameObject oldStable;
    Material material;

    Transform currentDoor;

    private void Start()
    {
        if (stablePrefab)
        {
            material = stablePrefab.transform.GetChild(0).GetChild(5).GetComponent<Renderer>().sharedMaterial;
           
        }
        if (oldStable)
        {
            currentDoor = oldStable.transform.GetChild(1).GetChild(0);
        }
    }

    public void OnEnable()
    {

        flash.color = new Color(1, 1, 1, 1);
        flash.DOColor(new Color(1, 1, 1, 0), 0.5f);
    }

    public void ChangeScene(string sceneName)
    {
        currentDoor.DORotate(new Vector3(0f, 120f, 0f), 0.5f).OnComplete(()=> { flash.DOColor(new Color(1, 1, 1, 1), 0.5f).OnComplete(() => SceneManager.LoadScene(sceneName)); });
       
    }

    public void NextDay()
    {
        if (stablePrefab==null)
        {
            return;
        }

            Vector3 newPos = stablePrefab.transform.position;
        newPos.x=(day* stableWidthMultiplier);
        GameObject stable = Instantiate(stablePrefab, newPos, Quaternion.identity);
        currentDoor = stable.transform.GetChild(1).GetChild(0);


        lastChoosenIndex = Random.Range(0, palettes.Length);
        print(lastChoosenIndex);
        Material _material = new Material(material);
        _material.SetTexture("_MainTex", palettes[lastChoosenIndex]);
        stable.transform.GetChild(0).GetChild(5).GetComponent<Renderer>().sharedMaterial = _material;

        float newX = (day * stableWidthMultiplier);
        Camera.main.transform.DOMoveX(newX, 1f).OnComplete(() => { Destroy(oldStable); oldStable = stable; });
        

        day++;
        scoreText.text = "DAY" + day;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)){

            NextDay();
        }
    }


}
