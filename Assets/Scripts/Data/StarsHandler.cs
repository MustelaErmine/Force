using UnityEngine;
using UnityEngine.SceneManagement;

public class StarsHandler : MonoBehaviour
{
    public int moves = 0;
    public int stars3moves;
    public int stars2moves;

    public static StarsHandler instance;

    private void Start()
    {
        moves = 0;
        instance = this;
    }

    public void PretendStars()
    {
        int stars = 1;
        if (moves <= stars2moves)
        {
            stars = 2;
        }
        if (moves <= stars3moves)
        {
            stars = 3;
        }
        Save.Instance.ApplyStars(SceneManager.GetActiveScene().name, stars);
        print(moves);
    }

    public void IncreaseMoves()
    {
        moves++;
    }
}