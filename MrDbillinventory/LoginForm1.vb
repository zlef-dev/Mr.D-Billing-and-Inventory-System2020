Public Class Login
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Login_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        LoginButt.PerformClick()

    End Sub



    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mclass.main()
        account.DataSource = Nothing
        account.DataSource = account

        If account.RecordCount = 0 Then
            Label2.Text = "No administrator account is configured."
            LoginButt.Enabled = False
            Button3.Enabled = False
            MessageBox.Show("The database has no administrator account. Configure an account in the Accounts table before signing in.", "Account required")
        Else
            account.MoveFirst()
            Label2.Text = account("Question").Value.ToString
        End If

        Dim p As New Drawing2D.GraphicsPath
        p.StartFigure()
        p.AddArc(New Rectangle(0, 0, 40, 40), 180, 90)
        p.AddLine(40, 0, Me.Width - 40, 0)
        p.AddArc(New Rectangle(Me.Width - 40, 0, 40, 40), -90, 90)
        p.AddLine(Me.Width, 40, Me.Width, Me.Height - 40)
        p.AddArc(New Rectangle(Me.Width - 40, Me.Height - 40, 40, 40), 0, 90)
        p.AddLine(Me.Width - 40, Me.Height, 40, Me.Height)
        p.AddArc(New Rectangle(0, Me.Height - 40, 40, 40), 90, 90)
        p.CloseFigure()
        Me.Region = New Region(p)
    End Sub

    Private Sub PasswordLabel_Click(sender As Object, e As EventArgs) Handles PasswordLabel.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles LoginButt.Click
     
        If account.RecordCount <> 0 Then
            account.MoveFirst()
            If UsernameTextBox.Text = account("Username").Value Then
                If PasswordTextBox.Text = account("Password").Value Then
                    MessageBox.Show("Access Granted")
                    Me.Hide()

                    Form1.Hide()
                    UsernameTextBox.Clear()
                    PasswordTextBox.Clear()

                    Inventory.ListView1.Items.Clear()
                    If invent.RecordCount <> 0 Then
                        invent.MoveFirst()
                        While Not invent.EOF
                            Inventory.ListView1.Items.Add(New ListViewItem({invent("UPSno").Value.ToString, invent("Item").Value.ToString, invent("Quantity").Value.ToString, "₱" & invent("SellingPrice").Value.ToString, "₱" & invent("TotalPrice").Value.ToString}))

                            invent.MoveNext()
                        End While
                        invent.MoveFirst()

                    End If

                    tranOut.DataSource = Nothing
                    tranOut.DataSource = tranOut

                    taborn.DataSource = Nothing
                    taborn.DataSource = taborn

                    po.DataSource = Nothing
                    po.DataSource = po

                    poitm.DataSource = Nothing
                    poitm.DataSource = poitm
                    Inventory.Label2.Text = account("Username").Value.ToString
                    Inventory.Show()
                Else
                    MessageBox.Show("Incorrect Password or Username")
                    PasswordTextBox.Clear()
                End If
            Else
                MessageBox.Show("Incorrect Password or Username")
                PasswordTextBox.Clear()
            End If

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PasswordTextBox.Clear()
        UsernameTextBox.Clear()
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub PasswordTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles PasswordTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoginButt.PerformClick()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If account.RecordCount <> 0 Then
            account.MoveFirst()
            If TextBox3.Text = TextBox2.Text Then
                account("Password").Value = TextBox3.Text
                account.Update()
                MessageBox.Show("Changes saved")
                TextBox3.Clear()
                TextBox2.Clear()
                Panel2.Width = 10
                Panel2.Height = 10


            Else
                MessageBox.Show("Password do not match")
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel2.Width = 10
        Panel2.Height = 10

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Panel1.Width = 10
        Panel1.Height = 10


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If account.RecordCount <> 0 Then
            account.MoveFirst()
            If TextBox1.Text = account("Answer").Value Then
                Panel1.Width = 10
                Panel1.Height = 10

                Panel2.Width = 375
                Panel2.Height = 321

                Panel2.Top = 69
                Panel2.Left = 25
                TextBox1.Clear()

            Else
                MessageBox.Show("Wrong Answer")
            End If
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Panel1.Width = 375
        Panel1.Height = 321

        Panel1.Top = 69
        Panel1.Left = 25
    End Sub
End Class
