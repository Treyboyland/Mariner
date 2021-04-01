using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauser : MonoBehaviour
{
    [SerializeField]
    GameEvent onPauseGame = null;

    [SerializeField]
    GameEvent onResumeGame = null;

    public bool GamePaused { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (GamePaused)
            {
                onResumeGame.Invoke();
            }
            else
            {
                onPauseGame.Invoke();
            }
        }
    }

    private void OnDisable()
    {
        ContinueGame();
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
    }
}
