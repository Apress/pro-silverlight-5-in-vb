Imports System.IO

' From Mike Taulty:
' http://mtaulty.com/CommunityServer/blogs/mike_taultys_blog/archive/2009/11/18/silverlight-4-rough-notes-camera-and-microphone-support.aspx

Public Class WavFileHelper
    Private Sub New()
    End Sub
    Public Shared Function GetWavFileHeader(ByVal audioLength As Long, ByVal audioFormat As AudioFormat) As Byte()
        ' This code could use some constants...   
        Dim stream As New MemoryStream(44)

        ' "RIFF"   
        stream.Write(New Byte() {&H52, &H49, &H46, &H46}, 0, 4)

        ' Data length + 44 byte header length - 8 bytes occupied by first 2 fields   
        stream.Write(BitConverter.GetBytes(CUInt(audioLength + 44 - 8)), 0, 4)

        ' "WAVE"   
        stream.Write(New Byte() {&H57, &H41, &H56, &H45}, 0, 4)

        ' "fmt "   
        stream.Write(New Byte() {&H66, &H6D, &H74, &H20}, 0, 4)

        ' Magic # of PCM file - not sure about that one   
        stream.Write(BitConverter.GetBytes(CUInt(16)), 0, 4)

        ' 1 == Uncompressed   
        stream.Write(BitConverter.GetBytes(CUShort(1)), 0, 2)

        ' Channel count   
        stream.Write(BitConverter.GetBytes(CUShort(audioFormat.Channels)), 0, 2)

        ' Sample rate   
        stream.Write(BitConverter.GetBytes(CUInt(audioFormat.SamplesPerSecond)), 0, 4)

        ' Byte rate   
        stream.Write(BitConverter.GetBytes(CUInt((audioFormat.SamplesPerSecond * audioFormat.Channels * audioFormat.BitsPerSample) / 8)), 0, 4)

        ' Block alignment   
        stream.Write(BitConverter.GetBytes(CUShort((audioFormat.Channels * audioFormat.BitsPerSample) / 8)), 0, 2)

        ' Bits per sample   
        stream.Write(BitConverter.GetBytes(CUShort(audioFormat.BitsPerSample)), 0, 2)

        ' "data"   
        stream.Write(New Byte() {&H64, &H61, &H74, &H61}, 0, 4)

        ' Length of the rest of the file   
        stream.Write(BitConverter.GetBytes(CUInt(audioLength)), 0, 4)

        Return (stream.GetBuffer())
    End Function
End Class

