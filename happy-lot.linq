<Query Kind="Program">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	const int NUM_TASKS = 10;
	var names= new List<string> {
		// Список студентов ...
	};
	
	var rng = RandomNumberGenerator.Create();
	var examTasks = new List<ExamTask>();
	var nums = new List<int>();
	while (names.Count > 0)
	{
		if (nums.Count == 0) nums = Enumerable.Range(1, NUM_TASKS).ToList();
		int taskNum = nums.Count == 1 ? nums[0] : nums[rng.Next(nums.Count)];
		nums.Remove(taskNum);
		examTasks.Add(new ExamTask { Имя = names[0], Задание = taskNum });
		names.RemoveAt(0);
	}
	
	examTasks.Dump();
}

class ExamTask { public string Имя; public int Задание; }

public static class RandomNumberGeneratorExtensions
{
	public static int Next(this RandomNumberGenerator rng, int max)
	{
		byte[] buf = new byte[4];
		rng.GetBytes(buf);
		return Math.Abs(BitConverter.ToInt32(buf, 0)) % max;
	}
}
