using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.XR.Management;


public class CargarJuego : MonoBehaviour
{
    private IEnumerator couroutine;
    public VideoPlayer mivideo;

    public void Cargando()
    {
        couroutine = WaitVideoandLoadScene(63.0f);
        StartCoroutine(couroutine);
    }


    private IEnumerator WaitVideoandLoadScene(float waitTime)
    {
        while (true)
            { 
                yield return new WaitForSeconds(waitTime);
                SceneManager.LoadScene(2);
             }
        

    }

    private void Start()
    {
        mivideo.Play();
        Cargando(); 
    }
}
