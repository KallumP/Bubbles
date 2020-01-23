Public Class Bodies
    Public location As Point
    Public radius As Decimal
    Dim mass As Decimal
    Dim force As Point
    Dim accelaration As Point
    Dim velocity As Point
    Dim momentum As Point
    Dim color As Pen = Pens.Black





    Public Sub CollisionForce(Xforce, Yforce)

        force.X = Xforce
        force.Y = Yforce
        'sets the force applied on the body by the collision

        accelaration.X = force.X / mass
        accelaration.Y = force.Y / mass
        'the force gives it an accelaration

        velocity.X += accelaration.X
        velocity.Y += accelaration.Y
        'accelaration is added onto the velocity

    End Sub

    Public Sub changeLocation()
        location.X += velocity.X
        location.Y += velocity.Y
    End Sub

    Public Sub changeColorRed()
        color = Pens.Red
        'changes the color of the pen to red

    End Sub
    'changes the color of the pen to red

    Public Sub New(positionX, positionY, massInput, radiusInput)
        location.X = positionX
        location.Y = positionY
        mass = massInput
        radius = radiusInput
        'all bodies will have the same density, so the radius will be a tenth of the mass
    End Sub
    'creates new objects in the list

    Public Sub drawBodies(g As Graphics)
        Dim meme = New System.Drawing.Font("Verdana", 20)
        g.DrawEllipse(color, location.X - radius, location.Y - radius, radius * 2, radius * 2)
        g.DrawString(accelaration.X.ToString, meme, Brushes.Black, location.X - 40, location.Y)
        g.DrawString(accelaration.Y.ToString, meme, Brushes.Black, location.X - 40, location.Y - 30)
        g.DrawString(velocity.X.ToString, meme, Brushes.Black, location.X - 10, location.Y)
        g.DrawString(velocity.Y.ToString, meme, Brushes.Black, location.X - 10, location.Y - 30)
    End Sub
    'draws stuff

End Class
