using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_playerHasHit)
        {
            GameObject _collider = collision.gameObject;
            if (_collider.CompareTag("Player"))
            {
                _playerHasHit = true;
                float _rotationAngleZ = -30;
                Quaternion _rotation = Quaternion.Euler(0, 0, _rotationAngleZ);
                gameObject.transform.rotation = _rotation ;

                // Pivot point is around center point:
                // Simulate object having pivot point on base.
                if (RotatingRight(_rotationAngleZ))
                {
                    float _gameObjHeight = 5.12f; // hardcoded from boxcollier (TODO change this!)
                    float _x = (_gameObjHeight / 2) * Mathf.Sin(DegToRad(_rotationAngleZ));
                    float _y = (_gameObjHeight / 2) * (1 - Mathf.Cos(DegToRad(_rotationAngleZ)));
                    gameObject.transform.position -= new Vector3(_x, 0, 0);
                    gameObject.transform.position += new Vector3(0,-_y, 0);
                }
            }
        }
    }

    private bool _playerHasHit = false;
    private bool RotatingRight(double rotationAngle)
    {
        return rotationAngle < 0;
    }

    private bool RotatingLeft(double rotationAngle)
    {
        return rotationAngle > 0;
    }

    private float DegToRad(float angleInDegrees)
    {
        return (Mathf.PI/180f) * angleInDegrees;
    }

}
