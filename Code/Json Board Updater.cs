using UnityEngine; 
using UnityEngine.Networking;
using UnityEngine.UI;

public class JSONUpdater : MonoBehaviour
{
	public string JsonURL = "https://raw.githubusercontent.com/SpacerYes/Gelada-Dev./main/UpdateBoard.json"
	public Text textComponent;


    private void Start()
    {
        StartCoroutine(FetchJSONData());
    }

    private IEnumerator FetchJSONData()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(jsonURL);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + webRequest.error);
        }
        else
        {
            string jsonData = webRequest.downloadHandler.text;
            JSONDataContainer dataContainer = JsonUtility.FromJson<JSONDataContainer>(jsonData);

            if (dataContainer != null)
            {
                string textValue = dataContainer.text;
                textComponent.text = textValue;
            }
            else
            {
                Debug.LogError("Failed to parse JSON data");
            }
        }
    }
}

[System.Serializable]
public class JSONDataContainer
{
    public string text;
}