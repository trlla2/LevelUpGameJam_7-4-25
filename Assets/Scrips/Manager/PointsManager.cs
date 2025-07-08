
using UnityEngine;
using UnityEngine.Events;


public class PointsManager : MonoBehaviour
{
   private static PointsManager instance;

    public static PointsManager Instance
    {
        get 
        { 
            if (instance == null)
            {
                instance = new PointsManager();
            }
            return instance; 
        }
    }

    private int score = 0;
    private int scoreGoal;

    // events that you can subcribe to execute a function everytime ... hapens
    public delegate void GetChangeScore(int points);
    public event GetChangeScore OnScoreChange;
    public delegate void GetGoalScoreReach();
    public event GetGoalScoreReach OnScoreGoalReach;

    private void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        if(score >= scoreGoal)
        {
            OnScoreGoalReach.Invoke();
        }
    }


    // Public functions to manage the score
    public void AddPoints(int p) 
    { 
        score += p;
        OnScoreChange.Invoke(score);
    }

    public void SetPointsGoal(int pG) { scoreGoal = pG; }

    public int GetPoints() { return score; }
}
