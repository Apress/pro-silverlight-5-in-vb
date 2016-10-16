Imports Microsoft.Xna.Framework.Graphics
Imports System.Windows.Graphics
Imports Microsoft.Xna.Framework
Imports System.Windows.Media.Imaging
Imports System.IO

Partial Public Class AnimationIn3D
    Inherits UserControl

    Private cube As Cube3D
    Private floor As Floor3D

    ' The position of the camera.        
    Private cameraPosition As New Vector3(0, 0, 0.01F)

    ' The direction the camera is looking at, *from the origin*.
    Private cameraLook As New Vector3(0, 0, -1)

    ' The combination of the camera's position and its look direction.
    Private cameraTarget As Vector3

    Public Sub New()
        InitializeComponent()

        ' Create the cube and floor.
        Dim device As GraphicsDevice = GraphicsDeviceManager.Current.GraphicsDevice
        Dim view As Matrix = Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up)
        cube = New Cube3D(device, New Vector3(-1, -1, -1), 2, "Silverlight3D;component/mayablur.jpg", 1.33, view)
        floor = New Floor3D(device, 1.33, view)

        ' Walk the camera back so the scene is visible.
        ' (The camera starts at the origin, so the rotations work around the origin.)
        cameraPosition -= cameraLook * 6

        ' Displace it before rotating it, to get an orbiting effect.
        'Matrix translation = Matrix.CreateTranslation(-2, 0, 0)
        'cube.World = cube.World * translation
    End Sub

    ' Keep track of whether the cube is rotating.
    Private rotate As Boolean = True

    Private Sub drawingSurface_Draw(ByVal sender As Object, ByVal e As DrawEventArgs)
        Dim device As GraphicsDevice = GraphicsDeviceManager.Current.GraphicsDevice
        device.Clear(New Color(0, 0, 0))

        ' This allows you to see the inside of the cube when you pass into it.
        device.RasterizerState = New RasterizerState With
        {
            .CullMode = CullMode.None
        }

        ' Spin the cube.
        If rotate Then
            Dim rotation As Matrix = Matrix.CreateRotationY(MathHelper.PiOver4 * e.DeltaTime.TotalMilliseconds / 2000)
            cube.World = cube.World * rotation
        End If

        ' Create the view for the current camera position and direction.
        cameraTarget = cameraPosition + cameraLook
        Dim view As Matrix = Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up)
        cube.View = view
        floor.View = view

        ' Draw the shapes.
        floor.Draw(device)
        cube.Draw(device)

        ' Keep the drawing surface updated.
        e.InvalidateSurface()
    End Sub

    Private Sub UserControl_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim rotation As Matrix = Matrix.Identity
        Select Case e.Key
            Case Key.Left
                rotation = Matrix.CreateRotationY(MathHelper.PiOver4 * 0.08)
                cameraLook = Vector3.Transform(cameraLook, rotation)
            Case Key.Right
                rotation = Matrix.CreateRotationY(MathHelper.PiOver4 * -0.08)
                cameraLook = Vector3.Transform(cameraLook, rotation)
            Case Key.Up
                cameraPosition += cameraLook * 0.08
            Case Key.Down
                cameraPosition -= cameraLook * 0.08
        End Select
        cube.View *= rotation
    End Sub

    Private Sub cmdToggleRotate_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        rotate = Not rotate
    End Sub

    Private Sub UserControl_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' This makes sure this part of the page receives the key events
        ' (not the page-selection list box).
        cmdToggleRotate.Focus()
    End Sub

End Class
