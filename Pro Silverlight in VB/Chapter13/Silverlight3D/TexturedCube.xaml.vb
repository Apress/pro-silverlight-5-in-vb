Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework
Imports System.Windows.Graphics
Imports System.IO
Imports System.Windows.Media.Imaging

Partial Public Class TexturedCube
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
        Dim vertices(35) As VertexPositionTexture
        ' Front face
        vertices(0) = New VertexPositionTexture(topRightFront, textureTopRight)
        vertices(1) = New VertexPositionTexture(bottomLeftFront, textureBottomLeft)
        vertices(2) = New VertexPositionTexture(topLeftFront, textureTopLeft)
        vertices(3) = New VertexPositionTexture(topRightFront, textureTopRight)
        vertices(4) = New VertexPositionTexture(bottomRightFront, textureBottomRight)
        vertices(5) = New VertexPositionTexture(bottomLeftFront, textureBottomLeft)
        ' Back face
        vertices(6) = New VertexPositionTexture(bottomLeftBack, textureBottomRight)
        vertices(7) = New VertexPositionTexture(topRightBack, textureTopLeft)
        vertices(8) = New VertexPositionTexture(topLeftBack, textureTopRight)
        vertices(9) = New VertexPositionTexture(bottomRightBack, textureBottomLeft)
        vertices(10) = New VertexPositionTexture(topRightBack, textureTopLeft)
        vertices(11) = New VertexPositionTexture(bottomLeftBack, textureBottomRight)
        ' Top face
        vertices(12) = New VertexPositionTexture(topLeftBack, textureTopLeft)
        vertices(13) = New VertexPositionTexture(topRightBack, textureTopRight)
        vertices(14) = New VertexPositionTexture(topLeftFront, textureBottomLeft)
        vertices(15) = New VertexPositionTexture(topRightBack, textureTopRight)
        vertices(16) = New VertexPositionTexture(topRightFront, textureBottomRight)
        vertices(17) = New VertexPositionTexture(topLeftFront, textureBottomLeft)
        ' Bottom face
        vertices(18) = New VertexPositionTexture(bottomRightBack, textureTopLeft)
        vertices(19) = New VertexPositionTexture(bottomLeftBack, textureTopRight)
        vertices(20) = New VertexPositionTexture(bottomLeftFront, textureBottomRight)
        vertices(21) = New VertexPositionTexture(bottomRightFront, textureBottomLeft)
        vertices(22) = New VertexPositionTexture(bottomRightBack, textureTopLeft)
        vertices(23) = New VertexPositionTexture(bottomLeftFront, textureBottomRight)
        ' Left face
        vertices(24) = New VertexPositionTexture(bottomLeftFront, textureBottomRight)
        vertices(25) = New VertexPositionTexture(bottomLeftBack, textureBottomLeft)
        vertices(26) = New VertexPositionTexture(topLeftFront, textureTopRight)
        vertices(27) = New VertexPositionTexture(topLeftFront, textureTopRight)
        vertices(28) = New VertexPositionTexture(bottomLeftBack, textureBottomLeft)
        vertices(29) = New VertexPositionTexture(topLeftBack, textureTopLeft)
        ' Right face
        vertices(30) = New VertexPositionTexture(bottomRightBack, textureBottomRight)
        vertices(31) = New VertexPositionTexture(bottomRightFront, textureBottomLeft)
        vertices(32) = New VertexPositionTexture(topRightFront, textureTopLeft)
        vertices(33) = New VertexPositionTexture(bottomRightBack, textureBottomRight)
        vertices(34) = New VertexPositionTexture(topRightFront, textureTopLeft)
        vertices(35) = New VertexPositionTexture(topRightBack, textureTopRight)

        ' Set up the vertex buffer.
        Dim device As GraphicsDevice = GraphicsDeviceManager.Current.GraphicsDevice
        vertexBuffer = New VertexBuffer(device, GetType(VertexPositionTexture), vertices.Length, BufferUsage.WriteOnly)
        vertexBuffer.SetData(0, vertices, 0, vertices.Length, 0)

        ' Configure the camera.
        Dim view As Matrix = Matrix.CreateLookAt(New Vector3(1, 1, 3), Vector3.Zero, Vector3.Up)
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
        'effect.VertexColorEnabled = true;            
        basicEffect.TextureEnabled = True
        basicEffect.Texture = texture
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

End Class
