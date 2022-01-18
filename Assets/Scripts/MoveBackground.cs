using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public Transform[] pieces;
    public float moveSpeed;
    public float width;
    public Vector2 heightChange;
    Score score;

    void Start()
    {
        score = FindObjectOfType<Score>();

        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i].transform.Translate(new Vector2(0, Random.Range(heightChange.x, heightChange.y)));
        }
    }

    void Update()
    {
        movePieces();
    }

    void movePieces()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i].position.x <= -width && heightChange != Vector2.zero)
            {
                pieces[i].transform.Translate(new Vector2(width * pieces.Length, -pieces[i].transform.position.y + Random.Range(heightChange.x, heightChange.y)));
                score.Unpass(i);
            }
            else if (pieces[i].position.x <= -width)
            {
                pieces[i].transform.Translate(new Vector2(width * pieces.Length, 0));
            }

            pieces[i].Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}
