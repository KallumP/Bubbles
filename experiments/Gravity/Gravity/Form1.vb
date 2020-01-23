Public Class Gravity
    Dim G As Integer
    Dim r As Integer
    Dim masses As New List(Of Bodies)
    Dim mass As Decimal = 500
    Dim radius As Decimal = 50
    Public forceMutiply = 10


    Private Sub WorldTime_Tick(sender As Object, e As EventArgs) Handles WorldTime.Tick
        Invalidate()
        'causes the screen to redraw

        checkDistanceAndCollision()
        'causes the "checkDistance()" procedure to run

        For i As Integer = 0 To masses.Count() - 1
            masses(i).changeLocation()
        Next

    End Sub
    'timer

    Private Sub checkDistanceAndCollision()
        Dim distance As Decimal
        Dim collided As Boolean

        For i As Integer = 0 To masses.Count() - 1
            For j As Integer = 0 To masses.Count() - 1
                If i <> j Then
                    'loops through the items in the list, per item in the list
                    'if the the second loops item isnt the same as the first loop item, then

                    distance = distanceDetect(i, j)
                    '"distance" variable is set to the return of function "distanceCheck"
                    collided = collisionDetect(distance, i, j)
                    '"collided" variable is set to the return of funtion "collisionCheck"

                    If collided = True Then
                        masses(i).changeColorRed()
                        CollisionMaths(i, j)
                        'if there is a collision, then  the colors of the masse will change to red
                        '(no need to do both here, because all the masses are checked)

                    Else
                        masses(i).CollisionForce(0, 0)

                    End If
                End If
            Next
        Next
    End Sub
    'checks the distance between all objects in the program

    Public Function collisionDetect(distance, main, buffer)
        If distance < (masses(main).radius + masses(buffer).radius) Then
            Return True
            'if the distance between the two bodies is less than the combined radius of the two bodies
            'it will return true (there is a collision)
        Else
            Return False
            'if not, then it will return false (no collision)
        End If
    End Function
    'checks if there is a collision or not

    Public Function distanceDetect(main, buffer)
        Dim difX 'difference in x
        Dim difY 'difference in y
        Dim dist 'distance

        difX = Math.Abs(masses(main).location.X - masses(buffer).location.X)
        'calculates the difference in x 

        difY = Math.Abs(masses(main).location.Y - masses(buffer).location.Y)
        'calculates the difference in y

        dist = ((difX ^ 2) + (difY ^ 2)) ^ 0.5
        'calculates the hypotenuse of the x and y to give the distance between the two masses

        Return dist
        'returns the distance between the two masses

    End Function
    'calculates the distances between two masses

    Public Sub CollisionMaths(main, buffer)
        Dim Differences As Point
        Dim MaxDistance As Decimal
        Differences.X = masses(main).location.X - masses(buffer).location.X
        Differences.Y = masses(main).location.Y - masses(buffer).location.Y
        MaxDistance = masses(main).radius + masses(buffer).radius
        'gets the distance away from each other

        Differences.X = MaxDistance + Differences.X
        Differences.Y = MaxDistance + Differences.Y

        Debug.Write(Differences.X)
        Debug.WriteLine(MaxDistance)

        masses(main).CollisionForce(Differences.X * forceMutiply, Differences.Y * forceMutiply)
        masses(buffer).CollisionForce(-Differences.X * forceMutiply, -Differences.Y * forceMutiply)
    End Sub

    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        masses.Add(New Bodies(e.X, e.Y, mass, radius))
        'adds a new object to the list "masses", in the class "bodies"

    End Sub
    'adds a body of mass where the user clicks to the program

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        For i = 0 To masses.Count - 1
            masses(i).drawBodies(e.Graphics)
            'looks at all of the objects in the list "masses" and draws out the object
        Next
    End Sub
    'draws everything in the program

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ConfirmMass.Click
        mass = massChoice_txt.Text
        'sets variable "mass" to what the user chose in the text box when clicking the confirm button
        Label1.Text = mass
    End Sub
    'allows the user to set the mass

    Private Sub ConfirmRadius_Click(sender As Object, e As EventArgs) Handles ConfirmRadius.Click
        radius = RadiusChoice_txt.Text
        'sets variable "radius" to what the user chose in the text box when clicking the confirm button
        Label2.Text = radius
    End Sub

    Private Sub ConfirmMult_Click(sender As Object, e As EventArgs) Handles ConfirmMult.Click
        forceMutiply = MultiplierChoice_txt.Text
    End Sub
End Class
