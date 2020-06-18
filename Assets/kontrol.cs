using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kontrol : MonoBehaviour
{

    private float targetPoint = -16f;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        if (gameControl.instantiate.gameOver == false && gameControl.instantiate.press)
        {
            MoveToWardsCloud();
        }
        
        
    }



    private void MoveToWardsCloud()
    {
        
            Vector2 _vector = transform.position;
            _vector.y = Mathf.MoveTowards(_vector.y, targetPoint, 0.03f * movement.instantiate.speed);
            if (Mathf.Abs(_vector.y - targetPoint) < 0.01f)
            {
                _vector.y = targetPoint;

            }
            transform.position = _vector;
            if (transform.position.y == -16)
            {
                transform.position = new Vector3(transform.position.x, 13f, transform.position.z);
            }
        
        
    }


}
