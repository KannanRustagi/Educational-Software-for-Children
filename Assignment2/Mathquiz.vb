
Imports System.Drawing.Drawing2D
Imports System.Data.SqlClient

Public Class Mathquiz
    Private username As String
    Private type As String
    Private score As String
    Private userId As Integer
    Private attempts As Integer = 0
    Private maxscore As Integer = 0

    Dim connectionString As String = "Data Source=SIDDHANT\SQLEXPRESS;Initial Catalog=Testingpt2;Integrated Security=True;Pooling=False"
    Dim connection As SqlConnection = New SqlConnection(connectionString)

    Public Sub New(ByVal username As String, ByVal type As String)
        InitializeComponent()
        Me.username = username
        Me.type = type

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

        ' check if the user has given this before
        query = "SELECT * FROM Quiz WHERE userId={0} AND Topic='{1}'"
        query = String.Format(query, userId, type)

        command = New SqlCommand(query, connection)


        Try
            connection.Open()

            Using reader As SqlDataReader = command.ExecuteReader
                If reader.HasRows Then
                    While reader.Read()
                        Me.maxscore = reader.GetInt32(2)
                        Me.attempts = reader.GetInt32(3)

                        Me.Label1.Text = String.Format("Attempted : {0}", Me.attempts)
                        Me.Label2.Text = String.Format("Max Score : {0}", Me.maxscore)
                    End While
                Else
                    reader.Close()
                    Dim q = String.Format("INSERT INTO Quiz (userId, Topic, maxscore, attempts) VALUES ({0}, '{1}', 0, 0)", userId, type)
                    Dim c As SqlCommand = New SqlCommand(q, connection)
                    c.ExecuteNonQuery()
                End If

            End Using

            connection.Close()
        Catch ex As Exception
            MessageBox.Show("Error connecting to the server!")
        End Try

    End Sub

    Dim font1 As New Font("Arial", 42)
    Dim font2 As New Font("Arial", 32)
    Dim correctAnswersCount As Integer = 0
    Dim panelContainer As New Panel()
    ' num1 num2 op correct => new table with just these
    Dim questions As New List(Of Tuple(Of Integer, Integer, String, Integer))
    Dim correctAnswerBoxes As New List(Of RichTextBox)

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        score = 0
        Button1.BackColor = Color.Yellow
        Button1.Font = New Font("Comic Sans MS", 12, FontStyle.Bold)
        Button2.ForeColor = Color.DarkBlue
        Button2.BackColor = Color.Yellow
        Button2.Font = New Font("Comic Sans MS", 12, FontStyle.Bold)
        Button3.ForeColor = Color.DarkBlue
        Button3.BackColor = Color.Yellow
        Button3.Font = New Font("Comic Sans MS", 12, FontStyle.Bold)
        Button3.ForeColor = Color.DarkBlue
        panelContainer.AutoScroll = True
        panelContainer.Dock = DockStyle.Fill ' Fill the entire form
        panelContainer.BackColor = Color.LightBlue ' Set background color to light blue

        ' Populate questions list
        Dim query As String = String.Format("SELECT * FROM Questions WHERE operator='{0}'", type)

        If type = "mixed" Then
            query = "SELECT * FROM Questions"
        End If

        Dim command As SqlCommand = New SqlCommand(query, connection)
        Dim candidateQuestions As New List(Of Tuple(Of Integer, Integer, String, Integer))

        Try
            connection.Open()


            Using reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim num1 As Integer = reader.GetInt32(0)
                    Dim num2 As Integer = reader.GetInt32(1)
                    Dim op As String = reader.GetString(2)
                    Dim correct As Integer = reader.GetInt32(3)

                    candidateQuestions.Add(Tuple.Create(num1, num2, op, correct))
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error connecting to server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End Try

        Dim cand As Tuple(Of Integer, Integer, String, Integer)() = candidateQuestions.ToArray
        Shuffle(cand)

        questions.Add(cand(0))
        questions.Add(cand(1))
        questions.Add(cand(2))
        questions.Add(cand(3))

        ' Render questions dynamically
        For i As Integer = 0 To questions.Count - 1
            ' Create controls for each question
            Dim richTextBoxOperand1 As New RichTextBox()
            Dim richTextBoxOperand2 As New RichTextBox()
            Dim labelIndex As New Label()
            Dim labelOperator As New Label()
            Dim labelOperator2 As New Label()
            Dim richTextBoxAnswer As New RichTextBox()

            ' Set properties for labelIndex
            labelIndex.AutoSize = True
            labelIndex.Location = New Point(25, 125 + i * 145)
            labelIndex.Font = New Font("Comic Sans MS", 18, FontStyle.Bold) ' Use playful font
            labelIndex.Text = (i + 1).ToString()
            labelIndex.ForeColor = Color.DarkGreen '

            ' Set properties for richTextBoxOperand1
            richTextBoxOperand1.Width = 80
            richTextBoxOperand1.Height = 80
            richTextBoxOperand1.Location = New Point(75, 100 + i * 150)
            richTextBoxOperand1.BackColor = Color.Lavender
            richTextBoxOperand1.BorderStyle = BorderStyle.None
            richTextBoxOperand1.Font = New Font("Comic Sans MS", 36, FontStyle.Bold) ' Use playful font
            richTextBoxOperand1.Text = questions(i).Item1.ToString()
            richTextBoxOperand1.ReadOnly = True
            richTextBoxOperand1.Padding = New Padding(0, (richTextBoxOperand1.Height - richTextBoxOperand1.Font.Height) \ 2, 0, 0)
            SetCircularShape(richTextBoxOperand1)

            ' Set properties for labelOperator
            labelOperator.AutoSize = True
            labelOperator.Location = New Point(175, 125 + i * 145)
            labelOperator.Font = New Font("Comic Sans MS", 18, FontStyle.Bold) ' Use playful font
            labelOperator.Text = questions(i).Item3
            labelOperator.ForeColor = Color.DarkGreen ' Use green color for operator

            ' Set properties for richTextBoxOperand2
            richTextBoxOperand2.Width = 80
            richTextBoxOperand2.Height = 80
            richTextBoxOperand2.Location = New Point(225, 100 + i * 150)
            richTextBoxOperand2.BackColor = Color.Lavender
            richTextBoxOperand2.BorderStyle = BorderStyle.None
            richTextBoxOperand2.Font = richTextBoxOperand1.Font ' Use same font as richTextBoxOperand1
            richTextBoxOperand2.Text = questions(i).Item2.ToString()
            richTextBoxOperand2.ReadOnly = True
            SetCircularShape(richTextBoxOperand2)

            ' Set properties for labelOperator
            labelOperator2.AutoSize = True
            labelOperator2.Location = New Point(345, 125 + i * 145)
            labelOperator2.Font = labelOperator.Font ' Use same font as labelOperator
            labelOperator2.Text = "="
            labelOperator2.ForeColor = labelOperator.ForeColor ' Use same color as labelOperator

            ' Set properties for richTextBoxAnswer
            richTextBoxAnswer.Width = 80
            richTextBoxAnswer.Height = 80
            richTextBoxAnswer.Location = New Point(405, 100 + i * 150)
            richTextBoxAnswer.BackColor = Color.White
            richTextBoxAnswer.BorderStyle = BorderStyle.None
            richTextBoxAnswer.Font = richTextBoxOperand1.Font ' Use same font as richTextBoxOperand1
            SetCircularShape(richTextBoxAnswer)

            ' Add controls to panelContaine
            panelContainer.Controls.Add(labelIndex)
            panelContainer.Controls.Add(richTextBoxOperand1)
            panelContainer.Controls.Add(labelOperator)
            panelContainer.Controls.Add(richTextBoxOperand2)
            panelContainer.Controls.Add(labelOperator2)
            panelContainer.Controls.Add(richTextBoxAnswer)
            SetRichTextBoxBackColor(richTextBoxAnswer, questions(i).Item4)
            AddHandler richTextBoxAnswer.KeyPress, AddressOf NumericTextBox_KeyPress
            richTextBoxOperand1.SelectAll()
            richTextBoxOperand1.SelectionAlignment = HorizontalAlignment.Center ' Center align text
            richTextBoxOperand2.SelectAll()
            richTextBoxOperand2.SelectionAlignment = HorizontalAlignment.Center ' Center align text
            richTextBoxAnswer.SelectAll()
            richTextBoxAnswer.SelectionAlignment = HorizontalAlignment.Center ' Center align text

        Next

        ' Add panelContainer to the form
        Me.Controls.Add(panelContainer)
        AddHandler Button2.Click, AddressOf CheckAllAnswers
        AddHandler Button3.Click, AddressOf ClearAnswers
    End Sub

    Private Sub NumericTextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        ' Get the RichTextBox control
        Dim rtb As RichTextBox = DirectCast(sender, RichTextBox)

        ' Allow only digits and Backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
            MessageBox.Show("Only integer values are allowed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ClearAnswers(ByVal sender As Object, ByVal e As EventArgs)
        ' Clear answer RichTextBoxes
        Dim i As Integer = 0
        For Each control As Control In panelContainer.Controls
            i += 1
            If TypeOf control Is RichTextBox AndAlso control.Tag Is Nothing AndAlso (i) Mod 3 = 0 Then
                Dim rtb As RichTextBox = DirectCast(control, RichTextBox)
                rtb.Clear()
                rtb.BackColor = Color.White ' Reset background color
            End If
        Next

        Dim controlsToRemove As New List(Of Control)

        ' Clear answer RichTextBoxes and collect controls to remove
        For Each control As Control In panelContainer.Controls
            If TypeOf control Is RichTextBox Then
                Dim rtb As RichTextBox = DirectCast(control, RichTextBox)
                If rtb.Tag IsNot Nothing AndAlso rtb.Tag.ToString() = "CorrectAnswer" Then
                    ' Remove correct answer box
                    controlsToRemove.Add(rtb)
                End If
            End If
        Next

        ' Remove collected controls from the panelContainer
        For Each control As Control In controlsToRemove
            panelContainer.Controls.Remove(control)
        Next
    End Sub


    Private Sub CheckAllAnswers(ByVal sender As Object, ByVal e As EventArgs)
        ' Reset correct answers count before checking
        correctAnswersCount = 0
        Dim controlsToRemove As New List(Of Control)

        ' Clear answer RichTextBoxes and collect controls to remove
        For Each control As Control In panelContainer.Controls
            If TypeOf control Is RichTextBox Then
                Dim rtb As RichTextBox = DirectCast(control, RichTextBox)
                If rtb.Tag IsNot Nothing AndAlso rtb.Tag.ToString() = "CorrectAnswer" Then
                    ' Remove correct answer box
                    controlsToRemove.Add(rtb)
                End If
            End If
        Next

        ' Remove collected controls from the panelContainer
        For Each control As Control In controlsToRemove
            panelContainer.Controls.Remove(control)
        Next
        ' Initialize question index counter
        Dim questionIndex As Integer = 0
        Dim Index As Integer = 0
        correctAnswerBoxes.Clear()
        ' Loop through all RichTextBoxes and check answers
        For Each control As Control In panelContainer.Controls
            If TypeOf control Is RichTextBox Then
                Dim rtb As RichTextBox = DirectCast(control, RichTextBox)

                ' Check if this RichTextBox is for a question (every third RichTextBox)
                If questionIndex < questions.Count AndAlso (Index + 1) Mod 3 = 0 Then

                    Dim comparisonValue As Integer = questions(questionIndex).Item4
                    Dim rtbCorrectAnswer As New RichTextBox()
                    rtbCorrectAnswer.Width = 80
                    rtbCorrectAnswer.Height = 80
                    rtbCorrectAnswer.BackColor = Color.LightGreen ' Background color for correct answer
                    rtbCorrectAnswer.BorderStyle = BorderStyle.None
                    rtbCorrectAnswer.Font = rtb.Font ' Use the same font as answer RichTextBox
                    SetCircularShape(rtbCorrectAnswer)
                    rtbCorrectAnswer.Text = comparisonValue.ToString()
                    rtbCorrectAnswer.ReadOnly = True ' Make it read-only
                    rtbCorrectAnswer.Tag = "CorrectAnswer" ' Add a tag to identify it later
                    panelContainer.Controls.Add(rtbCorrectAnswer)
                    rtbCorrectAnswer.SelectAll()
                    rtbCorrectAnswer.Location = New Point(rtb.Right + 10, rtb.Top)
                    rtbCorrectAnswer.SelectionAlignment = HorizontalAlignment.Center ' Center align text
                    If rtb.Text = comparisonValue.ToString() Then
                        ' Increment correct answers count
                        correctAnswersCount += 1
                    End If
                    questionIndex += 1
                End If

                ' Increment question index counter
                Index += 1
            End If
        Next

        score = correctAnswersCount

        Me.attempts += 1
        If score > maxscore Then
            maxscore = score
        End If

        Dim query = String.Format("UPDATE Quiz SET maxscore={0}, attempts={1} WHERE userId={2} AND Topic='{3}'", maxscore, attempts, userId, type)

        Dim command = New SqlCommand(query, connection)

        Try
            If connection.State <> ConnectionState.Open Then
                connection.Open()
            End If

            command.ExecuteNonQuery()

            Me.Label1.Text = String.Format("Attempted : {0}", Me.attempts)
            Me.Label2.Text = String.Format("Max Score : {0}", Me.maxscore)

            connection.Close()
        Catch ex As Exception
            MessageBox.Show("Error Reaching the server!")
            Exit Sub
        End Try

        ' Display message box with correct answers count
        If correctAnswersCount = questions.Count Then
            MessageBox.Show("All questions answered correctly! Total Points: " & correctAnswersCount.ToString(),
                        "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Total Points: " & correctAnswersCount.ToString(),
                        "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub SetCircularShape(ByVal richTextBox As RichTextBox)
        Dim path As New GraphicsPath()
        path.AddEllipse(0, 0, richTextBox.Width, richTextBox.Height)
        richTextBox.Region = New Region(path)
    End Sub

    Private Sub SetRichTextBoxBackColor(ByVal rtb As RichTextBox, ByVal comparisonValue As Integer)
        ' Get the text from the provided RichTextBox
        AddHandler Button2.Click, Sub(sender, e)
                                      Dim richTextBoxText As String = rtb.Text

                                      ' Attempt conversion, handling potential errors
                                      ' Comparison with the provided integer value
                                      If richTextBoxText = comparisonValue.ToString() Then
                                          ' Values match
                                          rtb.BackColor = Color.PaleGreen
                                      ElseIf richTextBoxText = "" Then

                                          ' Values differ
                                          rtb.BackColor = Color.White
                                      Else
                                          rtb.BackColor = Color.Pink
                                      End If
                                  End Sub
    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Show the original form (Form1)
        'Dim form4 As New Form4(username)
        'form4.Show()

        ' Close or hide the current form (Form2)
        Me.Close() ' Close Form2
        ' OR
        ' Me.Hide() ' Hide Form2
    End Sub


    Sub Shuffle(Of T)(ByRef array As T())
        Dim rand As New Random()
        Dim n As Integer = array.Length
        While n > 1
            Dim k As Integer = rand.Next(n)
            n -= 1
            Dim temp As T = array(n)
            array(n) = array(k)
            array(k) = temp
        End While
    End Sub

End Class
