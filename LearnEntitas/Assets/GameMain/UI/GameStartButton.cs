using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameStartButton : MonoBehaviour
{
    private Button _button;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();

        if (_button != null)
        {
            _button.onClick.AddListener(OnGameStartClick);
        }
    }

    private void OnGameStartClick()
    {
        var contexts = Contexts.sharedInstance; // 贯穿整个游戏的上下文

        // clear any previous entity
        var starts = contexts.game.GetGroup(GameMatcher.GameStarted);
        if (starts != null && starts.count > 0)
        {
            foreach (var start in starts)
            {
                start.Destroy();
            }
        }

        // create game start event
        contexts.game.isGameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}