using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class collisionHandler : MonoBehaviour
{
    public Text textBox;
    public Text gameOverTxt;
    // Start is called before the first frame update
    void Start()
    {
        gameOverTxt.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -10){
            Destroy(gameObject);  
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //Destroy(instance.GameObject, 5);
        if((gameObject.name).Contains("bomb(Clone)")){
            Debug.Log("Game over");
            textBox.GetComponent<score>().scoreCount = 0;
            textBox.text = ("Score: 0");
            quit();

        }else{
            int score = textBox.GetComponent<score>().scoreCount;
            score++;
            textBox.GetComponent<score>().scoreCount = score;
            Debug.Log("Score: " + score.ToString());
            textBox.text = ("Score: " + score.ToString());
        }
        Destroy(gameObject);
    }

    public void quit(){
        gameOverTxt.gameObject.SetActive(true);
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    IEnumerator gameOver(){
        
        yield return new WaitForSeconds(2f);
        //EditorApplication.Exitplaymode = true;
        textBox.GetComponent<score>().scoreCount = 0;
        
    }
}
