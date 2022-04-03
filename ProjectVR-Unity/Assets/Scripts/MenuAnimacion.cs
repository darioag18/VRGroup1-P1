using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimacion : MonoBehaviour
{
    // Start is called before the first frame update

    Animator miCompAnimacion;

    void Start()
    {
        miCompAnimacion = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CargarAnimacion()
    {

        miCompAnimacion.SetBool("activomenu", false);
    }
    public void CargarAnimacionExit()
    {

        miCompAnimacion.SetBool("activomenu", true);
    }

    public void DetenerAnimacion()
    {
        miCompAnimacion.SetBool("activomenu", true);
    }
    public void DetenerAnimacionExit()
    {
        miCompAnimacion.SetBool("activomenu", false);
    }

}
