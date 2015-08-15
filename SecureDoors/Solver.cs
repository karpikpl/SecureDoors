using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kattis.IO;

namespace SecureDoors
{
    class Solver
    {
        private HashSet<string> accessLog = new HashSet<string>();

        public void Solve(Stream inStream, Stream outStream)
        {
            Scanner scanner = new Scanner(inStream);

            StreamWriter writer = new StreamWriter(outStream);

            // read log size
            var logEntriesCount = scanner.NextInt();
            string name, result;

            for (int i = 0; i < logEntriesCount; i++)
            {
                var operation = scanner.Next();
                name = scanner.Next();

                if (operation == "entry")
                {
                    if (!accessLog.Contains(name))
                    {
                        // first entry
                        accessLog.Add(name);
                        result = Entry(false, name);
                    }
                    else
                    {
                        // already in the building
                        result = Entry(true, name);
                    }
                }
                else
                // exit
                {
                    if (accessLog.Contains(name))
                    {
                        accessLog.Remove(name);
                        result = Exit(false, name);
                    }
                    else
                    {
                        // not in the building but exiting
                        result = Exit(true, name);
                    }
                }

                writer.WriteLine(result);
            }


            writer.Flush();
        }

        public string Entry(bool isAnomaly, string name)
        {
            return name + " entered" + (isAnomaly ? " (ANOMALY)" : string.Empty);
        }

        public string Exit(bool isAnomaly, string name)
        {
            return name + " exited" + (isAnomaly ? " (ANOMALY)" : string.Empty);
        }
    }
}
