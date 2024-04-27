Imports System.Windows.Forms

Public Class UserManualForm
    Private Sub UserManualForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Display the user manual content when the form loads
        DisplayUserManual()
    End Sub

    Private Sub DisplayUserManual()
        ' Display the user manual content in the RichTextBox control
        RichTextBox1.Text = "User Manual for Abacus Software" & vbCrLf &
            vbCrLf &
            "The abacus is an ancient calculation tool used for performing arithmetic operations. It consists of a frame with several rods or wires, each containing beads that can be moved up and down." & vbCrLf &
            vbCrLf &
            "In this software, each rod represents a place value in a number (such as units, tens, hundreds, etc.), and the beads represent the digits of the number. The beads are divided into groups of 4 and 1 bead, with weights 1 and 5 respectively." & vbCrLf &
            vbCrLf &
            "Using the software, you can perform the following operations:" & vbCrLf &
            vbCrLf &
            "1. Enter Input: Enter an integer in the textbox and click the 'Enter Input' button to fill the abacus with the given number." & vbCrLf &
            vbCrLf &
            "2. Clear Input: Click the 'Clear Input' button to clear the abacus, representing 0." & vbCrLf &
            vbCrLf &
            "3. Move Beads: Click on the beads to move them up and down and set their values.There are 2 section of beads, separated by a horizontal line.The beads in the lower section represent value 1, and The bead in the upper section represents the value 5." & vbCrLf &
            vbCrLf &
            "To get started, enter a number and click the 'Enter Input' button to see it represented on the abacus. You can then use the mouse to move the beads and perform arithmetic operations as needed." & vbCrLf &
            vbCrLf &
            "Enjoy using the abacus software!"
    End Sub
End Class
