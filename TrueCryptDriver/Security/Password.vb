﻿Imports System.IO
Imports System.Text
Imports TrueCryptDriver.Common
Imports TrueCryptDriver.Driver.Constants

Namespace Security
    Public Class Password
        Dim pPassword As String
        Dim pKeyFile As New KeyFileCollection

        Public Property Password As String
            Set(value As String)
                pPassword = value
            End Set
            Get
                Return pPassword
            End Get
        End Property

        Public Property KeyFile As KeyFileCollection
            Set(value As KeyFileCollection)
                pKeyFile = value
            End Set
            Get
                Return pKeyFile
            End Get
        End Property

        Friend Function ApplyKeyFile(ByRef Password As String) As Boolean
            Dim keyPool(KEYFILE_POOL_SIZE - 1) As Byte, Ret(MAX_PASSWORD) As Byte
            Dim fInfo As FileInfo

            'For i As Integer = 0 To KEYFILE_POOL_SIZE - 1
            '    keyPool(i) = 204
            'Next

            For Each KeyFile As KeyFile In pKeyFile
                'If it's a token
                'TODO

                If KeyFile.IsDirectory Then 'If it's a directory
                    For Each sFile As String In Directory.EnumerateFiles(KeyFile.FileName, "*.*", SearchOption.TopDirectoryOnly)
                        fInfo = New FileInfo(sFile)

                        If Not fInfo.Attributes And FileAttributes.Hidden Then
                            If Not ProcessKeyFile(keyPool, KeyFile.FileName) Then Return False
                        End If
                    Next
                Else 'If it's a file
                    If Not ProcessKeyFile(keyPool, KeyFile.FileName) Then Return False
                End If
            Next

            'Mix the keyfile pool contents into the password
            For i As Integer = 0 To keyPool.Length - 1
                If i < pPassword.Length Then
                    Ret(i) = (Asc(pPassword(i)) + keyPool(i)) Mod 256
                Else
                    Ret(i) = keyPool(i)
                End If
            Next

            Password = Encoding.Default.GetString(Ret)

            keyPool = Nothing
            Ret = Nothing

            Return True
        End Function

        Private Function ProcessKeyFile(ByRef keyPool() As Byte, ByVal FileName As String) As Boolean
            Dim fsFile As FileStream, frFile As BinaryReader
            Dim src As IntPtr, ftCreationTime As Long, ftLastWriteTime As Long, ftLastAccessTime As Long, bTimeStampValid As Boolean = False
            Dim bytesRead As Integer, totalRead As Integer, buffer(64 * 1024) As Byte, crc As UInteger = 4294967295
            Dim writePos As Integer = 0

            src = CreateFile(FileName, FileAccess.ReadWrite, FileShare.ReadWrite, Nothing, FileMode.Open, 0, Nothing)

            If Not src = INVALID_HANDLE_VALUE Then
                If GetFileTime(src, ftCreationTime, ftLastAccessTime, ftLastWriteTime) Then bTimeStampValid = True
            End If

            fsFile = New FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            frFile = New BinaryReader(fsFile)

            bytesRead = frFile.Read(buffer, 0, buffer.Length)
            While bytesRead > 0
                For i As Integer = 0 To bytesRead - 1
                    crc = UPDC32(buffer(i), crc)

                    keyPool(writePos) = (keyPool(writePos) + ((crc >> 24) Mod 256)) Mod 256
                    keyPool(writePos + 1) = (keyPool(writePos + 1) + ((crc >> 16) Mod 256)) Mod 256
                    keyPool(writePos + 2) = (keyPool(writePos + 2) + ((crc >> 8) Mod 256)) Mod 256
                    keyPool(writePos + 3) = (keyPool(writePos + 3) + ((crc) Mod 256)) Mod 256
                    writePos += 4

                    If writePos >= KEYFILE_POOL_SIZE Then
                        writePos = 0
                    End If

                    If totalRead >= KEYFILE_MAX_READ_LEN Then GoTo close
                    totalRead += 1
                Next

                bytesRead = frFile.Read(buffer, 0, buffer.Length)
            End While

close:
            If bTimeStampValid And Not IsFileOnReadOnlyFilesystem(FileName) Then
                SetFileTime(src, ftCreationTime, ftLastAccessTime, ftLastWriteTime)
            End If

            frFile.Close()
            fsFile.Close()

            CloseHandle(src)

            If totalRead = 0 Then Return False

            Return True
        End Function

    End Class
End Namespace