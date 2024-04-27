Imports System.Data.SqlClient

Public Class Videolist

    Private topic As String
    Private username As String
    Private userId As Integer
    Private numWatched As Integer = 0

    Private watched As Boolean() = {False, False, False, False, False}

    Dim connectionString As String = "Data Source=SIDDHANT\SQLEXPRESS;Initial Catalog=Testingpt2;Integrated Security=True;Pooling=False"
    Dim connection As SqlConnection = New SqlConnection(connectionString)

    Public Sub New(ByVal username As String, ByVal topic As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.username = username
        Me.topic = topic

        Dim query = "SELECT userId FROM Users Where username='{0}'"
        query = String.Format(query, username)

        Dim command As SqlCommand = New SqlCommand(query, connection)
        Try
            connection.Open()

            Using reader As SqlDataReader = command.ExecuteReader
                While reader.Read()
                    Me.userId = reader.GetInt32(0)
                End While
            End Using

            connection.Close()
        Catch ex As Exception
            MessageBox.Show("Error Connecting to the server !")
        End Try

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Videoplayer.Visible = True
        Videoplayer.WebBrowser1.DocumentText = Me.WebBrowser1.DocumentText
        Me.Visible = False

        AddHandler Videoplayer.FormClosed, Sub(senderObj As System.Object, eArgs As EventArgs)
                                               Me.Show()
                                           End Sub

        If watched(0) Then
            Exit Sub
        End If

        watched(0) = True
        Label2.Text = "Watched"
        numWatched += 1
        Me.TextBox1.Text = String.Format("{0}", numWatched)
        Dim query = "INSERT INTO Watched (userId , videoId , Topic) VALUES ({0} , {1}, '{2}')"
        query = String.Format(query, userId, 0, topic)

        Dim command As SqlCommand = New SqlCommand(query, connection)

        Try
            connection.Open()

            Dim rowsAffected As Integer = command.ExecuteNonQuery()

            connection.Close()
        Catch ex As Exception
            MessageBox.Show("Error communicating with the server")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Videoplayer.Visible = True
        Videoplayer.WebBrowser1.DocumentText = Me.WebBrowser2.DocumentText
        Me.Visible = False

        AddHandler Videoplayer.FormClosed, Sub(senderObj As System.Object, eArgs As EventArgs)
                                               Me.Show()
                                           End Sub

        If watched(1) Then
            Exit Sub
        End If

        watched(1) = True
        Label3.Text = "Watched"
        numWatched += 1
        Me.TextBox1.Text = String.Format("{0}", numWatched)

        Dim query = "INSERT INTO Watched (userId , videoId , Topic) VALUES ({0} , {1}, '{2}')"
        query = String.Format(query, userId, 1, topic)

        Dim command As SqlCommand = New SqlCommand(query, connection)

        Try
            connection.Open()

            command.ExecuteNonQuery()

            connection.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Videoplayer.Visible = True
        Videoplayer.WebBrowser1.DocumentText = Me.WebBrowser3.DocumentText
        Me.Visible = False

        AddHandler Videoplayer.FormClosed, Sub(senderObj As System.Object, eArgs As EventArgs)
                                               Me.Show()
                                           End Sub

        If watched(2) Then
            Exit Sub
        End If

        watched(2) = True
        Label4.Text = "Watched"
        numWatched += 1
        Me.TextBox1.Text = String.Format("{0}", numWatched)
        Dim query = "INSERT INTO Watched (userId , videoId , Topic) VALUES ({0} , {1}, '{2}')"
        query = String.Format(query, userId, 2, topic)

        Dim command As SqlCommand = New SqlCommand(query, connection)

        Try
            connection.Open()

            command.ExecuteNonQuery()

            connection.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Videoplayer.Visible = True
        Videoplayer.WebBrowser1.DocumentText = Me.WebBrowser4.DocumentText
        Me.Visible = False

        AddHandler Videoplayer.FormClosed, Sub(senderObj As System.Object, eArgs As EventArgs)
                                               Me.Show()
                                           End Sub

        If watched(3) Then
            Exit Sub
        End If

        watched(3) = True
        Label5.Text = "Watched"
        numWatched += 1
        Me.TextBox1.Text = String.Format("{0}", numWatched)
        Dim query = "INSERT INTO Watched (userId , videoId , Topic) VALUES ({0} , {1}, '{2}')"
        query = String.Format(query, userId, 3, topic)

        Dim command As SqlCommand = New SqlCommand(query, connection)

        Try
            connection.Open()

            command.ExecuteNonQuery()

            connection.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Videoplayer.Visible = True
        Videoplayer.WebBrowser1.DocumentText = Me.WebBrowser5.DocumentText
        Me.Visible = False

        AddHandler Videoplayer.FormClosed, Sub(senderObj As System.Object, eArgs As EventArgs)
                                               Me.Show()
                                           End Sub

        If watched(4) Then
            Exit Sub
        End If

        watched(4) = True
        Label6.Text = "Watched"
        numWatched += 1
        Me.TextBox1.Text = String.Format("{0}", numWatched)
        Dim query = "INSERT INTO Watched (userId , videoId , Topic) VALUES ({0} , {1}, '{2}')"
        query = String.Format(query, userId, 4, topic)

        Dim command As SqlCommand = New SqlCommand(query, connection)

        Try
            connection.Open()

            command.ExecuteNonQuery()

            connection.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.WebBrowser1.Navigate("about:blank")
        Me.WebBrowser2.Navigate("about:blank")
        Me.WebBrowser3.Navigate("about:blank")
        Me.WebBrowser4.Navigate("about:blank")
        Me.WebBrowser5.Navigate("about:blank")

        Me.Close()
    End Sub

    Private Sub Videolist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query = "SELECT videoId FROM Watched WHERE Topic='{0}' AND userId={1}"
        query = String.Format(query, topic, userId)

        Dim labels As Label() = {Label2, Label3, Label4, Label5, Label6}
        Label2.Text = "Not Watched"
        Label3.Text = "Not Watched"
        Label4.Text = "Not Watched"
        Label5.Text = "Not Watched"
        Label6.Text = "Not Watched"


        Dim command As SqlCommand = New SqlCommand(query, connection)

        Try
            connection.Open()

            Using reader As SqlDataReader = command.ExecuteReader
                While reader.Read()
                    Dim index As Integer = reader.GetInt32(0)

                    labels(index).Text = "Watched"
                    watched(index) = True
                    numWatched += 1
                    Me.TextBox1.Text = String.Format("{0}", numWatched)
                End While
            End Using

            connection.Close()
        Catch ex As Exception
            MessageBox.Show("Error Connecting to the server !")
        End Try

    End Sub
End Class
