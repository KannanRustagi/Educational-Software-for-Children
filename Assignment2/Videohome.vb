Imports System.Data.SqlClient

Public Class Videohome
    Private username As String

    Public Sub New(ByVal username As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.username = username

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim topic As String = ComboBox1.SelectedItem.ToString()

        Dim connectionString As String = "Data Source=SIDDHANT\SQLEXPRESS;Initial Catalog=Testingpt2;Integrated Security=True;Pooling=False"
        Dim connection As SqlConnection = New SqlConnection(connectionString)

        Dim html As String = "<html><head>"
        html &= "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/></head><body>"
        html &= "<iframe id='video' src= 'https://www.youtube.com/embed/{0}' width='420' height='250' frameborder='0' allowfullscreen></iframe>"
        html &= "</body></html>"

        Me.Hide()
        Dim videolist = New Videolist(username, Me.ComboBox1.SelectedItem.ToString())
        videolist.Show()

        AddHandler videolist.FormClosed, Sub(senderObj As System.Object, eArgs As EventArgs)
                                             Me.Show()
                                         End Sub


        Dim urls(5) As String
        Dim ind As Integer = 0
        Dim query As String = String.Format("SELECT * FROM video WHERE Topic='{0}'", topic)

        Dim command As SqlCommand = New SqlCommand(query, connection)

        ' Open the database , and query for the video links of that topic : we gather the id and the link of the video
        connection.Open()
        Using reader As SqlDataReader = command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    Dim id As Integer = reader.GetInt32(0)
                    Dim link As String = reader.GetString(2)

                    urls(ind) = link
                    ind += 1
                End While
            End If
        End Using

        Dim i As Integer = 0

        Dim url1 As String = urls(0)
        videolist.WebBrowser1.DocumentText = String.Format(html, url1.Split("=")(1))
        Dim url2 As String = urls(1)
        videolist.WebBrowser2.DocumentText = String.Format(html, url2.Split("=")(1))
        Dim url3 As String = urls(2)
        videolist.WebBrowser3.DocumentText = String.Format(html, url3.Split("=")(1))
        Dim url4 As String = urls(3)
        videolist.WebBrowser4.DocumentText = String.Format(html, url4.Split("=")(1))
        Dim url5 As String = urls(4)
        videolist.WebBrowser5.DocumentText = String.Format(html, url5.Split("=")(1))

    End Sub

End Class