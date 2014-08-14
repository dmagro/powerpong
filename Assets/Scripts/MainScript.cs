using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour
{
	public static MainScript Instance;

	public const int player1 = 1;
	public const int player2 = 2;

	public Transform ballPrefab;
	public GUIElement player1ScoreGui;
	public GUIElement player2ScoreGui;

	private int player1Score = 0;	
	private int player2Score = 0;

	private const string namePlayer1 = "Player1";
	private const string namePlayer2 = "Player2";

	void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of MainScript!");
		}
		Instance = this;
	}

	void Start()
	{
		createBall();
	}

	void OnGUI(){
		player1ScoreGui.guiText.text = "Player1: " + player1Score.ToString();
		player2ScoreGui.guiText.text = "Player2: " + player2Score.ToString();
	}

	//Update the score for the player that scored and
	//put the gameobjects in their initial positions
	public void score(int player)
	{
		switch (player)
		{
			case 1:
				//Console.WriteLine("Case 1");
				player1Score++;
				break;
			case 2:
				//Console.WriteLine("Case 2");
				player2Score++;
				break;
		}

		Debug.Log("Player " + player.ToString() + " scores!!!");

		positioningPlayers();

		removePlayersPowers();

		createBall();
	}

	//Create and postioninig new ball
	private void createBall()
	{
		var ballTransform = Instantiate(ballPrefab) as Transform;
		ballTransform.position = new Vector3(0, 0, 0);
	}

	//Positioning the two players paddles
	private void positioningPlayers()
	{
		positioningPlayer(namePlayer1, -8, 0, 0);
		positioningPlayer(namePlayer2, 8, 0, 0);
	}

	//Positioning a individual player
	private void positioningPlayer(string name, int x, int y, int z)
	{
		GameObject player = GameObject.Find(name);
		player.transform.position = new Vector3(x,y,z);
	}

	private void removePlayersPowers()
	{
		removePlayerPower(namePlayer1);
		removePlayerPower(namePlayer2);
	}

	private void removePlayerPower(string name)
	{
		GameObject player = GameObject.Find(name);
		(player.GetComponent<PlayerScript>()).dequeuePower();
	}
	
}
