namespace Astronomy;

public static class SolarSystemData
{
	public static AstronomicalBody Sun = new AstronomicalBody(
		"The Sun (Sol)",
		"1.9855*10^30 kg",
		"4,379,000 km",
		"4.57 billion years",
		"☀️");

	public static AstronomicalBody Earth = new AstronomicalBody(
		"Earth",
		"5.97237*10^24 kg",
		"40,075 km",
		"4.54 billion years",
		"🌎");

	public static AstronomicalBody Moon = new AstronomicalBody(
		"Moon", 
		"7.342*10^22 kg", 
		"10,921 km", 
		"4.53 billion years", 
		"🌕");

	public static AstronomicalBody HalleysComet = new AstronomicalBody(
		"Halley's Comet",
		"22 * 10^14 kg",
		"11 km",
		"4.6 billion years",
		"☄");
}
