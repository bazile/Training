<Query Kind="Program">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
    var examTasks = new List<string> {
        // Список задач ...
    };
	var names = new List<string> {
        // Список студентов ...
	};
	
	var rng = RandomNumberGenerator.Create();
    var assignedTasks = new List<ExamTask>();
	while (examTasks.Count > 0)
	{
		int taskNum = examTasks.Count == 1 ? 0 : rng.Next(examTasks.Count);
        assignedTasks.Add(new ExamTask { Имя = names[0], Задание = examTasks[taskNum] });
		examTasks.RemoveAt(taskNum);
		names.RemoveAt(0);
	}
	
	assignedTasks.Dump();
}

class ExamTask { public string Имя; public string Задание; }

public static class RandomNumberGeneratorExtensions
{
	public static int Next(this RandomNumberGenerator rng, int max)
	{
		byte[] buf = new byte[4];
		rng.GetBytes(buf);
		return Math.Abs(BitConverter.ToInt32(buf, 0)) % max;
	}
}