
using MyMonkeyApp;

var asciiArts = new[]
{
	@"  (o\_/o)",
	@" (='.'=)",
	@" (")_(")",
	@"  (o.o)",
	@"  ( : )",
	@"  ( ^.^)",
	@"  (>'-')> <('-'<) ^(' - ')^ v(' - ')v (>'-')> <('-'<)"
};

var random = new Random();
void ShowRandomAsciiArt()
{
	if (random.Next(2) == 0)
	{
		Console.WriteLine();
		Console.WriteLine(asciiArts[random.Next(asciiArts.Length)]);
		Console.WriteLine();
	}
}

while (true)
{
	Console.WriteLine("============================");
	Console.WriteLine("🐒 Monkey Console App 🐒");
	Console.WriteLine("============================");
	Console.WriteLine("1. List all monkeys");
	Console.WriteLine("2. Get details for a specific monkey by name");
	Console.WriteLine("3. Get a random monkey");
	Console.WriteLine("4. Exit app");
	Console.Write("Select an option (1-4): ");

	var input = Console.ReadLine();
	Console.WriteLine();

	switch (input)
	{
		case "1":
			ShowRandomAsciiArt();
			var monkeys = MonkeyHelper.GetMonkeys();
			Console.WriteLine($"{"Name",-20} {"Location",-25} {"Population",10}");
			Console.WriteLine(new string('-', 60));
			foreach (var m in monkeys)
				Console.WriteLine($"{m.Name,-20} {m.Location,-25} {m.Population,10}");
			Console.WriteLine();
			break;
		case "2":
			Console.Write("Enter monkey name: ");
			var name = Console.ReadLine() ?? string.Empty;
			var monkey = MonkeyHelper.GetMonkeyByName(name);
			if (monkey != null)
			{
				ShowRandomAsciiArt();
				Console.WriteLine($"Name: {monkey.Name}");
				Console.WriteLine($"Location: {monkey.Location}");
				Console.WriteLine($"Population: {monkey.Population}");
				Console.WriteLine($"Details: {monkey.Details}");
				Console.WriteLine($"Image: {monkey.Image}");
				Console.WriteLine($"Coordinates: {monkey.Latitude}, {monkey.Longitude}");
			}
			else
			{
				Console.WriteLine("Monkey not found.");
			}
			Console.WriteLine();
			break;
		case "3":
			var randomMonkey = MonkeyHelper.GetRandomMonkey();
			ShowRandomAsciiArt();
			Console.WriteLine($"Random Monkey: {randomMonkey.Name}");
			Console.WriteLine($"Location: {randomMonkey.Location}");
			Console.WriteLine($"Population: {randomMonkey.Population}");
			Console.WriteLine($"Details: {randomMonkey.Details}");
			Console.WriteLine($"Image: {randomMonkey.Image}");
			Console.WriteLine($"Coordinates: {randomMonkey.Latitude}, {randomMonkey.Longitude}");
			Console.WriteLine($"Random pick count: {MonkeyHelper.GetRandomPickCount()}");
			Console.WriteLine();
			break;
		case "4":
			Console.WriteLine("Goodbye! 🐵");
			return;
		default:
			Console.WriteLine("Invalid option. Please try again.\n");
			break;
	}
}
