using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform[] pipes;
    int currentScore;
    Text scoretext;
    bool[] passed;

    void Start()
    {
        scoretext = FindObjectOfType<Text>();

        passed = new bool[pipes.Length];
    }

    void Update()
    {
        for (int i = 0; i < pipes.Length; i++)
        {
            if (pipes[i].position.x <= transform.position.x && !passed[i])
            {
                passed[i] = true;
                currentScore++;
            }
        }

        scoretext.text = currentScore.ToString();
    }

    public void Unpass(int i)
    {
        passed[i] = false;
    }
}
