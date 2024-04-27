Public Class BasicMathMain
    Private buttonClicked As String

    Public Sub New(ByVal buttonClicked As String)
        InitializeComponent()
        Me.buttonClicked = buttonClicked
    End Sub

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.AutoScroll() = True
        Label4.Text = " " & buttonClicked
    End Sub

    Private Sub btnBackToForm1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub btnCalaculate(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim num1 As Integer
        Dim num2 As Integer
        Dim result As Integer

        If Integer.TryParse(TextBox1.Text, num1) AndAlso Integer.TryParse(TextBox2.Text, num2) Then
            If num1 < 0 OrElse num2 < 0 Then
                Label3.Text = "No negatives!!"
            Else
                If buttonClicked = "Add" Then
                    result = num1 + num2
                ElseIf buttonClicked = "Subtract" Then
                    If num1 > num2 Then
                        result = num1 - num2
                    ElseIf num1 < num2 Then
                        Label3.Text = "Number2 cannot be subtracted from Number1!!"
                        Exit Sub
                    End If
                ElseIf buttonClicked = "Multiply" Then
                    result = num1 * num2
                ElseIf buttonClicked = "Divided" Then
                    If num2 <> 0 Then
                        result = num1 \ num2
                    Else
                        Label3.Text = "Cannot divide by zero!"
                        Exit Sub
                    End If
                End If

                DisplayOriginalResult(result)
            End If
        Else
            Label3.Text = "Invalid input!"
        End If


    End Sub

    Private Sub btnDisplaySticks(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Dim num1 As Integer
        Dim num2 As Integer
        Dim result As Integer

        If Integer.TryParse(TextBox1.Text, num1) AndAlso Integer.TryParse(TextBox2.Text, num2) Then
            If num1 < 0 OrElse num2 < 0 Then
                Label3.Text = "No negatives!!"
            Else
                If buttonClicked = "Add" Then
                    result = num1 + num2
                    Label8.Text = "+"
                ElseIf buttonClicked = "Subtract" Then
                    If num1 > num2 Then
                        result = num1 - num2
                        Label8.Text = "-"
                    ElseIf num1 < num2 Then
                        Label3.Text = "Number2 cannot be subtracted from Number1!!"
                        Exit Sub
                    End If
                ElseIf buttonClicked = "Multiply" Then
                    result = num1 * num2
                    If result <> 0 Then
                        Label8.Text = "X"
                    Else
                        Label8.Text = ""
                    End If
                ElseIf buttonClicked = "Divided" Then
                    If num2 <> 0 Then
                        result = num1 \ num2

                    Else
                        Label3.Text = "Cannot divide by zero!"
                        Exit Sub
                    End If
                End If
                Label9.Text = "Result :"


                Displaynum1UsingSticks(num1)
                Displaynum2UsingSticks(num2)
                If buttonClicked = "Divided" Then
                    DisplayDivisionUsingSticks(num1, num2, result)

                ElseIf buttonClicked = "Multiply" Then
                    DisplayMultiplicationUsingSticks(num1, num2, result)
                Else
                    DisplayResultUsingSticks(result)
                    Exit Sub
                End If



            End If
        Else
            Label3.Text = "Invalid input!"
        End If
    End Sub



    Private Sub DisplayOriginalResult(ByVal result As Integer)
        Label3.Text = "Result = " & result
    End Sub

    Private Sub Displaynum1UsingSticks(ByVal num1 As Integer)

        ' Represent the result using sticks
        Dim stickResult As String = ""
        For i As Integer = 1 To num1
            stickResult &= "| "
        Next
        Label5.Text = stickResult
    End Sub

    Private Sub Displaynum2UsingSticks(ByVal num2 As Integer)
        ' Represent the result using sticks
        Dim stickResult As String = ""
        For i As Integer = 1 To num2
            stickResult &= "| "
        Next
        Label6.Text = stickResult
    End Sub

    Private Sub DisplayResultUsingSticks(ByVal result As Integer)

        ' Represent the result using sticks
        Dim stickResult As String = ""
        For i As Integer = 1 To result
            stickResult &= "| "
        Next
        Label7.Text = stickResult
    End Sub

    Private Sub DisplayDivisionUsingSticks(ByVal num1 As Integer, ByVal num2 As Integer, ByVal result As Integer)
        If buttonClicked = "Divided" Then
            Label6.Text = ""
            ' Calculate the quotient and remainder
            Dim quotient As Integer = num1 \ num2 ' Integer division for quotient
            Dim remainder As Integer = num1 Mod num2 ' Remainder after division

            ' Initialize the quotientSticks string
            Dim quotientSticks As String = ""

            ' Build the quotientSticks string representing the quotient as groups of num2 sticks with spaces in between
            For i As Integer = 1 To quotient
                For j As Integer = 1 To num2
                    quotientSticks &= "| "
                Next
                quotientSticks &= "  " ' Add space between groups
            Next

            ' Display the quotient sticks
            Label5.Text = quotientSticks.Trim()

            ' Display the remainder
            Dim remainderSticks As String = ""
            For i As Integer = 1 To remainder
                remainderSticks &= "| "
            Next
            If remainder = 0 Then
                remainderSticks = "0"
            End If
            ' Display the remainder sticks along with the quotient information
            Label7.Text = "Quotient = " & quotient & ", Remainder = " & remainder & vbCrLf & quotient & " Groups of " & num2 & "sticks ,Remaining Sticks: " & remainderSticks
        Else
            ' Represent the result using sticks for other operations
            Dim stickResult As String = ""
            For i As Integer = 1 To result
                stickResult &= "| "
            Next
            Label7.Text = stickResult
        End If
    End Sub

    Private Sub DisplayMultiplicationUsingSticks(ByVal num1 As Integer, ByVal num2 As Integer, ByVal result As Integer)
        If buttonClicked = "Multiply" Then
            Dim multiplicationSticks As String = ""
            If num1 * num2 <> 0 Then
                For i As Integer = 1 To num2
                    For j As Integer = 1 To num1
                        multiplicationSticks &= "| "
                    Next
                    If i < num2 Then ' Check if it's not the last iteration of the outer loop
                        multiplicationSticks &= " + " ' Add plus sign after each row except the last one
                    End If
                Next
                Label7.Text = multiplicationSticks.Trim()
            Else
                Label5.Text = "Any number multiplied with 0 gives 0!!"
                Label7.Text = Nothing
                Label9.Text = Nothing
            End If

        End If
    End Sub



    Private Sub btnclear(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        Label3.Text = Nothing
        Label5.Text = Nothing
        Label6.Text = Nothing
        Label7.Text = Nothing
        Label8.Text = Nothing
        Label9.Text = Nothing
    End Sub
End Class
