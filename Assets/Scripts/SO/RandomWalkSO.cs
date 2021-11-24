using UnityEngine;

[CreateAssetMenu(menuName = "Generate/RandomWalkData")]
public class RandomWalkSO : ScriptableObject {
    public int iterations = 10, walkLength = 10;
    public bool startRandomPos = true;
}
