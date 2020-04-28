using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Worm : MonoBehaviour
{
    public Rigidbody2D _rbWorm;

    public float _fSpeed = 1f;

    public float _fMinSpeed = 8f;
    public float _fMaxSpeed = 12f;

    // Start is called before the first frame update
    void Start()
    {
        _fSpeed = Random.Range(_fMinSpeed, _fMaxSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);
        //
        _rbWorm.position = _rbWorm.position + forward * Time.fixedDeltaTime * _fSpeed;
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
        UnityEngine.Debug.Log("'" + name + "' can not be seen anymore.");
    }

}
