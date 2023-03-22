using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    public Sprite blank;
    public List<Sprite> positions = new List<Sprite>();
    public int place;
    [SerializeField]
    private Sprite character;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //Get the animation controller
        anim = GetComponent<Animator>();
        anim.StopPlayback();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Get the spawnChars game object and pull the randomized positions list
    public void setChar(){
        positions = GameObject.Find("spawnChars").GetComponent<spawnPos>().mixed;
        //Set the character according to the place of the card in relation to the randomized list
        character = positions[place];
        gameObject.GetComponent<SpriteRenderer>().sprite = character;
    }

    //Set the card to the blank sprite
    public void setBlank(){
        gameObject.GetComponent<SpriteRenderer>().sprite = blank;
    }

    void OnMouseDown() {
        //Only flip if the sprite is blank and the animmation isn't already running
        if(!(anim.GetCurrentAnimatorStateInfo(0).length > anim.GetCurrentAnimatorStateInfo(0).normalizedTime) && gameObject.GetComponent<SpriteRenderer>().sprite == blank){
            //Animate the flip
            anim.SetTrigger("Clicked");
            GameObject match = GameObject.Find("matchHandler");
            gameObject.GetComponent<SpriteRenderer>().sprite = character;
            //Determine which pick the character is and save it
            if(match.GetComponent<match>().firstPick == null){
                match.GetComponent<match>().firstPick = character;
                match.GetComponent<match>().firstPlace = place;
            }else{
                match.GetComponent<match>().secondPick = character;
                match.GetComponent<match>().secondPlace = place;
            }
        }
        
    }
}
