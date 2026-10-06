Public Class Resibo

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
    Dim a As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        a = a + 1
        If a >= 10 Then
            Timer1.Stop()
            Try
                PrintForm1.PrinterSettings = New Printing.PrinterSettings()
                If PrintForm1.PrinterSettings.IsValid Then
                    PrintForm1.Print()
                Else
                    MessageBox.Show("The sale was saved. Configure a default printer to print receipts.", "Printer unavailable")
                End If
            Catch ex As Exception
                MessageBox.Show("The sale was saved, but the receipt could not be printed. " & ex.Message, "Printing failed")
            End Try
            Me.Hide()
            Form1.Show()

            ListView2.Height = 48
            Label3.Top = 217
            Label4.Top = 237
            Label5.Top = 262
            Label7.Top = 237
            Label14.Top = 237
            Label15.Top = 237
            Label8.Top = 237
            Label6.Top = 291
            Label13.Top = 262
            Label12.Top = 291
            Me.Height = 325
            ListView2.Items.Clear()
            Timer1.Stop()
            a = 0
        End If

    End Sub
End Class
