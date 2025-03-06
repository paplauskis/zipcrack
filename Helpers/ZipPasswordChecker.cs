using ICSharpCode.SharpZipLib.Zip;

namespace zipcrack.Helpers;

public class ZipPasswordChecker
{
    private readonly string _zipFilePath;

    public ZipPasswordChecker(string zipFilePath)
    {
        _zipFilePath = zipFilePath;
    }
    
    public bool IsValid(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            return false;
        }
        
        try
        {
            using (ZipFile zip = new ZipFile(File.OpenRead(_zipFilePath)))
            {
                zip.Password = password;
                foreach (ZipEntry entry in zip)
                {
                    if (!entry.IsFile) continue;

                    using (Stream zipStream = zip.GetInputStream(entry))
                    using (FileStream fs = File.Create(entry.Name))
                    {
                        zipStream.CopyTo(fs);
                    }
                }

                return true;
            }
        }
        catch (ZipException)
        {
            return false;
        }
    }
}