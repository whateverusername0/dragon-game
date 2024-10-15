using System.Collections.Generic;
using UnityEngine;
using Dan.Main;
using TMPro;

public class LeaderboardController : MonoSingleton<LeaderboardController>
{
    [SerializeField] private TMP_Text[] _entryTextObjects;
    [SerializeField] private TMP_InputField _usernameInputField;
    [SerializeField] private int Score = 0;

    private void Start()
    => LoadEntries();

    private void LoadEntries()
    {
        Leaderboards.SHITASS.GetEntries(e =>
        {
            for (int i = 0; i < _entryTextObjects.Length; i++) _entryTextObjects[i].text = $"{i+1}.  - ";

            var len = Mathf.Min(_entryTextObjects.Length, e.Length);
            for (int i = 0; i < len; i++)
                _entryTextObjects[i].text = $"{e[i].Rank}. {e[i].Username} - {e[i].Score}";
        });
    }
    public void UploadEntry()
    {
        Leaderboards.SHITASS
            .UploadNewEntry(_usernameInputField.text, Score, success => {if(success)LoadEntries();});
    }
    public void RefreshLeaderboard()
        => LoadEntries();
}
