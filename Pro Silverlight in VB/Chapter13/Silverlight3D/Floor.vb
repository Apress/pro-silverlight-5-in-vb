Imports Microsoft.Xna.Framework.Graphics
Imports System.Windows.Graphics
Imports Microsoft.Xna.Framework

Public Class Floor3D
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
    Public Sub New(ByVal device As GraphicsDevice, ByVal aspectRatio As Single)
        Me.New(device, aspectRatio, Matrix.CreateLookAt(New Vector3(0, 0, 5), Vector3.Zero, Vector3.Up))
    End Sub

    Public Sub New(ByVal device As GraphicsDevice, ByVal aspectRatio As Single, ByVal view As Matrix)
        ' Create a large flat floor square, consisting of two triangles.

        Dim frontLeft As New Vector3(-100, -1, 100)
        Dim frontRight As New Vector3(100, -1, 100)
        Dim leftBack As New Vector3(-100, -1, -100)
        Dim rightBack As New Vector3(100, -1, -100)

        Dim grayColor As New Color(119, 136, 153)
        Dim vertices As VertexPositionColor() = New VertexPositionColor(5) {}

        vertices(0) = New VertexPositionColor(leftBack, grayColor)
        vertices(1) = New VertexPositionColor(frontRight, grayColor)
        vertices(2) = New VertexPositionColor(frontLeft, grayColor)
        vertices(3) = New VertexPositionColor(frontRight, grayColor)
        vertices(4) = New VertexPositionColor(leftBack, grayColor)
        vertices(5) = New VertexPositionColor(rightBack, grayColor)

        ' Set up the vertex buffer.            
        vertexBuffer = New VertexBuffer(device, GetType(VertexPositionColor), vertices.Length, BufferUsage.WriteOnly)
        vertexBuffer.SetData(0, vertices, 0, vertices.Length, 0)

        ' Configure the camera.            
        Dim projection As Matrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 1, 100)

        ' Set up the effect.
        effect = New BasicEffect(device)
        effect.World = Matrix.Identity
        effect.View = view
        effect.Projection = view * projection

        effect.VertexColorEnabled = True
    End Sub

    Public Sub Draw(ByVal device As GraphicsDevice)
        device.SetVertexBuffer(vertexBuffer)

        For Each pass As EffectPass In effect.CurrentTechnique.Passes
            pass.Apply()
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, vertexBuffer.VertexCount / 3)
        Next
    End Sub
End Class


