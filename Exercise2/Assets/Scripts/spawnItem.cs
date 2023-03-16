using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnItem : MonoBehaviour
{
    public GameObject GameObject1;
    public GameObject GameObject2;
    private GameObject Clone;
    private GameObject toSpawn;
    public float timeToSpawn = 4f;
    public float FirstSpawn = 10f;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        FirstSpawn -= Time.deltaTime;
        if (FirstSpawn <= 0f)
        {
            Vector2 randPos = new Vector2(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y)
            );

            if(Random.Range(1,5) == 1){
                toSpawn = GameObject2;
            }else{
                toSpawn = GameObject1;
            }

            Clone = Instantiate(toSpawn, randPos, Quaternion.identity);
            Clone.GetComponent<Rigidbody2D>().gravityScale = 1;
            FirstSpawn = timeToSpawn;
        }
    }
}
