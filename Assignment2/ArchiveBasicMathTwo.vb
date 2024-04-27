Public Class ArchiveBasicMathTwo
    Private buttonClicked As String

    Public Sub New(ByVal buttonClicked As String)
        InitializeComponent()
        Me.buttonClicked = buttonClicked
    End Sub

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Label4.Text = " " & buttonClicked
    End Sub

    Private Sub btnBackToForm1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub btnCalaculate(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim num1 As Integer
        Dim num2 As Integer
        Dim result As Integer

        ' Convert the text from TextBoxes to integers
        If Integer.TryParse(TextBox1.Text, num1) AndAlso Integer.TryParse(TextBox2.Text, num2) Then
            ' Check if the numbers are negative
            If num1 < 0 OrElse num2 < 0 Then
                Label3.Text = "No negatives!!"
            Else
                ' Perform the calculation if numbers are positive
                result = num1 + num2
                ' Display the original result
                DisplayOriginalResult(result)
            End If
        Else
            ' Handle invalid input
            Label3.Text = "Invalid input!"
        End If
    End Sub

    Private Sub btnDisplaySticks(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Dim num1 As Integer
        Dim num2 As Integer
        Dim result As Integer

        ' Convert the text from TextBoxes to integers
        If Integer.TryParse(TextBox1.Text, num1) AndAlso Integer.TryParse(TextBox2.Text, num2) Then
            ' Check if the numbers are negative
            If num1 < 0 OrElse num2 < 0 Then
                Label3.Text = "No negatives!!"
            Else
                ' Perform the calculation if numbers are positive
                result = num1 + num2
                ' Displa using sticks
                Displaynum1UsingSticks(num1)
                Displaynum2UsingSticks(num2)
                DisplayResultUsingSticks(result)
                Label8.Text = "+"
                Label9.Text = "Result ="
            End If
        Else
            ' Handle invalid input
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

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
