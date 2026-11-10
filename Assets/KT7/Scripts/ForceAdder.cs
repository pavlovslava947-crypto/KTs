using System.Collections;
using UnityEngine;

public class ForceAdder : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius = 15f;
    [SerializeField] private float _threshold = 0;
    [SerializeField] private Material _material;
    private Vector3 _center;
    private Rigidbody _rb;
    private Collider[] _colliders;
    private float _timeBelowThreshold = 0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _center = transform.position;

    }


    void FixedUpdate()
    {
        _colliders = Physics.OverlapSphere(_center, _radius);

        if (_colliders.Length > 0)
        {
            _rb.WakeUp();
            _rb.AddForce(Vector3.up * _force, ForceMode.Impulse);

            _material.color = Color.red;

            StartCoroutine(Porog());
        }

        else
        {
            _material.color = Color.green;
        }
    }

    IEnumerator Porog()
    {
        do
        {
            yield return null;

            float speed = _rb.linearVelocity.magnitude;

            if (speed < _threshold)
            {
                _timeBelowThreshold += Time.deltaTime;
            }

        } while (_rb.linearVelocity.magnitude < _threshold);


        Debug.Log($"Время ниже порога: {_timeBelowThreshold} секунд");
    }


}
