/*
Write a function, persistence, that takes in a positive parameter num and returns its 
multiplicative persistence, which is the number of times you must multiply the digits 
in num until you reach a single digit.

For example (Input --> Output):
39 --> 3 (because 3*9 = 27, 2*7 = 14, 1*4 = 4 and 4 has only one digit)
999 --> 4 (because 9*9*9 = 729, 7*2*9 = 126, 1*2*6 = 12, and finally 1*2 = 2)
4 --> 0 (because 4 is already a one-digit number)
*/

class Program
{
    public class Persist
    {
        /// <summary>
        /// Метод принимает положительное число и возвращает 
        /// мультипликативную настойчивость числа (сколько раз
        /// нужно перемножить цифры в числе до достижения 
        /// получения числа из единой цифры 
        /// </summary>
        /// <param name="n">положительное число</param>
        /// <returns>возвращает количество совершенных итераций</returns>
        public static int Persistence(long n)
        {
            if (n <= 0) { return 0; }                                           // только положительные числа
            int counter = 0;                                                    //счетчик итераций
            long intermediate = n;                                              //промежуточный результат перемножения
            while (intermediate > 9)                                            //до тех пор, пока промежуточное число состоит из двух цифр
            {
                intermediate = PersistenceCalc(intermediate);                   //вызов метода в цикле
                counter++;                                                      //инкрементация счетчика
            }
            return counter;                                                     //счетчик перемножений
        }
        /// <summary>
        /// Метод, перемножающий все цифры, образующие число
        /// </summary>
        /// <param name="num">исходное целое число</param>
        /// <returns>целочисленный результат перемножения</returns>
        public static long PersistenceCalc(long num)
        {
            long result = 1;                                                            //результат перемножения
            foreach (var e in num.ToString()) { result *= long.Parse(e.ToString()); }   //приведение числа к строковому представлению и перемножение 
            return result;
        }
        /// <summary>
        /// Два предыдущих метода, объединенные и сокращенные
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int PersistenceInOneLine(long n)
        {
            int count = 0;
            while (n > 9)
            {
                count++;
                n = n.ToString().Select(digit => int.Parse(digit.ToString())).Aggregate((x, y) => x * y);
            }
            return count;
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine(Persist.Persistence(39));             // 3    (3 * 9 = 27   2 * 7 = 14   1 * 4 = 4)
        Console.WriteLine(Persist.Persistence(999));            // 4
        Console.WriteLine(Persist.Persistence(990));            // 1
        Console.WriteLine(Persist.Persistence(4));              // 0
        Console.WriteLine(Persist.Persistence(0));              // 0

        Console.WriteLine();

        Console.WriteLine(Persist.PersistenceInOneLine(39));     // 3 
        Console.WriteLine(Persist.PersistenceInOneLine(999));    // 4
        Console.WriteLine(Persist.PersistenceInOneLine(990));    // 1
        Console.WriteLine(Persist.PersistenceInOneLine(4));      // 0
        Console.WriteLine(Persist.PersistenceInOneLine(0));      // 0
    }
}