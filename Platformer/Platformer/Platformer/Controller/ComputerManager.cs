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

        int inputWidth;
        int inputHeight;
        int hiddenNodes;

        int current = 0;

        List<Computer> computers;

        #endregion

        #region Initialization

        public ComputerManager(int numGenerations, int levelSelect, string file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string line = sr.ReadLine();
                    
                    //first line, input width
                    inputWidth = Convert.ToInt32(line);

                    line = sr.ReadLine();
                    
                    //second line, input height
                    inputHeight = Convert.ToInt32(line);

                    line = sr.ReadLine();

                    //third line, number of hidden nodes
                    hiddenNodes = Convert.ToInt32(line);

                    numWeights = (inputWidth * inputHeight * hiddenNodes) + (3 * hiddenNodes);

                    line = sr.ReadLine();

                    //fourth line, number of rows in the file (generation size)
                    generationSize = Convert.ToInt32(line);

                    line = sr.ReadLine();

                    computers = new List<Computer>(generationSize);

                    //now get the weight strings
                    //x counts the lines so we only get the number we expect
                    int x = 0;

                    while (line != null && x < generationSize)
                    {
                        string[] chunks = line.Split(',');

                        int[] w = new int[numWeights];

                        for (int i = 0; i < numWeights; i++)
                        {
                            w[i] = Convert.ToInt32(chunks[i]);
                        }

                        computers.Add(new Computer(w));

                        line = sr.ReadLine();
                        x++;
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
