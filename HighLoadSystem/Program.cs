using var input = new StreamReader(Console.OpenStandardInput());
using var output = new StreamWriter(Console.OpenStandardOutput());

int numberWorkStories = int.Parse(input.ReadLine());
for (int i = 0; i < numberWorkStories; i++) 
{ 
    string workTask = input.ReadLine().ToUpper(); 
    output.WriteLine(SequenceСheck(workTask) ? "yes" : "no"); 
}
output.Flush();

bool SequenceСheck(string workTask)
{
    if (workTask[0] != 'M' || workTask[workTask.Length - 1] != 'D')
        return false;

    char? currentTask = workTask[0];

    foreach (char task in workTask)
    {
        switch (task)
        {
            case 'M':
                if (currentTask == 'D' || currentTask == 'C' || currentTask == workTask[0])
                    currentTask = 'M';
                else
                    return false;
                break;
            case 'R':
                if (currentTask == 'M')
                    currentTask = 'R';
                else
                    return false;
                break;
            case 'C':
                if (currentTask == 'M' || currentTask == 'R')
                    currentTask = 'C';
                else
                    return false;
                break;
            case 'D':
                if (currentTask == 'M' || currentTask == 'R' || currentTask == 'C')
                    currentTask = 'D';
                else
                    return false;
                break;
            default:
                return false;
        }
    }

    return true;
}