using PlayFab;
using PlayFab.ClientModels;
using PlayFab.ServerModels;
using UnityEngine;

public class PlayerBanningScript : MonoBehaviour
{
    private const string TitleId = "YOUR_TITLE_ID";
    private const string DeveloperSecretKey = "YOUR_SECRET_KEY";

    private int banDurationInHours = 24; 
    private string banReason = "Violation of game rules";

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            string playFabId = playerController.PlayFabId;

            PlayFabSettings.TitleId = TitleId;
            PlayFabSettings.DeveloperSecretKey = DeveloperSecretKey;

            BanPlayerRequest request = new BanPlayerRequest
            {
                PlayFabId = playFabId,
                DurationInHours = banDurationInHours,
                Reason = banReason
            };

            PlayFabServerAPI.BanPlayer(request, OnBanPlayerSuccess, OnBanPlayerFailure);
        }
    }

    private void OnBanPlayerSuccess(BanPlayerResult result)
    {
        Debug.Log("Player banned successfully.");
    }

    private void OnBanPlayerFailure(PlayFabError error)
    {
        Debug.LogError("Error banning player: " + error.GenerateErrorReport());
    }
}