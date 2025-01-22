object obj = 99;
int error = 500;

if (obj is int number)
    Console.WriteLine(number + 1);

if (error is 400 or 500)
    Console.WriteLine(error);

List<int> list = [1, 2, 3, 4, 5];
int[] list2 = [ 0, ..list, 6, 7, 8 ];

foreach (var item in list2[1..5])
    Console.WriteLine(item);
