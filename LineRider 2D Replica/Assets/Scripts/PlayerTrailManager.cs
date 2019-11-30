using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 * PlayerTrail Manager responsible for generating the Player Trails while Player
 * is "riding" lines then in the course then displaying the trails once run time is
 * complete. 
 */

public class PlayerTrailManager : MonoBehaviour
{
    [SerializeField]
    public Transform currentPlayerTransform;
    [SerializeField]
    public GameObject playerTrailPrefab;

    /* Note:
     * Wait periods are calculated in seconds. For example, if "waitPeriod"
     * is set to ".5" it is waiting .5 seconds before a new trail is created.
     *
     * "NextTime" is used to keep track of the next time that a new trail will be
     * added throughout the session. As a result the initial variable will be
     * how long it takes for the first trail to be generated. 
     */

    [SerializeField]
    public double waitPeriod = .5;
    [SerializeField]
    public double nextTime = .1;

    private List<GameObject> fullTrail;
    private PlayerTrail currentPlayerTrail;
    private bool running;
    private int numberOfTrails;

    public void Start()
    {
        running = false;
        fullTrail = new List<GameObject>();
    }

    private void Update()
    {
        if (running)
        {
            double currentTime = Time.time;
            if (currentTime > nextTime)
            {
                nextTime = currentTime + waitPeriod;
                NewTrail();
                numberOfTrails++;
            }
        }

    }

    public void StartRunning()
    {
        running = true;
        if (fullTrail.Count != 0)
        {
            DeleteTrails();
        }
    }

    public void StopRunning()
    {
        running = false;
        TrailsAppear();
    }

    public bool IsRunning()
    {
        return running;
    }

    private void NewTrail()
    {
        GameObject trail = Instantiate(playerTrailPrefab) as GameObject;
        fullTrail.Add(trail);
        currentPlayerTrail = fullTrail.Last().GetComponent<PlayerTrail>();
        currentPlayerTrail.SetTransform(currentPlayerTransform);
    }

    private void DeleteTrails()
    {
        for (int trailNumber = 1; trailNumber <= numberOfTrails; trailNumber++)
        {
            Destroy(fullTrail.Last());
            fullTrail.RemoveAt(fullTrail.Count - 1);
        }
        numberOfTrails = 0;

    }

    private void TrailsAppear()
    {
        for (int trailNumber = 1; trailNumber <= numberOfTrails; trailNumber++)
        {

            currentPlayerTrail = fullTrail[trailNumber - 1].GetComponent<PlayerTrail>();

            if (trailNumber == numberOfTrails)
            {
                currentPlayerTrail.ChangeRed();
            }
            else
            {
                float percentageThrough = (float)(trailNumber) / (float)(numberOfTrails);
                currentPlayerTrail.ChangeOpacity(percentageThrough);
            }
        }
    }
}