Public Class Form1


    Dim autoid As Integer
    Dim idname As String

    Private Sub PictureBox146_Click(sender As Object, e As EventArgs) Handles SwtcUserIcon.Click
        Login.ShowDialog()

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

    Private Sub UPSTextbox_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ClearItmButt.Click
        If ListView2.Items.Count <> 0 Then
            validation2.ShowDialog()
        End If
    End Sub

    Private Sub ListView2_DoubleClick(sender As Object, e As EventArgs) Handles ListView2.DoubleClick
        If ListView2.SelectedItems.Count = 0 OrElse ListView2.FocusedItem Is Nothing Then Return
        validation.ShowDialog()
    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged
        If ListView2.SelectedItems.Count = 0 OrElse ListView2.FocusedItem Is Nothing Then Return
        ListView2.FullRowSelect = True

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        If ListView2.SelectedItems.Count = 0 OrElse ListView2.FocusedItem Is Nothing Then Return

        ListView2.FullRowSelect = False
        ListView2.FocusedItem.Remove()

        Dim a, b As Integer
        a = 0
        b = 0
        While a < ListView2.Items.Count
            b = CDbl(ListView2.Items(a).SubItems(3).Text) + b
            a = a + 1
        End While
        TotalLabel.Text = b
    End Sub

    Private Sub CashTextbox_GotFocus(sender As Object, e As EventArgs) Handles CashTextbox.GotFocus
        If CashTextbox.Text = "0" Then
            CashTextbox.Clear()
        End If
    End Sub

    Private Sub CashTextbox_KeyDown(sender As Object, e As KeyEventArgs) Handles CashTextbox.KeyDown
        If e.KeyCode = Keys.Enter Then
            PrintButt.PerformClick()
        End If
    End Sub

    Private Sub CashTextbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CashTextbox.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

    
   


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles PrintButt.Click
        'mclass.main()
          Dim orn As Integer
        tranOut.DataSource = Nothing
        tranOut.DataSource = tranOut

        If tranOut.State = ADODB.ObjectStateEnum.adStateOpen Then tranOut.Close()
        tranOut.Open("tranOut Order By ID", con, 1, 3)

        If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
        taborn.Open("taborn Order By ID", con, 1, 3)

        If ListView2.Items.Count <> 0 Then
            Dim totalAmount, cashAmount As Decimal
            If Not Decimal.TryParse(TotalLabel.Text, totalAmount) OrElse Not Decimal.TryParse(CashTextbox.Text, cashAmount) Then
                MessageBox.Show("Enter a valid cash amount.", "Transaction Declined")
                Return
            End If
            If totalAmount <= cashAmount Then
                If taborn.RecordCount <> 0 And tranOut.RecordCount <> 0 Then

                    Dim C, z As Integer
                    C = 0

                    taborn.MoveLast()
                    z = CDbl(taborn("tabOrn").Value)
                    orn = z + 1
                    taborn.AddNew()
                    taborn("tabOrn").Value = orn
                    taborn("tabTotal").Value = TotalLabel.Text
                    taborn("tabDate").Value = Format(Now, "dd/MM/yyyy")
                    taborn("tabYear").Value = Format(Now, "yyyy")
                    taborn("tabMonth").Value = Format(Now, "MMM")

                    taborn.Update()
                    taborn.MoveLast()




                    While C < ListView2.Items.Count
                        tranOut.MoveLast()
                        tranOut.AddNew()

                        tranOut("outOrno").Value = orn

                        tranOut("outUPSnumber").Value = ListView2.Items(C).SubItems(4).Text.ToString
                        tranOut("outItem").Value = ListView2.Items(C).SubItems(0).Text.ToString

                        tranOut("outQuantity").Value = CDbl(ListView2.Items(C).SubItems(1).Text)

                        tranOut("outSellingPrice").Value = CDbl(ListView2.Items(C).SubItems(2).Text)

                        tranOut("outTootal").Value = CDbl(ListView2.Items(C).SubItems(3).Text)

                        tranOut("outDate").Value = Format(Now, "dd/MM/yyyy")

                        tranOut("outMonth").Value = Format(Now, "MMM")

                        tranOut("outYear").Value = Format(Now, "yyyy")

                        C = C + 1
                        tranOut.Update()
                    End While

                    invent.DataSource = Nothing
                    invent.DataSource = invent

                    tranOut.DataSource = Nothing
                    tranOut.DataSource = tranOut


                    If tranOut.RecordCount <> 0 Then
                        tranOut.MoveFirst()
                        If tranOut.State = ADODB.ObjectStateEnum.adStateOpen Then tranOut.Close()
                        tranOut.Open("SELECT * from tranOut where outOrno = " & orn, con, 1, 3)
                        If tranOut.RecordCount <> 0 Then
                            While Not tranOut.EOF
                                invent.MoveFirst()
                                invent.Find("UPSno = '" & tranOut("outUPSnumber").Value & "'")
                                If Not invent.EOF Then
                                    invent("Quantity").Value = CDbl(invent("Quantity").Value) - CDbl(tranOut("outQuantity").Value)
                                    invent.Update()

                                End If
                                tranOut.MoveNext()

                            End While
                        End If

                    End If

                Else
                    Dim C As Integer
                    C = 0
                    orn = 1

                    taborn.AddNew()
                    taborn("tabOrn").Value = 1
                    taborn("tabTotal").Value = TotalLabel.Text
                    taborn("tabDate").Value = Format(Now, "dd/MM/yyyy")
                    taborn("tabYear").Value = Format(Now, "yyyy")
                    taborn("tabMonth").Value = Format(Now, "MMM")

                    taborn.Update()




                    While C < ListView2.Items.Count
                        tranOut.AddNew()
                        tranOut("outOrno").Value = 1
                        tranOut("outUPSnumber").Value = ListView2.Items(C).SubItems(4).Text.ToString
                        tranOut("outItem").Value = ListView2.Items(C).SubItems(0).Text.ToString
                        tranOut("outQuantity").Value = CDbl(ListView2.Items(C).SubItems(1).Text)
                        tranOut("outSellingPrice").Value = CDbl(ListView2.Items(C).SubItems(2).Text)
                        tranOut("outTootal").Value = CDbl(ListView2.Items(C).SubItems(3).Text)
                        tranOut("outDate").Value = Format(Now, "dd/MM/yyyy")
                        tranOut("outMonth").Value = Format(Now, "MMM")
                        tranOut("outYear").Value = Format(Now, "yyyy")

                        C = C + 1
                        tranOut.Update()
                    End While
                    tranOut.DataSource = Nothing
                    tranOut.DataSource = tranOut

                    invent.DataSource = Nothing
                    invent.DataSource = invent

                    If tranOut.RecordCount <> 0 Then
                        tranOut.MoveFirst()
                        'tranOut.Filter = "outOrno LIKE '" & "1" & "%'"
                        If tranOut.RecordCount <> 0 Then
                            While Not tranOut.EOF
                                invent.MoveFirst()
                                invent.Find("UPSno = '" & tranOut("outUPSnumber").Value & "'")
                                If Not invent.EOF Then
                                    invent("Quantity").Value = CDbl(invent("Quantity").Value) - CDbl(tranOut("outQuantity").Value)
                                    invent.Update()
                                End If
                                tranOut.MoveNext()
                            End While
                        End If
                    End If

                End If
                MessageBox.Show("Done!")
                Resibo.Label8.Text = TotalLabel.Text
                Resibo.Label13.Text = CashTextbox.Text
                Resibo.Label12.Text = ChangeLabel.Text

                Resibo.Label9.Text = Format(Now, "dd/MM/yyyy")
                Resibo.Label10.Text = Format(Now, "HH:mm:ss")
                Resibo.Label16.Text = Format(Now, "ddd")
                Resibo.Label11.Text = orn
                Dim a As Integer
                a = 0
                If Resibo.ListView2.Items.Count = 1 Then
                    While a < ListView2.Items.Count
                        Resibo.ListView2.Items.Add(New ListViewItem({ListView2.Items(a).SubItems(0).Text.ToString, ListView2.Items(a).SubItems(1).Text.ToString, ListView2.Items(a).SubItems(2).Text.ToString, ListView2.Items(a).SubItems(3).Text.ToString}))
                        Resibo.Label15.Text = ListView2.Items(a).SubItems(1).Text.ToString
                        a = a + 1
                    End While
                Else
                    While a < ListView2.Items.Count

                        Resibo.ListView2.Items.Add(New ListViewItem({ListView2.Items(a).SubItems(0).Text.ToString, ListView2.Items(a).SubItems(1).Text.ToString, ListView2.Items(a).SubItems(2).Text.ToString, ListView2.Items(a).SubItems(3).Text.ToString}))
                        Resibo.Label15.Text = ListView2.Items(a).SubItems(1).Text.ToString

                        Resibo.ListView2.Height = Resibo.ListView2.Height + 18
                        Resibo.Label3.Top = Resibo.Label3.Top + 18
                        Resibo.Label4.Top = Resibo.Label4.Top + 18
                        Resibo.Label5.Top = Resibo.Label5.Top + 18
                        Resibo.Label7.Top = Resibo.Label7.Top + 18
                        Resibo.Label14.Top = Resibo.Label14.Top + 18
                        Resibo.Label15.Top = Resibo.Label15.Top + 18
                        Resibo.Label8.Top = Resibo.Label8.Top + 18
                        Resibo.Label6.Top = Resibo.Label6.Top + 18
                        Resibo.Label13.Top = Resibo.Label13.Top + 18
                        Resibo.Label12.Top = Resibo.Label12.Top + 18
                        Resibo.Height = Resibo.Height + 18
                        a = a + 1
                    End While
                End If
                Me.Hide()
                Resibo.Show()
                Resibo.Timer1.Enabled = True
              


                ListView2.Items.Clear()
                TotalLabel.Text = "0"
                CashTextbox.Clear()
            Else
                MessageBox.Show("Your cash is not enough", "Transaction Declined")
            End If

        Else
            MessageBox.Show("Please put items")
        End If



    End Sub



    Private Sub Label452_Click(sender As Object, e As EventArgs) Handles SwtcUserLabel.Click
        Login.ShowDialog()
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        mclass.main()
        invent.DataSource = Nothing
        invent.DataSource = invent

        taborn.DataSource = Nothing
        taborn.DataSource = taborn

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
        If TextBox1.Text.Length >= 12 Then
            If e.KeyChar <> ControlChars.Back Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If invent.State <> ADODB.ObjectStateEnum.adStateOpen Then Return
        If TextBox2.Text <> "" Then
            Dim requestedQuantity As Integer
            If Not Integer.TryParse(TextBox2.Text, requestedQuantity) OrElse requestedQuantity <= 0 Then
                MessageBox.Show("Enter a valid quantity greater than zero.")
                Return
            End If
        End If
        Dim a As Double
        Dim x As Integer = 0
        invent.DataSource = Nothing
        invent.DataSource = invent
        If TextBox1.Text <> "" Then
            If invent.RecordCount <> 0 Then

                invent.MoveFirst()
                invent.Find("UPSno = '" & TextBox1.Text & "'")
                If Not invent.EOF Then
                    If Val(TextBox2.Text) > Val(invent("Quantity").Value) Then
                        MessageBox.Show("Sorry we only have " & invent("Quantity").Value.ToString & " number of " & invent("Item").Value.ToString)
                    Else
                        If ListView2.Items.Count <> 0 Then
                            While x < ListView2.Items.Count
                                If ListView2.Items(x).SubItems(4).Text = TextBox1.Text Then
                                    If TextBox2.Text = "" Then
                                        If Val(ListView2.Items(x).SubItems(1).Text) >= Val(invent("Quantity").Value) Then
                                            MessageBox.Show("Sorry we only have " & invent("Quantity").Value.ToString & " number of " & invent("Item").Value.ToString)
                                            ListView2.Items(x).SubItems(1).Text = invent("Quantity").Value
                                        Else
                                            ListView2.Items(x).SubItems(1).Text = CDbl(ListView2.Items(x).SubItems(1).Text) + 1
                                            ListView2.Items(x).SubItems(3).Text = CDbl(ListView2.Items(x).SubItems(1).Text) * CDbl(ListView2.Items(x).SubItems(2).Text)
                                        End If
                                    Else
                                        If Val(ListView2.Items(x).SubItems(1).Text) >= Val(invent("Quantity").Value) Then
                                            MessageBox.Show("Sorry we only have " & invent("Quantity").Value.ToString & " number of " & invent("Item").Value.ToString)
                                            ListView2.Items(x).SubItems(1).Text = invent("Quantity").Value
                                        Else
                                            ListView2.Items(x).SubItems(1).Text = CDbl(ListView2.Items(x).SubItems(1).Text) + CDbl(TextBox2.Text)
                                            ListView2.Items(x).SubItems(3).Text = CDbl(ListView2.Items(x).SubItems(1).Text) * CDbl(ListView2.Items(x).SubItems(2).Text)
                                        End If
                                    End If
                                    x = ListView2.Items.Count
                                    GoTo lugaw
                                Else
                                    x = x + 1
                                End If

                            End While

                            If TextBox2.Text = "" Then
                                    a = 1 * CDbl(invent("SellingPrice").Value)
                                    ListView2.Items.Add(New ListViewItem({invent("Item").Value, "1", invent("SellingPrice").Value, a, invent("UPSno").Value}))
                                    TotalLabel.Text = "1" * CDbl(invent("SellingPrice").Value) + CDbl(TotalLabel.Text)
                                    TextBox1.Clear()
                                    TextBox2.Clear()
                            Else
                                a = CDbl(TextBox2.Text) * CDbl(invent("SellingPrice").Value)
                                ListView2.Items.Add(New ListViewItem({invent("Item").Value, TextBox2.Text, invent("SellingPrice").Value, a, invent("UPSno").Value}))
                                TotalLabel.Text = (CDbl(TextBox2.Text) * CDbl(invent("SellingPrice").Value)) + CDbl(TotalLabel.Text)
                            End If
                        Else
                            If TextBox2.Text = "" Then
                                a = 1 * CDbl(invent("SellingPrice").Value)
                                ListView2.Items.Add(New ListViewItem({invent("Item").Value, "1", invent("SellingPrice").Value, a, invent("UPSno").Value}))
                                TotalLabel.Text = "1" * CDbl(invent("SellingPrice").Value) + CDbl(TotalLabel.Text)
                                TextBox1.Clear()
                                TextBox2.Clear()
                            Else
                                a = CDbl(TextBox2.Text) * CDbl(invent("SellingPrice").Value)
                                ListView2.Items.Add(New ListViewItem({invent("Item").Value, TextBox2.Text, invent("SellingPrice").Value, a, invent("UPSno").Value}))
                                TotalLabel.Text = (CDbl(TextBox2.Text) * CDbl(invent("SellingPrice").Value)) + CDbl(TotalLabel.Text)
                            End If
                        End If
