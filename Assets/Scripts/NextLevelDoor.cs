using UnityEngine;

public class NextLevelDoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public int doorID;
    [SerializeField] public int countGoal;
    private int count = 0;
    [SerializeField] private Animation openAnimation;
    public void Start()
    {
        openAnimation = GetComponentInChildren<Animation>();
        
    }

    public void UpdateTargetCount(int targetValue)
    {
        count+= targetValue;
        if (count >= countGoal) { openAnimation.Play(); }
    }
}
