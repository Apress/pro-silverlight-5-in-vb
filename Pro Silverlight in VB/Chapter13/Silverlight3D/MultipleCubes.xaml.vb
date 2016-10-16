Imports Microsoft.Xna.Framework.Graphics
Imports System.Windows.Graphics
Imports Microsoft.Xna.Framework

Partial Public Class MultipleCubes
    Inherits UserControl

    Private cube As Cube3D
    Private cube2 As Cube3D
    Private cube3 As Cube3D

    Public Sub New()
        InitializeComponent()

        Dim device As GraphicsDevice = GraphicsDeviceManager.Current.GraphicsDevice
        Dim uri As String = "Silverlight3D;component/mayablur.jpg"

        ' Create a view that all three cubes will share.
        Dim view As Matrix = Matrix.CreateLookAt(New Vector3(1, 1, 3), Vector3.Zero, Vector3.Up)

        ' Create the three cubes.
        cube = New Cube3D(device, New Vector3(-1, -1, -1), 2, uri, 1.33, view)
        cube2 = New Cube3D(device, New Vector3(-2, -2, 1), 1.5, uri, 1.33, view)
        cube3 = New Cube3D(device, New Vector3(-5, -2, -2.5), 2, uri, 1.33, view)
    End Sub


    Private Sub drawingSurface_Draw(ByVal sender As Object, ByVal e As DrawEventArgs)
        Dim device As GraphicsDevice = GraphicsDeviceManager.Current.GraphicsDevice
        device.Clear(New Color(0, 0, 0))

        cube.Draw(device)
        cube2.Draw(device)
        cube3.Draw(device)
    End Sub


End Class
