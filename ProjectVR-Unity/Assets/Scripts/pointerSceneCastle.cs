using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pointerSceneCastle : MonoBehaviour
{
    private const float _maxDistance = 10.0f;
    private GameObject _gazedAtObject = null;
    public float tiempoclick = 1.0f;
    private float tiempotrasncurrido = 20.0f;
    public Image puntero;
    private int contador = 0;
    private AudioSource _audioexplosion;
    public float tiempoRes = 0.0f;
    
    private bool kingRes = false;

    public Canvas canvas1;
    

    [SerializeField]
    public TextMeshProUGUI _texto;
    public TextMeshProUGUI _textCount;
    public TextMeshProUGUI _textResVerify;

    void Start()
    {   
        canvas1.GetComponent<Canvas> ().enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        DispararRayo();
        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClick");
        }
        if (contador >= 1)
        {
            
        }
    }

    void DispararRayo()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            tiempoRes += Time.deltaTime;
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
                    //_textMeshProUGUI.text = contador.ToString();
                    
                    Debug.Log("asdasdsadsad");
                    //StartCoroutine(DestruirEnemigo(hit.transform.gameObject));
                }

                if (hit.transform.tag == "king")
                {
                    if (!kingRes) {
                        _audioexplosion = hit.transform.GetComponent<AudioSource>();
                        _audioexplosion.Play();

                        canvas1.enabled = true;
                    }
                }


                // Options
                // Right options
                if (hit.transform.tag == "rightAnsKing")
                {
                    if (!kingRes) 
                    {
                        contador++;
                        _textCount.text = contador.ToString() + "/5";
                        kingRes = true;
                        canvas1.enabled = false;
                        StartCoroutine(ShowVerificationAns("Correct Answer", 3, true));
                    }
                }
                
                // Wrong options
                if (hit.transform.tag == "wrongAnsKing")
                {
                    if (!kingRes) 
                    {
                        StartCoroutine(ShowVerificationAns("Wrong Answer", 2, false));
                    }
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
            canvas1.enabled = false;
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

    private IEnumerator ShowVerificationAns (string message, float delay, bool correct) {
        _textResVerify.text = message;
        if (!correct)
        {
            _textResVerify.color = new Color(255, 0, 0, 255);
        } else
        {
            _textResVerify.color = new Color(0, 255, 0, 255);
        }
        _textResVerify.enabled = true;
        yield return new WaitForSeconds(delay);
        _textResVerify.enabled = false;
    }
        
}
