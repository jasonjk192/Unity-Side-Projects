using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateland : MonoBehaviour {
    public int size = 1;
    public Vector2 separation = new Vector2(0.86f,0.5f);
    public GameObject tile;
	void Start ()
    {
        List<Vector2> coords = new List<Vector2>();
        int x = 0;
        int rad = size;
        int n = 2 * rad - 1;
        for (int r = rad - 1; r < n; r++, x++)
        {
            int s = n - r - 1;
            int d = n - r - 1;
            int t = s;
            for (; d < n; d++, t += 2)
                coords.Add(new Vector2(t* separation.x-(n-1)*separation.x, x* separation.y - (rad-1)*separation.y));
        }
        for (int r = n - 1; r > rad - 1; r--, x++)
        {
            int s = n - r;
            int d = n - r;
            int t = s;
            for (; d < n; d++, t += 2)
                coords.Add(new Vector2(t * separation.x -(n-1) * separation.x, x* separation.y- (rad - 1) * separation.y));
        }
        Debug.Log(coords.Count);
        for (int o=0;o< coords.Count; o++)
        {
            Instantiate(tile, new Vector3(coords[o].x,0, coords[o].y), Quaternion.identity);
        }
        /*GameObject mid, tl, tr, l, r, bl, br;
        mid=Instantiate(tile, new Vector3(0, 0, 0), Quaternion.identity);
        for(int i=1;i<=size;i++)
        {
            r=Instantiate(tile, new Vector3(1*i, 0, 0), Quaternion.identity);
            l=Instantiate(tile, new Vector3(-1 * i, 0, 0), Quaternion.identity);
            tr=Instantiate(tile, new Vector3(0.5f * i, 0, 0.86f * i), Quaternion.identity);
            tl=Instantiate(tile, new Vector3(-0.5f * i, 0, 0.86f * i), Quaternion.identity);
            br=Instantiate(tile, new Vector3(0.5f * i, 0, -0.86f * i), Quaternion.identity);
            bl=Instantiate(tile, new Vector3(-0.5f * i, 0, -0.86f * i), Quaternion.identity);
        }*/
    }

}
