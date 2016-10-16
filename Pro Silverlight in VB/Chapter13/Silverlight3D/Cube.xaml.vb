Imports Microsoft.Xna.Framework.Graphics
Imports System.Windows.Graphics
Imports Microsoft.Xna.Framework

Partial Public Class Cube
    Inherits UserControl

    Public Sub New()
        InitializeComponent()

        PrepareDrawing()
    End Sub

    Private vertexBuffer As VertexBuffer
    Private basicEffect As BasicEffect

    Private Sub PrepareDrawing()
        ' The colors to use for coloring triangles.
        Dim colorRed As New Color(255, 0, 0, 0)
        Dim colorBlue As New Color(0, 255, 0, 0)
        Dim colorGreen As New Color(0, 0, 255, 0)
        Dim colorWhite As New Color(255, 255, 255, 255)

        ' The points to use for the vertices.            
        Dim topLeftFront As New Vector3(-1, 1, 1)
        Dim bottomLeftFront As New Vector3(-1, -1, 1)
        Dim topRightFront As New Vector3(1, 1, 1)
        Dim bottomRightFront As New Vector3(1, -1, 1)
        Dim topLeftBack As New Vector3(-1, 1, -1)
        Dim topRightBack As New Vector3(1, 1, -1)
        Dim bottomLeftBack As New Vector3(-1, -1, -1)
        Dim bottomRightBack As New Vector3(1, -1, -1)

        ' The vertex data.
        Dim vertices(35) As VertexPositionColor

        ' Shaded example.
        ' Front face
        vertices(0) = New VertexPositionColor(topRightFront, colorBlue)
        vertices(1) = New VertexPositionColor(bottomLeftFront, colorGreen)
        vertices(2) = New VertexPositionColor(topLeftFront, colorRed)
        vertices(3) = New VertexPositionColor(topRightFront, colorBlue)
        vertices(4) = New VertexPositionColor(bottomRightFront, colorWhite)
        vertices(5) = New VertexPositionColor(bottomLeftFront, colorGreen)
        ' Back face
        vertices(6) = New VertexPositionColor(bottomLeftBack, colorWhite)
        vertices(7) = New VertexPositionColor(topRightBack, colorRed)
        vertices(8) = New VertexPositionColor(topLeftBack, colorBlue)
        vertices(9) = New VertexPositionColor(bottomRightBack, colorGreen)
        vertices(10) = New VertexPositionColor(topRightBack, colorRed)
        vertices(11) = New VertexPositionColor(bottomLeftBack, colorWhite)
        ' Top face
        vertices(12) = New VertexPositionColor(topLeftBack, colorRed)
        vertices(13) = New VertexPositionColor(topRightBack, colorBlue)
        vertices(14) = New VertexPositionColor(topLeftFront, colorRed)
        vertices(15) = New VertexPositionColor(topRightBack, colorBlue)
        vertices(16) = New VertexPositionColor(topRightFront, colorBlue)
        vertices(17) = New VertexPositionColor(topLeftFront, colorRed)
        ' Bottom face
        vertices(18) = New VertexPositionColor(bottomRightBack, colorRed)
        vertices(19) = New VertexPositionColor(bottomLeftBack, colorBlue)
        vertices(20) = New VertexPositionColor(bottomLeftFront, colorWhite)
        vertices(21) = New VertexPositionColor(bottomRightFront, colorGreen)
        vertices(22) = New VertexPositionColor(bottomRightBack, colorRed)
        vertices(23) = New VertexPositionColor(bottomLeftFront, colorWhite)
        ' Left face
        vertices(24) = New VertexPositionColor(bottomLeftFront, colorWhite)
        vertices(25) = New VertexPositionColor(bottomLeftBack, colorGreen)
        vertices(26) = New VertexPositionColor(topLeftFront, colorRed)
        vertices(27) = New VertexPositionColor(topLeftFront, colorRed)
        vertices(28) = New VertexPositionColor(bottomLeftBack, colorGreen)
        vertices(29) = New VertexPositionColor(topLeftBack, colorRed)
        ' Right face
        vertices(30) = New VertexPositionColor(bottomRightBack, colorWhite)
        vertices(31) = New VertexPositionColor(bottomRightFront, colorGreen)
        vertices(32) = New VertexPositionColor(topRightFront, colorRed)
        vertices(33) = New VertexPositionColor(bottomRightBack, colorWhite)
        vertices(34) = New VertexPositionColor(topRightFront, colorRed)
        vertices(35) = New VertexPositionColor(topRightBack, colorBlue)

        ' Solid coloring example.
        ' Front face
        'vertices(0) = New VertexPositionColor(topRightFront, colorBlue)
        'vertices(1) = New VertexPositionColor(bottomLeftFront, colorBlue)
        'vertices(2) = New VertexPositionColor(topLeftFront, colorBlue)
        'vertices(3) = New VertexPositionColor(topRightFront, colorGreen)
        'vertices(4) = New VertexPositionColor(bottomRightFront, colorGreen)
        'vertices(5) = New VertexPositionColor(bottomLeftFront, colorGreen)
        ' Back face
        'vertices(6) = New VertexPositionColor(bottomLeftBack, colorRed)
        'vertices(7) = New VertexPositionColor(topRightBack, colorRed)
        'vertices(8) = New VertexPositionColor(topLeftBack, colorRed)
        'vertices(9) = New VertexPositionColor(bottomRightBack, colorWhite)
        'vertices(10) = New VertexPositionColor(topRightBack, colorWhite)
        'vertices(11) = New VertexPositionColor(bottomLeftBack, colorWhite)
        ' Top face
        'vertices(12) = New VertexPositionColor(topLeftBack, colorRed)
        'vertices(13) = New VertexPositionColor(topRightBack, colorRed)
        'vertices(14) = New VertexPositionColor(topLeftFront, colorRed)
        'vertices(15) = New VertexPositionColor(topRightBack, colorWhite)
        'vertices(16) = New VertexPositionColor(topRightFront, colorWhite)
        'vertices(17) = New VertexPositionColor(topLeftFront, colorWhite)
        ' Bottom face
        'vertices(18) = New VertexPositionColor(bottomRightBack, colorWhite)
        'vertices(19) = New VertexPositionColor(bottomLeftBack, colorWhite)
        'vertices(20) = New VertexPositionColor(bottomLeftFront, colorWhite)
        'vertices(21) = New VertexPositionColor(bottomRightFront, colorGreen)
        'vertices(22) = New VertexPositionColor(bottomRightBack, colorGreen)
        'vertices(23) = New VertexPositionColor(bottomLeftFront, colorGreen)
        ' Left face
        'vertices(24) = New VertexPositionColor(bottomLeftFront, colorGreen)
        'vertices(25) = New VertexPositionColor(bottomLeftBack, colorGreen)
        'vertices(26) = New VertexPositionColor(topLeftFront, colorGreen)
        'vertices(27) = New VertexPositionColor(topLeftFront, colorRed)
        'vertices(28) = New VertexPositionColor(bottomLeftBack, colorRed)
        'vertices(29) = New VertexPositionColor(topLeftBack, colorRed)
        ' Right face
        'vertices(30) = New VertexPositionColor(bottomRightBack, colorRed)
        'vertices(31) = New VertexPositionColor(bottomRightFront, colorRed)
        'vertices(32) = New VertexPositionColor(topRightFront, colorRed)
        'vertices(33) = New VertexPositionColor(bottomRightBack, colorBlue)
        'vertices(34) = New VertexPositionColor(topRightFront, colorBlue)
        'vertices(35) = New VertexPositionColor(topRightBack, colorBlue)

        ' Set up the vertex buffer.
        Dim device As GraphicsDevice = GraphicsDeviceManager.Current.GraphicsDevice
        vertexBuffer = New VertexBuffer(device, GetType(VertexPositionColor), vertices.Length, BufferUsage.WriteOnly)
        vertexBuffer.SetData(0, vertices, 0, vertices.Length, 0)

        ' Configure the camera.
        Dim view As Matrix = Matrix.CreateLookAt(New Vector3(1, 1, 3), Vector3.Zero, Vector3.Up)
        Dim projection As Matrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 1.33, 1, 100)

        ' Set up the effect.
        basicEffect = New BasicEffect(device)
        basicEffect.World = Matrix.Identity
        basicEffect.View = view
        basicEffect.Projection = view * projection
        basicEffect.VertexColorEnabled = True
    End Sub

    Private Sub drawingSurface_Draw(ByVal sender As Object, ByVal e As DrawEventArgs)
        Dim device As GraphicsDevice = GraphicsDeviceManager.Current.GraphicsDevice

        device.Clear(New Color(0, 0, 0, 0))
        device.SetVertexBuffer(vertexBuffer)

        For Each pass As EffectPass In basicEffect.CurrentTechnique.Passes
            pass.Apply()
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, vertexBuffer.VertexCount / 3)
        Next
    End Sub

End Class
