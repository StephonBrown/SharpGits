namespace SharpGits.Console.Data;

public class Database
{
    public static void Init(string workspacePath)
    {
        var workingDirectory =
            string.IsNullOrWhiteSpace(workspacePath) ? 
                Directory.GetCurrentDirectory() : workspacePath;
        var dotGitDirectory = Path.Combine(workspacePath, ".git");
        var refsDirectory = Path.Combine(dotGitDirectory, "refs");
        var objectsDirectory = Path.Combine(dotGitDirectory, "objects");
        var headFile = Path.Combine(dotGitDirectory, "HEAD");

        try
        {
            if (!Directory.Exists(workspacePath))
            {
                Directory.CreateDirectory(workingDirectory);
            }
            if (!Directory.Exists(dotGitDirectory))
            {
                Directory.CreateDirectory(dotGitDirectory);
            }
            if (!Directory.Exists(refsDirectory))
            {
                Directory.CreateDirectory(refsDirectory);
            }
            if (!Directory.Exists(objectsDirectory))
            {
                Directory.CreateDirectory(objectsDirectory);
            }
            if(!File.Exists(headFile))
            {
                File.WriteAllText(headFile,"ref: refs/heads/main\n");
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
            throw;
        }

    }
    
}