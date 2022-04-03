using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuGaze : MonoBehaviour
{
    // Variables for distance from camera and menu

    private const float _minObjectDistance = 2.5f;
    private const float _maxObjectDistance = 3.5f;
    private const float _minObjectHeight = 0.5f;
    private const float _maxObjectHeight = 3.5f;

    public GameObject animarMenu;
    MenuAnimacion menuAnimado;


    public void OnPointerMenuQEnter()
    {
     
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
			Application.Quit();
        #endif
    }

    public void OnPointerMenuL0Enter()
    {
        SceneManager.LoadScene(2);
        
    }

    public void OnPointerMenuL1Enter()
    {
        SceneManager.LoadScene(3);

    }
    public void OnPointerExit()
    {

    }

    public void OnPointerMenuL0Exit()
    {

    }

    public void OnPointerMenuL1Exit()
    {

    }

    public void OnPointerMenuQExit()
    {

    }

    private void Update()
    {
        ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);

    }
    private void Start()
    {
        menuAnimado = animarMenu.GetComponent<MenuAnimacion>();
    }
}