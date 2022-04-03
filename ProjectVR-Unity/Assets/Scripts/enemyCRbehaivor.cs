using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCRbehaivor : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemigoS;

    [SerializeField] 
    private GameObject _enemigoT;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float rnd = Random.Range(-0.48f, 0.48f);
            Vector3 lugar = new Vector3(rnd, transform.position.y, transform.position.z );
            Instantiate(_enemigoS, lugar, Quaternion.Euler(0, 180, 0));
            float rnd2 = Random.Range(-0.48f, 0.48f);
            float offset = Random.Range(-0.01f, 0.01f);
            Vector3 lugar2 = new Vector3(rnd2+offset, transform.position.y, transform.position.z);
            Instantiate(_enemigoT, lugar2, Quaternion.Euler(0, 180, 0));
            yield return new WaitForSeconds(14);

        }
    }


}
