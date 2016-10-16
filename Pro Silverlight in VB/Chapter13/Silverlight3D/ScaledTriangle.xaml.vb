Imports Microsoft.Xna.Framework.Graphics
Imports System.Windows.Graphics
Imports Microsoft.Xna.Framework

Partial Public Class ScaledTriangle
    Inherits UserControl

    Public Sub New()
        InitializeComponent()

        PrepareDrawing()
    End Sub

    ' Stores the corners of all your triangles.
    Private vertexBuffer As VertexBuffer

    ' Stores various drawing details.
    Private basicEffect As BasicEffect

    Private Sub PrepareDrawing()
        ' Define the triangle's vertices.
        Dim topCenter As New Vector3(0, 1, 0)
        Dim bottomLeft As New Vector3(-1, 0, 0)
        Dim bottomRight As New Vector3(1, 0, 0)

        ' White:
        Dim color1 As New Color(255, 255, 255)
        ' Red:
        Dim color2 As New Color(255, 0, 0)
        ' Green:
        Dim color3 As New Color(0, 255, 0)

        ' Combine the color and vertex information.
        Dim vertices(2) As VertexPositionColor
        vertices(0) = New VertexPositionColor(bottomLeft, color1)
        vertices(1) = New VertexPositionColor(topCenter, color3)
        vertices(2) = New VertexPositionColor(bottomRight, color2)

        ' Set up the vertex buffer.
        Dim device As GraphicsDevice = GraphicsDeviceManager.Current.GraphicsDevice
        vertexBuffer = New VertexBuffer(device, GetType(VertexPositionColor), vertices.Length, BufferUsage.WriteOnly)
        vertexBuffer.SetData(0, vertices, 0, vertices.Length, 0)

        ' Configure the camera.
        Dim view As Matrix = Matrix.CreateLookAt(New Vector3(0, 0, 5), Vector3.Zero, Vector3.Up)
        Dim projection As Matrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 1.33, 1, 10)
        Dim viewProjection As Matrix = view * projection

        ' Set up the effect.
        basicEffect = New BasicEffect(device)
        basicEffect.World = Matrix.Identity
        basicEffect.View = view
        basicEffect.Projection = viewProjection
        basicEffect.VertexColorEnabled = True
    End Sub

    Private Sub drawingSurface_Draw(ByVal sender As Object, ByVal e As DrawEventArgs)
        Dim device As GraphicsDevice = GraphicsDeviceManager.Current.GraphicsDevice

        device.Clear(New Color(0, 0, 0))

        device.SetVertexBuffer(vertexBuffer)

        For Each pass As EffectPass In basicEffect.CurrentTechnique.Passes
            pass.Apply()
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, vertexBuffer.VertexCount / 3)
        Next

        e.InvalidateSurface()
    End Sub

    Private Sub UserControl_SizeChanged(ByVal sender As Object, ByVal e As SizeChangedEventArgs)
        ' Apply new scale.
        Dim aspectRatio As Single = e.NewSize.Width / e.NewSize.Height
        Dim view As Matrix = Matrix.CreateLookAt(New Vector3(0, 0, 5), Vector3.Zero, Vector3.Up)
        Dim projection As Matrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 1, 10)

        basicEffect.Projection = view * projection

        ' Redraw.
        ' surface.Invalidate();        
    End Sub


End Class
