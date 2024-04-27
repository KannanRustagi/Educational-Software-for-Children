Public Class ArchivePzlQzHome

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim form2 As New ArchiveMathQz()
        form2.Show()
        Me.Hide() ' Optionally hide the current form

        AddHandler form2.FormClosed, Sub(senderObj As Object, eArgs As EventArgs)
                                         Me.Show()
                                     End Sub
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim form3 As New ArchiveShapeQz()
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

        ' Set button properties
        Button1.Text = "Shapes Quiz"
        Button2.Text = "Maths Quiz"
        Button1.BackColor = Color.Yellow
        Button2.BackColor = Color.Yellow
        Button1.Font = New Font("Comic Sans MS", 14, FontStyle.Bold)
        Button2.Font = New Font("Comic Sans MS", 14, FontStyle.Bold)

        ' Set form title
        Me.Text = "Kids Quiz App"

        ' Add a label to provide information
        Dim labelInfo As New Label()
        labelInfo.Text = "Welcome to the Kids Quiz App! Choose a quiz to play:"
        labelInfo.AutoSize = True
        labelInfo.Location = New Point(150, 50)
        labelInfo.Font = New Font("Comic Sans MS", 18, FontStyle.Bold)
        labelInfo.ForeColor = Color.DarkBlue

        ' Add controls to the form
        Me.Controls.Add(labelInfo)
    End Sub
End Class
