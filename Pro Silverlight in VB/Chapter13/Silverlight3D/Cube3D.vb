Imports Microsoft.Xna.Framework.Graphics
Imports System.Windows.Graphics
Imports Microsoft.Xna.Framework
Imports System.IO
Imports System.Windows.Media.Imaging

Public Class Cube3D
    Private vertexBuffer As VertexBuffer
    Private effect As BasicEffect

    Public Property World() As Matrix
        Get
            Return effect.World
        End Get
        Set(ByVal value As Matrix)
            effect.World = value
        End Set
    End Property
    Public Property View() As Matrix
        Get
            Return effect.View
        End Get
        Set(ByVal value As Matrix)
            effect.View = value
        End Set
    End Property
    Public Property Projection() As Matrix
        Get
            Return effect.Projection
        End Get
        Set(ByVal value As Matrix)
            effect.Projection = value
        End Set
    End Property

    Public Sub New(ByVal device As GraphicsDevice, ByVal bottomLeftBack As Vector3, ByVal width As Single, ByVal textureUri As String, ByVal aspectRatio As Single)
        Me.New(device, bottomLeftBack, width, textureUri, aspectRatio, Matrix.CreateLookAt(New Vector3(0, 0, 5), Vector3.Zero, Vector3.Up))
    End Sub

    Public Sub New(ByVal device As GraphicsDevice, ByVal bottomLeftBack As Vector3, ByVal width As Single, ByVal textureUri As String, ByVal aspectRatio As Single, ByVal view As Matrix)
        Dim textureTopLeft As New Vector2(0, 0)
        Dim textureTopRight As New Vector2(1, 0)
        Dim textureBottomLeft As New Vector2(0, 1)
        Dim textureBottomRight As New Vector2(1, 1)

        Dim topLeftFront As New Vector3(bottomLeftBack.X, bottomLeftBack.Y + width, bottomLeftBack.Z + width)
        Dim bottomLeftFront As New Vector3(bottomLeftBack.X, bottomLeftBack.Y, bottomLeftBack.Z + width)
        Dim topRightFront As New Vector3(bottomLeftBack.X + width, bottomLeftBack.Y + width, bottomLeftBack.Z + width)
        Dim bottomRightFront As New Vector3(bottomLeftBack.X + width, bottomLeftBack.Y, bottomLeftBack.Z + width)
        Dim topLeftBack As New Vector3(bottomLeftBack.X, bottomLeftBack.Y + width, bottomLeftBack.Z)
        Dim topRightBack As New Vector3(bottomLeftBack.X + width, bottomLeftBack.Y + width, bottomLeftBack.Z)
        'Dim bottomLeftBack As New Vector3(-1, -1, -1)
        Dim bottomRightBack As New Vector3(bottomLeftBack.X + width, bottomLeftBack.Y, bottomLeftBack.Z)
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
        vertexBuffer = New VertexBuffer(device, GetType(VertexPositionTexture), vertices.Length, BufferUsage.WriteOnly)
        vertexBuffer.SetData(0, vertices, 0, vertices.Length, 0)

        ' Configure the camera.
        Dim projection As Matrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 1, 100)

        ' Set up the effect.
        effect = New BasicEffect(device)
        effect.World = Matrix.Identity
        effect.View = view
        effect.Projection = view * projection

        ' Load the texture from a resoure, and place it in a BitmapImage            
        Dim s As Stream = Application.GetResourceStream(New Uri(textureUri, UriKind.Relative)).Stream
        Dim bmp As New BitmapImage()
        bmp.SetSource(s)

        ' Copy the BitmapImage data into a Texture2D object.
        Dim texture As Texture2D
        texture = New Texture2D(device, bmp.PixelWidth, bmp.PixelHeight)
        bmp.CopyTo(texture)

        ' Configure the BasicEffect to use a texture instead of vertex shading.
        'basicEffect.VertexColorEnabled = True            
        effect.TextureEnabled = True
        effect.Texture = texture
    End Sub

    Public Sub Draw(ByVal device As GraphicsDevice)
        device.SetVertexBuffer(vertexBuffer)

        For Each pass As EffectPass In effect.CurrentTechnique.Passes
            pass.Apply()
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, vertexBuffer.VertexCount / 3)
        Next
    End Sub
End Class
