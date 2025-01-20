using System.Collections.Generic;
using _project.Scripts.Game.Obstacles;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private List<Obstacle> obstacles;
    [SerializeField] private List<Transform> obstacleSpawnPoints;
    [SerializeField] private GameObject plane;
    


    public void GenerateLevel()
    {
        foreach (var spawnPoint in obstacleSpawnPoints)
        {
            
        }
    }
}