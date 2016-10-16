Imports Microsoft.Xna.Framework.Graphics
Imports System.Windows.Graphics
Imports Microsoft.Xna.Framework
Imports System.Windows.Media.Imaging
Imports System.IO

Partial Public Class Lighting
    Inherits UserControl

    Public Sub New()
        InitializeComponent()

        PrepareDrawing()
    End Sub

    Private vertexBuffer As VertexBuffer
    Private basicEffect As BasicEffect

    Private Sub PrepareDrawing()
        Dim textureTopLeft As New Vector2(0, 0)
        Dim textureTopRight As New Vector2(1, 0)
        Dim textureBottomLeft As New Vector2(0, 1)
        Dim textureBottomRight As New Vector2(1, 1)

        Dim topLeftFront As New Vector3(-1, 1, 1)
        Dim bottomLeftFront As New Vector3(-1, -1, 1)
        Dim topRightFront As New Vector3(1, 1, 1)
        Dim bottomRightFront As New Vector3(1, -1, 1)
        Dim topLeftBack As New Vector3(-1, 1, -1)
        Dim topRightBack As New Vector3(1, 1, -1)
        Dim bottomLeftBack As New Vector3(-1, -1, -1)
        Dim bottomRightBack As New Vector3(1, -1, -1)
        Dim vertices(35) As VertexPositionNormalTexture

        Dim frontNormal As New Vector3(0, 0, 1)
        Dim backNormal As New Vector3(0, 0, -1)
        Dim topNormal As New Vector3(0, 1, 0)
        Dim bottomNormal As New Vector3(0, -1, 0)
        Dim leftNormal As New Vector3(-1, 0, 0)
        Dim rightNormal As New Vector3(1, 0, 0)
        ' Front face
        vertices(0) = New VertexPositionNormalTexture(topRightFront, frontNormal, textureTopRight)
        vertices(1) = New VertexPositionNormalTexture(bottomLeftFront, frontNormal, textureBottomLeft)
        vertices(2) = New VertexPositionNormalTexture(topLeftFront, frontNormal, textureTopLeft)
        vertices(3) = New VertexPositionNormalTexture(topRightFront, frontNormal, textureTopRight)
        vertices(4) = New VertexPositionNormalTexture(bottomRightFront, frontNormal, textureBottomRight)
        vertices(5) = New VertexPositionNormalTexture(bottomLeftFront, frontNormal, textureBottomLeft)
        ' Back face
        vertices(6) = New VertexPositionNormalTexture(bottomLeftBack, backNormal, textureBottomRight)
        vertices(7) = New VertexPositionNormalTexture(topRightBack, backNormal, textureTopLeft)
        vertices(8) = New VertexPositionNormalTexture(topLeftBack, backNormal, textureTopRight)
        vertices(9) = New VertexPositionNormalTexture(bottomRightBack, backNormal, textureBottomLeft)
        vertices(10) = New VertexPositionNormalTexture(topRightBack, backNormal, textureTopLeft)
        vertices(11) = New VertexPositionNormalTexture(bottomLeftBack, backNormal, textureBottomRight)
        ' Top face
        vertices(12) = New VertexPositionNormalTexture(topLeftBack, topNormal, textureTopLeft)
        vertices(13) = New VertexPositionNormalTexture(topRightBack, topNormal, textureTopRight)
        vertices(14) = New VertexPositionNormalTexture(topLeftFront, topNormal, textureBottomLeft)
        vertices(15) = New VertexPositionNormalTexture(topRightBack, topNormal, textureTopRight)
        vertices(16) = New VertexPositionNormalTexture(topRightFront, topNormal, textureBottomRight)
        vertices(17) = New VertexPositionNormalTexture(topLeftFront, topNormal, textureBottomLeft)
        ' Bottom face
        vertices(18) = New VertexPositionNormalTexture(bottomRightBack, bottomNormal, textureTopLeft)
        vertices(19) = New VertexPositionNormalTexture(bottomLeftBack, bottomNormal, textureTopRight)
        vertices(20) = New VertexPositionNormalTexture(bottomLeftFront, bottomNormal, textureBottomRight)
        vertices(21) = New VertexPositionNormalTexture(bottomRightFront, bottomNormal, textureBottomLeft)
        vertices(22) = New VertexPositionNormalTexture(bottomRightBack, bottomNormal, textureTopLeft)
        vertices(23) = New VertexPositionNormalTexture(bottomLeftFront, bottomNormal, textureBottomRight)
        ' Left face
        vertices(24) = New VertexPositionNormalTexture(bottomLeftFront, leftNormal, textureBottomRight)
        vertices(25) = New VertexPositionNormalTexture(bottomLeftBack, leftNormal, textureBottomLeft)
        vertices(26) = New VertexPositionNormalTexture(topLeftFront, leftNormal, textureTopRight)
        vertices(27) = New VertexPositionNormalTexture(topLeftFront, leftNormal, textureTopRight)
        vertices(28) = New VertexPositionNormalTexture(bottomLeftBack, leftNormal, textureBottomLeft)
        vertices(29) = New VertexPositionNormalTexture(topLeftBack, leftNormal, textureTopLeft)
        ' Right face
        vertices(30) = New VertexPositionNormalTexture(bottomRightBack, rightNormal, textureBottomRight)
        vertices(31) = New VertexPositionNormalTexture(bottomRightFront, rightNormal, textureBottomLeft)
        vertices(32) = New VertexPositionNormalTexture(topRightFront, rightNormal, textureTopLeft)
        vertices(33) = New VertexPositionNormalTexture(bottomRightBack, rightNormal, textureBottomRight)
        vertices(34) = New VertexPositionNormalTexture(topRightFront, rightNormal, textureTopLeft)
        vertices(35) = New VertexPositionNormalTexture(topRightBack, rightNormal, textureTopRight)

        ' Set up the vertex buffer.
        Dim device As GraphicsDevice = GraphicsDeviceManager.Current.GraphicsDevice
        vertexBuffer = New VertexBuffer(device, GetType(VertexPositionNormalTexture), vertices.Length, BufferUsage.WriteOnly)
        vertexBuffer.SetData(0, vertices, 0, vertices.Length, 0)

        ' Configure the camera.
        Dim view As Matrix = Matrix.CreateLookAt(New Vector3(0.5, 0.5, 2.0), Vector3.Zero, Vector3.Up)
        Dim projection As Matrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 1.33, 1, 100)

        ' Set up the effect.
        basicEffect = New BasicEffect(device)
        basicEffect.World = Matrix.Identity
        basicEffect.View = view
        basicEffect.Projection = view * projection

        ' Load the texture from a resoure, and place it in a BitmapImage
        Dim uri As String = "Silverlight3D;component/mayablur.jpg"
        Dim s As Stream = Application.GetResourceStream(New Uri(uri, UriKind.Relative)).Stream
        Dim bmp As New BitmapImage()
        bmp.SetSource(s)

        ' Copy the BitmapImage data into a Texture2D object.
        Dim texture As Texture2D
        texture = New Texture2D(device, bmp.PixelWidth, bmp.PixelHeight)
        bmp.CopyTo(texture)

        ' Configure the BasicEffect to use a texture instead of vertex shading.
        'basicEffect.VertexColorEnabled = True          
        basicEffect.TextureEnabled = True
        basicEffect.Texture = texture

        'basicEffect.AmbientLightColor = New Vector3(1.0, 0.0, 0.0)
        'basicEffect.LightingEnabled = True

        basicEffect.EnableDefaultLighting()
    End Sub

    Private Sub drawingSurface_Draw(ByVal sender As Object, ByVal e As DrawEventArgs)
        Dim device As GraphicsDevice = GraphicsDeviceManager.Current.GraphicsDevice
        device.Clear(New Color(0, 0, 0))
        device.SetVertexBuffer(vertexBuffer)

        For Each pass As EffectPass In basicEffect.CurrentTechnique.Passes
            pass.Apply()
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, vertexBuffer.VertexCount / 3)
        Next
    End Sub

    Private Sub slider_ValueChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Double))
        basicEffect.World = Matrix.Identity
        Dim rotation As Matrix = Matrix.CreateRotationY(MathHelper.Pi * slider.Value / 100)
        basicEffect.World *= rotation

        drawingSurface.Invalidate()
    End Sub

End Class
