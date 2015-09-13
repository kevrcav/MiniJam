using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JeebusWorshipperMgr : MonoBehaviour {

    public int numberWorshippers;
    public Transform worshipperStart;
    public JeebusWorshipper worshipperPrefab;

    List<JeebusWorshipper> worshippers = new List<JeebusWorshipper>();
    int currentWorshipper = 0;

    bool ready = true;

    void Start()
    {
        Vector3 currentSpawnPos = worshipperStart.position;
        for (int i = 0; i < numberWorshippers; ++i)
        {
            JeebusWorshipper newWorshipper = (JeebusWorshipper)Instantiate(worshipperPrefab, currentSpawnPos, Quaternion.identity);
            worshippers.Add(newWorshipper);
            newWorshipper.transform.parent = transform;
            currentSpawnPos.x += 1.9f;
        }
    }

    void Update()
    {

        if (currentWorshipper >= worshippers.Count) return;

        if (!ready)
        {
            ready = Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0;
            return;
        }
        if (worshippers[currentWorshipper].CheckPrayer())
        {
            if (++currentWorshipper >= worshippers.Count)
                MiniGame.Instance.ReportWin();
            ready = false;
        }
	}
}
