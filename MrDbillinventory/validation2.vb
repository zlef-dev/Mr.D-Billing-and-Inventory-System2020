Public Class validation2

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If account.RecordCount <> 0 Then
            account.MoveFirst()
            account.Find("PIN = '" & TextBox1.Text.Replace("'", "''") & "'")
            If Not account.EOF Then
                Form1.ListView2.Items.Clear()
                Dim a As Integer
                Form1.TotalLabel.Text = 0
                Form1.ChangeLabel.Text = "-"
                Form1.TotalLabel.Text = "0"

                TextBox1.Clear()
                Me.Hide()
            Else
                MessageBox.Show("Wrong PIN")
            End If
        End If



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        TextBox1.Clear()
        Form1.Show()
    End Sub

    
End Class
