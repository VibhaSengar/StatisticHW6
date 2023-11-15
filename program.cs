using System;

class vibha
{
    static Random random = new Random();

    static double DiscardProbability(int A, int B, int C, int D)
    {
        int discardedCount = 0;

        for (int i = 0; i < A; i++)
        {
            double penetrationScoreVariable = 0;

            for (int j = 0; j < B; j++)
            {
                penetrationScoreVariable += random.NextDouble() * 100; 

                if (penetrationScoreVariable >= C)
                {
                    break; 
                }

                if (penetrationScoreVariable < D)
                {
                    discardedCount++;
                    break; // discard
                }
            }
        }

        return (double)discardedCount / A; // Probability of being discarded
    }

    static void SimulationRun()
    {
        const int A = 10000; // Number of systems
        const int B = 10;    // Number of attacks

        int[] DValues = { 20, 60, 100 }; // Different values of D

        for (int k = 2; k <= 10; k++)
        {
            int C = k * 10;

            foreach (int D in DValues)
            {
                double probability = DiscardProbability(A, B, C, D);

                Console.WriteLine($"For C = {C} and D = {D}, Probability of being discarded: {probability}");
            }
        }
    }

    static void Main()
    {
        SimulationRun();
    }
}