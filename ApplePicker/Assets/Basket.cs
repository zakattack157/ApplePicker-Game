using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public AppleTree appleTree;
    public Rounds rounds;
    public GameObject restartButton;
    public ScoreCounter scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        GameObject appleTreeGO = GameObject.Find("AppleTree");
        GameObject roundsGO = GameObject.Find("Round");
        GameObject restartGO = GameObject.Find("Restart");


        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        appleTree = appleTreeGO.GetComponent<AppleTree>();
        rounds = roundsGO.GetComponent<Rounds>();
        restartButton = restartGO;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            scoreCounter.score += 100;

            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }

        else if (collidedWith.CompareTag("Stick"))
        {
            Destroy(collidedWith);
            appleTree.CancelInvoke();
            GameObject[] stickArray = GameObject.FindGameObjectsWithTag("Stick");
            foreach (GameObject tempGO in stickArray)
            {
                Destroy(tempGO);
            }
            rounds.GameOver();
            
        }
    }
}
