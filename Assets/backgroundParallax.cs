using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundParallax : MonoBehaviour
{
    public float bgSpeed;
    public float floorSpeed;

    public GameObject[] floors;
    public GameObject[] bgs;
    public GameObject[] ceilings;

    public Vector3 leftLimitPos;
    public Vector3 restartRightPos;
    // Start is called before the first frame update
    void Start()
    {
        leftLimitPos = floors[0].transform.position;
        restartRightPos = floors[2].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionChange = new Vector3(-floorSpeed * Time.deltaTime, 0, 0);
        Vector3 positionChangeBg = new Vector3(-bgSpeed * Time.deltaTime, 0, 0);

        foreach (GameObject floor in floors)
        {
            if (floor != null && floor.transform != null)
            {
                floor.transform.position += positionChange;
            }
            if (floor.transform.position.x <= leftLimitPos.x)
            {
                floor.transform.position = restartRightPos;
            }
        }
        foreach (GameObject ceeling in ceilings)
        {
            if (ceeling != null && ceeling.transform != null)
            {
                ceeling.transform.position += positionChange;
            }
            if (ceeling.transform.position.x <= leftLimitPos.x)
            {
                ceeling.transform.position = new Vector3(restartRightPos.x, ceeling.transform.position.y, ceeling.transform.position.z);
            }
        }
        foreach (GameObject bg in bgs)
        {
            if (bg != null && bg.transform != null)
            {
                bg.transform.position += positionChangeBg;
            }
            if (bg.transform.position.x <= leftLimitPos.x)
            {
                bg.transform.position = new Vector3(restartRightPos.x, bg.transform.position.y, bg.transform.position.z);
            }
        }

    }
}
