using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.02f;
    [SerializeField] Color32 hasPackColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackColor = new Color32(0, 1, 0, 1);
    [SerializeField] GameObject package;
    [SerializeField] GameObject costumer;

    float mapSizeHeight = 100;
    float mapSizeWidth = 15;

    int packCounter;

   Vector3[] positions = {  new Vector3 { x = 22, y = 3, z = 5 }, 
                            new Vector3 { x = 4, y = -16, z = 5},
                            new Vector3 { x = -2, y = 41, z = 5}, 
                            new Vector3 { x = -22, y = 10, z = 5},
                            new Vector3 { x = -8, y = 23, z = 5}, 
                            new Vector3 { x = 120, y = 10, z = 5}, 
                            new Vector3 { x = 155, y = 32, z = 5},
                            new Vector3 { x = 149, y = -11, z = 5}, 
                            new Vector3 { x = 109, y = -64, z = 5},
                            new Vector3 { x = 120, y = -32, z = 5},   
                            }; // possible positions for costumer spawns, ideally to be set next to an house
    

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        packCounter = 0;   
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        float randomXSpawn = Random.Range(-10, mapSizeWidth);
        float randomYSpawn = Random.Range(-40, mapSizeHeight);
        if (other.tag == "Package" && !hasPackage)
        {
            int tempPos = Random.Range(0, positions.Length);
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackColor;
            Instantiate(costumer,  positions[tempPos], Quaternion.identity);
        }
        else if (other.tag == "Costumer" && hasPackage)
        {
            hasPackage = false;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = noPackColor;
            Instantiate(package,  new Vector3(randomYSpawn, randomXSpawn, 0), Quaternion.identity);
            Counter.packsDelivered++;
        }
    }
}
