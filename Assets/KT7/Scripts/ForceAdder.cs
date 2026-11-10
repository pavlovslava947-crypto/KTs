using System.Collections;
using UnityEngine;

public class ForceAdder : MonoBehaviour
{
    [SerializeField] private float _timeBelowThreshold = 0f;
    [SerializeField] private float _force;
    [SerializeField] private float _radius = 15f;
    [SerializeField] private float _threshold = 0;
    [SerializeField] private Material _material;
    private Vector3 _center;
    private Rigidbody _rb;
    private Collider[] _colliders;
    
    void Start()
    {
       _rb = GetComponent<Rigidbody>();
        _center = transform.position;
        
    }

   
    void FixedUpdate()
    {
        _colliders = Physics.OverlapSphere(_center, _radius);

        foreach (Collider collider in _colliders)
        {
            if (collider)
            {
                _rb.WakeUp();
                _rb.AddForce(Vector3.up * _force, ForceMode.Impulse);
                
                StartCoroutine(Porog());
            }
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
