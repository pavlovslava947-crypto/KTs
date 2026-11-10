using System.Collections;
using System.Linq.Expressions;
using UnityEngine;

public class CubeBubbleSort : MonoBehaviour
{
    [SerializeField] private GameObject[] _cubes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BubbleSort();
    }


    public void BubbleSort()
    {
        for(int i = 0; i < _cubes.Length - 1; i++)
        {
          
            for(int j = 0; j < _cubes.Length - i - 1; j++)
            {
                if (_cubes[j].transform.localScale.magnitude < _cubes[j +1].transform.localScale.magnitude)
                {
                    var temp = _cubes[j];
                    _cubes[j] = _cubes[j + 1];
                    _cubes[j + 1] = temp;

                    
                }
            }
        }

        for(int i = 0; i < _cubes.Length; i++)
        {
            _cubes[i].transform.position = new Vector3(8f * i, 0, 0);
        }
    }

    

    
}
