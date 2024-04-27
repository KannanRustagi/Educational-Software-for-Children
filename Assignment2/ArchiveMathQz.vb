
Imports System.Drawing.Drawing2D

Public Class ArchiveMathQz
    Dim font1 As New Font("Arial", 42)
    Dim font2 As New Font("Arial", 32)
    Dim correctAnswersCount As Integer = 0
    Dim panelContainer As New Panel()
    Dim questions As New List(Of Tuple(Of Integer, Integer, String, Integer))
    Dim correctAnswerBoxes As New List(Of RichTextBox)
    Private Sub Form2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        panelContainer.AutoScroll = True
        panelContainer.Dock = DockStyle.Fill ' Fill the entire form
        panelContainer.BackColor = Color.LightBlue ' Set background color to light blue

        ' Populate questions list
        questions.Add(Tuple.Create(40, 8, "/", 5))
        questions.Add(Tuple.Create(2, 4, "+", 6))
        questions.Add(Tuple.Create(5, 5, "-", 0))

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
        Dim form1 As New ArchivePzlQzHome()
        form1.Show()

        ' Close or hide the current form (Form2)
        Me.Hide() ' Close Form2
        ' OR
        ' Me.Hide() ' Hide Form2
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub
End Class
