Imports System
Imports System.IO
Imports System.IO.Compression

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")

        If File.Exists("�����ļ�.zip") Then
            File.Delete("�����ļ�.zip")
        End If
        If Directory.Exists("unzip") Then
            Directory.Delete("unzip")
        End If
        Directory.CreateDirectory("unzip")

        zipFolder("�����ļ�", "�����ļ�.zip")
        unzipFile("�����ļ�.zip", "unzip")
    End Sub



    'zip a folder
    Private Sub zipFolder(folderPath As String, zipPath As String)
        Using archive As ZipArchive = ZipFile.Open(zipPath, ZipArchiveMode.Create)
            For Each file As String In Directory.GetFiles(folderPath)
                archive.CreateEntryFromFile(file, Path.GetFileName(file))
            Next
        End Using
    End Sub

    'unzip a file
    Private Sub unzipFile(zipPath As String, folderPath As String)
        Using archive As ZipArchive = ZipFile.Open(zipPath, ZipArchiveMode.Read)
            For Each entry As ZipArchiveEntry In archive.Entries
                entry.ExtractToFile(Path.Combine(folderPath, entry.FullName))
            Next
        End Using
    End Sub

End Module
