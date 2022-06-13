int min_p = 0;
int max_p = 0;
start:
try {
    Console.WriteLine("Enter minimum number for Primary numbers");
    min_p = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter maximum number for Primary numbers");
    max_p = int.Parse(Console.ReadLine());
}
catch { Console.WriteLine("ERROR: YouAreBadUser"); Console.ReadKey(true); Console.Clear(); goto start; }
int min_f = 0;
int max_f = 0;
start2:
try {
    Console.WriteLine("Enter minimum number for Fibonacci numbers");
    min_f = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter maximum number for Fibonacci numbers");
    max_f = int.Parse(Console.ReadLine());
}
catch { Console.WriteLine("ERROR: YouAreBadUser!"); Console.ReadKey(true); Console.Clear(); goto start2; }
Console.WriteLine("\nPrimary - press 'P' to pouse, 'O' to continue \nFibonacci - press 'F' to pouse, 'G' to continue \nPouse both - Spacebar\nFull restart - 'R'\n\nPress any key to start...");
if (min_p % 2 == 0) { min_p++; }
bool r = false;
ConsoleKeyInfo cki;
Mutex mutex = new Mutex(false, "MyMutex");
bool P = false, F = false, pr = false, fb = false, prap = true;
cki = Console.ReadKey(true);
Thread thread = new Thread(loop, 10);
thread.Start();
Thread thread1 = new Thread(prime, 10);
thread1.Start();
Thread thread2 = new Thread(fib, 10);
thread2.Start();
if (r) { Thread.Sleep(10); Console.Clear(); goto start; }
void loop(object? obj) {
    while (true) {
        if (pr && fb) break;
        if (Console.KeyAvailable == true) {
            cki = Console.ReadKey(true);
            switch (cki.Key) {
                case ConsoleKey.Spacebar:
                    P = true;
                    F = true;
                    break;
                case ConsoleKey.R:
                    r = true;
                    return;
                case ConsoleKey.P:
                    P = true;
                    break;
                case ConsoleKey.F:
                    F = true;
                    break;
                case ConsoleKey.O:
                    P = false;
                    break;
                case ConsoleKey.G:
                    F = false;
                    break;
            }
        }
    }
}

void fib(object? obj) {
    int i1;
    int i11;
    i1 = min_f;
    for (int i = min_f; i <= max_f; i += 0) {
        if (r) return;
        if (F) { continue; }
        i11 = i1;
        i1 = i;
        i = i + i11;
        if (i < max_f)
            Console.WriteLine("\t\t" + i);
        Thread.Sleep(240);
    }
    fb = true;
}

void prime(object? obj) {
    for (int i = min_p; i <= max_p; i += 2) {
        if (r) return;
        if (P) { i -= 2; continue; }
        prap = true;
        for (int j = 2; j < Math.Sqrt(i); j -= -1) {
            if (i % j == 0) { prap = false; break; }
        }
        if (prap && i != 1) { Console.WriteLine(i); }
        Thread.Sleep(90);
    }
    pr = true;
}
