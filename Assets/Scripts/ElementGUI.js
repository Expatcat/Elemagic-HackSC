#pragma strict

var controlTexture : Texture2D;
var eleVariable:String;
var instr1:String;
var instr2:String;
var instr3:String;


function OnGUI() {
		GUI.Label(Rect(100,100,200,200), "Element: " + eleVariable);
		GUI.Label(Rect(20,40,300,100), instr1);

}
function Update () {

if (Input.GetKeyDown("x")) { //Fire
	eleVariable = "Fire";
	instr1 = "Flex Fingers To Unleash The Flame";
}

else if (Input.GetKeyDown("c")) {
	eleVariable = "Water";
	instr1 = "Flex Fingers To Release A Refreshing Fountain"; 
}
else if (Input.GetKeyDown("v")) {
	eleVariable = "Air";
	instr1 = "Flex Fingers To Soar In The Sky";
}
else if (Input.GetKeyDown("b")) {
	eleVariable = "Earth";
	instr1 = "Touch Thumb To Pinky And Master The Earth";
	instr2 = "Afterwards, Flex Fingers To Push Earth Down";
	instr3 = "Or Make a Fist To Pull It Up";
}
}