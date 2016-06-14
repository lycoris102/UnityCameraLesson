using UnityEngine;
using System.Collections;

public class SphereSpawner : MonoBehaviour {

    public float spawnInterval = 5.0f;
    public GameObject sphere;

    void Start () {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn ()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            var position = new Vector3(
                Random.Range(-5.0f, 5.0f),
                10.0f,
                Random.Range(-5.0f, 5.0f)
            );
            Instantiate(sphere, position, Quaternion.identity);
        }
    }
}
