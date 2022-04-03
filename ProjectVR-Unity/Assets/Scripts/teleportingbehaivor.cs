using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleportingbehaivor : MonoBehaviour
{
    public GameObject _player;

    public void teleportMove()
    {
        _player.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
    }

    public void teleportEscena()
    {
        SceneManager.LoadScene(3);
    }
}
