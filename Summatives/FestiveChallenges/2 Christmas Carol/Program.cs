string[] gifts =
{
   "a partridge in a pear tree",
   "Two turtle doves",
   "Three French hens",
   "Four calling birds",
   "Five gold rings",
   "six geese a-laying",
   "seven swans a-swimming",
   "eight maids a-milking",
   "nine ladies dancing",
   "ten lords a-leaping",
   "eleven pipers piping",
   "twelve drummers drumming"
};

string[] days =
{
    "first",
    "second",
    "third",
    "fourth",
    "fifth",
    "sixth",
    "seventh",
    "eighth",
    "nineth",
    "tenth",
    "eleventh",
    "twelvth"
};
int numberOfGifts = 1;
string giftsOnDays = null;
Console.WriteLine("On the first day of Christmas my true love sent to me A partridge in a pear tree");
for (int i = 1; i < gifts.Length; i++)
{
    giftsOnDays = gifts[i] + ", " + giftsOnDays;
    Console.WriteLine($"On the {days[i]} day of Christmas my true love sent to me {giftsOnDays}and {gifts[0]}");
    Console.WriteLine();
   for (int j = 0; j <= i + 1; j++)
    {
        numberOfGifts = numberOfGifts + j;
    }

}
Console.WriteLine($"Total gifts = {numberOfGifts}");
