Public Class BasicMathHome
    Private Sub btnOpenForm2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        OpenForm2("Add")
    End Sub

    Private Sub btnOpenForm2_Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        OpenForm2("Subtract")
    End Sub

    Private Sub btnOpenForm2_Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        OpenForm2("Multiply")
    End Sub

    Private Sub btnOpenForm2_Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        OpenForm2("Divided")
    End Sub

    Private Sub OpenForm2(ByVal buttonClicked As String)
        Dim form2 As New BasicMathMain(buttonClicked)
        form2.Show()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AutoScroll() = True

    End Sub
End Class