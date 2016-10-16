Imports System.Windows.Threading
Imports Microsoft.Xna.Framework.Audio
Imports System.Windows.Resources

Partial Public Class LowLatencyAudio
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub cmdPlaySound_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Get the sound file data.
        Dim sri As StreamResourceInfo = Application.GetResourceStream(New Uri("Media;component/explosion.wav", UriKind.RelativeOrAbsolute))

        ' Load the sound. 
        Dim explosionSound As SoundEffect = SoundEffect.FromStream(sri.Stream)

        ' Play the sound. This happens asynchronously, so the code carries on
        ' with no pause.
        explosionSound.Play()
    End Sub

    Private Sub cmdPlayModifiedSound_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Get the sound file data.
        Dim sri As StreamResourceInfo = Application.GetResourceStream(New Uri("Media;component/explosion.wav", UriKind.RelativeOrAbsolute))

        ' Load the sound. 
        Dim explosionSound As SoundEffect = SoundEffect.FromStream(sri.Stream)

        ' Play the sound. This happens asynchronously, so the code carries on
        ' with no pause.
        explosionSound.Play(0.8, 1.0, -0.3)
    End Sub

    Private Sub cmdPlayMultipleSounds_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Get the sound file data.
        Dim sri As StreamResourceInfo = Application.GetResourceStream(New Uri("Media;component/explosion.wav", UriKind.RelativeOrAbsolute))

        ' Load the sound. 
        Dim explosionSound As SoundEffect = SoundEffect.FromStream(sri.Stream)

        Dim explosion1 As SoundEffectInstance = explosionSound.CreateInstance()
        Dim explosion2 As SoundEffectInstance = explosionSound.CreateInstance()

        ' explosion1 will be a lower, quieter sound.
        explosion1.Pitch = -0.5
        explosion1.Volume = 0.8

        ' explosion2 will be panned to one side, higher-pitched, and even quieter.
        explosion1.Pitch = 1.5
        explosion2.Pan = -0.9
        explosion2.Volume = 0.7

        ' Play all three at once.
        explosionSound.Play()
        explosion1.Play()
        explosion2.Play()
    End Sub

    Private Sub cmdPlayStaggeredSounds_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Get the sound file data.
        Dim sri As StreamResourceInfo = Application.GetResourceStream(New Uri("Media;component/explosion.wav", UriKind.RelativeOrAbsolute))

        ' Load the sound. 
        Dim explosionSound As SoundEffect = SoundEffect.FromStream(sri.Stream)

        Dim explosion1 As SoundEffectInstance = explosionSound.CreateInstance()
        Dim explosion2 As SoundEffectInstance = explosionSound.CreateInstance()

        ' explosion1 will be a lower, quieter sound.
        explosion1.Pitch = -0.5
        explosion1.Volume = 0.8

        ' explosion2 will be panned to one side, and even quieter.
        explosion2.Pan = -0.9
        explosion2.Volume = 0.7

        Dim timer1 As New DispatcherTimer()
        timer1.Interval = TimeSpan.FromSeconds(0.5)
        ' Play the second sound half a second later.
        AddHandler timer1.Tick, Sub()
                                    timer1.Stop()
                                    explosion1.Play()
                                End Sub

        Dim timer2 As New DispatcherTimer()
        timer2.Interval = TimeSpan.FromSeconds(1)
        ' Play the third sound a second later.
        AddHandler timer2.Tick, Sub()
                                    timer2.Stop()
                                    explosion2.Play()
                                End Sub

        ' Play the first sound.
        explosionSound.Play()

        ' Queue the next sounds.            
        timer1.Start()
        timer2.Start()
    End Sub

    Private backgroundInstance As SoundEffectInstance
    Private Sub cmdStartLoop_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Get the sound file data.
        Dim sri As StreamResourceInfo = Application.GetResourceStream(New Uri("Media;component/explosion.wav", UriKind.RelativeOrAbsolute))

        Dim backgroundEffect As SoundEffect = SoundEffect.FromStream(sri.Stream)
        backgroundInstance = backgroundEffect.CreateInstance()

        backgroundInstance.IsLooped = True
        backgroundInstance.Play()
    End Sub

    Private Sub cmdStopLoop_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not backgroundInstance Is Nothing Then
            backgroundInstance.Stop()
            backgroundInstance = Nothing
        End If
    End Sub

End Class
