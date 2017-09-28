using Newtonsoft.Json;
using System;
using System.IO;

namespace WoWJsonDumper
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Not enough arguments!");
            }
            else
            {
                if (args[0] == "dumpadt")
                {
                    if (args.Length != 2) throw new Exception("Not enough arguments. Need mode, file");

                    var adt = new WoWFormatLib.FileReaders.ADTReader();

                    adt.LoadADT(File.OpenRead(args[1]));

                    for(var i = 0; i < adt.adtfile.chunks.Length; i++)
                    {
                        adt.adtfile.chunks[i].vertices = new WoWFormatLib.Structs.ADT.MCVT();
                        adt.adtfile.chunks[i].normals = new WoWFormatLib.Structs.ADT.MCNR();
                        adt.adtfile.chunks[i].vertexShading = new WoWFormatLib.Structs.ADT.MCCV();
                    }

                    Console.WriteLine(JsonConvert.SerializeObject(adt, Formatting.Indented));
                }
            }
        }
    }
}
