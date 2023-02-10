/*  
    Demo from nice article : https://www.c-sharpcorner.com/UploadFile/damubetha/solid-principles-in-C-Sharp/
    LSP Liskov Substitution Principle states that you should be able to use any derived class instead of a parent class and it behaves the same manner
    without modification
    
    It ensures that the derived class doesn't affect the behaviour of the parent class.
 */
using System.Text;
List<IReadableSqlFile> readableSqlFile = null;
List<IWritableSqlFile> writableSqlFile = null;

if(readableSqlFile != null)
    SqlFileManager.GetTextFromFiles(readableSqlFile);

if(writableSqlFile != null)
SqlFileManager.SaveTextIntoFiles(writableSqlFile);

Console.WriteLine("Hello, World!");

/*
    Our leaders might tell us that we may have a few read-only files in the application folder, so we need to restrict the flow whenever it tries to save them
    So, we can do like this : Create a ReadOnlySqlFile 
    
    We introduce two interfaces to make SqlFileManager class independant to the rest of the block.
*/

public interface IReadableSqlFile
{
    string LoadText();
}
public interface IWritableSqlFile
{
    void SaveText();
}

public class ReadOnlySqlFile : IReadableSqlFile
{
    public string FilePath { get; set; }
    public string FileText { get; set; }
    public string LoadText()
    {
        return "Code to read text from sql file";
    }
}
public class SqlFile : IReadableSqlFile , IWritableSqlFile
{
    public string FilePath { get; set; }
    public string FileText { get; set; }
    public string LoadText()
    {
        return "Code to read text from sql file";
    }
    public void SaveText()
    {
        /* Code to save text */
    }
}

public static class SqlFileManager
{
    public static string GetTextFromFiles(List<IReadableSqlFile> aLstReadableFiles)
    {
        StringBuilder objStrBuilder = new StringBuilder();
        foreach (var objFile in aLstReadableFiles)
        {
            objStrBuilder.Append(objFile.LoadText());
        }
        return objStrBuilder.ToString();
    }
    public static void SaveTextIntoFiles(List<IWritableSqlFile> aLstWritableFiles)
    {
        foreach (var objFile in aLstWritableFiles)
        {
            objFile.SaveText();
        }
    }
}
