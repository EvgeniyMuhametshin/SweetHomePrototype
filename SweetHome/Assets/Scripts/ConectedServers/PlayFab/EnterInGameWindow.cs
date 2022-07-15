using UnityEngine;
using UnityEngine.UI;

public class EnterInGameWindow : MonoBehaviour
{
    [SerializeField]
    private Button _signInButton;

    [SerializeField]
    private Button _createAccountButton;

    [SerializeField]
    private Canvas _enterInGameCanvas;

    [SerializeField]
    private Canvas _createAccountCanvas;

    [SerializeField]
    private Canvas _signInCanvas;

	private void Start()
	{
        _signInButton.onClick.AddListener(OpenSignInWindow);
        _createAccountButton.onClick.AddListener(OpenCreateAccountWindow);
	}

	private void OnDestroy()
	{
		_signInButton.onClick.RemoveAllListeners();
		_createAccountButton.onClick.RemoveAllListeners();

	}

	private void OpenSignInWindow()
	{
		_enterInGameCanvas.enabled = false;
		_signInCanvas.enabled = true;
	}

	private void OpenCreateAccountWindow()
	{
		_enterInGameCanvas.enabled = false;
		_createAccountCanvas.enabled = true;
	}
}