namespace Assignment_19___MVC___shahd_mostafa.Helper
{
    public static class DocumentSettings
    {
        public static string UploadFile(this IFormFile formFile,string folderName)
        {
            string folderPath=Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Files",folderName);
            string fileName =$"{Guid.NewGuid()}-{formFile.FileName}";
            string filePath=Path.Combine(folderPath,fileName);
            using var stream=new FileStream(filePath,FileMode.Create);
            formFile.CopyTo(stream);
            return fileName;
        }
        public static void DeleteFile(string formFile, string folderName)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Files", folderName);
            string fileName = $"{Guid.NewGuid()}-{formFile}";
            if (File.Exists(folderPath))
            {
                File.Delete(folderPath);
            }
        }

    }
}
