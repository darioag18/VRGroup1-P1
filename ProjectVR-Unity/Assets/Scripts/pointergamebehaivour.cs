using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pointergamebehaivour : MonoBehaviour
{
    private const float _maxDistance = 20.0f;
    private GameObject _gazedAtObject = null;
    public float tiempoclick = 1.0f;
    private float tiempotrasncurrido = 0.0f;
    public Image puntero;
    private int contador = 0;
    private AudioSource _audioexplosion;

    [SerializeField]
    private TextMeshProUGUI _textMeshProUGUI;


    // Update is called once per frame
    void Update()
    {
        DispararRayo();
        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClick");
        }
    }

    void DispararRayo()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {

            tiempotrasncurrido += Time.deltaTime;
            puntero.fillAmount = (1.0f * tiempotrasncurrido) / tiempoclick;


            // GameObject detected in front of the camera.
            if ((_gazedAtObject != hit.transform.gameObject) && tiempotrasncurrido >= tiempoclick)
            {

                if (hit.transform.tag == "enemy")
                {
                    //Debug.Log("Eliminado  :" + hit.transform.name);
                    contador++;
                    _audioexplosion = hit.transform.GetComponent<AudioSource>();
                    _audioexplosion.Play();
                    _textMeshProUGUI.text = contador.ToString();
                    StartCoroutine(DestruirEnemigo(hit.transform.gameObject));
                }

                if (hit.transform.tag =="teleport" && hit.transform.name != "Portal 4")
                {
                    _gazedAtObject = hit.transform.gameObject;
                    _gazedAtObject.SendMessage("teleportMove");
                    _gazedAtObject = null;
                }
                if (hit.transform.tag =="teleport" && hit.transform.name == "Portal 4")
                {
                    _gazedAtObject = hit.transform.gameObject;
                    _gazedAtObject.SendMessage("teleportEscena");
                    _gazedAtObject = null;
                }
                tiempotrasncurrido = 0.0f;
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            //_gazedAtObject?.SendMessage("OnPointerExit");
            //  _gazedAtObject?.SendMessage("CargarAnimacion");
            //  _gazedAtObject = null;
            puntero.fillAmount = 0.0f;

        }
    }

    private IEnumerator DestruirEnemigo(GameObject enemigo)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Destroy(enemigo);
        }
    }
        
}
