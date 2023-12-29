using static System.Console;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using WorkingWithStreams;
using System.Xml;
using System.IO.Compression;

//WorkingWithText();
static void WorkingWithText()
{
    string textFile = Combine(CurrentDirectory, "streams.txt");

    StreamWriter text = File.CreateText(textFile);

    foreach (string item in Viper.Callsigns)
    {
        text.WriteLine(item);
    }
    text.Close();
    WriteLine($"{textFile} contains {new FileInfo(textFile).Length}");
    WriteLine(File.ReadAllText(textFile));

}

// workWithXml();
static void workWithXml()
{
    FileStream? xmlFileStream = null;
    XmlWriter xmlWriter = null;
    try
    {
        string xmlFile = Combine(CurrentDirectory, "streams.xml");


        xmlFileStream = File.Create(xmlFile);

        xmlWriter = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });


        // start the xml declaration 
        xmlWriter.WriteStartDocument();


        // write a root element
        xmlWriter.WriteStartElement("callsigns");

        // enumerate the strings writing each one to the stream
        foreach (string item in Viper.Callsigns)
        {
            xmlWriter.WriteElementString("callsign", item);
        }

        // write the close root element 
        xmlWriter.WriteEndElement();

        xmlWriter.Close();

        xmlFileStream.Close();

        WriteLine($"{xmlFile} contains {new FileInfo(xmlFile).Length} bytes");

        WriteLine(File.ReadAllText(xmlFile));
    }
    catch (Exception ex)
    {
        WriteLine($"{ex.GetType()} says {ex.Message}");

    }
    finally
    {
        if (xmlWriter != null)
        {
            xmlWriter.Dispose();
            WriteLine($"the xml writer's unmanaged resources have been disposed");
        }

        if (xmlFileStream != null)
        {
            xmlFileStream.Dispose();
            WriteLine($"the file stream's unmanaged resources have been disposed");
        }
    }
}


WorkingWithCompression();
WorkingWithCompression(false);
static void WorkingWithCompression(bool useBrotli = true)
{

    string fileExt = useBrotli ? "brotli" : "gzip";



    string filePath = Combine(CurrentDirectory, $"streams.{fileExt}");

    FileStream file = File.Create(filePath);

    Stream compressor;

    if (useBrotli)
    {
       compressor = new BrotliStream(file, CompressionMode.Compress);
    }
    else
    {
        compressor = new GZipStream(file, CompressionMode.Compress);
    }



    using (compressor)
    {
        using (XmlWriter xml = XmlWriter.Create(compressor))
        {
            xml.WriteStartDocument();
            xml.WriteStartElement("callsigns");

            foreach (string item in Viper.Callsigns)
            {
                xml.WriteElementString("callsign", item);
            }
        }
    }

    WriteLine($"{filePath} contains {new FileInfo(filePath).Length} bytes");


    WriteLine($"the compressed contents");

    WriteLine(File.ReadAllText(filePath));


    WriteLine($"Reading the compressed XML File: ");

    file = File.Open(filePath, FileMode.Open);


    Stream decompressor;
    if (useBrotli)
    {
        decompressor = new BrotliStream(file, CompressionMode.Decompress);
    }
    else
    {
        decompressor = new GZipStream(file, CompressionMode.Decompress);
    }

    using (decompressor)
    {
        using (XmlReader reader = XmlReader.Create(decompressor))
        {
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
                {
                    reader.Read();

                    WriteLine($"{reader.Value}");
                }
            }
        }
    }


}