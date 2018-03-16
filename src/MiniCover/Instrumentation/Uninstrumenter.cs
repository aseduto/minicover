﻿using MiniCover.Model;
using System.IO;

namespace MiniCover.Instrumentation
{
    public static class Uninstrumenter
    {
        public static void Execute(InstrumentationResult result)
        {
            foreach (var assembly in result.Assemblies)
            {
                foreach (var assemblyLocation in assembly.Locations)
                {
                    if (File.Exists(assemblyLocation.BackupFile))
                    {
                        File.Copy(assemblyLocation.BackupFile, assemblyLocation.File, true);
                        File.Delete(assemblyLocation.BackupFile);
                    }

                    if (File.Exists(assemblyLocation.BackupPdbFile))
                    {
                        File.Copy(assemblyLocation.BackupPdbFile, assemblyLocation.PdbFile, true);
                        File.Delete(assemblyLocation.BackupPdbFile);
                    }
                }
            }

            foreach (var extraAssembly in result.ExtraAssemblies)
            {
                if (File.Exists(extraAssembly))
                {
                    File.Delete(extraAssembly);
                }
            }
        }
    }
}
