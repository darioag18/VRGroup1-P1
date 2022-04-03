using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAndWalk : MonoBehaviour
{
    public Transform vrCamera;
    public float puntolimite = 30.0f;

    public float speed = 1.0f;

    private bool moviendose;
    Vector3 adelante;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moverse();
    }




    private void moverse()
    {
         if (vrCamera.eulerAngles.x >= puntolimite && vrCamera.eulerAngles.x< 90.0f)
        {
            moviendose = true;
        }
        else
        {
            moviendose = false;
        }

        if (moviendose)
            {
                adelante = vrCamera.transform.TransformDirection(Vector3.forward);
                adelante *= speed * Time.deltaTime;
                adelante.y = 0f;
                transform.position += adelante;
            }
      /*  if (vrCamera.rotation.eulerAngles.y > 20 && vrCamera.rotation.eulerAngles.y < 350f)
        {
            Quaternion rotacion = vrCamera.transform.rotation;
            Quaternion mirando = transform.rotation;
            transform.rotation = Quaternion.Slerp(mirando, rotacion, speed * Time.deltaTime);
        }*/
    }
}
