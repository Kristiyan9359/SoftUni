
int start = int.Parse(Console.ReadLine());
int end = int.Parse(Console.ReadLine());

int startFirst = start / 1000;
int startSecond = (start % 1000) / 100;
int startThird = (start % 100) / 10;
int startFourth = start % 10;

int endFirst = end / 1000;
int endSecond = (end % 1000) / 100;
int endThird = (end % 100) / 10;
int endFourth = end % 10;

for (int first = startFirst; first <= endFirst; first++)
{
    if (first % 2 == 0) continue;

    for (int second = startSecond; second <= endSecond; second++)
    {
        if (second % 2 == 0) continue;

        for (int third = startThird; third <= endThird; third++)
        {
            if (third % 2 == 0) continue;

            for (int fourth = startFourth; fourth <= endFourth; fourth++)
            {
                if (fourth % 2 == 0) continue;

                int barcode = first * 1000 + second * 100 + third * 10 + fourth;
                Console.Write(barcode + " ");
            }
        }
    }
}