using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;


namespace WindowsApp2.Services
{
    public static class ContentManager
    {

        #region Public Methods (API)

        public static async Task<bool> TryWriteEventsJsonAsync(StorageFile outFile, string eventsJson)
        {
            return await TryWriteAsync(outFile, eventsJson);
        }

        public static async Task<string> GetEventsJsonAsync(StorageFile inputFile)
        {
            return await TryReadAsync(inputFile);
        }

        #endregion
        
        #region Private Helpers

        private static void WriteXmlLine(XmlWriter writer, object contentGraph)
        {
            DataContractSerializer ser = new DataContractSerializer(contentGraph.GetType());
            ser.WriteObject(writer, contentGraph);
            writer.WriteWhitespace("\r\n");
        }

        private static async Task<bool> TryWriteAsync(StorageFile outFile, string content)
        {
            bool result;
            try
            {
                await FileIO.WriteTextAsync(outFile, content);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        private static async Task<string> TryReadAsync(StorageFile inputFile)
        {
            try
            {
                string s = await FileIO.ReadTextAsync(inputFile);
                return s;
            }
            catch
            {
                return null;
            }
        }

        private static object DeserializeXmlString(string xmlString, Type expectedType)
        {
            XmlReader reader = null;
            try
            {
                DataContractSerializer ser = new DataContractSerializer(expectedType);
                reader = XmlReader.Create(new StringReader(xmlString));
                return ser.ReadObject(reader);
            }
            catch
            {
                return default(object);
            }
            finally
            {
                if (reader != null)
                    reader.Dispose();
            }
        }

        #endregion

    }
}
