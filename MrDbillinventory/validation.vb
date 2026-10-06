Public Class validation

   
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        TextBox1.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Form1.ListView2.SelectedItems.Count = 0 OrElse Form1.ListView2.FocusedItem Is Nothing Then
            Me.Hide()
            Return
        End If
        If account.RecordCount <> 0 Then
            account.MoveFirst()
            account.Find("PIN = '" & TextBox1.Text.Replace("'", "''") & "'")
            If Not account.EOF Then
                Form1.ListView2.FocusedItem.Remove()
                Dim a As Integer
                Form1.TotalLabel.Text = 0

                While a < Form1.ListView2.Items.Count
                    Form1.TotalLabel.Text = Val(Form1.TotalLabel.Text) + Val(Form1.ListView2.Items(a).SubItems(3).Text)
                    a = a + 1
                End While
                TextBox1.Clear()
                Me.Hide()
            Else
                MessageBox.Show("Wrong PIN")
            End If
        End If
    End Sub
End Class
