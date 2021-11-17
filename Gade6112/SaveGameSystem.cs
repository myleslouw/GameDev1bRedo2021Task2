using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;  //used to get file directory
using System.Runtime.Serialization;

namespace Gade6112
{
    class SaveGameSystem   //the file is saved in the Project folder\bin\debug\ SavedGameData.txt
    {
        private Map savingMap;

        public Map SavingMap
        {
            get { return savingMap; }
            set { savingMap = value; }
        }  //map object for storing data

        Stream stream = null;
        BinaryFormatter Bformatter = null;
        string txtFileName = "";

        public SaveGameSystem(string fileName)
        {
            txtFileName = fileName;
            stream = File.Open(txtFileName, FileMode.Create);  //when initialised it will create a new file and a new binary formatter
            Bformatter = new BinaryFormatter();
        }

        public void SerializeObject(object objectToSerialise)
        {
            Bformatter.Serialize(stream, objectToSerialise);  //the formatter will be given an object(the map) to be serialised
        }

        public Object DeserialiseObject()
        {
            object objectTOdeserialisze = null;
            stream = File.Open(txtFileName, FileMode.Open);  //opens the file it was saved in 

            try
            {
                while (stream.CanSeek)  //seeks through the file and deserialises it
                {
                    objectTOdeserialisze = (object)Bformatter.Deserialize(stream); //deserialises the object

                    if (objectTOdeserialisze is Map)  //if it is of type map
                    {
                        Map _map = (Map)objectTOdeserialisze;   //cast the deserialised object to a map object 
                        return objectTOdeserialisze;   //give us the deserialised object
                    }
                }
            }
            catch (SerializationException ex)  
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("end of file");
            }
            return objectTOdeserialisze;
        }
        public void CloseStream()
        {
            stream.Close(); 
        }

    }
}
