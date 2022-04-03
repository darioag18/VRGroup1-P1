using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject persona;
    public GameObject puntollegada;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Personaje")
        {

            /*micamara = transform.GetComponentInChildren<Camera>();
            micamara.transform.rotation = Quaternion.Slerp(micamara.transform.rotation, puntollegada.transform.rotation, 1);
            micamara.transform.position = new Vector3(puntollegada.transform.position.x, puntollegada.transform.position.y, puntollegada.transform.position.z);
            */
            persona.transform.position = new Vector3(puntollegada.transform.position.x, puntollegada.transform.position.y +1.5f, puntollegada.transform.position.z);

            /* transform.rotation = puntollegada.transform.rotation;
            transform.localScale = puntollegada.transform.localScale;
            transform.LookAt(Vector3.forward);*/
        }
    }
}
