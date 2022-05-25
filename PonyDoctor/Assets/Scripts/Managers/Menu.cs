using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField]
    Image flash;


    [SerializeField]
    TMP_Text scoreText;

    [SerializeField]
    GameObject stablePrefab;

    float stableWidthMultiplier = 3.373f;
    [SerializeField]
    GameObject oldStable;
    Material material;

    Transform currentDoor;


    Transform currentStable;


    private void Start()
    {

        if (oldStable)
        {
            material = oldStable.transform.GetChild(0).Find("Mesh.057").GetComponent<Renderer>().sharedMaterial;
            currentDoor = oldStable.transform.GetChild(1).GetChild(0);
        }
    }

    private void OnEnable()
    {

        flash.color = new Color(1, 1, 1, 1);
        flash.DOColor(new Color(1, 1, 1, 0), 0.5f);

        SceneManager.sceneLoaded += NextDay;

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= NextDay;
    }

    public void ChangeScene(string sceneName)
    {
        if (currentDoor == null)
        {
            currentDoor=currentStable.GetChild(1).GetChild(0);
        }

        currentDoor.DORotate(new Vector3(0f, 120f, 0f), 0.5f).OnComplete(() => {
            flash.DOColor(new Color(1, 1, 1, 1), 0.5f).
            OnComplete(() =>
            {
                PonyTextures.Instance.firstTimeOpen = false; 
                SceneManager.LoadScene(sceneName);
            });
            });
    }

    public void NextDayOnClick()
    {
        NextDay(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }


    public void NextDay(Scene _scene, LoadSceneMode _loadSceneMode)
    {
        if (stablePrefab==null)
        {
            return;
        }

        if (_scene.name != "MainMenu")
        {
            return;
        }

        if (PonyTextures.Instance.firstTimeOpen)
            return;

        Vector3 newPos = stablePrefab.transform.position;
        newPos.x=(PonyTextures.Instance.day* stableWidthMultiplier);
        GameObject stable = Instantiate(stablePrefab, newPos, Quaternion.identity);
        currentDoor = stable.transform.GetChild(1).GetChild(0);
        currentStable = stable.transform;

        if (material==null && oldStable)
        {
            material = oldStable.transform.GetChild(0).Find("Mesh.057").GetComponent<Renderer>().sharedMaterial;
        }


        Material _material = new Material(material);
        _material.SetTexture("_MainTex", PonyTextures.Instance.GetRandomTexture());


        stable.transform.GetChild(0).GetChild(5).GetComponent<Renderer>().sharedMaterial = _material;

        float newX = (PonyTextures.Instance.day * stableWidthMultiplier);
        Camera.main.transform.DOMoveX(newX, 1f).OnComplete(() => { Destroy(oldStable); oldStable = stable; });


        PonyTextures.Instance.day++;
        scoreText.text = "DAY" + PonyTextures.Instance.day;
    }






    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)){

            NextDay(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }
    }


}
