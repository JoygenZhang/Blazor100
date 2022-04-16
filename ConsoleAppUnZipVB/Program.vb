Imports System
Imports System.IO
Imports System.IO.Compression
Imports System.Text

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)

        If File.Exists("�����ļ�.zip") Then
            File.Delete("�����ļ�.zip")
        End If
        If Directory.Exists("unzip") Then
            Directory.Delete("unzip", True)
        End If
        Directory.CreateDirectory("unzip")

        zipFolder("�����ļ�", "�����ļ�.zip")
        unzipFile("�����ļ�.zip", "unzip")
        unzipFile("ref.zip", "unzip")
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
    Private Sub unzipFile(zip�ļ�·�� As String, ��ѹ·�� As String)
        If Not Directory.Exists(��ѹ·��) Then
            Directory.CreateDirectory(��ѹ·��)
        End If
        ZipFile.ExtractToDirectory(zip�ļ�·��, ��ѹ·��, Text.Encoding.GetEncoding(��GB2312��), True)
    End Sub

End Module
