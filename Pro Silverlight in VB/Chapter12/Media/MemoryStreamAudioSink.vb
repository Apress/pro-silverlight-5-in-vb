Imports System.IO

Public Class MemoryStreamAudioSink
    Inherits AudioSink

    Private stream As MemoryStream
    Protected Overrides Sub OnCaptureStarted()
        ' Prepare a new in-memory stream to store the captured audio.            
        stream = New MemoryStream()
    End Sub

    Protected Overrides Sub OnCaptureStopped()
        ' Genereate the header.
        Dim wavFileHeader As Byte() = WavFileHelper.GetWavFileHeader(AudioData.Length, AudioFormat)

        ' Write the header to a new stream.
        Dim wavStream As New MemoryStream()
        wavStream.Write(wavFileHeader, 0, wavFileHeader.Length)

        ' Write the rest of the data, one chunk of 4096 bytes at a time.
        Dim buffer(4095) As Byte
        Dim read As Integer = 0
        stream.Seek(0, SeekOrigin.Begin)
        read = stream.Read(buffer, 0, buffer.Length)
        Do While read > 0
            wavStream.Write(buffer, 0, read)
            read = stream.Read(buffer, 0, buffer.Length)
        Loop

        ' Replace the raw stream with the new stream.
        stream = wavStream
        stream.Seek(0, SeekOrigin.Begin)
    End Sub

    Private _audioFormat As AudioFormat
    Public ReadOnly Property AudioFormat() As AudioFormat
        Get
            Return _audioFormat
        End Get
    End Property

    Public ReadOnly Property AudioData() As MemoryStream
        Get
            Return stream
        End Get
    End Property

    Protected Overrides Sub OnFormatChange(ByVal audioFormat As AudioFormat)
        If _audioFormat Is Nothing Then
            _audioFormat = audioFormat
        Else
            ' Don't allow changes that could affect an existing capture.
            Throw New InvalidOperationException()
        End If
    End Sub

    Protected Overrides Sub OnSamples(ByVal sampleTime As Long, ByVal sampleDuration As Long, ByVal sampleData As Byte())
        ' Each time a sample is received, write it to the in-memory stream.
        ' (A more complex implementation might stream it over the network.)
        stream.Write(sampleData, 0, sampleData.Length)
    End Sub

End Class
