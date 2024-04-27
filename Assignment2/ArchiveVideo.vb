Imports System.Data.SqlClient

Public Class ArchiveVideo

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim topic As String = ComboBox1.SelectedItem.ToString()
        Dim html As String = "<html><head>"
        html &= "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>"
        html &= "<iframe id='video' src= 'https://www.youtube.com/embed/{0}' width='420' height='250' frameborder='0' allowfullscreen></iframe>"
        html &= "</body></html>"


        Dim connectionString As String = "Data Source=SIDDHANT\SQLEXPRESS;Initial Catalog=Testingpt2;Integrated Security=True;Pooling=False"

        ' Establishing connection
        Dim connection As New SqlConnection(connectionString)
        connection.Open()


        ' Executing SQL command
        Dim commandText As String = String.Format("SELECT * FROM ytvdo WHERE topic = '{0}'", topic)
        Dim command As New SqlCommand(commandText, connection)

        Dim urls(3) As String
        Dim i As Integer = 0

        ' Handling results
        Dim reader As SqlDataReader = command.ExecuteReader()
        While reader.Read()
            ' Accessing data
            Dim value1 As String = reader("Link").ToString()
            urls(i) = value1
            i += 1
            ' Do something with the data...
        End While

        ' Closing resources
        reader.Close()
        connection.Close()



        Dim url1 As String = urls(0)
        Me.WebBrowser1.DocumentText = String.Format(html, url1.Split("=")(1))
        Dim url2 As String = urls(1)
        Me.WebBrowser2.DocumentText = String.Format(html, url2.Split("=")(1))
        Dim url3 As String = urls(2)
        Me.WebBrowser3.DocumentText = String.Format(html, url3.Split("=")(1))
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub WebBrowser2_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser2.DocumentCompleted

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub
End Class
