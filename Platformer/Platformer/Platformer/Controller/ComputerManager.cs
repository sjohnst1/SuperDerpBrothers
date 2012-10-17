using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Platformer.Controller
{
    public class ComputerManager
    {
        #region Fields

        int numGenerations;
        int levelSelect;
        int numWeights;
        int generationSize;

        int current = 0;

        List<Computer> computers;

        #endregion

        #region Initialization

        public ComputerManager(int g, int l)
        {
            numGenerations = g;
            levelSelect = l;

            computers = new List<Computer>(generationSize);

            try
            {
                using (StreamReader sr = new StreamReader("weightData.txt"))
                {
                    string line = sr.ReadLine();

                    //if we're gonna use header data to determine generation size, do it here

                    while (line != null)
                    {
                        string[] chunks = line.Split(',');

                        int[] w = new int[numWeights];

                        for (int i = 0; i < numWeights; i++)
                        {
                            w[i] = Convert.ToInt32(chunks[i]);
                        }

                        //make sure we have the same # of weights and scores
                        computers.Add(new Computer(w));

                        line = sr.ReadLine();
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        #endregion

        public Computer GetComputer()
        {
            return computers[current++];
        }

        public bool HasMoreComputers()
        {
            if (current >= computers.Count) return false;
            return true;
        }

    }
}
