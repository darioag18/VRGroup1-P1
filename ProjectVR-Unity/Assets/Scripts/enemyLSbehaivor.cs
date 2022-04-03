using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLSbehaivor : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemigoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies()); 
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float rnd = Random.Range(-0.52f, 0.49f);
            Vector3 lugar = new Vector3(transform.position.x,transform.position.y, rnd);
            Instantiate(_enemigoPrefab,lugar,Quaternion.Euler(transform.rotation.x,0,0));
            yield return new WaitForSeconds(7);

        }
    }
 
}
