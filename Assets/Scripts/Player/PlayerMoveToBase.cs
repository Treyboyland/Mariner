using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveToBase : MonoBehaviour
{
    [SerializeField]
    float secondsToWaitBeforeMoving = 0;

    [SerializeField]
    float secondsToMove = 0;

    [SerializeField]
    Player player = null;

    [SerializeField]
    GameObject playerBase = null;

    [SerializeField]
    Vector3 offset = new Vector3();

    [SerializeField]
    GameEvent resurrectPlayer = null;

    public void StartMove()
    {
        StartCoroutine(Move());
    }

    public IEnumerator Move()
    {
        yield return new WaitForSeconds(secondsToWaitBeforeMoving);
        float elapsed = 0;
        var start = player.transform.position;
        var end = playerBase.transform.position + offset;
        while (elapsed < secondsToMove)
        {
            elapsed += Time.deltaTime;
            player.transform.position = Vector3.Lerp(start, end, elapsed / secondsToMove);
            yield return null;
        }

        player.transform.position = end;
        resurrectPlayer.Invoke();
    }
}
