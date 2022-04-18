using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pointergamebehaivour : MonoBehaviour
{
    private const float _maxDistance = 10.0f;
    private GameObject _gazedAtObject = null;
    public float tiempoclick = 1.0f;
    private float tiempotrasncurrido = 20.0f;
    public Image puntero;
    private int contador = 0;
    private AudioSource _audioexplosion;
    public Canvas canvas1;
    public Canvas canvas2;
    public Canvas canvas3;
    public Canvas canvas4;
    public Canvas canvas5;
    public GameObject book;
    
    

    [SerializeField]
    public TextMeshProUGUI _texto;

    void Start()
    {   
        canvas1.GetComponent<Canvas> ().enabled = false;
        canvas2.GetComponent<Canvas> ().enabled = false;
        canvas3.GetComponent<Canvas> ().enabled = false;
        canvas4.GetComponent<Canvas> ().enabled = false;
        canvas5.GetComponent<Canvas> ().enabled = false;
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
                    //_textMeshProUGUI.text = contador.ToString();
                    
                    Debug.Log("asdasdsadsad");
                    //StartCoroutine(DestruirEnemigo(hit.transform.gameObject));
                }

                if (hit.transform.tag == "nino")
                {
                    _audioexplosion = hit.transform.GetComponent<AudioSource>();
                    _audioexplosion.Play();

                    canvas1.enabled = true;
                }

                if (hit.transform.tag == "elfo")
                {
                    _audioexplosion = hit.transform.GetComponent<AudioSource>();
                    _audioexplosion.Play();

                    canvas2.enabled = true;
                }

                if (hit.transform.tag == "lenadora")
                {
                    _audioexplosion = hit.transform.GetComponent<AudioSource>();
                    _audioexplosion.Play();

                    canvas3.enabled = true;
                }

                if (hit.transform.tag == "cajero")
                {
                    _audioexplosion = hit.transform.GetComponent<AudioSource>();
                    _audioexplosion.Play();

                    canvas4.enabled = true;
                }

                if (hit.transform.tag == "constructora")
                {
                    _audioexplosion = hit.transform.GetComponent<AudioSource>();
                    _audioexplosion.Play();

                    canvas5.enabled = true;
                }
                if (hit.transform.tag == "book")
                {
                    book.SetActive(true);
                    _texto.text = "Wh Questions.\nUse do and does to make questions. “Does” for third person singular (he/she/it) and “Do” for others (I/you/we/they). Wh + Auxiliary + Subject + Verb";
                }
                if (hit.transform.tag == "book2")
                {
                    book.SetActive(true);
                    _texto.text = "Yes/No Questions.\n Yes/no Questions Those questions can be answered by yes or no.Auxiliary + Subject + Verb";
                }
                if (hit.transform.tag == "book3")
                {
                    book.SetActive(true);
                    _texto.text = "Affirmative. \n To make positive sentences, the pronouns I/you/we/they always go at the beginning of the sentence and the verb keeps in its base form. To make positive sentences, the pronouns he/she/it need a complement to above conditions to the base form of the verb.";
                }
                 if (hit.transform.tag == "book4")
                {
                    book.SetActive(true);
                    _texto.text = "Negative. \n To make negative sentences, we need to use the same rules of positive sentences, but with conjugations “do not” (don’t) to I/you/we/they pronouns or “does not” (doesn’t) to he/she/it pronouns.To make the verb to be negative, the structure of the sentence is to be + not. ";
                }
                  if (hit.transform.tag == "book5")
                {
                    book.SetActive(true);
                    _texto.text = "Conjugation. \nIn the present simple 3rd person singular adds “s”, “es” or “ies” to the base form of the verb:"
                    +"\n For verbs that end in “X”, “Z”, “O”, “H”, “SS” or “SH” we add “ES”"
                    +"\nFor verbs that end in consonant + “Y” we remove the “Y” and add “IES”"
                    +"\nFor other verbs that end in vowel + “Y” we add a “S”";
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
            canvas2.enabled = false;
            canvas3.enabled = false;
            canvas4.enabled = false;
            canvas5.enabled = false;
           book.SetActive(false);
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
