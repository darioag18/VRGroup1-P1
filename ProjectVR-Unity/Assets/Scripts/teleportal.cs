using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class teleportal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject persona;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Personaje")
        {
            SceneManager.LoadScene(3);
        }
    }
}
