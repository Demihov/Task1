using System;
using System.IO;
using Newtonsoft.Json;
using NLog;

namespace Task1_Matrix
{
    public class MatrixJSONSerialezer
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        string path;
        public MatrixJSONSerialezer(string path)
        {
            this.path = path;
        }
        public void SaveMatrix(Matrix matrix)
        {
            try
            {
                logger.Info("Start serialization matrix");
                using StreamWriter file = File.CreateText(path);
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, matrix);
            }
            catch (Exception e)
            {
                logger.Error(e, "Exception in SaveMatrix method!");
                throw;
            }
            
        }
        public Matrix ReadMatrix()
        {
            Matrix matrix = null;
            try
            {
                logger.Info("Start deserializing matrix");
                using StreamReader file = File.OpenText(path);
                JsonSerializer serializer = new JsonSerializer();
                matrix = (Matrix)serializer.Deserialize(file, typeof(Matrix));
                return matrix;
            }
            catch(Exception e)
            {
                logger.Error(e, "Exception in ReadMatrix method!");
                throw;
            }
        }
    }
}
