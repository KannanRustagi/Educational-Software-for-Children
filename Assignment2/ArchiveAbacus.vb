Imports Microsoft.VisualBasic.PowerPacks
Imports System.Windows.Forms ' Required for MessageBox

Public Class ArchiveAbacus

    'Iniitialising the arrays
    Dim input1() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}
    Dim input2() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}
    Dim result() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Create a new ShapeContainer
        Dim shapeContainer As New ShapeContainer()
        Me.Controls.Add(shapeContainer)

        ' Loop through the columns (i)
        For i As Integer = 0 To 7
            ' Loop through the beads in each column (j)
            For j As Integer = 0 To 4
                ' Create the ovalName using String.Format
                Dim ovalName As String = String.Format("input1{0}{1}", i, j)

                ' Find the OvalShape control by name using LINQ
                Dim ovalControls = Me.Controls.Find(ovalName, True).OfType(Of OvalShape)()

                ' Check if the control with the specified name exists and is OvalShape
                If ovalControls.Any() Then
                    ' Use the first OvalShape found (assuming there's only one)
                    Dim beadShape As OvalShape = ovalControls.First()

                    ' Add the OvalShape to the ShapeContainer
                    shapeContainer.Shapes.Add(beadShape)
                Else
                    ' Handle the case where the control is not found or not OvalShape
                    'l with the specified name {ovalName} was not found or is not an OvalShape.")
                End If
            Next

        Next
        For i As Integer = 0 To 7
            ' Loop through the beads in each column (j)
            For j As Integer = 0 To 4
                ' Create the ovalName using String.Format
                Dim ovalName As String = String.Format("input2{0}{1}", i, j)

                ' Find the OvalShape control by name using LINQ
                Dim ovalControls = Me.Controls.Find(ovalName, True).OfType(Of OvalShape)()

                ' Check if the control with the specified name exists and is OvalShape
                If ovalControls.Any() Then
                    ' Use the first OvalShape found (assuming there's only one)
                    Dim beadShape As OvalShape = ovalControls.First()

                    ' Add the OvalShape to the ShapeContainer
                    shapeContainer.Shapes.Add(beadShape)
                Else
                    ' Handle the case where the control is not found or not OvalShape
                    'l with the specified name {ovalName} was not found or is not an OvalShape.")
                End If
            Next

        Next
        For i As Integer = 0 To 7
            ' Loop through the beads in each column (j)
            For j As Integer = 0 To 4
                ' Create the ovalName using String.Format
                Dim ovalName As String = String.Format("result{0}{1}", i, j)

                ' Find the OvalShape control by name using LINQ
                Dim ovalControls = Me.Controls.Find(ovalName, True).OfType(Of OvalShape)()

                ' Check if the control with the specified name exists and is OvalShape
                If ovalControls.Any() Then
                    ' Use the first OvalShape found (assuming there's only one)
                    Dim beadShape As OvalShape = ovalControls.First()

                    ' Add the OvalShape to the ShapeContainer
                    shapeContainer.Shapes.Add(beadShape)
                Else
                    ' Handle the case where the control is not found or not OvalShape
                    'l with the specified name {ovalName} was not found or is not an OvalShape.")
                End If
            Next

        Next

    End Sub
    Private Sub MoveBeadUp(ByVal ovalName As String)
        ' Find the OvalShape control by name using LINQ

        Dim ovalControls = Me.Controls.Find(ovalName, True).OfType(Of OvalShape)()

        ' Check if the control with the specified name exists and is OvalShape
        If ovalControls.Any() Then
            ' Move the OvalShape up by 25 pixels
            ovalControls.First().Top -= 25
        Else
            ' Handle the case where the control is not found or not OvalShape
            'MessageBox.Show($"The OvalShape control with the specified name {ovalName} was not found or is not an OvalShape.")
        End If
    End Sub
    Private Sub MoveBeadDown(ByVal ovalName As String)
        ' Find the OvalShape control by name using LINQ

        Dim ovalControls = Me.Controls.Find(ovalName, True).OfType(Of OvalShape)()

        ' Check if the control with the specified name exists and is OvalShape
        If ovalControls.Any() Then
            ' Move the OvalShape up by 25 pixels
            ovalControls.First().Top += 25
        Else
            ' Handle the case where the control is not found or not OvalShape
            'MessageBox.Show($"The OvalShape control with the specified name {ovalName} was not found or is not an OvalShape.")
        End If
    End Sub
    Public Sub UpdateCol(ByVal value As Integer, ByVal name As String)
        Dim column As String = name
        Dim bead As String = column
        If value = 1 Then
            bead = column + "3"
            MoveBeadUp(bead)
        ElseIf value = 2 Then
            bead = column + "3"
            MoveBeadUp(bead)
            bead = column + "2"
            MoveBeadUp(bead)
        ElseIf value = 3 Then
            bead = column + "3"
            MoveBeadUp(bead)
            bead = column + "2"
            MoveBeadUp(bead)
            bead = column + "1"
            MoveBeadUp(bead)
        ElseIf value = 4 Then
            bead = column + "3"
            MoveBeadUp(bead)
            bead = column + "2"
            MoveBeadUp(bead)
            bead = column + "1"
            MoveBeadUp(bead)
            bead = column + "0"
            MoveBeadUp(bead)
        ElseIf value = 5 Then
            bead = column + "4"
            MoveBeadDown(bead)
        ElseIf value = 6 Then
            bead = column + "4"
            MoveBeadDown(bead)
            bead = column + "3"
            MoveBeadUp(bead)
        ElseIf value = 7 Then
            bead = column + "4"
            MoveBeadDown(bead)
            bead = column + "3"
            MoveBeadUp(bead)
            bead = column + "2"
            MoveBeadUp(bead)
        ElseIf value = 8 Then
            bead = column + "4"
            MoveBeadDown(bead)
            bead = column + "3"
            MoveBeadUp(bead)
            bead = column + "2"
            MoveBeadUp(bead)
            bead = column + "1"
            MoveBeadUp(bead)
        ElseIf value = 9 Then
            bead = column + "4"
            MoveBeadDown(bead)
            bead = column + "3"
            MoveBeadUp(bead)
            bead = column + "2"
            MoveBeadUp(bead)
            bead = column + "1"
            MoveBeadUp(bead)
            bead = column + "0"
            MoveBeadUp(bead)
        End If

    End Sub

    Private Sub AddArrays(ByVal array1 As Integer(), ByVal array2 As Integer(), ByRef resultArray As Integer())
        ' Check if the arrays have the same length
        If array1.Length <> array2.Length OrElse resultArray.Length <> 8 Then
            Throw New ArgumentException("Arrays must have the same length, and resultArray must be of size 8.")
        End If

        ' Perform array addition with carry
        Dim carry As Integer = 0
        For i As Integer = array1.Length - 1 To 0 Step -1
            Dim sum As Integer = array1(i) + array2(i) + carry
            resultArray(i) = sum Mod 10
            carry = sum \ 10
            UpdateCol(resultArray(i), "result" + i)
            UpdateCol(carry, "result" + i - 1)

        Next


        ' Check if the result has more than 8 digits
        If carry > 0 Then
            ' Discard the carry and show a message box
            MessageBox.Show("Result has more than 8 digits. Discarding the carry.")
        End If
    End Sub
    Private Sub SubtractArrays(ByVal array1 As Integer(), ByVal array2 As Integer(), ByRef resultArray As Integer())
        ' Check if the arrays have the same length
        If array1.Length <> array2.Length OrElse resultArray.Length <> 8 Then
            Throw New ArgumentException("Arrays must have the same length, and resultArray must be of size 8.")
        End If

        ' Perform array subtraction with borrow
        Dim borrow As Integer = 0
        For i As Integer = array1.Length - 1 To 0 Step -1
            Dim diff As Integer = array1(i) - array2(i) - borrow

            ' Adjust for borrow
            If diff < 0 Then
                diff += 10
                borrow = 1
            Else
                borrow = 0
            End If

            resultArray(i) = diff

            'NEED TO UPDATE THE WHOLE RESULT ABACUS AND FOR THAT WE WILL STORE BORROWS

        Next

        ' Check if the result is negative
        If borrow > 0 Then
            ' Display a message box for negative result (borrow indicates a negative result)
            MessageBox.Show("Result is negative.")
        End If
    End Sub

    Private Sub enterbtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles enterbtn1.Click

    End Sub

    Private Sub enterbtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles enterbtn2.Click

    End Sub

    Private Sub clearbtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearbtn1.Click

    End Sub

    Private Sub clrbtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clrbtn2.Click

    End Sub

    Private Sub addnbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addnbtn.Click

    End Sub

    Private Sub subtrctnbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles subtrctnbtn.Click

    End Sub

    Private Sub resetbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resetbtn.Click

    End Sub

    Private Sub Input134_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Input134.Click

    End Sub
End Class

