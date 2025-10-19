Console.WriteLine("Staff Records Application");

string filename = "StaffRecords.csv";
if (File.Exists(filename))
{
    StreamReader reader = new StreamReader(filename);

    int numberOfLines = 0;
    while (!reader.EndOfStream)
    {
        reader.ReadLine();
        numberOfLines++;
    }
    string[] lines = new string[numberOfLines];
    reader.BaseStream.Seek(0, SeekOrigin.Begin);
    StaffRecord[] records = new StaffRecord[numberOfLines-1];

    for (int i = 0; i < numberOfLines; i++)
    {
        if (i == 0)
        {
            reader.ReadLine();
        }
        else
        {
            string[] parts = new string[3];
            lines[i] = reader.ReadLine(); 
            parts = lines[i].Split(',');
            records[i-1].FirstName = parts[0];
            records[i-1].Surname = parts[1];
            records[i-1].Salary = int.Parse(parts[2]);

        }
    }
   
    reader.Close();

    bool notInOrder;
    do
    {
        notInOrder = false;
        for (int i = 1; i < records.Length; i++)
        {
            if (records[i].Salary < records[i - 1].Salary)
            {
                notInOrder = true;
                StaffRecord temp = records[i];
                records[i] = records[i - 1];
                records[i - 1] = temp;
            }
        }
    } while (notInOrder);

    records = records.Reverse().ToArray();
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"{i+1}. {records[i].Surname} {records[i].FirstName} - £{records[i].Salary}");
    }


}
else
{
    Console.WriteLine($"{filename} does not exist");
}

struct StaffRecord
{
    public string FirstName;
    public string Surname;
    public int Salary;
}