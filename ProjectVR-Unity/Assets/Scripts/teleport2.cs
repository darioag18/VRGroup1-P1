using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport2 : MonoBehaviour
{

    void OnTriggerEnter()
    {
        SceneManager.LoadScene(4);
    }

    
}
