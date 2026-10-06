Public Class Inventory

    Dim autoid As Integer
    Dim idname As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles StocksButt.Click
        ColumnHeader1.Width = 230
        mclass.main()
        If invent.State = ADODB.ObjectStateEnum.adStateOpen Then invent.Close()
        invent.Open("Inventory Order By Item", con, 1, 3)
        ListView1.Items.Clear()
        If invent.RecordCount <> 0 Then
            invent.MoveFirst()
            While Not invent.EOF
                ListView1.Items.Add(New ListViewItem({invent("UPSno").Value.ToString, invent("Item").Value.ToString, "   " & invent("Quantity").Value.ToString, "₱ " & invent("SellingPrice").Value.ToString, "₱ " & invent("TotalPrice").Value.ToString}))

                invent.MoveNext()
            End While
            invent.MoveFirst()

        End If

        ListView2.Items.Clear()
        ListView4.Items.Clear()

        PictureBox1.Image = My.Resources.oned
        StocksButt.ForeColor = Color.FromArgb(157, 243, 196)
        LineShape1.BorderColor = Color.FromArgb(157, 243, 196)


        PictureBox4.Image = My.Resources.three
        ItemsButt.ForeColor = Color.Black
        LineShape2.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox5.Image = My.Resources.purchzz
        SettingsButt.ForeColor = Color.Black
        LineShape3.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox6.Image = My.Resources.four
        Button6.ForeColor = Color.Black
        LineShape5.BorderColor = Color.FromArgb(31, 171, 137)

        LineShape9.BorderColor = Color.FromArgb(31, 171, 137)
        Button10.ForeColor = Color.Black
        PictureBox12.Image = My.Resources.settings

        PearlPnl.Visible = True

        Panel21.Width = 10
        Panel21.Height = 10
        Panel21.Visible = False

        PearlPnl.Width = 1139
        PearlPnl.Height = 724
        PearlPnl.Top = 23
        PearlPnl.Left = 227

        Panel5.Left = 10
        Panel5.Top = 10
        Panel5.Width = 10
        Panel5.Height = 10

        Panel5.Visible = False
        Panel1.Visible = False
        Panel7.Visible = False
        Panel3.Visible = False

        Panel7.Width = 10

        Panel1.Width = 10
        Panel1.Height = 10



        Panel3.Width = 10
        Panel3.Height = 10
        Panel3.Top = 10
        Panel3.Left = 10


    End Sub

    Private Sub ItemsButt_Click(sender As Object, e As EventArgs) Handles ItemsButt.Click
        ColumnHeader9.Width = 110
        ColumnHeader14.Width = 80
        ColumnHeader22.Width = 130
        ColumnHeader8.Width = 178
        ColumnHeader10.Width = 199
        ColumnHeader12.Width = 102
        ColumnHeader13.Width = 149
        ColumnHeader24.Width = 99



        ListView4.Items.Clear()
        ListView2.Items.Clear()
        tranOut.DataSource = Nothing
        tranOut.DataSource = tranOut
        ListView4.Items.Clear()
        taborn.DataSource = Nothing
        taborn.DataSource = taborn

        If taborn.RecordCount <> 0 Then
            taborn.MoveFirst()

            While Not taborn.EOF
                ListView2.Items.Add(New ListViewItem({taborn("tabOrn").Value.ToString, taborn("tabTotal").Value.ToString, taborn("tabDate").Value.ToString}))
                taborn.MoveNext()
            End While
            taborn.MoveFirst()
        End If


        PictureBox4.Image = My.Resources.threed
        ItemsButt.ForeColor = Color.FromArgb(157, 243, 196)
        LineShape2.BorderColor = Color.FromArgb(157, 243, 196)

        PictureBox1.Image = My.Resources.one
        StocksButt.ForeColor = Color.Black
        LineShape1.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox5.Image = My.Resources.purchzz
        SettingsButt.ForeColor = Color.Black
        LineShape3.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox6.Image = My.Resources.four
        Button6.ForeColor = Color.Black
        LineShape5.BorderColor = Color.FromArgb(31, 171, 137)

        LineShape9.BorderColor = Color.FromArgb(31, 171, 137)
        Button10.ForeColor = Color.Black
        PictureBox12.Image = My.Resources.settings

        Panel1.Visible = True

        Panel21.Width = 10
        Panel21.Height = 10
        Panel21.Visible = False

        Panel1.Width = 1139
        Panel1.Height = 724
        Panel1.Left = 227
        Panel1.Top = 23

        Panel5.Visible = False
        PearlPnl.Visible = False
        Panel7.Visible = False
        Panel3.Visible = False

        Panel5.Left = 10
        Panel5.Top = 10
        Panel5.Width = 10
        Panel5.Height = 10

        PearlPnl.Width = 10
        PearlPnl.Height = 10
        Panel7.Width = 10
        Panel7.Height = 10

        Panel3.Width = 10
        Panel3.Height = 10
        Panel3.Top = 10
        Panel3.Left = 10
    End Sub

    Private Sub SettingsButt_Click(sender As Object, e As EventArgs) Handles SettingsButt.Click
        ColumnHeader32.Width = 93
        ColumnHeader33.Width = 120
        ColumnHeader34.Width = 107

        ColumnHeader27.Width = 174
        ColumnHeader28.Width = 200
        ColumnHeader29.Width = 99
        ColumnHeader30.Width = 152
        ColumnHeader31.Width = 103

        ListView7.Items.Clear()
        ListView8.Items.Clear()

        LineShape9.BorderColor = Color.FromArgb(31, 171, 137)
        Button10.ForeColor = Color.Black
        PictureBox12.Image = My.Resources.settings

        PictureBox5.Image = My.Resources.purch
        SettingsButt.ForeColor = Color.FromArgb(157, 243, 196)
        LineShape3.BorderColor = Color.FromArgb(157, 243, 196)

        PictureBox4.Image = My.Resources.three
        ItemsButt.ForeColor = Color.Black
        LineShape2.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox1.Image = My.Resources.one
        StocksButt.ForeColor = Color.Black
        LineShape1.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox6.Image = My.Resources.four
        Button6.ForeColor = Color.Black
        LineShape5.BorderColor = Color.FromArgb(31, 171, 137)

        Panel3.Width = 10
        Panel3.Height = 10

        Panel21.Width = 10
        Panel21.Height = 10
        Panel21.Visible = False

        Panel5.Width = 10
        Panel5.Height = 10

        PearlPnl.Width = 10
        PearlPnl.Height = 10
        Panel1.Width = 10
        Panel1.Height = 10

        Panel5.Visible = False
        Panel1.Visible = False
        PearlPnl.Visible = False
        Panel3.Visible = False

        Panel7.Visible = True

        Panel7.Left = 227
        Panel7.Top = 23
        Panel7.Width = 1139
        Panel7.Height = 724
        With po
            .DataSource = Nothing
            .DataSource = po
            If .RecordCount <> 0 Then
                .MoveFirst()
                ListView8.Items.Clear()
                While Not .EOF
                    ListView8.Items.Add(New ListViewItem({.Fields(1).Value.ToString, .Fields(3).Value, .Fields(2).Value}))
                    .MoveNext()
                End While
                .MoveFirst()
            End If


        End With

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        invent.DataSource = Nothing
        invent.DataSource = invent

        taborn.DataSource = Nothing
        taborn.DataSource = taborn

        tranOut.DataSource = Nothing
        tranOut.DataSource = tranOut
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs)
        Panel3.Visible = True


        Panel3.Width = 1139
        Panel3.Height = 743
        Panel3.Top = 13
        Panel3.Left = 227

        Panel7.Width = 10
        Panel7.Height = 10
        Panel7.Top = 10
        Panel7.Left = 10
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs)
        If TextBox1.Text <> "" Then
            If taborn.RecordCount <> 0 Then
                taborn.MoveFirst()
                If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
                taborn.Open("SELECT * from taborn where tabOrn = " & TextBox1.Text, con, 1, 3)
                If taborn.RecordCount <> 0 Then
                    taborn.MoveFirst()
                    ListView2.Items.Clear()
                    ListView2.Items.Add(New ListViewItem({taborn(1).Value, taborn(2).Value, taborn(3).Value}))
                End If
            End If
        Else
            ListView4.Items.Clear()
            ListView2.Items.Clear()
            tranOut.DataSource = Nothing
            tranOut.DataSource = tranOut

            taborn.DataSource = Nothing
            taborn.DataSource = taborn
            If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
            taborn.Open("taborn Order By ID desc", con, 1, 3)
            If taborn.RecordCount <> 0 Then
                taborn.MoveFirst()

                While Not taborn.EOF
                    ListView2.Items.Add(New ListViewItem({taborn("tabOrn").Value.ToString, taborn("tabTotal").Value.ToString, taborn("tabDate").Value.ToString}))
                    taborn.MoveNext()
                End While
                taborn.MoveFirst()
            End If
        End If
    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged
        If ListView2.SelectedItems.Count = 0 OrElse ListView2.FocusedItem Is Nothing Then Return
        If taborn.State <> ADODB.ObjectStateEnum.adStateOpen OrElse taborn.RecordCount = 0 Then Return
        taborn.DataSource = Nothing
        taborn.DataSource = taborn
        ListView2.FullRowSelect = True

        tranOut.DataSource = Nothing
        tranOut.DataSource = tranOut

        If tranOut.RecordCount <> 0 Then
            tranOut.MoveFirst()
            If tranOut.State = ADODB.ObjectStateEnum.adStateOpen Then tranOut.Close()
            tranOut.Open("SELECT * from tranOut where outOrno = " & ListView2.FocusedItem.SubItems(0).Text, con, 1, 3)
            If tranOut.RecordCount <> 0 Then
                tranOut.MoveFirst()
                ListView4.Items.Clear()
                While Not tranOut.EOF
                    ListView4.Items.Add(New ListViewItem({tranOut(2).Value, tranOut(3).Value, tranOut(4).Value, "₱ " & tranOut(5).Value, "₱ " & tranOut(6).Value}))
                    tranOut.MoveNext()

                End While

            End If
        End If

    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        With po
            If ListView5.Items.Count <> 0 Then
                If TextBox2.Text <> "" And TextBox4.Text <> "" Then
                    .AddNew()
                    .Fields("PONo").Value = TextBox2.Text
                    .Fields("PODate").Value = Format(DateTimePicker3.Value, "dd/MM/yyy")
                    .Fields("Supplier").Value = TextBox4.Text
                    .Fields("TotalQuantity").Value = Label11.Text
                    .Fields("TotalPrice").Value = Label13.Text
                    .Update()
                    Dim a As Integer = 0
                   

                    While a < ListView5.Items.Count
                        Dim b As Decimal
                        b = Val(ListView5.Items(a).SubItems(3).Text)

                        With poitm
                            .AddNew()
                            .Fields("PONo").Value = TextBox2.Text
                            .Fields("UPC").Value = ListView5.Items(a).SubItems(0).Text
                            .Fields("itmdate").Value = Format(Now, "dd/MM/yyyy")
                            .Fields("itmonth").Value = Format(Now, "MMM")
                            .Fields("itmyr").Value = Format(Now, "yyyy")
                            With invent
                                .DataSource = Nothing
                                .DataSource = invent
                                itemno()
                                If .RecordCount <> 0 Then
                                    .MoveFirst()
                                    .Find("UPSno = '" & ListView5.Items(a).SubItems(0).Text & "'")
                                    If Not .EOF Then

                                        .Fields(4).Value = Int(.Fields(4).Value) + CDbl(ListView5.Items(a).SubItems(2).Text)
                                        .Fields(5).Value = CDbl(ListView5.Items(a).SubItems(3).Text)
                                        .Fields(6).Value = CDbl(ListView5.Items(a).SubItems(4).Text)
                                        .Update()

                                    Else
                                        .AddNew()
                                        .Fields(1).Value = idname
                                        .Fields(2).Value = ListView5.Items(a).SubItems(1).Text
                                        '.Fields(3).Value = b
                                        .Fields(4).Value = ListView5.Items(a).SubItems(2).Text
                                        .Fields(5).Value = ListView5.Items(a).SubItems(3).Text
                                        .Fields(6).Value = Val(ListView5.Items(a).SubItems(4).Text)
                                        .Update()
                                    End If
                                Else
                                    .AddNew()
                                    .Fields(1).Value = idname
                                    .Fields(2).Value = ListView5.Items(a).SubItems(1).Text
                                    .Fields(3).Value = b
                                    .Fields(4).Value = ListView5.Items(a).SubItems(2).Text
                                    .Fields(5).Value = ListView5.Items(a).SubItems(3).Text
                                    .Fields(6).Value = ListView5.Items(a).SubItems(4).Text
                                    .Update()
                                End If

                            End With
                            .Fields("Description").Value = ListView5.Items(a).SubItems(1).Text
                            .Fields("Quantity").Value = ListView5.Items(a).SubItems(2).Text
                            .Fields("Price").Value = ListView5.Items(a).SubItems(3).Text
                            .Update()
                            a = a + 1
                        End With
                    End While

                    MessageBox.Show("Item Added")
                    Label11.Text = "-"
                    Label13.Text = "-"
                    TextBox2.Clear()
                    TextBox4.Clear()
                    ListView5.Items.Clear()
                Else
                    MessageBox.Show("Please fill up blanks")
                End If

            Else
                MessageBox.Show("Please put items")
            End If
        End With
    End Sub
    Sub itemno()
        With invent
            If .RecordCount <> 0 Then
                .MoveLast()
                autoid = Int(.Fields(1).value) + 1
                If autoid < 9 Then
                    idname = "0000" & autoid
                ElseIf autoid < 99 Then
                    idname = "000" & autoid
                ElseIf autoid < 999 Then
                    idname = "00" & autoid
                ElseIf autoid < 9999 Then
                    idname = "0" & autoid
                ElseIf autoid < 99999 Then
                    idname = autoid
                Else
                    idname = autoid
                End If
            Else
                idname = "00001"
            End If
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ListView7.Items.Clear()
        ListView8.Items.Clear()

        PictureBox5.Image = My.Resources.purch
        SettingsButt.ForeColor = Color.FromArgb(157, 243, 196)
        LineShape3.BorderColor = Color.FromArgb(157, 243, 196)

        PictureBox4.Image = My.Resources.three
        ItemsButt.ForeColor = Color.Black
        LineShape2.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox1.Image = My.Resources.one
        StocksButt.ForeColor = Color.Black
        LineShape1.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox6.Image = My.Resources.four
        Button6.ForeColor = Color.Black
        LineShape5.BorderColor = Color.FromArgb(31, 171, 137)

        Panel3.Width = 10
        Panel3.Height = 10
        Panel3.Top = 10
        Panel3.Left = 10

        Panel5.Left = 10
        Panel5.Top = 10
        Panel5.Width = 10
        Panel5.Height = 10

        PearlPnl.Width = 10
        PearlPnl.Height = 10
        Panel1.Width = 10
        Panel1.Height = 10

        Panel5.Visible = False
        Panel1.Visible = False
        PearlPnl.Visible = False
        Panel3.Visible = False

        Panel7.Visible = True

        Panel7.Left = 227
        Panel7.Top = 23
        Panel7.Width = 1139
        Panel7.Height = 724
        With po
            .DataSource = Nothing
            .DataSource = po
            If .RecordCount <> 0 Then
                .MoveFirst()
                ListView8.Items.Clear()
                While Not .EOF
                    ListView8.Items.Add(New ListViewItem({.Fields(1).Value.ToString, .Fields(2).Value, .Fields(3).Value}))
                    .MoveNext()
                End While
                .MoveFirst()
            End If


        End With
    End Sub

    Private Sub ListView1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 0 OrElse ListView1.FocusedItem Is Nothing Then Return
        ListView1.FullRowSelect = True
    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub ListView5_DoubleClick(sender As Object, e As EventArgs) Handles ListView5.DoubleClick
        If ListView5.SelectedItems.Count = 0 OrElse ListView5.FocusedItem Is Nothing Then Return
        If MessageBox.Show("Are you sure you want to delete this item?", "Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            ListView5.FocusedItem.Remove()
            Dim a As Integer
            Label11.Text = 0
            Label13.Text = 0
            While a < ListView5.Items.Count
                Label11.Text = CDbl(Label11.Text) + CDbl(ListView5.Items(a).SubItems(2).Text)
                Label13.Text = CDbl(Label13.Text) + CDbl(ListView5.Items(a).SubItems(3).Text)
                a = a + 1
            End While
        End If
    End Sub



    Private Sub Label18_Click(sender As Object, e As EventArgs)




    End Sub

    Sub chartdaily()
        taborn.DataSource = Nothing
        taborn.DataSource = taborn

        If taborn.RecordCount <> 0 Then
            taborn.Filter = "tabDate LIKE '" & Format(Now, "dd/MM/yyyy") & "%'"
            If taborn.RecordCount <> 0 Then
                Label24.Text = taborn.RecordCount
            End If
        Else
            Label24.Text = 0
        End If

        taborn.DataSource = Nothing
        taborn.DataSource = taborn

        If taborn.RecordCount <> 0 Then
            taborn.Filter = "tabDate LIKE '" & Format(Now, "dd/MM/yyyy") & "%'"
            If taborn.RecordCount <> 0 Then
                Dim n As Double
                taborn.MoveFirst()
                While Not taborn.EOF
                    n = n + CDbl(taborn("tabTotal").Value)
                    taborn.MoveNext()
                End While
                Label21.Text = n
            End If
        Else
            Label21.Text = 0
        End If

        taborn.DataSource = Nothing
        taborn.DataSource = taborn

        tranOut.DataSource = Nothing
        tranOut.DataSource = tranOut

        If tranOut.RecordCount <> 0 Then
            tranOut.Filter = "outDate LIKE '" & Format(Now, "dd/MM/yyyy") & "%'"
            If tranOut.RecordCount <> 0 Then
                Dim n As Integer
                While Not tranOut.EOF
                    n = n + tranOut("outQuantity").Value
                    tranOut.MoveNext()
                End While
                Label20.Text = n
            End If
        Else
            Label24.Text = 0
        End If
        tranOut.DataSource = Nothing
        tranOut.DataSource = tranOut


        Dim a, b, day7, day6, day5, day4, day3, day2, day1 As Integer
        Dim thedate7, thedate6, thedate5, thedate4, thedate3, thedate2, thedate1 As String
        Dim hiest, m As Integer


        Chart1.Series.Clear()
        Chart1.Series.Add("Sales")
        Chart1.Series("Sales").ChartType = DataVisualization.Charting.SeriesChartType.Line


        If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
        taborn.Open("taborn order by ID", con, 1, 3)
        With taborn
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .MoveLast()
                thedate1 = .Fields("tabDate").Value
                day1 = day1 + CDbl(.Fields("tabTotal").Value)
                .MovePrevious()
                If .BOF Then GoTo lugaw7
                If Not .BOF Then
                    While thedate1 = .Fields("tabDate").Value
                        day1 = day1 + CDbl(.Fields("tabTotal").Value)
                        .MovePrevious()
                        If .BOF Then GoTo lugaw7
                    End While

lugaw7:

                    Label36.Text = day1
                    Chart1.Series("Sales").Points.AddXY(thedate1, day1)
                Else
                    Chart1.Series("Sales").Points.AddXY(thedate1, day1)
                End If





                If Not .BOF Then
                    thedate2 = .Fields("tabDate").Value
                    day2 = day2 + CDbl(.Fields("tabTotal").Value)
                    .MovePrevious()
                    If .BOF Then GoTo lugaw8
                    If Not .BOF Then
                        While thedate2 = .Fields("tabDate").Value
                            day2 = day2 + CDbl(.Fields("tabTotal").Value)
                            .MovePrevious()
                            If .BOF Then GoTo lugaw8
                        End While
lugaw8:
                        Label37.Text = day2

                        Chart1.Series("Sales").Points.AddXY(thedate2, day2)
                    Else
                        Chart1.Series("Sales").Points.AddXY(thedate2, day2)
                    End If
                End If




                If Not .BOF Then
                    thedate3 = .Fields("tabDate").Value
                    day3 = day3 + CDbl(.Fields("tabTotal").Value)
                    .MovePrevious()
                    If .BOF Then GoTo lugaw9
                    If Not .BOF Then
                        While thedate3 = .Fields("tabDate").Value
                            day3 = day3 + CDbl(.Fields("tabTotal").Value)
                            .MovePrevious()
                            If .BOF Then GoTo lugaw9
                        End While
lugaw9:
                        Label38.Text = day3

                        Chart1.Series("Sales").Points.AddXY(thedate3, day3)
                    Else
                        Chart1.Series("Sales").Points.AddXY(thedate3, day3)
                    End If
                End If




                If Not .BOF Then
                    thedate4 = .Fields("tabDate").Value
                    day4 = day4 + CDbl(.Fields("tabTotal").Value)
                    .MovePrevious()
                    If .BOF Then GoTo lugaw10
                    If Not .BOF Then
                        While thedate4 = .Fields("tabDate").Value
                            day4 = day4 + CDbl(.Fields("tabTotal").Value)
                            .MovePrevious()
                            If .BOF Then GoTo lugaw10
                        End While

lugaw10:
                        Label39.Text = day4
                        Chart1.Series("Sales").Points.AddXY(thedate4, day4)
                    Else
                        Chart1.Series("Sales").Points.AddXY(thedate4, day4)
                    End If
                End If



                If Not .BOF Then
                    thedate5 = .Fields("tabDate").Value
                    day5 = day5 + CDbl(.Fields("tabTotal").Value)
                    .MovePrevious()
                    If .BOF Then GoTo lugaw11
                    If Not .BOF Then
                        While thedate5 = .Fields("tabDate").Value
                            day5 = day5 + CDbl(.Fields("tabTotal").Value)
                            .MovePrevious()
                            If .BOF Then GoTo lugaw11
                        End While

lugaw11:
                        Label32.Text = day5
                        Chart1.Series("Sales").Points.AddXY(thedate5, day5)
                    Else
                        Chart1.Series("Sales").Points.AddXY(thedate5, day5)
                    End If
                End If




                If Not .BOF Then
                    thedate6 = .Fields("tabDate").Value
                    day6 = day6 + CDbl(.Fields("tabTotal").Value)
                    .MovePrevious()
                    If .BOF Then GoTo lugaw12
                    If Not .BOF Then
                        While thedate6 = .Fields("tabDate").Value
                            day6 = day6 + CDbl(.Fields("tabTotal").Value)
                            .MovePrevious()
                            If .BOF Then GoTo lugaw12
                        End While

lugaw12:
                        Label33.Text = day6
                        Chart1.Series("Sales").Points.AddXY(thedate6, day6)
                    Else
                        Chart1.Series("Sales").Points.AddXY(thedate6, day6)
                    End If
                End If




                If Not .BOF Then
                    thedate7 = .Fields("tabDate").Value
                    day7 = day7 + CDbl(.Fields("tabTotal").Value)
                    .MovePrevious()
                    If .BOF Then GoTo lugaw13
                    If Not .BOF Then
                        While thedate7 = .Fields("tabDate").Value
                            day7 = day7 + CDbl(.Fields("tabTotal").Value)
                            .MovePrevious()
                            If .BOF Then GoTo lugaw13
                        End While

lugaw13:
                        Label34.Text = day7
                        Chart1.Series("Sales").Points.AddXY(thedate7, day7)
                    Else
                        Chart1.Series("Sales").Points.AddXY(thedate7, day7)
                    End If
                End If
            End If
        End With



        taborn.DataSource = Nothing
        taborn.DataSource = taborn



    End Sub



    Sub chartyear()

        If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
        taborn.Open("SELECT * from taborn where tabYear = " & Format(Now, "yyyy"), con, 1, 3)

        If taborn.RecordCount <> 0 Then
            taborn.Filter = "tabMonth LIKE '" & Format(Now, "MMM") & "%'"
            If taborn.RecordCount <> 0 Then
                Label40.Text = taborn.RecordCount
            Else
                Label40.Text = 0
            End If

        End If
        taborn.DataSource = Nothing
        taborn.DataSource = taborn

        If taborn.RecordCount <> 0 Then
            taborn.Filter = "tabMonth LIKE '" & Format(Now, "MMM") & "%'"
            If taborn.RecordCount <> 0 Then
                Dim n As Double = 0
                taborn.MoveFirst()
                While Not taborn.EOF
                    n = n + CDbl(taborn("tabTotal").Value)
                    taborn.MoveNext()
                End While
                Label43.Text = n
            End If
        Else
            Label43.Text = 0
        End If

        taborn.DataSource = Nothing
        taborn.DataSource = taborn

        tranOut.DataSource = Nothing
        tranOut.DataSource = tranOut

        If tranOut.RecordCount <> 0 Then
            tranOut.Filter = "outMonth LIKE '" & Format(Now, "MMM") & "%'"
            If tranOut.RecordCount <> 0 Then
                Dim n As Integer
                While Not tranOut.EOF
                    n = n + tranOut("outQuantity").Value
                    tranOut.MoveNext()
                End While
                Label45.Text = n
            End If
        Else
            Label45.Text = 0
        End If
        tranOut.DataSource = Nothing
        tranOut.DataSource = tranOut



        Dim year As Integer = Format(Now, "yyyy")
        Chart2.Series.Add("monthly")
        Chart2.Series("monthly").ChartType = DataVisualization.Charting.SeriesChartType.Column

        If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
        taborn.Open("SELECT * from tabOrn where tabYear =" & year, con, 1, 3)
        With taborn
            If .RecordCount <> 0 Then
                .Filter = "tabMonth LIKE '" & "Jan" & "%'"
                If .RecordCount <> 0 Then
                    .MoveFirst()
                    Dim a As Integer
                    While Not .EOF
                        a = a + CDbl(.Fields("tabTotal").Value)
                        .MoveNext()
                    End While
                    Chart2.Series("monthly").Points.AddXY("Jan", a)
                    Label64.Text = a
                End If
            End If
            'If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
            'taborn.Open("SELECT * from tabOrn where tabYear = " & year, con, 1, 3)
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .Filter = "tabMonth LIKE '" & "Feb" & "%'"
                If .RecordCount <> 0 Then
                    .MoveFirst()
                    Dim a As Integer
                    While Not .EOF
                        a = a + CDbl(.Fields("tabTotal").Value)
                        .MoveNext()
                    End While

                    Chart2.Series("monthly").Points.AddXY("Feb", a)
                    Label63.Text = a
                End If
            End If
            'If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
            'taborn.Open("SELECT * from tabOrn where tabYear = " & year, con, 1, 3)
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .Filter = "tabMonth LIKE '" & "Mar" & "%'"
                If .RecordCount <> 0 Then
                    .MoveFirst()
                    Dim a As Integer
                    While Not .EOF
                        a = a + CDbl(.Fields("tabTotal").Value)
                        .MoveNext()
                    End While
                    Chart2.Series("monthly").Points.AddXY("Mar", a)
                    Label62.Text = a
                End If
            End If
            'If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
            ' taborn.Open("SELECT * from tabOrn where tabYear = " & year, con, 1, 3)
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .Filter = "tabMonth LIKE '" & "Apr" & "%'"
                If .RecordCount <> 0 Then
                    .MoveFirst()
                    Dim a As Integer
                    While Not .EOF
                        a = a + CDbl(.Fields("tabTotal").Value)
                        .MoveNext()
                    End While
                    Chart2.Series("monthly").Points.AddXY("Apr", a)
                    Label61.Text = a
                End If
            End If
            'If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
            'taborn.Open("SELECT * from tabOrn where tabYear = " & year, con, 1, 3)
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .Filter = "tabMonth LIKE '" & "May" & "%'"
                If .RecordCount <> 0 Then
                    .MoveFirst()
                    Dim a As Integer
                    While Not .EOF
                        a = a + CDbl(.Fields("tabTotal").Value)
                        .MoveNext()
                    End While
                    Chart2.Series("monthly").Points.AddXY("May", a)
                    Label53.Text = a
                End If
            End If
            'If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
            'taborn.Open("SELECT * from tabOrn where tabYear = " & year, con, 1, 3)
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .Filter = "tabMonth LIKE '" & "Jun" & "%'"
                If .RecordCount <> 0 Then
                    .MoveFirst()
                    Dim a As Integer
                    While Not .EOF
                        a = a + CDbl(.Fields("tabTotal").Value)
                        .MoveNext()
                    End While
                    Chart2.Series("monthly").Points.AddXY("Jun", a)
                    Label52.Text = a
                End If
            End If
            'If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
            'taborn.Open("SELECT * from tabOrn where tabYear = " & year, con, 1, 3)
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .Filter = "tabMonth LIKE '" & "Jul" & "%'"
                If .RecordCount <> 0 Then
                    .MoveFirst()
                    Dim a As Integer
                    While Not .EOF
                        a = a + CDbl(.Fields("tabTotal").Value)
                        .MoveNext()
                    End While
                    Chart2.Series("monthly").Points.AddXY("Jul", a)
                    Label51.Text = a
                End If
            End If
            'If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
            'taborn.Open("SELECT * from tabOrn where tabYear = " & year, con, 1, 3)
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .Filter = "tabMonth LIKE '" & "Aug" & "%'"
                If .RecordCount <> 0 Then
                    .MoveFirst()
                    Dim a As Integer
                    While Not .EOF
                        a = a + CDbl(.Fields("tabTotal").Value)
                        .MoveNext()
                    End While
                    Chart2.Series("monthly").Points.AddXY("Aug", a)
                    Label50.Text = a
                End If
            End If
            'If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
            'taborn.Open("SELECT * from tabOrn where tabYear = " & year, con, 1, 3)
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .Filter = "tabMonth LIKE '" & "Sep" & "%'"
                If .RecordCount <> 0 Then
                    .MoveFirst()
                    Dim a As Integer
                    While Not .EOF
                        a = a + CDbl(.Fields("tabTotal").Value)
                        .MoveNext()
                    End While
                    Chart2.Series("monthly").Points.AddXY("Sep", a)
                    Label49.Text = a
                End If
            End If
            'If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
            'taborn.Open("SELECT * from tabOrn where tabYear = " & year, con, 1, 3)
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .Filter = "tabMonth LIKE '" & "Oct" & "%'"
                If .RecordCount <> 0 Then
                    .MoveFirst()
                    Dim a As Integer
                    While Not .EOF
                        a = a + CDbl(.Fields("tabTotal").Value)
                        .MoveNext()
                    End While
                    Chart2.Series("monthly").Points.AddXY("Oct", a)
                    Label48.Text = a
                End If
            End If
            'If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
            'taborn.Open("SELECT * from tabOrn where tabYear = " & year, con, 1, 3)
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .Filter = "tabMonth LIKE '" & "Nov" & "%'"
                If .RecordCount <> 0 Then
                    .MoveFirst()
                    Dim a As Integer
                    While Not .EOF
                        a = a + CDbl(.Fields("tabTotal").Value)
                        .MoveNext()
                    End While
                    Chart2.Series("monthly").Points.AddXY("Nov", a)
                    Label47.Text = a
                End If
            End If
            'If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
            'taborn.Open("SELECT * from tabOrn where tabYear = " & year, con, 1, 3)
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .Filter = "tabMonth LIKE '" & "Dec" & "%'"
                If .RecordCount <> 0 Then
                    .MoveFirst()
                    Dim a As Integer
                    While Not .EOF
                        a = a + CDbl(.Fields("tabTotal").Value)
                        .MoveNext()
                    End While
                    Chart2.Series("monthly").Points.AddXY("Dec", a)
                    Label31.Text = a
                End If
            End If
        End With





    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        LineShape4.BorderColor = Color.FromArgb(74, 122, 255)
        LineShape6.BorderColor = Color.FromArgb(98, 210, 162)
        LineShape7.BorderColor = Color.FromArgb(98, 210, 162)
        Button7.ForeColor = Color.FromArgb(74, 122, 255)
        Button8.ForeColor = Color.Black
        Button2.ForeColor = Color.Black

        LineShape9.BorderColor = Color.FromArgb(31, 171, 137)
        Button10.ForeColor = Color.Black
        PictureBox12.Image = My.Resources.settings


        Chart1.Series.Clear()




        Panel18.Width = 1103
        Panel18.Height = 573
        Panel18.Top = 113
        Panel18.Left = 34

        chartdaily()


        PictureBox6.Image = My.Resources.foured
        Button6.ForeColor = Color.FromArgb(157, 243, 196)
        LineShape5.BorderColor = Color.FromArgb(157, 243, 196)

        PictureBox4.Image = My.Resources.three
        ItemsButt.ForeColor = Color.Black
        LineShape2.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox5.Image = My.Resources.purchzz
        SettingsButt.ForeColor = Color.Black
        LineShape3.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox1.Image = My.Resources.one
        StocksButt.ForeColor = Color.Black
        LineShape1.BorderColor = Color.FromArgb(31, 171, 137)

        Panel3.Width = 10
        Panel3.Height = 10
  
        Panel21.Width = 10
        Panel21.Height = 10
        Panel21.Visible = False

        PearlPnl.Width = 10
        PearlPnl.Height = 10
        Panel1.Width = 10
        Panel1.Height = 10

  
        Panel7.Width = 10
        Panel7.Height = 10

        PearlPnl.Visible = False
        Panel1.Visible = False
        Panel7.Visible = False
        Panel3.Visible = False
        Panel2.Visible = False
        Panel15.Visible = False

        Panel18.Visible = True

        Panel5.Visible = True

        Panel5.Left = 227
        Panel5.Top = 23
        Panel5.Width = 1139
        Panel5.Height = 724

        Panel2.Width = 10
        Panel2.Height = 10

        Panel15.Width = 10
        Panel15.Height = 10

    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        LineShape4.BorderColor = Color.FromArgb(74, 122, 255)
        LineShape6.BorderColor = Color.FromArgb(98, 210, 162)
        LineShape7.BorderColor = Color.FromArgb(98, 210, 162)
        Button7.ForeColor = Color.FromArgb(74, 122, 255)
        Button8.ForeColor = Color.Black
        Button2.ForeColor = Color.Black

        Chart1.Series.Clear()

        Panel18.Width = 1103
        Panel18.Height = 573
        Panel18.Top = 113
        Panel18.Left = 34

        chartdaily()


        PictureBox6.Image = My.Resources.foured
        Button6.ForeColor = Color.FromArgb(157, 243, 196)
        LineShape5.BorderColor = Color.FromArgb(157, 243, 196)

        PictureBox4.Image = My.Resources.three
        ItemsButt.ForeColor = Color.Black
        LineShape2.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox5.Image = My.Resources.purchzz
        SettingsButt.ForeColor = Color.Black
        LineShape3.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox1.Image = My.Resources.one
        StocksButt.ForeColor = Color.Black
        LineShape1.BorderColor = Color.FromArgb(31, 171, 137)

        Panel3.Width = 10
        Panel3.Height = 10
        Panel3.Top = 10
        Panel3.Left = 10

        PearlPnl.Width = 10
        PearlPnl.Height = 10
        Panel1.Width = 10
        Panel1.Height = 10

        Panel7.Left = 10
        Panel7.Top = 10
        Panel7.Width = 10
        Panel7.Height = 10

        PearlPnl.Visible = False
        Panel1.Visible = False
        Panel7.Visible = False
        Panel3.Visible = False
        Panel2.Visible = False
        Panel15.Visible = False

        Panel18.Visible = True

        Panel5.Left = 227
        Panel5.Top = 23
        Panel5.Width = 1139
        Panel5.Height = 724

        Panel2.Width = 10
        Panel2.Height = 10

        Panel15.Width = 10
        Panel15.Height = 10

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        LineShape6.BorderColor = Color.FromArgb(74, 122, 255)
        LineShape7.BorderColor = Color.FromArgb(98, 210, 162)
        LineShape4.BorderColor = Color.FromArgb(98, 210, 162)
        Button8.ForeColor = Color.FromArgb(74, 122, 255)
        Button7.ForeColor = Color.Black
        Button2.ForeColor = Color.Black

        Panel2.Width = 1103
        Panel2.Height = 573
        Panel2.Top = 113
        Panel2.Left = 34

        Panel18.Width = 10
        Panel18.Height = 10

        Panel15.Width = 15
        Panel15.Height = 15

   
        Chart2.Series.Clear()

        Panel2.Visible = True

        Panel15.Visible = False
        Panel18.Visible = False

        chartyear()
    End Sub


    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mclass.main()
        invent.DataSource = Nothing
        invent.DataSource = invent

        tranOut.DataSource = Nothing
        tranOut.DataSource = tranOut

        taborn.DataSource = Nothing
        taborn.DataSource = taborn

        po.DataSource = Nothing
        po.DataSource = po

        poitm.DataSource = Nothing
        poitm.DataSource = poitm

        PearlPnl.Visible = False
        Panel1.Visible = False
        Panel7.Visible = False
        Panel3.Visible = False
        Panel5.Visible = False

    End Sub

    

    Private Sub TextBox6_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""

        If TextBox6.Text.Length >= 12 Then
            If e.KeyChar <> ControlChars.Back Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If invent.State <> ADODB.ObjectStateEnum.adStateOpen Then Return
        invent.DataSource = Nothing
        invent.DataSource = invent
        If invent.RecordCount <> 0 Then
            invent.MoveFirst()
            invent.Find("UPSno = '" & TextBox6.Text & "'")
            If Not invent.EOF Then
                TextBox5.Text = invent("Item").Value.ToString
                TextBox5.ReadOnly = True
            Else
                TextBox5.ReadOnly = False
            End If

        End If
    End Sub



    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

    Private Sub TextBox7_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress

        Dim DecimalSeparator As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or
                         Asc(e.KeyChar) = 8 Or
                         (e.KeyChar = DecimalSeparator And sender.Text.IndexOf(DecimalSeparator) = -1))
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text <> "" Then
                If taborn.RecordCount <> 0 Then
                    taborn.MoveFirst()
                    If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
                    taborn.Open("SELECT * from taborn where tabOrn = " & TextBox1.Text, con, 1, 3)
                    If taborn.RecordCount <> 0 Then
                        taborn.MoveFirst()
                        ListView2.Items.Clear()
                        ListView2.Items.Add(New ListViewItem({taborn(1).Value, taborn(2).Value, taborn(3).Value}))
                    End If
                End If
            Else
                ListView4.Items.Clear()
                ListView2.Items.Clear()
                tranOut.DataSource = Nothing
                tranOut.DataSource = tranOut

                taborn.DataSource = Nothing
                taborn.DataSource = taborn
                If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
                taborn.Open("taborn Order By ID desc", con, 1, 3)
                If taborn.RecordCount <> 0 Then
                    taborn.MoveFirst()

                    While Not taborn.EOF
                        ListView2.Items.Add(New ListViewItem({taborn("tabOrn").Value.ToString, taborn("tabTotal").Value.ToString, taborn("tabDate").Value.ToString}))
                        taborn.MoveNext()
                    End While
                    taborn.MoveFirst()
                End If
            End If

        End If

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            ListView4.Items.Clear()
            ListView2.Items.Clear()
            tranOut.DataSource = Nothing
            tranOut.DataSource = tranOut
            ListView4.Items.Clear()
            taborn.DataSource = Nothing
            taborn.DataSource = taborn

            If taborn.RecordCount <> 0 Then
                taborn.MoveFirst()

                While Not taborn.EOF
                    ListView2.Items.Add(New ListViewItem({taborn("tabOrn").Value.ToString, taborn("tabTotal").Value.ToString, taborn("tabDate").Value.ToString}))
                    taborn.MoveNext()
                End While
                taborn.MoveFirst()
            End If
        End If
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        ListView4.Items.Clear()
        ListView2.Items.Clear()
        TextBox1.Clear()
        tranOut.DataSource = Nothing
        tranOut.DataSource = tranOut

        taborn.DataSource = Nothing
        taborn.DataSource = taborn
        If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
        taborn.Open("taborn Order By ID desc", con, 1, 3)
        If taborn.RecordCount <> 0 Then
            taborn.MoveFirst()

            While Not taborn.EOF
                ListView2.Items.Add(New ListViewItem({taborn("tabOrn").Value.ToString, taborn("tabTotal").Value.ToString, taborn("tabDate").Value.ToString}))
                taborn.MoveNext()
            End While
            taborn.MoveFirst()
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim c As Decimal
        Dim x, quantity As Integer
        Dim unitPrice As Decimal
        If Not Integer.TryParse(TextBox7.Text, quantity) OrElse quantity <= 0 OrElse Not Decimal.TryParse(TextBox8.Text, unitPrice) OrElse unitPrice < 0 Then
            MessageBox.Show("Enter a valid quantity greater than zero and a valid price.")
            Return
        End If
        c = quantity * unitPrice
        If TextBox5.Text <> "" And TextBox6.Text <> "" And TextBox7.Text <> "" And TextBox8.Text <> "" Then
            While x < ListView5.Items.Count
                If ListView5.Items(x).SubItems(1).Text = TextBox6.Text Then
                    MessageBox.Show("This item is already on the list", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    GoTo lugaw
                Else
                    x = x + 1
                End If
            End While
lugaw:
            If x >= ListView5.Items.Count Then
                ListView5.Items.Add(New ListViewItem({TextBox6.Text, TextBox5.Text, TextBox7.Text, TextBox8.Text, c}))
                Dim a As Integer
                Label11.Text = 0
                Label13.Text = 0
                While a < ListView5.Items.Count
                    Label11.Text = CDbl(Label11.Text) + CDbl(ListView5.Items(a).SubItems(2).Text)
                    Label13.Text = CDbl(Label13.Text) + CDbl(ListView5.Items(a).SubItems(3).Text)
                    a = a + 1
                End While
                TextBox5.Clear()
                TextBox6.Clear()
                TextBox7.Clear()
                TextBox8.Clear()
            End If
        Else
            MessageBox.Show("Please fill up blanks")
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        ListView7.Items.Clear()
        ListView8.Items.Clear()

        PictureBox5.Image = My.Resources.purch
        SettingsButt.ForeColor = Color.FromArgb(157, 243, 196)
        LineShape3.BorderColor = Color.FromArgb(157, 243, 196)

        PictureBox4.Image = My.Resources.three
        ItemsButt.ForeColor = Color.Black
        LineShape2.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox1.Image = My.Resources.one
        StocksButt.ForeColor = Color.Black
        LineShape1.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox6.Image = My.Resources.four
        Button6.ForeColor = Color.Black
        LineShape5.BorderColor = Color.FromArgb(31, 171, 137)

        Panel3.Width = 10
        Panel3.Height = 10
        Panel3.Top = 10
        Panel3.Left = 10

        Panel5.Left = 10
        Panel5.Top = 10
        Panel5.Width = 10
        Panel5.Height = 10

        PearlPnl.Width = 10
        PearlPnl.Height = 10
        Panel1.Width = 10
        Panel1.Height = 10

        Panel5.Visible = False
        Panel1.Visible = False
        PearlPnl.Visible = False
        Panel3.Visible = False

        Panel7.Visible = True

        Panel7.Left = 227
        Panel7.Top = 23
        Panel7.Width = 1139
        Panel7.Height = 724
        With po
            .DataSource = Nothing
            .DataSource = po
            If .RecordCount <> 0 Then
                .MoveFirst()
                ListView8.Items.Clear()
                While Not .EOF
                    ListView8.Items.Add(New ListViewItem({.Fields(1).Value.ToString, .Fields(2).Value, .Fields(3).Value}))
                    .MoveNext()
                End While
                .MoveFirst()
            End If


        End With

    End Sub

    Private Sub ListView8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView8.SelectedIndexChanged
        If ListView8.SelectedItems.Count = 0 OrElse ListView8.FocusedItem Is Nothing Then Return
        If po.State <> ADODB.ObjectStateEnum.adStateOpen OrElse po.RecordCount = 0 Then Return
        If poitm.State = ADODB.ObjectStateEnum.adStateOpen Then poitm.Close()
        poitm.Open("PO_Items Order By ID", con, 1, 3)

        po.DataSource = Nothing
        po.DataSource = po
        ListView8.FullRowSelect = True

        poitm.DataSource = Nothing
        poitm.DataSource = poitm

        If poitm.RecordCount <> 0 Then
            poitm.MoveFirst()
            If poitm.State = ADODB.ObjectStateEnum.adStateOpen Then poitm.Close()
            poitm.Open("SELECT * from PO_Items where PONo = " & ListView8.FocusedItem.SubItems(0).Text, con, 1, 3)
            If poitm.RecordCount <> 0 Then
                poitm.MoveFirst()
                Dim c, v As Integer
                c = 0
                ListView7.Items.Clear()
                While Not poitm.EOF
                    c = CDbl(poitm(4).Value) * CDbl(poitm(5).Value)
                    ListView7.Items.Add(New ListViewItem({poitm(2).Value, poitm(3).Value, poitm(4).Value, "₱ " & poitm(5).Value, "₱ " & c}))
                    poitm.MoveNext()
                    v = v + 1
                End While
            End If
        End If
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        If TextBox1.Text <> "" Then
            If taborn.RecordCount <> 0 Then
                taborn.MoveFirst()
                If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
                taborn.Open("SELECT * from taborn where tabOrn = " & TextBox1.Text, con, 1, 3)

                If taborn.RecordCount <> 0 Then
                    taborn.MoveFirst()
                    ListView2.Items.Clear()
                    ListView2.Items.Add(New ListViewItem({taborn(1).Value, taborn(2).Value, taborn(3).Value}))
                End If
            End If
        Else
            ListView4.Items.Clear()
            ListView2.Items.Clear()
            tranOut.DataSource = Nothing
            tranOut.DataSource = tranOut

            taborn.DataSource = Nothing
            taborn.DataSource = taborn
            If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
            taborn.Open("taborn Order By ID desc", con, 1, 3)
            If taborn.RecordCount <> 0 Then
                taborn.MoveFirst()

                While Not taborn.EOF
                    ListView2.Items.Add(New ListViewItem({taborn("tabOrn").Value.ToString, taborn("tabTotal").Value.ToString, taborn("tabDate").Value.ToString}))
                    taborn.MoveNext()
                End While
                taborn.MoveFirst()
            End If
        End If
    End Sub

    Private Sub TextBox10_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox10.KeyDown
        If e.KeyCode = Keys.Enter Then


            If TextBox10.Text <> "" Then
                If po.RecordCount <> 0 Then
                    po.MoveFirst()
                    If IsNumeric(TextBox10.Text) Then
                        If po.State = ADODB.ObjectStateEnum.adStateOpen Then po.Close()
                        po.Open("SELECT * from PurchaseOrders where PONo = " & TextBox10.Text, con, 1, 3)
                        If po.RecordCount <> 0 Then
                            po.MoveFirst()
                            ListView8.Items.Clear()
                            ListView8.Items.Add(New ListViewItem({po(1).Value, po(3).Value, po(2).Value}))
                        End If
                    Else
                        If po.RecordCount <> 0 Then
                            If po.State = ADODB.ObjectStateEnum.adStateOpen Then po.Close()
                            po.Open("SELECT * from PurchaseOrders where Supplier = '" & TextBox10.Text.Replace("'", "''") & "'", con, 1, 3)
                            If po.RecordCount <> 0 Then
                                po.MoveFirst()
                                ListView8.Items.Clear()
                                ListView8.Items.Add(New ListViewItem({po(1).Value, po(3).Value, po(2).Value}))
                            End If

                        End If
                    End If
                End If
            End If
        End If
    End Sub


    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        If TextBox10.Text <> "" Then
            If po.RecordCount <> 0 Then
                po.MoveFirst()
                If IsNumeric(TextBox10.Text) Then
                    If po.State = ADODB.ObjectStateEnum.adStateOpen Then po.Close()
                    po.Open("SELECT * from PurchaseOrders where PONo = " & TextBox10.Text, con, 1, 3)
                    If po.RecordCount <> 0 Then
                        po.MoveFirst()
                        ListView8.Items.Clear()
                        ListView8.Items.Add(New ListViewItem({po(1).Value, po(3).Value, po(2).Value}))
                    End If
                Else
                    If po.RecordCount <> 0 Then
                        po.MoveFirst()
                        po.Find("Supplier = '" & TextBox10.Text & "'")
                        If Not po.EOF Then
                            If po.RecordCount <> 0 Then
                                ListView8.Items.Clear()
                                ListView8.Items.Add(New ListViewItem({po(1).Value, po(3).Value, po(2).Value}))
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        ListView7.Items.Clear()
        ListView8.Items.Clear()
        TextBox10.Clear()
        po.DataSource = Nothing
        po.DataSource = po

        poitm.DataSource = Nothing
        poitm.DataSource = poitm

        If po.State = ADODB.ObjectStateEnum.adStateOpen Then po.Close()
        po.Open("PurchaseOrders Order By ID desc", con, 1, 3)
        If po.RecordCount <> 0 Then
            po.MoveFirst()

            While Not po.EOF
                ListView8.Items.Add(New ListViewItem({po("PONo").Value.ToString, po("Supplier").Value.ToString, po("PODate").Value.ToString}))
                po.MoveNext()
            End While
            po.MoveFirst()
        End If

    End Sub

    



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        mclass.main()
        If invent.State = ADODB.ObjectStateEnum.adStateOpen Then invent.Close()
        invent.Open("Inventory Order By Quantity desc", con, 1, 3)
        ListView1.Items.Clear()
        If invent.RecordCount <> 0 Then
            invent.MoveFirst()
            While Not invent.EOF
                ListView1.Items.Add(New ListViewItem({invent("UPSno").Value.ToString, invent("Item").Value.ToString, invent("Quantity").Value.ToString, "₱" & invent("SellingPrice").Value.ToString, "₱" & invent("TotalPrice").Value.ToString}))

                invent.MoveNext()
            End While
            invent.MoveFirst()

        End If

        ListView2.Items.Clear()
        ListView4.Items.Clear()




        PictureBox1.Image = My.Resources.oned
        StocksButt.ForeColor = Color.FromArgb(157, 243, 196)
        LineShape1.BorderColor = Color.FromArgb(157, 243, 196)


        PictureBox4.Image = My.Resources.three
        ItemsButt.ForeColor = Color.Black
        LineShape2.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox5.Image = My.Resources.purchzz
        SettingsButt.ForeColor = Color.Black
        LineShape3.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox6.Image = My.Resources.four
        Button6.ForeColor = Color.Black
        LineShape5.BorderColor = Color.FromArgb(31, 171, 137)


        PearlPnl.Visible = True

        PearlPnl.Width = 1139
        PearlPnl.Height = 724
        PearlPnl.Top = 23
        PearlPnl.Left = 227

        Panel5.Left = 10
        Panel5.Top = 10
        Panel5.Width = 10
        Panel5.Height = 10

        Panel5.Visible = False
        Panel1.Visible = False
        Panel7.Visible = False
        Panel3.Visible = False

        Panel7.Width = 10

        Panel1.Width = 10
        Panel1.Height = 10



        Panel3.Width = 10
        Panel3.Height = 10
        Panel3.Top = 10
        Panel3.Left = 10
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        ListView4.Items.Clear()
        ListView2.Items.Clear()
        tranOut.DataSource = Nothing
        tranOut.DataSource = tranOut
        ListView4.Items.Clear()
        taborn.DataSource = Nothing
        taborn.DataSource = taborn

        If taborn.RecordCount <> 0 Then
            taborn.MoveFirst()

            While Not taborn.EOF
                ListView2.Items.Add(New ListViewItem({taborn("tabOrn").Value.ToString, taborn("tabTotal").Value.ToString, taborn("tabDate").Value.ToString}))
                taborn.MoveNext()
            End While
            taborn.MoveFirst()
        End If


        PictureBox4.Image = My.Resources.threed
        ItemsButt.ForeColor = Color.FromArgb(157, 243, 196)
        LineShape2.BorderColor = Color.FromArgb(157, 243, 196)

        PictureBox1.Image = My.Resources.one
        StocksButt.ForeColor = Color.Black
        LineShape1.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox5.Image = My.Resources.purchzz
        SettingsButt.ForeColor = Color.Black
        LineShape3.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox6.Image = My.Resources.four
        Button6.ForeColor = Color.Black
        LineShape5.BorderColor = Color.FromArgb(31, 171, 137)

        Panel1.Visible = True

        Panel1.Width = 1139
        Panel1.Height = 724
        Panel1.Left = 227
        Panel1.Top = 23

        Panel5.Visible = False
        PearlPnl.Visible = False
        Panel7.Visible = False
        Panel3.Visible = False

        Panel5.Left = 10
        Panel5.Top = 10
        Panel5.Width = 10
        Panel5.Height = 10

        PearlPnl.Width = 10
        PearlPnl.Height = 10
        Panel7.Width = 10
        Panel7.Height = 10

        Panel3.Width = 10
        Panel3.Height = 10
        Panel3.Top = 10
        Panel3.Left = 10
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        LineShape4.BorderColor = Color.FromArgb(74, 122, 255)
        LineShape6.BorderColor = Color.FromArgb(98, 210, 162)
        LineShape7.BorderColor = Color.FromArgb(98, 210, 162)
        Button7.ForeColor = Color.FromArgb(74, 122, 255)
        Button8.ForeColor = Color.Black
        Button2.ForeColor = Color.Black



        Chart1.Series.Clear()




        Panel18.Width = 1103
        Panel18.Height = 573
        Panel18.Top = 113
        Panel18.Left = 34

        chartdaily()


        PictureBox6.Image = My.Resources.foured
        Button6.ForeColor = Color.FromArgb(157, 243, 196)
        LineShape5.BorderColor = Color.FromArgb(157, 243, 196)

        PictureBox4.Image = My.Resources.three
        ItemsButt.ForeColor = Color.Black
        LineShape2.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox5.Image = My.Resources.purchzz
        SettingsButt.ForeColor = Color.Black
        LineShape3.BorderColor = Color.FromArgb(31, 171, 137)

        PictureBox1.Image = My.Resources.one
        StocksButt.ForeColor = Color.Black
        LineShape1.BorderColor = Color.FromArgb(31, 171, 137)

        Panel3.Width = 10
        Panel3.Height = 10
        Panel3.Top = 10
        Panel3.Left = 10

        PearlPnl.Width = 10
        PearlPnl.Height = 10
        Panel1.Width = 10
        Panel1.Height = 10

        Panel7.Left = 10
        Panel7.Top = 10
        Panel7.Width = 10
        Panel7.Height = 10

        PearlPnl.Visible = False
        Panel1.Visible = False
        Panel7.Visible = False
        Panel3.Visible = False
        Panel2.Visible = False
        Panel15.Visible = False

        Panel18.Visible = True

        Panel5.Visible = True

        Panel5.Left = 227
        Panel5.Top = 23
        Panel5.Width = 1139
        Panel5.Height = 724

        Panel2.Width = 10
        Panel2.Height = 10

        Panel15.Width = 10
        Panel15.Height = 10
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Panel3.Visible = True


        Panel3.Width = 1139
        Panel3.Height = 724
        Panel3.Top = 23
        Panel3.Left = 227

        Panel7.Width = 10
        Panel7.Height = 10
        Panel7.Top = 10
        Panel7.Left = 10
    End Sub



    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        LineShape7.BorderColor = Color.FromArgb(74, 122, 255)
        LineShape4.BorderColor = Color.FromArgb(98, 210, 162)
        LineShape6.BorderColor = Color.FromArgb(98, 210, 162)
        Button2.ForeColor = Color.FromArgb(74, 122, 255)
        Button8.ForeColor = Color.Black
        Button7.ForeColor = Color.Black

        Panel15.Width = 1103
        Panel15.Height = 573
        Panel15.Top = 113
        Panel15.Left = 34

        Panel2.Width = 10
        Panel2.Height = 10
 

        Panel18.Width = 10
        Panel18.Height = 10

        Panel15.Visible = True
        Panel2.Visible = False
        Panel18.Visible = False

        chartaon()
    End Sub


    Sub chartaon()

        taborn.DataSource = Nothing
        taborn.DataSource = taborn

        If taborn.RecordCount <> 0 Then
            If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
            taborn.Open("SELECT * from taborn where tabYear = " & Format(Now, "yyyy"), con, 1, 3)
            If taborn.RecordCount <> 0 Then
                Label54.Text = taborn.RecordCount
            Else
                Label54.Text = 0
            End If
        End If

        taborn.DataSource = Nothing
        taborn.DataSource = taborn

        If taborn.RecordCount <> 0 Then
            If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
            taborn.Open("SELECT * from taborn where tabYear = " & Format(Now, "yyyy"), con, 1, 3)
            If taborn.RecordCount <> 0 Then
                Dim n As Double = 0
                taborn.MoveFirst()
                While Not taborn.EOF
                    n = n + CDbl(taborn("tabTotal").Value)
                    taborn.MoveNext()
                End While
                Label57.Text = n
            End If
        Else
            Label57.Text = 0
        End If

        taborn.DataSource = Nothing
        taborn.DataSource = taborn


        tranOut.DataSource = Nothing
        tranOut.DataSource = tranOut

        If tranOut.RecordCount <> 0 Then
            tranOut.Filter = "outYear LIKE '" & Format(Now, "yyyy") & "%'"
            If tranOut.RecordCount <> 0 Then
                Dim n As Integer
                While Not tranOut.EOF
                    n = n + tranOut("outQuantity").Value
                    tranOut.MoveNext()
                End While
                Label59.Text = n
            End If
        Else
            Label59.Text = 0
        End If
        tranOut.DataSource = Nothing
        tranOut.DataSource = tranOut




        Chart3.Series.Clear()

        Dim year As Integer = Format(Now, "yyyy")
        Chart3.Series.Clear()
        Chart3.Series.Add("Year")
        Chart3.Series("Year").ChartType = DataVisualization.Charting.SeriesChartType.Column
        Chart3.Series("Year").BorderWidth = 5
        If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
        taborn.Open("SELECT * from taborn where tabYear = " & year, con, 1, 3)
        With taborn
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .MoveFirst()
                Dim a As Integer
                While Not .EOF
                    a = a + CDbl(.Fields("tabTotal").Value)
                    .MoveNext()
                End While
                Chart3.Series("Year").Points.AddXY(year, a)
            End If
        End With
        year = year - 1

        If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
        taborn.Open("SELECT * from taborn where tabYear = " & year, con, 1, 3)
        With taborn
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .MoveFirst()
                Dim a As Integer
                While Not .EOF
                    a = a + CDbl(.Fields("tabTotal").Value)
                    .MoveNext()
                End While
                Chart3.Series("Year").Points.AddXY(year, a)
            End If
        End With
        year = year - 1

        If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
        taborn.Open("SELECT * from taborn where tabYear = " & year, con, 1, 3)
        With taborn
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .MoveFirst()
                Dim a As Integer
                While Not .EOF
                    a = a + CDbl(.Fields("tabTotal").Value)
                    .MoveNext()
                End While
                Chart3.Series("Year").Points.AddXY(year, a)
            End If
        End With
        year = year - 1

        If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
        taborn.Open("SELECT * from taborn where tabYear = " & year, con, 1, 3)
        With taborn
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .MoveFirst()
                Dim a As Integer
                While Not .EOF
                    a = a + CDbl(.Fields("tabTotal").Value)
                    .MoveNext()
                End While
                Chart3.Series("Year").Points.AddXY(year, a)
            End If
        End With
        year = year - 1

        If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
        taborn.Open("SELECT * from taborn where tabYear = " & year, con, 1, 3)
        With taborn
            .DataSource = Nothing
            .DataSource = taborn
            If .RecordCount <> 0 Then
                .MoveFirst()
                Dim a As Integer
                While Not .EOF
                    a = a + CDbl(.Fields("tabTotal").Value)
                    .MoveNext()
                End While
                Chart3.Series("Year").Points.AddXY(year, a)
            End If
        End With

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        If MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            Me.Dispose()
            Form1.Dispose()
        End If
    End Sub

    Private Sub PictureBox8_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox8.MouseLeave
        PictureBox8.Image = My.Resources.joystick
    End Sub

    Private Sub PictureBox8_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox8.MouseMove
        PictureBox8.Image = My.Resources.joystickk

    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged
        If taborn.State <> ADODB.ObjectStateEnum.adStateOpen Then Return
        taborn.DataSource = Nothing
        taborn.DataSource = taborn
        ListView9.Items.Clear()
        If taborn.RecordCount <> 0 Then
            taborn.Filter = "tabDate LIKE '" & Format(DateTimePicker3.Value, "dd/MM/yyy") & "%'"
            If taborn.RecordCount <> 0 Then
                While Not taborn.EOF
                    ListView9.Items.Add(New ListViewItem({taborn(1).Value, taborn(2).Value, taborn(3).Value}))
                    taborn.MoveNext()
                End While
            End If
        End If
    End Sub

    Private Sub DateTimePicker4_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker4.ValueChanged
        If taborn.State <> ADODB.ObjectStateEnum.adStateOpen Then Return
        taborn.DataSource = Nothing
        taborn.DataSource = taborn
        ListView6.Items.Clear()
        If taborn.RecordCount <> 0 Then
            taborn.Filter = "tabMonth LIKE '" & Format(DateTimePicker4.Value, "MMM") & "%'"
            If taborn.RecordCount <> 0 Then
                While Not taborn.EOF
                    ListView6.Items.Add(New ListViewItem({taborn(1).Value, taborn(2).Value, taborn(3).Value}))
                    taborn.MoveNext()
                End While
            End If
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        If taborn.State <> ADODB.ObjectStateEnum.adStateOpen Then Return
        taborn.DataSource = Nothing
        taborn.DataSource = taborn
        ListView3.Items.Clear()
        If taborn.RecordCount <> 0 Then
            taborn.Filter = "tabDate LIKE '" & Format(DateTimePicker2.Value, "dd/MM/yyy") & "%'"
            If taborn.RecordCount <> 0 Then
                While Not taborn.EOF
                    ListView3.Items.Add(New ListViewItem({taborn(1).Value, taborn(2).Value, taborn(3).Value}))
                    taborn.MoveNext()
                End While
            End If
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Button11.ForeColor = Color.FromArgb(74, 122, 255)
        LineShape10.BorderColor = Color.FromArgb(74, 122, 255)

        Button12.ForeColor = Color.Black
        LineShape11.BorderColor = Color.FromArgb(98, 210, 162)

        Panel22.Width = 363
        Panel22.Height = 513
        Panel22.Top = 162
        Panel22.Left = 388

        Panel23.Width = 10
        Panel23.Height = 10

        LineShape1.BorderColor = Color.FromArgb(31, 171, 137)
        LineShape2.BorderColor = Color.FromArgb(31, 171, 137)
        LineShape3.BorderColor = Color.FromArgb(31, 171, 137)
        LineShape5.BorderColor = Color.FromArgb(31, 171, 137)
        Button6.ForeColor = Color.Black
        StocksButt.ForeColor = Color.Black
        SettingsButt.ForeColor = Color.Black
        ItemsButt.ForeColor = Color.Black
        PictureBox1.Image = My.Resources.one
        PictureBox4.Image = My.Resources.three
        PictureBox5.Image = My.Resources.purchzz
        PictureBox6.Image = My.Resources.four


        LineShape9.BorderColor = Color.FromArgb(157, 243, 196)
        Button10.ForeColor = Color.FromArgb(157, 243, 196)
        PictureBox12.Image = My.Resources.settings1


        Panel21.Left = 227
        Panel21.Top = 23
        Panel21.Width = 1139
        Panel21.Height = 724

        Panel5.Width = 10
        Panel5.Height = 10
        Panel2.Width = 10
        Panel2.Height = 10
        Panel15.Width = 10
        Panel15.Height = 10
        Panel3.Width = 10
        Panel3.Height = 10
        PearlPnl.Width = 10
        PearlPnl.Height = 10
        Panel1.Width = 10
        Panel1.Height = 10
        Panel7.Width = 10
        Panel7.Height = 10



        PearlPnl.Visible = False
        Panel1.Visible = False
        Panel7.Visible = False
        Panel3.Visible = False
        Panel2.Visible = False
        Panel15.Visible = False
        Panel5.Visible = False

        Panel21.Visible = True


    End Sub

   
  
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        account.DataSource = Nothing
        account.DataSource = account

        If account.RecordCount <> 0 Then
            account.MoveFirst()
            If TextBox9.Text <> "" And TextBox11.Text <> "" And TextBox12.Text <> "" And TextBox14.Text <> "" And ComboBox1.Text <> "" And TextBox13.Text <> "" Then
                If TextBox11.Text = TextBox13.Text Then
                    If TextBox9.Text = account("Password").Value Then
                        If TextBox11.TextLength >= 5 Then
                            account("Username").Value = TextBox14.Text
                            account("Password").Value = TextBox11.Text
                            account("Question").Value = ComboBox1.Text
                            account("Answer").Value = TextBox12.Text
                            account.Update()
                            MessageBox.Show("Changes saved")
                            account.DataSource = Nothing
                            account.DataSource = account
                        Else
                            MessageBox.Show("Password must be at least 5 characters long.")
                        End If
                    Else
                        MessageBox.Show("Passwords do not match")
                    End If

                Else
                    MessageBox.Show("Passwords do not match")
                End If
            Else
                MessageBox.Show("Fill up the blanks")
            End If
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Button11.ForeColor = Color.FromArgb(74, 122, 255)
        LineShape10.BorderColor = Color.FromArgb(74, 122, 255)

        Button12.ForeColor = Color.Black
        LineShape11.BorderColor = Color.FromArgb(98, 210, 162)

        Panel22.Width = 363
        Panel22.Height = 513
        Panel22.Top = 162
        Panel22.Left = 388

        Panel23.Width = 10
        Panel23.Height = 10
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        account.DataSource = Nothing
        account.DataSource = account

        If account.RecordCount <> 0 Then
            account.MoveFirst()
            If TextBox17.Text <> "" And TextBox16.Text <> "" And TextBox15.Text <> "" Then
                If TextBox17.Text = account("PIN").Value.ToString Then
                    If TextBox15.Text = TextBox16.Text Then
                        If TextBox16.TextLength >= 5 Then
                            account("PIN").Value = TextBox16.Text
                            account.Update()
                            MessageBox.Show("Changes saved")
                            TextBox17.Clear()
                            TextBox16.Clear()
                            TextBox15.Clear()
                        Else
                            MessageBox.Show("PIN must be at least 5 characters long.")
                        End If
                    Else
                        MessageBox.Show("PIN do not match")
                    End If
                Else
                    MessageBox.Show("Wrong PIN")
                End If
            Else
                MessageBox.Show("Fill up the blanks")
            End If
        End If

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Button12.ForeColor = Color.FromArgb(74, 122, 255)
        LineShape11.BorderColor = Color.FromArgb(74, 122, 255)

        Button11.ForeColor = Color.Black
        LineShape10.BorderColor = Color.FromArgb(98, 210, 162)

        Panel23.Width = 306
        Panel23.Height = 409
        Panel23.Top = 180
        Panel23.Left = 414

        Panel22.Width = 10
        Panel22.Height = 10
    End Sub

    Private Sub TextBox17_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox17.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

    Private Sub TextBox16_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox16.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

    Private Sub TextBox15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox15.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

    Private Sub PictureBox13_Click(sender As Object, e As EventArgs) Handles PictureBox13.Click
        If searchstocks.Text <> "" Then
            If invent.State = ADODB.ObjectStateEnum.adStateOpen Then invent.Close()
            invent.Open("Inventory Order By ID", con, 1, 3)
            If invent.RecordCount <> 0 Then
                invent.MoveFirst()

                If IsNumeric(searchstocks.Text) Then
                    If invent.State = ADODB.ObjectStateEnum.adStateOpen Then invent.Close()
                    invent.Open("SELECT * from Inventory where UPSno = " & searchstocks.Text, con, 1, 3)

                    If invent.RecordCount <> 0 Then
                        invent.MoveFirst()
                        ListView1.Items.Clear()
                        ListView1.Items.Add(New ListViewItem({invent("UPSno").Value.ToString, invent("Item").Value.ToString, invent("Quantity").Value.ToString, "₱" & invent("SellingPrice").Value.ToString, "₱" & invent("TotalPrice").Value.ToString}))
                    End If
                Else
                    'If invent.State = ADODB.ObjectStateEnum.adStateOpen Then invent.Close()
                    'invent.Open("SELECT * from Inventory where Item = " & searchstocks.Text & "", con, 1, 3)
                    If invent.RecordCount <> 0 Then
                        invent.MoveFirst()
                        invent.Find("Item = '" & searchstocks.Text & "'")
                        If Not invent.EOF Then
                            If invent.RecordCount <> 0 Then
                                ListView1.Items.Clear()
                                ListView1.Items.Add(New ListViewItem({invent("UPSno").Value.ToString, invent("Item").Value.ToString, invent("Quantity").Value.ToString, "₱" & invent("SellingPrice").Value.ToString, "₱" & invent("TotalPrice").Value.ToString}))
                            End If
                        End If
                    End If

                End If

                End If


        End If
    End Sub

    Private Sub searchstocks_KeyDown(sender As Object, e As KeyEventArgs) Handles searchstocks.KeyDown
        If e.KeyCode = Keys.Enter Then
            If searchstocks.Text <> "" Then
                If invent.State = ADODB.ObjectStateEnum.adStateOpen Then invent.Close()
                invent.Open("Inventory Order By ID", con, 1, 3)
                If invent.RecordCount <> 0 Then
                    invent.MoveFirst()

                    If IsNumeric(searchstocks.Text) Then
                        If invent.State = ADODB.ObjectStateEnum.adStateOpen Then invent.Close()
                        invent.Open("SELECT * from Inventory where UPSno = " & searchstocks.Text, con, 1, 3)

                        If invent.RecordCount <> 0 Then
                            invent.MoveFirst()
                            ListView1.Items.Clear()
                            ListView1.Items.Add(New ListViewItem({invent("UPSno").Value.ToString, invent("Item").Value.ToString, invent("Quantity").Value.ToString, "₱" & invent("SellingPrice").Value.ToString, "₱" & invent("TotalPrice").Value.ToString}))
                        End If
                    Else
                        'If invent.State = ADODB.ObjectStateEnum.adStateOpen Then invent.Close()
                        'invent.Open("SELECT * from Inventory where Item = " & searchstocks.Text & "", con, 1, 3)
                        If invent.RecordCount <> 0 Then
                            invent.MoveFirst()
                            invent.Find("Item = '" & searchstocks.Text & "'")
                            If Not invent.EOF Then
                                If invent.RecordCount <> 0 Then
                                    ListView1.Items.Clear()
                                    ListView1.Items.Add(New ListViewItem({invent("UPSno").Value.ToString, invent("Item").Value.ToString, invent("Quantity").Value.ToString, "₱" & invent("SellingPrice").Value.ToString, "₱" & invent("TotalPrice").Value.ToString}))
                                End If
                            End If
                        End If

                    End If
                End If
            End If

        End If
    End Sub

    
    Private Sub PictureBox14_Click(sender As Object, e As EventArgs) Handles PictureBox14.Click
        ListView1.Items.Clear()
        searchstocks.Clear()
        If invent.State = ADODB.ObjectStateEnum.adStateOpen Then invent.Close()
        invent.Open("Inventory Order By Item", con, 1, 3)
        ListView1.Items.Clear()
        If invent.RecordCount <> 0 Then
            invent.MoveFirst()
            While Not invent.EOF
                ListView1.Items.Add(New ListViewItem({invent("UPSno").Value.ToString, invent("Item").Value.ToString, invent("Quantity").Value.ToString, "₱" & invent("SellingPrice").Value.ToString, "₱" & invent("TotalPrice").Value.ToString}))

                invent.MoveNext()
            End While
            invent.MoveFirst()

        End If
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            DateTimePicker5.Enabled = True
        Else
            DateTimePicker5.Enabled = False
        End If

    End Sub

    Private Sub DateTimePicker5_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker5.ValueChanged
        If con.State <> ADODB.ObjectStateEnum.adStateOpen OrElse taborn.State <> ADODB.ObjectStateEnum.adStateOpen Then Return
        If taborn.State = ADODB.ObjectStateEnum.adStateOpen Then taborn.Close()
        taborn.Open("taborn Order By ID desc", con, 1, 3)
        taborn.DataSource = Nothing
        taborn.DataSource = taborn
        If taborn.RecordCount <> 0 Then
            taborn.MoveFirst()

            taborn.Filter = "tabDate LIKE '" & Format(DateTimePicker5.Value, "dd/MM/yyyy") & "%'"
            If taborn.RecordCount <> 0 Then
                taborn.MoveFirst()
                ListView2.Items.Clear()
                While Not taborn.EOF
                    ListView2.Items.Add(New ListViewItem({taborn(1).Value, taborn(2).Value, taborn(3).Value}))
                    taborn.MoveNext()
                End While
            End If
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            DateTimePicker6.Enabled = True
        Else
            DateTimePicker6.Enabled = False
        End If
    End Sub

    Private Sub DateTimePicker6_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker6.ValueChanged
        If con.State <> ADODB.ObjectStateEnum.adStateOpen OrElse po.State <> ADODB.ObjectStateEnum.adStateOpen Then Return
        If poitm.State = ADODB.ObjectStateEnum.adStateOpen Then poitm.Close()
        poitm.Open("PO_Items Order By ID", con, 1, 3)

        po.DataSource = Nothing
        po.DataSource = po
        If po.RecordCount <> 0 Then
            po.MoveFirst()
            po.Filter = "PODate LIKE '" & Format(DateTimePicker6.Value, "dd/MM/yyyy") & "%'"
            If po.RecordCount <> 0 Then
                po.MoveFirst()
                ListView8.Items.Clear()
                While Not po.EOF
                    ListView8.Items.Add(New ListViewItem({po(1).Value, po(2).Value, po(3).Value}))
                    po.MoveNext()
                End While
            End If
        End If
    End Sub


    Private Sub PictureBox15_Click(sender As Object, e As EventArgs) Handles PictureBox15.Click
        Try
            PrintDialog1.Document = PrintDocument1
            PrintDocument1.PrinterSettings = New Printing.PrinterSettings()
            If Not PrintDocument1.PrinterSettings.IsValid Then
                MessageBox.Show("Configure a default printer before printing stocks.", "Printer unavailable")
                Return
            End If
            PrintDocument1.PrinterSettings.DefaultPageSettings.Landscape = False
            PrintDocument1.Print()
        Catch ex As Exception
            MessageBox.Show("Stocks could not be printed. " & ex.Message, "Printing failed")
        End Try
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim h As Integer = 0
        h = 40
        e.Graphics.DrawString("Mr.D Stocks", New Drawing.Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, 360, h)

        e.Graphics.DrawString(Format(Now, " hh:mm tt"), New Drawing.Font("Times New Roman", 8), Brushes.Black, 700, 45)
        e.Graphics.DrawString(Format(Now, "dd/MM/yyyy"), New Drawing.Font("Times New Roman", 8), Brushes.Black, 700, 60)

        e.Graphics.DrawString("UPC", New Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 130, 95)
        e.Graphics.DrawString("Item", New Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 272, 95)
        e.Graphics.DrawString("Quantity", New Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 380, 95)
        e.Graphics.DrawString("Selling Price", New Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 500, 95)
        e.Graphics.DrawString("Total Price", New Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 640, 95)
        h += 80
        For Each itm As ListViewItem In ListView1.Items
            e.Graphics.DrawString(itm.Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 100, h)
            e.Graphics.DrawString(itm.SubItems(1).Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 240, h)
            e.Graphics.DrawString(itm.SubItems(2).Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 390, h)
            e.Graphics.DrawString(itm.SubItems(3).Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 520, h)
            e.Graphics.DrawString(itm.SubItems(4).Text, New Drawing.Font("Times New Roman", 12), Brushes.Black, 655, h)
            h += 20
        Next
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

    End Sub
End Class
