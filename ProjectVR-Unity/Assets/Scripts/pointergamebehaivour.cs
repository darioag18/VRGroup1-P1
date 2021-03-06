using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    private AudioSource[] _audio;
    public float tiempoRes = 0.0f;
    
    private bool ninoRes, elfoRes, lenadoraRes, cajeroRes, constructoraRes = false;
    private bool ninoShow, elfoShow, lenadoraShow, cajeroShow, constructoraShow = false;

    public Canvas canvas1;
    public Canvas canvas2;
    public Canvas canvas3;
    public Canvas canvas4;
    public Canvas canvas5;
    public GameObject book;
    public GameObject wallToDestroy;
    

    [SerializeField]
    public TextMeshProUGUI _texto;
    public TextMeshProUGUI _textCount;
    public TextMeshProUGUI _textResVerify;

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
        if (contador >= 5)
        {
            Destroy(wallToDestroy);
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

                if (hit.transform.tag == "nino")
                {
                    if (!ninoRes) {
                        _audio = hit.transform.GetComponents<AudioSource>();
                        Debug.Log(_audio);
                      
                        if(!ninoShow){
                            _audio[0].Play();

                        }

                        canvas1.enabled = true;
                        ninoShow = true;
                    }
                }

                if (hit.transform.tag == "elfo")
                {
                    if (!elfoRes) {
                        _audio = hit.transform.GetComponents<AudioSource>();
                        if(!elfoShow){
                            _audio[0].Play();
                        }
                        
                        canvas2.enabled = true;
                        elfoShow = true;
                    }
                }

                if (hit.transform.tag == "lenadora")
                {
                    if (!lenadoraRes) {
                        _audio = hit.transform.GetComponents<AudioSource>();
                        if(!lenadoraShow){
                            _audio[0].Play();    
                        }

                        
                        canvas3.enabled = true;
                        lenadoraShow = true;
                    }
                }

                if (hit.transform.tag == "cajero")
                {
                    if (!cajeroRes) {
                        _audio = hit.transform.GetComponents<AudioSource>();
                        if(!cajeroShow){
                            _audio[0].Play();    
                        }

                        
                        canvas4.enabled = true;
                        cajeroShow = true;
                    }
                }

                if (hit.transform.tag == "constructora")
                {
                    if (!constructoraRes) {
                        _audio = hit.transform.GetComponents<AudioSource>();

                        if(!constructoraShow){
                            _audio[0].Play();    
                        }
                        
                        canvas5.enabled = true;
                        constructoraShow = true;
                    }
                }
                if (hit.transform.tag == "book")
                {
                    book.SetActive(true);
                    _texto.text = "Wh Questions.\nUse do and does to make questions. ???Does??? for third person singular (he/she/it) and ???Do??? for others (I/you/we/they). Wh + Auxiliary + Subject + Verb";
                }
                if (hit.transform.tag == "book2")
                {
                    book.SetActive(true);
                    _texto.text = "Yes/No Questions.\n Yes/no Questions Those questions can be answered by yes or no.Auxiliary + Subject + Verb";
                }
                if (hit.transform.tag == "book3")
                {
                    book.SetActive(true);
                    _texto.text = "Affirmative. \n To make positive sentences, the pronouns I/you/we/they always go at the beginning of the sentence and the verb keeps in its base form.";
                }
                 if (hit.transform.tag == "book4")
                {
                    book.SetActive(true);
                    _texto.text = "Negative. \n To make negative sentences, we need to use the same rules of positive sentences, but with conjugations ???do not??? (don???t) to I/you/we/they pronouns or ???does not??? (doesn???t) to he/she/it pronouns.To make the verb to be negative, the structure of the sentence is to be + not. ";
                }
                  if (hit.transform.tag == "book5")
                {
                    book.SetActive(true);
                    _texto.text = "Conjugation. \nIn the present simple 3rd person singular adds ???s???, ???es??? or ???ies??? to the base form of the verb:"
                    +"\n For verbs that end in ???X???, ???Z???, ???O???, ???H???, ???SS??? or ???SH??? we add ???ES???"
                    +"\nFor verbs that end in consonant + ???Y??? we remove the ???Y??? and add ???IES???"
                    +"\nFor other verbs that end in vowel + ???Y??? we add a ???S???";
                }


                // Options
                // Right options
                if (hit.transform.tag == "rightAns1")
                {
                    if (ninoShow) 
                    {   
                        _audio = hit.transform.GetComponents<AudioSource>();
                        Debug.Log(_audio);
                        _audio[0].Play();

                        contador++;
                        _textCount.text = contador.ToString() + "/5";
                        ninoRes = true;
                        canvas1.enabled = false;
                        StartCoroutine(ShowVerificationAns("Correct Answer", 3, true));
                        ninoShow = false;
                    }
                }
                if (hit.transform.tag == "rightAns2")
                {
                    if (elfoShow) 
                    {
                        _audio = hit.transform.GetComponents<AudioSource>();
                        Debug.Log(_audio);
                        _audio[0].Play();
                        contador++;
                        _textCount.text = contador.ToString() + "/5";
                        elfoRes = true;
                        canvas2.enabled = false;
                        StartCoroutine(ShowVerificationAns("Correct Answer", 3, true));
                        elfoShow = false;
                    }
                }
                if (hit.transform.tag == "rightAns3")
                {
                    if (lenadoraShow) 
                    {
                        _audio = hit.transform.GetComponents<AudioSource>();
                        Debug.Log(_audio);
                        _audio[0].Play();
                        contador++;
                        _textCount.text = contador.ToString() + "/5";
                        lenadoraRes = true;
                        canvas3.enabled = false;
                        StartCoroutine(ShowVerificationAns("Correct Answer", 3, true));
                        lenadoraShow = false;
                    }
                }
                if (hit.transform.tag == "rightAns4")
                {
                    if (cajeroShow) 
                    {
                        _audio = hit.transform.GetComponents<AudioSource>();
                        Debug.Log(_audio);
                        _audio[0].Play();
                        contador++;
                        _textCount.text = contador.ToString() + "/5";
                        cajeroRes = true;
                        canvas4.enabled = false;
                        StartCoroutine(ShowVerificationAns("Correct Answer", 3, true));
                        cajeroShow = false;
                    }
                }
                if (hit.transform.tag == "rightAns5")
                {
                    if (constructoraShow) 
                    {
                        _audio = hit.transform.GetComponents<AudioSource>();
                        Debug.Log(_audio);
                        _audio[0].Play();
                        contador++;
                        _textCount.text = contador.ToString() + "/5";
                        constructoraRes = true;
                        canvas5.enabled = false;
                        StartCoroutine(ShowVerificationAns("Correct Answer!", 3, true));
                        constructoraShow = false;
                    }
                }
                // Wrong options
                if (hit.transform.tag == "wrongAns1")
                {
                    if (ninoShow) 
                    {
                        _audio = hit.transform.GetComponents<AudioSource>();
                        Debug.Log(_audio);
                        _audio[0].Play();
                        StartCoroutine(ShowVerificationAns("Wrong Answer", 2, false));
                    }
                }
                if (hit.transform.tag == "wrongAns2")
                {
                    if (elfoShow) 
                    {
                        _audio = hit.transform.GetComponents<AudioSource>();
                        Debug.Log(_audio);
                        _audio[0].Play();
                        StartCoroutine(ShowVerificationAns("Wrong Answer", 2, false));
                    }
                }
                if (hit.transform.tag == "wrongAns3")
                {
                    if (lenadoraShow) 
                    {
                        _audio = hit.transform.GetComponents<AudioSource>();
                        Debug.Log(_audio);
                        _audio[0].Play();
                        StartCoroutine(ShowVerificationAns("Wrong Answer", 2, false));
                    }
                }
                if (hit.transform.tag == "wrongAns4")
                {
                    if (cajeroShow) 
                    {
                        _audio = hit.transform.GetComponents<AudioSource>();
                        Debug.Log(_audio);
                        _audio[0].Play();
                        StartCoroutine(ShowVerificationAns("Wrong Answer", 2, false));
                    }
                }
                if (hit.transform.tag == "wrongAns5")
                {
                    if (constructoraShow) 
                    {
                        _audio = hit.transform.GetComponents<AudioSource>();
                        Debug.Log(_audio);
                        _audio[0].Play();
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
            /*canvas1.enabled = false;
            canvas2.enabled = false;
            canvas3.enabled = false;
            canvas4.enabled = false;
            canvas5.enabled = false;*/
            book.SetActive(false);
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
