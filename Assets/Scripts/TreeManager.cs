using UnityEngine;

public class TreeManager : MonoBehaviour {
    [SerializeField]
    Transform player, treePrefab;
    
    [SerializeField]
    Terrain terrain;

    [SerializeField, Range(1, 20)]
    int treeCount = 10;
    
    [SerializeField, Range(0, 20)]
    float spawnRange = 10, despawnRange = 10;
    
    Transform[] trees;

    void Awake() {
        trees = new Transform[treeCount];
        for(int i = 0; i < trees.Length; i++) {
            Transform tree = trees[i] = Instantiate(treePrefab);
            tree.SetParent(transform, false);
            tree.position += RandomPosition(spawnRange);
        }
    }
    
    Vector3 RandomPosition(float range) {
        Vector3 p = player.position;
        p.x += Random.Range(-range, range);
        p.y = 1.0f;
        p.z += Random.Range(-range, range);
        return p;
    }
    
    Vector3 MoveTowards(Vector3 current, Vector3 target, float scale) {
        Vector3 p = current;
        p.x -= (current.x - target.x) * scale;
        p.y = current.y;
        p.z -= (current.z - target.z) * scale;
        return p;
    }

    void LateUpdate() {
        // only update when player transform changes
        if(player.hasChanged) {
            RespawnTrees();
        }
    }
    
    void RespawnTrees() {
        foreach(Transform tree in trees) {
            float distance = Vector3.Distance(tree.position, player.position);
            if(distance > despawnRange) {
                tree.position = MoveTowards(tree.position, player.position, 1.95f);
            }
        }
    }
}
