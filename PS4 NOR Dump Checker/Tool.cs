using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PS4_NOR_Dump_Checker
{
    /// <summary>
    /// Tool Class which contain several small and usefull routines
    /// </summary>
    public class Tool
    {
        /// <summary>
        /// This variable is used to read into it for the ReadWriteData()
        /// </summary>
        public static byte[] readBuffer = new byte[0];

        /// <summary>
        /// Check Installed Software from Registry Entry
        /// </summary>
        /// <param name="level">Describe which base root to use "hklm" = HotKey_Local_Machine, "hkcu" = HotKey_Current_User, "hkcr" = HotKey_Classes_Root, "hku" = HotKey_Users, "hkcc" = HotKey_Current_Config</param>
        /// <param name="path">Describe the path to the software within the base root</param>
        /// <param name="entryName">Describe the entry you want to check like eg. the DisplayName , DisplayVersion...</param>
        /// <param name="entryValue">Describe the entry Value you want to compare against the reall entry</param>
        /// <returns>True if the Registry Entry do match the overloaded entry value</returns>
        public static bool CheckInstalledSoft(string level, string path, string entryName, string entryValue)
        {
            RegistryKey key = null;
            if (level == "hklm")
            {
                key = Registry.LocalMachine.OpenSubKey(path);
            }
            else if (level == "hkcu")
            {
                key = Registry.CurrentUser.OpenSubKey(path);
            }
            else if (level == "hkcr")
            {
                key = Registry.ClassesRoot.OpenSubKey(path);
            }
            else if (level == "hku")
            {
                key = Registry.Users.OpenSubKey(path);
            }
            else if (level == "hkcc")
            {
                key = Registry.CurrentConfig.OpenSubKey(path);
            }

            if (key != null)
            {
                string entryVTrue;
                foreach (String keyNames in key.GetSubKeyNames())
                {
                    RegistryKey subKey = key.OpenSubKey(keyNames);
                    entryVTrue = subKey.GetValue(entryName) as string;
                    if (entryValue.Equals(entryVTrue, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Converts a Littel Endian Hex Decimal value to a Integer Decimal value
        /// </summary>
        /// <param name="Hex">The byte[] Array to convert from</param>
        /// <param name="reverse">Defines if a array is Little Endian and should be reversed first</param>
        /// <returns>The converted Integer Decimal value</returns>
        public static long HexToDec(byte[] Hex, [Optional] string reverse)
        {
            if (reverse == "reverse")
            {
                Array.Reverse(Hex);
            }

            string bufferString = BitConverter.ToString(Hex).Replace("-", "");
            long bufferInteger = Convert.ToInt32(bufferString, 16);
            return bufferInteger;
        }

        /// <summary>
        /// Compare Byte by Byte or Array by Array
        /// </summary>
        /// <param name="bA1">Byte Array 1</param>
        /// <param name="bA2">Byte Array 2</param>
        /// <returns>True if both Byte Array's do match</returns>
        public static bool CompareBytes(byte[] bA1, byte[] bA2)
        {
            int s = 0;
            for (int z = 0; z < bA1.Length; z++)
            {
                if (bA1[z] != bA2[z])
                {
                    s++;
                }
            }

            if (s == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This is for patching Hex/Byte Values with Offset
        /// </summary>
        /// <param name="patchFile">The File to patch</param>
        /// <param name="position">The Offset of the first byte to patch</param>
        /// <param name="value">Byte Value to patch</param>
        public static void PatchBytes(string patchFile, byte position, byte value)
        {
            using (var v = new FileStream(patchFile, FileMode.Append, FileAccess.ReadWrite))
            {
                v.Position = position;
                v.WriteByte(value);
                v.Close();
            }
        }

        /// <summary>
        /// Copy a Stream
        /// </summary>
        /// <param name="input">The Input File Stream</param>
        /// <param name="output">The Output File Stream</param>
        public static void CopyStream(Stream input, Stream output)
        {
            // this is a variable for the Buffer size. Play arround with it and maybe set a new size to get better result's
            int workingBufferSize = 4096; // high
            // int workingBufferSize = 2048; // middle
            // int workingBufferSize = 1024; // default
            // int workingBufferSizeE = 128;  // minimum

            byte[] buffer = new byte[workingBufferSize];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) != 0)
            {
                output.Write(buffer, 0, len);
            }
            output.Flush();
        }

        /// <summary>
        /// Kombinated Command for Read or Write Binary or Integer Data
        /// </summary>
        /// <param name="fileToUse">The File that will be used to Read from or to Write to it</param>
        /// <param name="fileToUse2">This is used for the "both" methode. fileToUse will be the file to read from and fileToUse2 will be the file to write to it.</param>
        /// <param name="methodReadOrWriteOrBoth">Defination for Read "r" or Write "w" or if you have big data just use Both "b"</param>
        /// <param name="methodBinaryOrInteger">Defination for Binary Data (bi) or Integer Data (in) when write to a file</param>
        /// <param name="binData">byte array of the binary data to read or write</param>
        /// <param name="binData2">integer array of the integer data to read or write</param>
        /// <param name="offset">Otional, used for the "both" methode to deffine a offset to start to read from a file. If you do not wan't to read from the begin use this var to tell the Routine to jump to your deffined offset.</param>
        /// <param name="count">Optional, also used for the "both" methode to deffine to only to read a specific byte count and not till the end of the file.</param>
        public static void ReadWriteData(string fileToUse, [Optional] string fileToUse2, string methodReadOrWriteOrBoth, [Optional] string methodBinaryOrInteger, [Optional] byte[] binData, [Optional] int binData2, [Optional] long offset, [Optional] long count)
        {
            string caseSwitch = methodReadOrWriteOrBoth;
            switch (caseSwitch)
            {
                case "r":
                    {
                        FileInfo fileInfo = new FileInfo(fileToUse);
                        readBuffer = new byte[fileInfo.Length];
                        using (BinaryReader b = new BinaryReader(new FileStream(fileToUse, FileMode.Open, FileAccess.Read)))
                        {
                            b.Read(readBuffer, 0, readBuffer.Length);
                            b.Close();
                        }
                    }
                    break;
                case "w":
                    {
                        using (BinaryWriter b = new BinaryWriter(new FileStream(fileToUse, FileMode.Append, FileAccess.Write)))
                        {
                            caseSwitch = methodBinaryOrInteger;
                            switch (caseSwitch)
                            {
                                case "bi":
                                    {
                                        b.Write(binData, 0, binData.Length);
                                        b.Close();
                                    }
                                    break;
                                case "in":
                                    {
                                        b.Write(binData2);
                                        b.Close();
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "b":
                    {   // For data that will cause a buffer overflow we use this method. We read from a Input File and Write to a Output File with the help of a Buffer till the end of file or the specified length is reached.
                        using (BinaryReader br = new BinaryReader(new FileStream(fileToUse, FileMode.Open, FileAccess.Read)))
                        {
                            using (BinaryWriter bw = new BinaryWriter(new FileStream(fileToUse2, FileMode.Append, FileAccess.Write)))
                            {
                                // this is a variable for the Buffer size. Play arround with it and maybe set a new size to get better result's
                                int workingBufferSize = 4096; // high
                                // int workingBufferSize = 2048; // middle
                                // int workingBufferSize = 1024; // default
                                // int workingBufferSize = 128;  // minimum

                                // Do we read data that is smaller then our working buffer size?
                                if (count < workingBufferSize)
                                {
                                    workingBufferSize = (int)count;
                                }

                                byte[] buffer = new byte[workingBufferSize];
                                int len;

                                // Do we use a specific offset?
                                if (offset != 0)
                                {
                                    br.BaseStream.Seek(offset, SeekOrigin.Begin);
                                }

                                // Run the process in a loop
                                while ((len = br.Read(buffer, 0, workingBufferSize)) != 0)
                                {
                                    bw.Write(buffer, 0, len);

                                    // Do we read a specific length?
                                    if (count != 0)
                                    {
                                        // Subtract the working buffer size from the byte count to read/write.
                                        count -= workingBufferSize;

                                        // Stop the loop when the specified byte count to read/write is reached.
                                        if (count == 0)
                                        {
                                            break;
                                        }

                                        // When the count value is lower then the working buffer size we set the working buffer to the value of the count variable to not read more data as wanted
                                        if (count < workingBufferSize)
                                        {
                                            workingBufferSize = (int)count;
                                        }
                                    }
                                }
                                bw.Close();
                            }
                            br.Close();
                        }
                    }
                    break;
            }
        }
    }
}
