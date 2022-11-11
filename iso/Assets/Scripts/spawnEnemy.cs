using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour {

    public GameObject[] enemy;
    GameObject player;
    [SerializeField]
    LayerMask groundLayer;
    float yval;
    
    void Start()
    {
        yval = transform.position.y;
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Spawner());
    }

    void Update()
    {
        Vector3 pos = player.transform.position;
        pos.y = yval;
        transform.position = pos;
    }
    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            x: Vector3 spawn = transform.position;
            int r = Random.Range(0, 4);
                if (r == 0)
                    spawn.x -= 35;
                else if (r == 1)
                    spawn.x += 35;
                else if (r == 2)
                    spawn.z -= 35;
                else if (r == 3)
                    spawn.z += 35;
            if (!IsGrounded(spawn))
                goto x;
            spawn.y += 1;
            Vector3 direction = Vector3.Normalize(player.transform.position - spawn);
            r = Random.Range(0, enemy.Length*2);
            GameObject go = Instantiate(enemy[r/2],spawn, Quaternion.LookRotation(direction));
        }
    }
    bool IsGrounded(Vector3 pos)
    {
        bool hit = Physics.Raycast(pos, -transform.up, 1f, groundLayer);
        if (hit)
            return true;
        return false;
    }
}
