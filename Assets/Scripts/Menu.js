
function OnGUI () {

if (GUI.Button (Rect ((Screen.width / 2) - 50, (Screen.height / 2) - 40, 100, 30), "Oculus Rift")) {
	Application.LoadLevel("CreativeNarwhal");
	
}
if (GUI.Button(Rect((Screen.width / 2) - 30, Screen.height / 2, 60, 20), "Begin")) {
Application.LoadLevel("CreativeNarwhal");
}
}

function Update () {

}