Imports System.Drawing.Drawing2D

Public Class ArchiveShapeQz
    Dim font1 As New Font("Arial", 42)
    Dim font2 As New Font("Arial", 32)
    Dim shapes As New List(Of Tuple(Of String, String))
    Dim panelContainer As New Panel()
    Dim correctAnswersCount As Integer = 0
    Private Sub Form3_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        Dim pen As New Pen(Color.Black, 3)
        panelContainer.AutoScroll = True
        panelContainer.Dock = DockStyle.Fill ' Fill the entire form
        panelContainer.BackColor = Color.LightBlue ' Set background color to light blue

        ' Populate shapes list
        shapes.Add(Tuple.Create("Circle", "A circle is a shape with all points the same distance from its center."))
        shapes.Add(Tuple.Create("Square", "A square is a shape with four equal sides and four right angles."))
        shapes.Add(Tuple.Create("Triangle", "A triangle is a shape with three straight sides and three angles."))

        ' Render shapes dynamically
        For i As Integer = 0 To shapes.Count - 1
            ' Create controls for each shape
            Dim labelIndex As New Label()
            Dim pictureBoxShape As New PictureBox()
            Dim labelQuestion As New Label()
            Dim textBoxAnswer As New RichTextBox()

            ' Set properties for labelIndex
            labelIndex.AutoSize = True
            labelIndex.Location = New Point(25, 125 + i * 250)
            labelIndex.Font = New Font("Comic Sans MS", 18, FontStyle.Bold) ' Use playful font
            labelIndex.Text = (i + 1).ToString()
            labelIndex.ForeColor = Color.DarkGreen

            ' Set properties for pictureBoxShape
            pictureBoxShape.Size = New Size(120, 120)
            pictureBoxShape.Location = New Point(100, 100 + i * 250)
            pictureBoxShape.BackColor = Color.White ' Set background color
            pictureBoxShape.BorderStyle = BorderStyle.FixedSingle
            pictureBoxShape.SizeMode = PictureBoxSizeMode.StretchImage

            ' Draw the shape on the PictureBox
            Dim shapeName As String = shapes(i).Item1.ToLower()
            Dim shapeBitmap As Bitmap = New Bitmap(pictureBoxShape.Width, pictureBoxShape.Height)
            Using g As Graphics = Graphics.FromImage(shapeBitmap)
                Select Case shapeName
                    Case "circle"
                        g.FillEllipse(Brushes.Red, 20, 20, 80, 80)
                        g.DrawEllipse(pen, 20, 20, 80, 80)
                    Case "square"
                        g.FillRectangle(Brushes.Lavender, 20, 20, 80, 80)
                        g.DrawRectangle(pen, 20, 20, 80, 80)
                    Case "triangle"
                        Dim points As PointF() = {New PointF(60, 20), New PointF(20, 100), New PointF(100, 100)}
                        g.FillPolygon(Brushes.Yellow, points)
                        g.DrawPolygon(pen, points)
                End Select
            End Using
            pictureBoxShape.Image = shapeBitmap

            ' Set properties for labelQuestion
            labelQuestion.AutoSize = True
            labelQuestion.Location = New Point(100, 240 + i * 250)
            labelQuestion.Font = New Font("Comic Sans MS", 18, FontStyle.Bold) ' Use playful font
            labelQuestion.Text = "What shape am I?"
            labelQuestion.ForeColor = Color.DarkGreen

            ' Set properties for textBoxAnswer
            textBoxAnswer.Width = 100
            textBoxAnswer.Height = 30
            textBoxAnswer.Location = New Point(350, 245 + i * 250)
            textBoxAnswer.Font = New Font("Comic Sans MS", 12) ' Use playful font
            textBoxAnswer.ForeColor = Color.Black
            textBoxAnswer.BorderStyle = BorderStyle.FixedSingle

            ' Add controls to panelContainer
            panelContainer.Controls.Add(labelIndex)
            panelContainer.Controls.Add(pictureBoxShape)
            panelContainer.Controls.Add(labelQuestion)
            panelContainer.Controls.Add(textBoxAnswer)

            SetRichTextBoxBackColor(textBoxAnswer, shapeName.ToLower())
        Next

        ' Add panelContainer to the form
        Me.Controls.Add(panelContainer)
        AddHandler Button2.Click, AddressOf CheckAllAnswers
    End Sub

    Private Sub CheckAllAnswers(ByVal sender As Object, ByVal e As EventArgs)
        ' Reset correct answers count before checking
        correctAnswersCount = 0

        ' Initialize question index counter
        Dim questionIndex As Integer = 0
        Dim index As Integer = 0

        ' Remove existing explanation labels
        Dim controlsToRemove As New List(Of Control)

        ' Clear answer RichTextBoxes and collect controls to remove
        For Each control As Control In panelContainer.Controls
            If TypeOf control Is Label Then
                Dim rtb As Label = DirectCast(control, Label)
                If TypeOf control Is Label AndAlso control.Tag IsNot Nothing AndAlso control.Tag.ToString() = "Explanation" Then
                    controlsToRemove.Add(rtb)
                End If
            End If
        Next

        For Each control As Control In controlsToRemove
            panelContainer.Controls.Remove(control)
        Next

        ' Loop through all RichTextBoxes and check answers
        For Each control As Control In panelContainer.Controls
            If TypeOf control Is RichTextBox Then
                Dim rtb As RichTextBox = DirectCast(control, RichTextBox)

                ' Check if this RichTextBox is for a question (every fourth RichTextBox)
                If questionIndex < shapes.Count Then
                    Dim comparisonValue As String = shapes(questionIndex).Item1.ToLower()
                    'Display correct answer explanation below the question
                    Dim labelExplanation As New Label()
                    labelExplanation.AutoSize = False
                    labelExplanation.AutoSize = True
                    labelExplanation.TextAlign = ContentAlignment.MiddleLeft ' Center-align the text
                    labelExplanation.Font = New Font("Comic Sans MS", 12) ' Set the font
                    labelExplanation.BackColor = Color.Lavender ' Set the background color
                    labelExplanation.BorderStyle = BorderStyle.FixedSingle ' Add a border
                    labelExplanation.Location = New Point(100, rtb.Top + 60) ' Adjust Y position as needed
                    labelExplanation.Text = shapes(questionIndex).Item2 ' Explanation text
                    labelExplanation.Tag = "Explanation" ' Tag to identify explanation labels
                    panelContainer.Controls.Add(labelExplanation)

                    ' Check if the answer is correct
                    If rtb.Text.ToLower() = comparisonValue Then
                        ' Increment correct answers count
                        correctAnswersCount += 1
                    End If

                    ' Increment question index counter
                    questionIndex += 1
                End If

                ' Increment control index counter
                index += 1
            End If
        Next

        ' Display message box with correct answers count
        If correctAnswersCount = shapes.Count Then
            MessageBox.Show("All questions answered correctly! Total Points: " & correctAnswersCount.ToString(),
                        "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Total Points: " & correctAnswersCount.ToString(),
                        "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub



    Private Sub SetRichTextBoxBackColor(ByVal rtb As RichTextBox, ByVal comparisonValue As String)
        ' Get the text from the provided RichTextBox
        AddHandler Button2.Click, Sub(sender, e)
                                      Dim richTextBoxText As String = rtb.Text

                                      ' Attempt conversion, handling potential errors
                                      ' Comparison with the provided integer value
                                      If richTextBoxText.ToLower() = comparisonValue Then
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

        ' Close or hide the current form (Form3)
        Me.Hide() ' Close Form3
        ' OR
        ' Me.Hide() ' Hide Form3
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        For Each control As Control In panelContainer.Controls
            If TypeOf control Is RichTextBox Then
                Dim rtb As RichTextBox = DirectCast(control, RichTextBox)
                rtb.Clear()
                rtb.BackColor = Color.White ' Reset background color
            End If
        Next

        ' Remove existing explanation labels
        Dim controlsToRemove As New List(Of Control)

        ' Clear answer RichTextBoxes and collect controls to remove
        For Each control As Control In panelContainer.Controls
            If TypeOf control Is Label Then
                Dim rtb As Label = DirectCast(control, Label)
                If TypeOf control Is Label AndAlso control.Tag IsNot Nothing AndAlso control.Tag.ToString() = "Explanation" Then
                    controlsToRemove.Add(rtb)
                End If
            End If
        Next

        For Each control As Control In controlsToRemove
            panelContainer.Controls.Remove(control)
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub
End Class
