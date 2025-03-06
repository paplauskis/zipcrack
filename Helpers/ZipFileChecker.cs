namespace zipcrack.Helpers;

public static class ZipFileChecker
{
    public static bool IsFileZip(string zipFilePath)
    {
        string fullPath = Path.GetFullPath(zipFilePath);
        
        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException("File not found", fullPath);
        }

        byte[] zipSignature = [0x50, 0x4B, 0x03, 0x04];
        byte[] fileHeader = new byte[4];
            
        using (var fileStream = new FileStream(zipFilePath, FileMode.Open, FileAccess.Read))
        {
            fileStream.Read(fileHeader, 0, 4);
        }
        
        return fileHeader.SequenceEqual(zipSignature);
    }
}