lugaw:

                        TextBox1.Clear()
                        TextBox2.Clear()
                    End If

                End If
                    x = 0
                    Dim z, b As Integer
                    While z < ListView2.Items.Count
                        b = CDbl(ListView2.Items(z).SubItems(3).Text) + b
                        z = z + 1
                    End While
                    TotalLabel.Text = b

                End If
        End If
    End Sub


    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
        If TextBox3.Text.Length >= 12 Then
            If e.KeyChar <> ControlChars.Back Then
                e.Handled = True
            End If
        End If
    End Sub



    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If invent.State <> ADODB.ObjectStateEnum.adStateOpen Then Return
        If invent.RecordCount <> 0 Then

            invent.MoveFirst()
            invent.Find("UPSno = '" & TextBox3.Text & "'")
            If Not invent.EOF Then
                Label8.Text = invent("SellingPrice").Value.ToString
                Label9.Text = invent("Item").Value.ToString
            Else
                Label8.Text = "0"
                Label9.Text = "-"

            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox3.Text <> "" Then
            If invent.RecordCount <> 0 Then

                invent.MoveFirst()
                invent.Find("UPSno = '" & TextBox3.Text & "'")
                If Not invent.EOF Then
                    TextBox1.Text = TextBox3.Text
                    Label8.Text = "0"
                    Label9.Text = "-"
                    TextBox3.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

   
    Private Sub Button3_Click_1(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub ItemsButt_Click(sender As Object, e As EventArgs) Handles ItemsButt.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        If MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            Me.Dispose()
        End If
    End Sub

   
   
    Private Sub PictureBox6_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox6.MouseLeave
        PictureBox6.Image = My.Resources.joystick
        Panel2.Visible = False

    End Sub

    Private Sub PictureBox6_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox6.MouseMove
        PictureBox6.Image = My.Resources.joystickk
        Panel2.Visible = True
        Label11.Text = "   Close"
    End Sub

    Private Sub ItemsButt_MouseLeave(sender As Object, e As EventArgs) Handles ItemsButt.MouseLeave
        Panel2.Visible = False

    End Sub

    
    Private Sub ItemsButt_MouseMove(sender As Object, e As MouseEventArgs) Handles ItemsButt.MouseMove
        Panel2.Visible = True
        Label11.Text = "Minimize"
    End Sub

   
    Private Sub CashTextbox_LostFocus(sender As Object, e As EventArgs) Handles CashTextbox.LostFocus
        If CashTextbox.Text = "" Then
            CashTextbox.Text = "0"
        End If
    End Sub

  
    Private Sub CashTextbox_TextChanged(sender As Object, e As EventArgs) Handles CashTextbox.TextChanged
        Dim cashAmount, totalAmount As Decimal
        If Decimal.TryParse(CashTextbox.Text, cashAmount) AndAlso Decimal.TryParse(TotalLabel.Text, totalAmount) Then
            ChangeLabel.Text = (cashAmount - totalAmount).ToString()
        Else
            ChangeLabel.Text = "-"
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    
End Class
