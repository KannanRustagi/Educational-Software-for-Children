Imports System.IO
Imports System.Data.SqlClient

Public Class Quizhome
    Private username As String
    Dim connectionString As String = "Data Source=SIDDHANT\SQLEXPRESS;Initial Catalog=Testingpt2;Integrated Security=True;Pooling=False"
    Dim connection As SqlConnection = New SqlConnection(connectionString)

    Public Sub New(ByVal username As String)
        InitializeComponent()
        Me.username = username
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim form2 As New Mathquiz(username, "+")
        form2.Show()
        Me.Hide() ' Optionally hide the current form

        AddHandler form2.FormClosed, Sub(senderObj As Object, eArgs As EventArgs)
                                         Me.Show()
                                     End Sub
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim form2 As New Mathquiz(username, "-")
        form2.Show()
        Me.Hide() ' Optionally hide the current form

        AddHandler form2.FormClosed, Sub(senderObj As Object, eArgs As EventArgs)
                                         Me.Show()
                                     End Sub
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim form2 As New Mathquiz(username, "*")
        form2.Show()
        Me.Hide() ' Optionally hide the current form

        AddHandler form2.FormClosed, Sub(senderObj As Object, eArgs As EventArgs)
                                         Me.Show()
                                     End Sub
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim form2 As New Mathquiz(username, "/")
        form2.Show()
        Me.Hide() ' Optionally hide the current form

        AddHandler form2.FormClosed, Sub(senderObj As Object, eArgs As EventArgs)
                                         Me.Show()
                                     End Sub
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim form2 As New Mathquiz(username, "mixed")
        form2.Show()
        Me.Hide() ' Optionally hide the current form

        AddHandler form2.FormClosed, Sub(senderObj As Object, eArgs As EventArgs)
                                         Me.Show()
                                     End Sub
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim form3 As New Shapequiz(username)
        form3.Show()
        Me.Hide() ' Optionally hide the current form

        AddHandler form3.FormClosed, Sub(senderObj As Object, eArgs As EventArgs)
                                         Me.Show()
                                     End Sub
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Set background color and font for the form
        Me.BackColor = Color.LightBlue
        Me.Font = New Font("Comic Sans MS", 12, FontStyle.Bold)

        ' Set form title
        Me.Text = "Quiz Page"
        Dim labelTitle As New Label()
        labelTitle.Text = "Welcome to the Quiz Section!" & vbCrLf & "Choose which quiz you wanna play"
        labelTitle.AutoSize = True
        labelTitle.Location = New Point(50, 50)
        labelTitle.Font = New Font("Comic Sans MS", 14, FontStyle.Bold)
        labelTitle.ForeColor = Color.DarkBlue
        ' Add a button for Shapes Quiz
        Button1.Text = "Shapes Quiz"
        Button1.BackColor = Color.Yellow
        Button1.Font = New Font("Comic Sans MS", 14, FontStyle.Bold)
        Button1.Location = New Point(100, 100)
        Button1.Size = New Size(300, 60)

        ' Add a label for Maths Quiz
        Dim labelMathsQuiz As New Label()
        labelMathsQuiz.Text = "Maths Quiz"
        labelMathsQuiz.AutoSize = True
        labelMathsQuiz.Location = New Point(80, 200)
        labelMathsQuiz.Font = New Font("Comic Sans MS", 14, FontStyle.Bold)
        labelMathsQuiz.ForeColor = Color.DarkBlue

        ' Add buttons for different Maths quizzes
        Button2.Text = "Addition Quiz"
        Button2.BackColor = Color.Yellow
        Button2.Font = New Font("Comic Sans MS", 14, FontStyle.Bold)
        Button2.Location = New Point(100, 250)
        Button2.Size = New Size(300, 60)

        Button5.Text = "Subtraction Quiz"
        Button5.BackColor = Color.Yellow
        Button5.Font = New Font("Comic Sans MS", 14, FontStyle.Bold)
        Button5.Location = New Point(100, 320)
        Button5.Size = New Size(300, 60)

        Button6.Text = "Multiplication Quiz"
        Button6.BackColor = Color.Yellow
        Button6.Font = New Font("Comic Sans MS", 14, FontStyle.Bold)
        Button6.Location = New Point(100, 390)
        Button6.Size = New Size(300, 60)

        Button7.Text = "Division Quiz"
        Button7.BackColor = Color.Yellow
        Button7.Font = New Font("Comic Sans MS", 14, FontStyle.Bold)
        Button7.Location = New Point(100, 460)
        Button7.Size = New Size(300, 60)

        Button8.Text = "Mixed Quiz"
        Button8.BackColor = Color.Yellow
        Button8.Font = New Font("Comic Sans MS", 14, FontStyle.Bold)
        Button8.Location = New Point(100, 530)
        Button8.Size = New Size(300, 60)

        ' Add controls to the form
        Me.Controls.Add(labelMathsQuiz)
    End Sub

End Class
