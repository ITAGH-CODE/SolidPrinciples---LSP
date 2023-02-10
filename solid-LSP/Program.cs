/*  
    Demo from nice article : https://www.c-sharpcorner.com/UploadFile/damubetha/solid-principles-in-C-Sharp/
    
    LSP Liskov Substitution Principle states that you should be able to use any derived class instead of a parent class and it behave the same manner
    without modification
    
    It ensures that the derived class doesn't affect the behaviour of the parent class.
 */

using System.Text;
Console.WriteLine("Hello, World!");

public class SqlFile
{
    public string FilePath { get; set; }
    public string FileText { get; set; }
    public string LoadText()
    {
        return " Code to read text from sql file";
    }
    public string SaveText()
    {
        return "Code to save text into sql file";
    }
}
public class SqlFileManager
{
    public List<SqlFile> LstSqlFiles { get; set; }

    public string GetTextFromFiles()
    {
        StringBuilder objStrBuilder = new StringBuilder();
        foreach (var objFile in LstSqlFiles)
        {
            objStrBuilder.Append(objFile.LoadText());
        }
        return objStrBuilder.ToString();
    }
    public void SaveTextIntoFiles()
    {
        foreach (var objFile in LstSqlFiles)
        {
            objFile.SaveText();
        }
    }
}

/*
    Our leaders might tell us that we may have a few read-only files in the application folder, so we need to restrict the flow whenever it tries to save them
    So, we can do like this : Create a ReadOnlySqlFile 
*/

public class ReadOnlySqlFile : SqlFile
{
    public string FilePath { get; set; }
    public string FileText { get; set; }
    public string LoadText()
    {
        return "Code to read text from sql file";
    }
    public void SaveText()
    {
        /* Throw an exception when app flow tries to do save. */
        throw new IOException("Can't Save");
    }
}

/* 
    So, to avoid the exception, we need to modify the class SqlFileManager to put a condition before saving text. In this case we are not respecting
    LSP.
    So, we cannot use the ReadOnlySqlFile as a substitute of its parent class SqlFile without altering SqlFileManager class => This design is not folowwing LSP
 */
