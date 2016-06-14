using UnityEngine;
using System.Collections;
using UnityChan;

public class Sphere : MonoBehaviour
{

    private GameObject explosion;
    private GameObject mainCameraObject;

    void Start()
    {
        explosion = (GameObject)Resources.Load("Explosion");
        mainCameraObject = GameObject.FindWithTag("MainCamera");
    }

    public void OnCollisionEnter(Collision collision2d)
    {
        ShakeCamera();
        Instantiate(explosion, this.gameObject.transform.localPosition, Quaternion.identity);
        Destroy(this.gameObject);
    }

    void ShakeCamera ()
    {
        //iTween.ShakePosition(mainCameraObject, iTween.Hash("x", 0.3f, "y", 0.3f, "time", 0.1f));
    }
}
