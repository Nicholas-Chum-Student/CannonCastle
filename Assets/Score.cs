using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text scoreDisplay;
    public int TwoStars = 4;
    public int ThreeStars = 2;
    public Animator scoreAnimator;
    public int score = 0;
    public int nextLevel = 0;
    public void EndLevel()
    {
        Cannon cannon = FindObjectOfType<Cannon>();

        if (cannon)
        {
            int numProjectiles = cannon.numProjectiles;

            if (numProjectiles < ThreeStars)
            {
                print("You earned 3 stars!");
                scoreDisplay.text = "3 stars!";
                score = 3;
                scoreAnimator.SetInteger("Stars", 3);
            }
            else if (numProjectiles < TwoStars)
            {
                print("You earned 2 stars!");
                scoreDisplay.text = "2 stars!";
                score = 2;
                scoreAnimator.SetInteger("Stars", 2);
            }
            else
            {
                print("You earned a star!");
                scoreDisplay.text = "One star!";
                score = 1;
                scoreAnimator.SetInteger("Stars", 1);
            }
            Invoke("NextLevel", 2);
        }
    }
    void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
