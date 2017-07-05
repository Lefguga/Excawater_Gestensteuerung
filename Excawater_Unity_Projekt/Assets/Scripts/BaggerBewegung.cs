using UnityEngine;
using BaggerLibrary;
using Leap;

public class BaggerBewegung : MonoBehaviour {

	[Header("Game Objects")]
	public GameObject GameObjectBagger;
	public GameObject GameObjectAusleger;
	public GameObject GameObjectStiel;
	public GameObject GameObjectLöffel;

	//Bagger Variablen
	float W_Rotation = 0, W_Ausleger = 0, W_Stiel = 0, W_Löffel = 0;
	BaggerLibrary.Bagger bagger;

	// Use this for initialization
	void Start () {
		Debug.Log("Start: Bagger Skript");

		bagger = new BaggerLibrary.Bagger()
		{
			Länge_Ausleger = 300,
			Länge_Löffelstiel = 200,
			FaktorRotation = 0.5f,
			TimeToReact = 200,
			FaktorBewegung = 2
		};

		//Gibt den Log der Klasse aus
		//bagger.OnLog += Bagger_OnLog;
		bagger.Reset ();
		bagger.Start ();

		bagger.BaggerData += Bagger_BaggerData;
	}

	private void Bagger_BaggerData(object sender, System.EventArgs e)
	{
		W_Rotation = bagger.Winkel_Rotation;
		W_Ausleger = bagger.Winkel_Ausleger;
		W_Stiel = bagger.Winkel_Löffelstiel;
		W_Löffel = -bagger.Winkel_Löffel;

		Debug.Log(string.Format("New Values...ROT:{0}, Aus:{1}, Sti:{2}, Löf:{3}",
			W_Rotation,
			W_Ausleger,
			W_Stiel,
			W_Löffel));
	}

	private void Bagger_OnLog(object sender, System.EventArgs e)
	{
		Debug.Log(sender);
	}

	// Update is called once per frame
	void Update ()
	{
		
		GameObjectBagger.transform.rotation = Quaternion.Euler (0, bagger.Winkel_Rotation, 0);
		GameObjectAusleger.transform.localRotation = Quaternion.Euler (0, 0, bagger.Winkel_Ausleger);
		GameObjectStiel.transform.localRotation = Quaternion.Euler (0, 0, bagger.Winkel_Löffelstiel);
		GameObjectLöffel.transform.localRotation = Quaternion.Euler (0, 0, bagger.Winkel_Löffel);

		//bagger.Move(new Leap.Vector(0, 0.1f, 0.1f), 200, 200);

		if (Input.GetKeyDown (KeyCode.I)) {
			Debug.Log (string.Format ("rot:{0} aus:{1} sti:{2} löf:{3}", W_Rotation, W_Ausleger, W_Stiel, W_Löffel));
		}

		if (Input.GetKeyDown (KeyCode.M)) {
			Debug.Log ("Pull Data");
			bagger.Pull ();
		}

		//close on ESC
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log ("Trigger Quit");
			Application.Quit ();
		}

	}

	void OnGUI()
	{
		GUI.Label (new Rect(10, 10, 200, 200), string.Format ("Rotation:\t{0:N2}\nAusleger:\t{1:N2}\nStiel:\t{2:N2}\nLöffel:\t{3:N2}",
			bagger.Winkel_Rotation, bagger.Winkel_Ausleger, bagger.Winkel_Löffelstiel, bagger.Winkel_Löffel));
	}

	// Stopt den Leap.Controller um einen Absturz der Simulation zu verhindern
	void OnApplicationQuit()
	{
		Debug.Log("Call Bagger.Close();");
		bagger.Stop ();
		Debug.Log ("Dat lief " + Time.time + "Sekunden...");
	}
}