<Query Kind="Program" />

void Main()
{
	const int NUM_TASKS = 3;
	var names= new List<string> {
		// Список студентов ...
	};
	
	Random rnd = new Random(Environment.TickCount);
	var examTasks = new List<ExamTask>();
	var nums = new List<int>();
	while (names.Count > 0)
	{
		if (nums.Count == 0) nums = Enumerable.Range(1, NUM_TASKS).ToList();
		int taskNum = nums.Count == 1 ? nums[0] : nums[rnd.Next(0, nums.Count)];
		nums.Remove(taskNum);
		examTasks.Add(new ExamTask { Имя = names[0], Задание = taskNum });
		names.RemoveAt(0);
	}
	
	examTasks.Dump();
}

class ExamTask { public string Имя; public int Задание; }