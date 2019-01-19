using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace PS4_NOR_Dump_Checker
{
    public class DataEntropy
    {
        public SortedDictionary<byte, int> DistributionDict { get; private set; }

        public SortedDictionary<byte, double> ProbabilityDict { get; private set; }

        public int DataSampleSize { get; private set; }

        public int UniqueSymbols
        {
            get
            {
                return this.DistributionDict.Count;
            }
        }

        public double AbsoluteEntropy { get; private set; }

        public double ShannonSpecificEntropy { get; private set; }

        public double NormalizedAbsoluteEntropy { get; private set; }

        public double NormalizedShannonSpecificEntropy { get; private set; }

        public double CompressionEntropy { get; private set; }

        public DataEntropy()
        {
            Clear();
        }

        public DataEntropy(FileInfo file)
      : this()
        {
            if (!file.Exists)
                return;
            CalculateCompressionEntropy(file);
            ExamineBytes(file);
            CalculateEntropy();
        }

        public void Clear()
        {
            DataSampleSize = 0;
            AbsoluteEntropy = 0.0;
            CompressionEntropy = 0.0;
            ShannonSpecificEntropy = 0.0;
            NormalizedAbsoluteEntropy = 0.0;
            NormalizedShannonSpecificEntropy = 0.0;
            DistributionDict = new SortedDictionary<byte, int>();
            ProbabilityDict = new SortedDictionary<byte, double>();
        }

        private void ExamineBytes(FileInfo file)
        {
            byte[] numArray = File.ReadAllBytes(file.FullName);
            DataSampleSize = numArray.Length;
            foreach (byte key in numArray)
            {
                if (!DistributionDict.ContainsKey(key))
                    DistributionDict.Add(key, 1);
                else
                    DistributionDict[key]++;
            }
            foreach (KeyValuePair<byte, int> keyValuePair in DistributionDict)
                ProbabilityDict.Add(keyValuePair.Key, (double)keyValuePair.Value / (double)DataSampleSize);
        }

        public static double ExamineChunk(byte[] chunk)
        {
            if (chunk.Length < 1 || chunk == null)
                throw new ArgumentException();
            int length = chunk.Length;
            Dictionary<byte, int> dictionary = new Dictionary<byte, int>();
            foreach (byte key in chunk)
            {
                if (!dictionary.ContainsKey(key))
                    dictionary.Add(key, 1);
                else
                    dictionary[key]++;
            }
            double num = 0.0;
            foreach (KeyValuePair<byte, int> keyValuePair in dictionary)
            {
                double a = (double)keyValuePair.Value / (double)length;
                num += a * Math.Log(a, 2.0) * -1.0;
            }
            dictionary.Clear();
            return num;
        }

        private void CalculateEntropy()
        {
            foreach (KeyValuePair<byte, double> keyValuePair in ProbabilityDict)
                ShannonSpecificEntropy += keyValuePair.Value * Math.Log(keyValuePair.Value, 2.0) * -1.0;
            if (ShannonSpecificEntropy > 8.0)
                ShannonSpecificEntropy = 8.0;
            NormalizedShannonSpecificEntropy = ShannonSpecificEntropy / Math.Log(256.0, 2.0);
            AbsoluteEntropy = ShannonSpecificEntropy * (double)DataSampleSize;
            NormalizedAbsoluteEntropy = AbsoluteEntropy / Math.Log(256.0, 2.0);
        }

        private void CalculateCompressionEntropy(FileInfo file)
        {
            string tempFileName = Path.GetTempFileName();
            using (FileStream fileStream = new FileStream(tempFileName, FileMode.Open))
            {
                using (GZipStream gzipStream = new GZipStream((Stream)fileStream, CompressionMode.Compress))
                    gzipStream.Write(File.ReadAllBytes(file.FullName), 0, (int)file.Length);
            }
            FileInfo fileInfo = new FileInfo(tempFileName);
            double num = (double)fileInfo.Length / (double)file.Length * 100.0;
            if (num > 100.0)
                num = 100.0;
            fileInfo.Delete();
            CompressionEntropy = num;
        }

        public double GetSymbolDistribution(byte symbol)
        {
            return (double)DistributionDict[symbol];
        }

        public double GetSymbolEntropy(byte symbol)
        {
            return ProbabilityDict[symbol];
        }

    }

}
