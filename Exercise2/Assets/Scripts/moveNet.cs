using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveNet : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;
    public float maxX = 10;
    public float minX = -10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rawHorizontalAxis = Input.GetAxisRaw("Horizontal");
        
        Vector3 direction = Vector3.zero;
        direction.x = rawHorizontalAxis;

        float timeSinceLastFrame = Time.deltaTime;

        Vector3 translation = direction * timeSinceLastFrame * speed;
        transform.Translate(translation);


    }


}
