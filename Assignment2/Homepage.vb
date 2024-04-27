Public Class Homepage
    Private username As String

    Public Sub New(ByVal username As String)
        InitializeComponent()

        Me.username = username

        Me.BackColor = Color.LightBlue
    End Sub
    
    Private Sub Abacus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Abacus.Click
        Dim abacus As New Abacus()
        abacus.Show()
        Me.Hide()

        AddHandler abacus.FormClosed, Sub(senderObj As System.Object, eArgs As EventArgs)
                                          Me.Show()
                                      End Sub
    End Sub

    Private Sub Basicmath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Basicmath.Click
        Dim basicmath As New BasicMathHome()
        basicmath.Show()
        Me.Hide()

        AddHandler basicmath.FormClosed, Sub(senderObj As System.Object, eArgs As EventArgs)
                                             Me.Show()
                                         End Sub
    End Sub

    Private Sub Videos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Videos.Click
        Dim video As New Videohome(username)
        video.Show()
        Me.Hide()

        AddHandler video.FormClosed, Sub(senderObj As System.Object, eArgs As EventArgs)
                                             Me.Show()
                                         End Sub
    End Sub

    Private Sub Puzzlequiz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Puzzlequiz.Click
        Dim quizhome As New Quizhome(username)
        quizhome.Show()
        Me.Hide()

        AddHandler quizhome.FormClosed, Sub(senderObj As System.Object, eArgs As EventArgs)
                                            Me.Show()
                                        End Sub
    End Sub

    Private Sub Homepage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim welcome As String = String.Format("             Hey {0}" & vbCrLf & "What would you like to learn today !", username)

        Me.RichTextBox1.Text = welcome
        Me.RichTextBox1.Font = New Font("Comic Sans MS", 14, FontStyle.Bold)
    End Sub
End Class