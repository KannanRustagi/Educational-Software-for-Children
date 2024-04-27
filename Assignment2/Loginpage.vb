Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient

Public Class Loginpage
    Dim passwordChecker As PasswordChecker
    Dim connectionString As String = "Data Source=SIDDHANT\SQLEXPRESS;Initial Catalog=Testingpt2;Integrated Security=True;Pooling=False"
    Dim connection As SqlConnection = New SqlConnection(connectionString)
    Private passwordChar As Char = "*"
    Private PasswordEntered As String = ""

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.LightBlue
        Button1.BackColor = Color.Yellow
        Button1.Font = New Font("Comic Sans MS", 14, FontStyle.Bold)
        Button1.ForeColor = Color.DarkBlue

        Label1.Text = "Welcome to Kids Educational Platform"
        Label1.Font = New Font("Comic Sans MS", 14, FontStyle.Bold)
        Label1.ForeColor = Color.DarkBlue

    End Sub

    Private Sub LoginButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        ' Validate username and password
        Dim username As String = RichTextBox2.Text
        Dim password As String = PasswordEntered
        If IsValidUsername(username) Then
            ' Check if the username exists in the file
            If CheckUsernameExists(username) Then
                ' Username exists, check password
                passwordChecker = New PasswordChecker(password)
                Dim result As Tuple(Of String, List(Of String)) = passwordChecker.CheckPasswordStrength()
                Dim message As String = "Password Strength: " & result.Item1 & vbCrLf
                If result.Item2.Count = 0 Then
                    MessageBox.Show("Login successful!" & message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim homepage As New Homepage(username)
                    homepage.Show()
                    Me.Hide()

                    AddHandler homepage.FormClosed, Sub(senderObj As System.Object, eArgs As EventArgs)
                                                        Me.Show()
                                                    End Sub
                Else
                    message &= "Conditions not satisfied:" & vbCrLf
                    For Each condition As String In result.Item2
                        message &= "- " & condition & vbCrLf
                    Next
                    MessageBox.Show("Invalid password. Please try again." & vbCrLf & message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Username does not exist. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Invalid username or password format. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function IsValidUsername(ByVal username As String) As Boolean
        ' Check if username contains only alphabets, numbers, '_', or '.'
        Return System.Text.RegularExpressions.Regex.IsMatch(username, "^[a-zA-Z0-9_.]+$")
    End Function

    Private Function IsValidPassword(ByVal password As String) As Boolean
        ' Check if password is not empty
        Return Not String.IsNullOrWhiteSpace(password)
    End Function

    Private Function CheckUsernameExists(ByVal username As String) As Boolean
        ' Check if the username exists in the file
        Dim query As String = String.Format("SELECT * FROM Users WHERE username='{0}'", username)

        Dim command As SqlCommand = New SqlCommand(query, connection)

        Try
            connection.Open()

            Using reader As SqlDataReader = command.ExecuteReader
                If reader.HasRows Then
                    connection.Close()
                    Return True
                Else
                    Return False
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error Connecting to the server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

        connection.Close()

        Return False
    End Function

    Private Function CheckPassword(ByVal username As String, ByVal password As String) As Boolean
        Dim query As String = String.Format("SELECT * FROM Users WHERE username='{0}'", username)
        Dim command As SqlCommand = New SqlCommand(query, connection)
        Dim savedPassword As String = ""

        Try
            connection.Open()

            Using reader As SqlDataReader = command.ExecuteReader
                savedPassword = reader.GetString(2)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error Connecting to the server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

        connection.Close()

        ' Validate the password against the username in the DB
        Return password = savedPassword
    End Function

    Private Sub RichTextBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles RichTextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Back) Then
            ' Handle backspace key
            If PasswordEntered.Length > 0 Then
                ' Remove the last character from the passwordEntered variable
                PasswordEntered = PasswordEntered.Substring(0, PasswordEntered.Length - 1)
            End If
            ' Clear the selected text (to visually remove the password character)
            RichTextBox1.SelectedText = ""
        Else
            ' Append the typed character to the passwordEntered variable
            PasswordEntered &= e.KeyChar

            ' Replace the typed character with the password character
            RichTextBox1.SelectedText = passwordChar.ToString()

            ' Move the cursor to the end of the RichTextBox
            RichTextBox1.SelectionStart = RichTextBox1.Text.Length

        End If

        ' Cancel the key press event to prevent the typed character from being added to the RichTextBox
        e.Handled = True
    End Sub
End Class

Class PasswordChecker
    Private password As String

    ' Constructor to initialize the password
    Public Sub New(ByVal password As String)
        Me.password = password
    End Sub

    ' Check if password has minimum length
    Public Function HasMinimumLength(ByVal minLength As Integer) As Boolean
        Return password.Length >= minLength
    End Function

    ' Check if password has at least one lowercase character
    Public Function HasLowercase() As Boolean
        Return password.Any(Function(c) Char.IsLower(c))
    End Function

    ' Check if password has at least one uppercase character
    Public Function HasUppercase() As Boolean
        Return password.Any(Function(c) Char.IsUpper(c))
    End Function

    ' Check if password has at least one digit
    Public Function HasDigit() As Boolean
        Return password.Any(Function(c) Char.IsDigit(c))
    End Function

    ' Check if password has at least one special character
    Public Function HasSpecialCharacter() As Boolean
        Dim regex As New Regex("[^a-zA-Z0-9]") ' Define a regular expression pattern for non-alphanumeric characters
        Return regex.IsMatch(password)
    End Function

    ' Check if password has no spaces
    Public Function HasNoSpaces() As Boolean
        Return password.All(Function(c) c <> " ")
    End Function

    ' Check if password is strong
    Public Function IsStrongPassword() As Boolean
        Return (
            HasMinimumLength(8) AndAlso
            HasLowercase() AndAlso
            HasUppercase() AndAlso
            HasDigit() AndAlso
            HasSpecialCharacter() AndAlso
            HasNoSpaces()
        )
    End Function

    ' Check if password is medium
    Public Function IsMediumPassword() As Boolean
        Dim Count As Integer = 0
        If HasDigit() Then
            Count += 1
        End If
        If HasLowercase() Then
            Count += 1
        End If
        If HasUppercase() Then
            Count += 1
        End If
        If HasSpecialCharacter() Then
            Count += 1
        End If
        Return (
            HasMinimumLength(8) AndAlso
            Count >= 2 AndAlso
            HasNoSpaces()
        )
    End Function

    ' Check if password is weak
    Public Function IsWeakPassword() As Boolean
        Return (
            password.Length < 8 OrElse
            password.Any(Function(c) Char.IsLetterOrDigit(c)) OrElse
            Not HasNoSpaces()
        )
    End Function

    ' Determine password strength category
    Public Function CheckPasswordStrength() As Tuple(Of String, List(Of String))
        Dim conditionsMet As New List(Of String)
        Dim conditionsNotMet As New List(Of String)


        If IsStrongPassword() Then
            conditionsMet.Add("Strong Password")
        ElseIf IsMediumPassword() Then
            conditionsMet.Add("Medium Password")
        ElseIf IsWeakPassword() Then
            conditionsMet.Add("Weak Password")
        End If

        'Checking which conditions have not been satisfied and adding them to the conditionsNotMet list
        If Not HasMinimumLength(8) Then conditionsNotMet.Add("Minimum length is 8 characters.")
        If Not HasLowercase() Then conditionsNotMet.Add("At least one lowercase character is required.")
        If Not HasUppercase() Then conditionsNotMet.Add("At least one uppercase character is required.")
        If Not HasDigit() Then conditionsNotMet.Add("At least one digit is required.")
        If Not HasSpecialCharacter() Then conditionsNotMet.Add("At least one special character is required.")
        If Not HasNoSpaces() Then conditionsNotMet.Add("Spaces are not allowed.")


        If conditionsMet.Contains("Strong Password") Then
            Return Tuple.Create("Strong Password", conditionsNotMet)
        ElseIf conditionsMet.Contains("Medium Password") Then
            Return Tuple.Create("Medium Password", conditionsNotMet)
        Else
            Return Tuple.Create("Weak Password", conditionsNotMet)
        End If
    End Function


End Class