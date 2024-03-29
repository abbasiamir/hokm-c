Public Class Main
    Public Class playedcard
        Public cardname As String
        Public sequence As Integer
        Public Function playedcard(ByVal name As String, ByVal seq As Integer)
            cardname = name
            sequence = seq
        End Function
        Public Sub New(ByVal name As String, ByVal seq As Integer)
            cardname = name
            sequence = seq
        End Sub
        Public Sub New()

        End Sub
    End Class

    Public hokm As String
    Public playerName As String
    Public playerbegin As Integer
    Public hakem As Integer
    Public remindedcard As Integer = 52
    Public remindedcount4players As Integer = 13
    'Public remindedcardkol As Integer = 52
    'Public group1koly, group2koly, group1jari, group2jari As Integer
    Public swap As Array = Array.CreateInstance(GetType(String), 52)
    Public Cards() As String = {"02خشت", "02دل", "02اسپیک", "02گیشنیز", "03خشت", "03دل", "03اسپیک", "03گیشنیز", "04خشت", "04دل", "04اسپیک", "04گیشنیز", "05خشت", "05دل", "05اسپیک", "05گیشنیز", "06خشت", "06دل", "06اسپیک", "06گیشنیز", "07خشت", "07دل", "07اسپیک", "07گیشنیز", "08خشت", "08دل", "08اسپیک", "08گیشنیز", "09خشت", "09دل", "09اسپیک", "09گیشنیز", "10خشت", "10دل", "10اسپیک", "10گیشنیز", "11خشت", "11دل", "11اسپیک", "11گیشنیز", "12خشت", "12دل", "12اسپیک", "12گیشنیز", "13خشت", "13دل", "13اسپیک", "13گیشنیز", "14خشت", "14دل", "14اسپیک", "14گیشنیز"}
    Public typesname() As String = {"اسپیک", "خشت", "گیشنیز", "دل"}
    Public sars() As Integer = {14, 14, 14, 14}
    Public remindedcounts() As Integer = {13, 13, 13, 13}
    Public sarsbefor(3) As Integer
    'Public players As Array = Array.CreateInstance(GetType(Integer), 4, 13)
    Public playerscards As Array = Array.CreateInstance(GetType(String), 4, 13)
    'Public playedcards As Array = Array.CreateInstance(GetType(String), 52)
    Public playerplayed(3, 12) As playedcard
    Public vasat As Array = Array.CreateInstance(GetType(String), 4)
    Public typescounts As Array = Array.CreateInstance(GetType(Integer), 4, 4)
    Public cuted As Array = Array.CreateInstance(GetType(Boolean), 4, 4)
    Public cutable As Array = Array.CreateInstance(GetType(Boolean), 4, 4)
    Public zerocount As Array = Array.CreateInstance(GetType(Boolean), 4, 4)
    Public javab As Array = Array.CreateInstance(GetType(Boolean), 4, 4)
    Dim PBs(3, 12) As PictureBox
    Dim cent(3) As PictureBox
    Dim path As String
    'PBs = {{PB1_1, PB1_2, PB1_3, PB1_4, PB1_5, PB1_6, PB1_7, PB1_8, PB1_9, PB1_10, PB1_11, PB1_12, PB1_13} _
    ', {PB2_1, PB2_2, PB2_3, PB2_4, PB2_5, PB2_6, PB2_7, PB2_8, PB2_9, PB2_10, PB2_11, PB2_12, PB2_13} _
    ', {PB3_1, PB3_2, PB3_3, PB3_4, PB3_5, PB3_6, PB3_7, PB3_8, PB3_9, PB3_10, PB3_11, PB3_12, PB3_13} _
    ', {PB4_1, PB4_2, PB4_3, PB4_4, PB4_5, PB4_6, PB4_7, PB4_8, PB4_9, PB4_10, PB4_11, PB4_12, PB4_13}}
    'Public ctrls(3, 12) As Integer ' = {{Controls.IndexOfKey("PB1_1"), Controls.IndexOfKey("PB1_2")}, {Controls.IndexOfKey("PB2_1"), Controls.IndexOfKey("PB2_2")}}



    Public Shared Sub Main()




    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initializ()
        Dim Image1 As Image = New Bitmap(Application.StartupPath + "\\Resources\\اسپیک02.bmp", Me.Width, Me.Height)



        Dialogstart.Timerstart.Start()
        Dialogstart.ShowDialog()
        NameDlg.ShowDialog()
        lbplayer.Text = playerName
        path = Application.StartupPath + "\Resources\"
        start()
    End Sub

    Sub start()
        Array.Copy(Cards, swap, 52)
        Dim go As Boolean
        ToolStripStatusLabel2.Text = playerName + "-بازیگر1"
        ToolStripStatusLabel7.Text = playerName + "-بازیگر1"
        go = False
        While go = False
            forhakem()
            Dim sar As Integer
            sar = Convert.ToInt32(vasat(0).Substring(0, 2))
            For index As Integer = 1 To 3
                If (Convert.ToInt32(vasat(index).substring(0, 2))) > sar Then
                    sar = Convert.ToInt32(vasat(index).substring(0, 2))
                    hakem = index
                End If
            Next
            go = True
            For index As Integer = 0 To 3
                If index <> hakem Then
                    If (Convert.ToInt32(vasat(index).substring(0, 2))) = sar Then
                        go = False
                    End If
                End If
            Next

        End While
        If hakem = 0 Then
            lbhakemName.Text = "بازیگر1"
        End If
        If hakem = 1 Then
            lbhakemName.Text = "بازیگر2"
        End If
        If hakem = 2 Then
            lbhakemName.Text = playerName
        End If
        If hakem = 3 Then
            lbhakemName.Text = "بازیگر4"
        End If
        t.Interval = 100
        t.Start()
    End Sub
    Public Sub forhakem()
        Dim hakemsar As Integer
        hakemsar = TimeOfDay.Now.Millisecond Mod 52
        While swap(hakemsar) = Nothing
            hakemsar = TimeOfDay.Now.Millisecond Mod 52
        End While
        Dim img As Image = Image.FromFile(path + swap(hakemsar) + ".bmp")
        cent1.Image = img
        Array.Clear(swap, hakemsar, 1)
        vasat(0) = Cards(hakemsar)

        hakemsar = TimeOfDay.Now.Millisecond Mod 52
        While swap(hakemsar) = Nothing
            hakemsar = TimeOfDay.Now.Millisecond Mod 52
        End While
        img = Image.FromFile(path + swap(hakemsar) + ".bmp")
        cent2.Image = img
        Array.Clear(swap, hakemsar, 1)
        vasat(1) = Cards(hakemsar)

        hakemsar = TimeOfDay.Now.Millisecond Mod 52
        While swap(hakemsar) = Nothing
            hakemsar = TimeOfDay.Now.Millisecond Mod 52
        End While
        img = Image.FromFile(path + swap(hakemsar) + ".bmp")
        cent3.Image = img
        Array.Clear(swap, hakemsar, 1)
        vasat(2) = Cards(hakemsar)

        hakemsar = TimeOfDay.Now.Millisecond Mod 52
        While swap(hakemsar) = Nothing
            hakemsar = TimeOfDay.Now.Millisecond Mod 52
        End While
        img = Image.FromFile(path + swap(hakemsar) + ".bmp")
        cent4.Image = img
        Array.Clear(swap, hakemsar, 1)
        vasat(3) = Cards(hakemsar)
    End Sub
    Public Sub forhokm()
        Array.Copy(Cards, swap, 52)
        dist(5)
        cent1.Visible = False
        cent2.Visible = False
        cent3.Visible = False
        cent4.Visible = False
        sort(5)
        If hakem = 2 Then
            selecthokm.ShowDialog()
        Else
            Dim types As Array = Array.CreateInstance(GetType(Integer), 4)
            Dim cardNo As Integer
            Dim cardtype As String
            For index As Integer = 0 To 4
                cardtype = playerscards(hakem, index).Substring(2)
                cardNo = Convert.ToInt32(playerscards(hakem, index).Substring(0, 2))
                Select Case cardtype
                    Case "اسپیک"
                        types(0) = types(0) + cardNo
                    Case "خشت"
                        types(1) = types(1) + cardNo
                    Case "دل"
                        types(2) = types(2) + cardNo
                    Case "گیشنیز"
                        types(3) = types(3) + cardNo
                End Select
            Next
            Dim max As Integer
            Dim type As Integer
            For index As Integer = 0 To 3
                If types(index) > max Then
                    max = types(index)
                    type = index
                End If
            Next
            Select Case type
                Case 0
                    hokm = "اسپیک"
                    lbhokmName.Text = "اسپیک"
                Case 1
                    hokm = "خشت"
                    lbhokmName.Text = "خشت"
                Case 2
                    hokm = "دل"
                    lbhokmName.Text = "دل"
                Case 3
                    hokm = "گیشنیز"
                    lbhokmName.Text = "گیشنیز"
            End Select


        End If
        Timer1.Interval = 500
        Timer1.Start()

    End Sub

    Private Sub t_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t.Tick
        t.Stop()
        forhokm()
    End Sub
    Sub sort(ByVal count As Integer)

        For index As Integer = 0 To 3

            For index1 As Integer = 0 To 3
                typescounts(index, index1) = 0
            Next

        Next

        For p As Integer = 0 To 3
            Dim typesCount(3) As Integer
            For index As Integer = 0 To count - 1
                Select Case playerscards(p, index).ToString().Substring(2)
                    Case "اسپیک"
                        typesCount(1) = typesCount(1) + 1
                        typescounts(p, 0) = typescounts(p, 0) + 1
                    Case "خشت"
                        typesCount(2) = typesCount(2) + 1
                        typescounts(p, 1) = typescounts(p, 1) + 1
                    Case "گیشنیز"
                        typesCount(3) = typesCount(3) + 1
                        typescounts(p, 2) = typescounts(p, 2) + 1
                    Case "دل"
                        typescounts(p, 3) = typescounts(p, 3) + 1
                End Select
            Next
            typesCount(2) = typesCount(1) + typesCount(2)
            typesCount(3) = typesCount(3) + typesCount(2)
            Dim img As Image
            Dim types() As String = {"اسپیک", "خشت", "گیشنیز", "دل"}

            For t As Integer = 0 To 3
                For index As Integer = typesCount(t) To count - 1

                    For index1 As Integer = index + 1 To count - 1

                        If playerscards(p, index1).ToString().Substring(2) = types(t) Then
                            If playerscards(p, index).ToString().Substring(2) = types(t) Then
                                If Convert.ToInt32(playerscards(p, index1).ToString().Substring(0, 2)) > Convert.ToInt32(playerscards(p, index).ToString().Substring(0, 2)) Then
                                    Dim tmp As String
                                    tmp = playerscards(p, index).ToString()
                                    playerscards(p, index) = playerscards(p, index1)
                                    playerscards(p, index1) = tmp
                                    If p = 2 Then
                                        img = PBs(p, index).Image
                                        PBs(p, index).Image = PBs(p, index1).Image
                                        PBs(p, index1).Image = img
                                    End If
                                End If
                            Else
                                Dim tmp As String
                                tmp = playerscards(p, index).ToString()
                                playerscards(p, index) = playerscards(p, index1)
                                playerscards(p, index1) = tmp
                                If p = 2 Then
                                    img = PBs(p, index).Image
                                    PBs(p, index).Image = PBs(p, index1).Image
                                    PBs(p, index1).Image = img

                                End If


                            End If
                        End If

                    Next
                Next
            Next
        Next
    End Sub
    Sub dist(ByVal count As Integer)

        Dim begin As Integer
        Select Case count
            Case 5
                begin = 0
            Case 13
                begin = 5
        End Select
        For a As Integer = hakem To hakem + 3
            Dim playerno As Integer
            If (a > 3) Then
                playerno = a Mod 4
            Else
                playerno = a
            End If
            For index As Integer = begin To count - 1
                Dim card As Integer = TimeOfDay.Now.Millisecond Mod remindedcard
                playerscards(playerno, index) = swap(card)
                For i As Integer = card To remindedcard - 2
                    swap(i) = swap(i + 1)
                Next
                swap(remindedcard - 1) = Nothing
                remindedcard -= 1
                If playerno = 2 Then
                    Dim img As Image = Image.FromFile(path + playerscards(playerno, index) + ".bmp")

                    PBs(2, index).Visible = True
                    PBs(2, index).Image = img

                Else
                    Dim img As Image = Image.FromFile(path + "پشت.bmp")
                    PBs(playerno, index).Visible = True
                    PBs(playerno, index).Image = img
                End If

            Next
        Next
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        dist(13)
        sort(13)
        playerbegin = hakem
        Dim player As Integer = hakem
        For index As Integer = hakem To hakem + 3
            player = index

            If index > 3 Then
                player = index Mod 4
            End If
            If player = 2 Then
                Exit For
            End If
            play(player, index - hakem)
        Next


    End Sub
    Sub play(ByVal player As Integer, ByVal sequence As Integer)
        Dim playerNext As Integer = player + 1
        Dim yar As Integer = player + 2
        Dim lastplayer As Integer = player + 3
        'Dim playerbefor As Integer = player - 1
        'If player <> playerbegin Then
        'If playerbefor = -1 Then
        'playerbefor = 3
        'End If
        'End If
        If playerNext > 3 Then
            playerNext = playerNext Mod 4
        End If
        If yar > 3 Then
            yar = yar Mod 4
        End If
        If lastplayer > 3 Then
            lastplayer = lastplayer Mod 4
        End If
        Dim played As Boolean = False
        If sequence = 0 Then
            Dim sartarin As Integer = 0
            Dim sartarinindex As Integer = -1
            For index As Integer = 0 To remindedcount4players - 1
                If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) = sars(typesindex(playerscards(player, index).ToString().Substring(2))) And playerscards(player, index).ToString().Substring(2) <> hokm Then
                    If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) > sartarin _
                    And javab(playerNext, typesindex(playerscards(player, index).ToString().Substring(2))) = False _
                    And javab(lastplayer, typesindex(playerscards(player, index).ToString().Substring(2))) = False _
                    Then
                        sartarin = Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2))
                        sartarinindex = index
                    End If

                End If

            Next
            If sartarin <> 0 And sartarinindex <> -1 Then
                If playerscards(player, sartarinindex).ToString().Substring(2) <> hokm Then
                    Dim type As Integer = typesindex(playerscards(player, sartarinindex).ToString().Substring(2))
                    If cuted(playerNext, type) = False And cuted(lastplayer, type) = False _
                    And cutable(playerNext, type) = False And cutable(lastplayer, type) = False Then
                        playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, sartarinindex), 0)
                        playcard(player, sartarinindex)
                        Exit Sub
                    End If
                End If
            End If

            Dim hokmlazem As Integer = 0
            For index As Integer = 0 To remindedcount4players - 1
                If playerscards(player, index).ToString().Substring(2) = hokm Then
                    hokmlazem += Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2))
                End If
            Next

            If typescounts(player, typesindex(hokm)) >= remindedcounts(typesindex(hokm)) / 2 Or typescounts(player, typesindex(hokm)) >= remindedcount4players / 2 Or hokmlazem >= 60 Then

                For index As Integer = 0 To remindedcount4players - 1
                    If playerscards(player, index).ToString().Substring(2) = hokm Then
                        javab(player, typesindex(hokm)) = True
                        If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) = sars(typesindex(hokm)) Then
                            playerplayed(player, 13 - remindedcount4players) = New playedcard()
                            playerplayed(player, 13 - remindedcount4players).cardname = playerscards(player, index).ToString()
                            playerplayed(player, 13 - remindedcount4players).sequence = 0
                            playcard(player, index)
                            played = True
                            'sars(typesindex(hokm)) -= 1
                            Exit Sub
                        Else
                            If typescounts(yar, typesindex(hokm)) <> 0 Then
                                playerplayed(player, 13 - remindedcount4players) = New playedcard()
                                playerplayed(player, 13 - remindedcount4players).cardname = playerscards(player, index + typescounts(player, typesindex(hokm)) - 1).ToString()
                                playerplayed(player, 13 - remindedcount4players).sequence = 0
                                playcard(player, index + typescounts(player, typesindex(hokm)) - 1)
                                played = True
                                Exit Sub
                            End If
                        End If
                    End If
                Next


            End If
            For index As Integer = 0 To 3
                If (cuted(yar, index) = True Or cutable(yar, index) = True) And cuted(playerNext, index) = False And cutable(playerNext, index) = False _
                And cuted(lastplayer, index) = False And cutable(lastplayer, index) = False _
                And javab(playerNext, index) = False And javab(lastplayer, index) = False Then

                    For index1 As Integer = 0 To remindedcount4players - 1
                        If playerscards(player, index1).ToString().Substring(2) = typesname(index) Then
                            playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index1 + typescounts(player, index) - 1), 0)
                            playcard(player, index1 + typescounts(player, index) - 1)
                            Exit Sub
                        End If

                    Next

                End If
            Next

            For index1 As Integer = 0 To 3
                If javab(yar, index1) = True And javab(playerNext, index1) = False And javab(lastplayer, index1) = False Then
                    For index As Integer = 0 To remindedcount4players - 1
                        If typesindex(playerscards(player, index).ToString().Substring(2)) = index1 Then
                            If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) = sars(index1) Then
                                playerplayed(player, 13 - remindedcount4players) = New playedcard()
                                playerplayed(player, 13 - remindedcount4players).cardname = playerscards(player, index).ToString()
                                playerplayed(player, 13 - remindedcount4players).sequence = 0
                                playcard(player, index)
                                played = True
                                'sars(typesindex(hokm)) -= 1
                                Exit Sub
                            Else
                                playerplayed(player, 13 - remindedcount4players) = New playedcard()
                                playerplayed(player, 13 - remindedcount4players).cardname = playerscards(player, index + typescounts(player, index1) - 1).ToString()
                                playerplayed(player, 13 - remindedcount4players).sequence = 0
                                playcard(player, index + typescounts(player, index1) - 1)
                                played = True
                                Exit Sub
                            End If
                        End If
                    Next
                End If
            Next

            If remindedcount4players < 13 Then
                For index As Integer = 12 - remindedcount4players To 0 Step -1
                    If playerplayed(yar, index).sequence = 0 Then
                        If typescounts(player, typesindex(playerplayed(yar, index).cardname.Substring(2))) > 0 Then
                            If Convert.ToInt32(playerplayed(yar, index).cardname.Substring(0, 2)) < sars(typesindex(playerplayed(yar, index).cardname.Substring(2))) _
                            And Convert.ToInt32(playerplayed(yar, index).cardname.Substring(0, 2)) < 10 Then

                                For index1 As Integer = 0 To remindedcount4players - 1
                                    If playerscards(player, index1).ToString().Substring(2) = playerplayed(yar, index).cardname.Substring(2) Then
                                        If cutable(lastplayer, typesindex(playerscards(player, index1).ToString().Substring(2))) = False _
                                        And cutable(playerNext, typesindex(playerscards(player, index1).ToString().Substring(2))) = False Then
                                            playerplayed(player, 13 - remindedcount4players) = New playedcard()
                                            playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index1 + typescounts(player, typesindex(playerplayed(yar, index).cardname.Substring(2))) - 1), 0)
                                            playcard(player, index1 + typescounts(player, typesindex(playerplayed(yar, index).cardname.Substring(2))) - 1)
                                            played = True
                                            Exit Sub
                                        End If
                                    End If
                                Next
                            End If
                        End If

                    End If
                Next

            End If

            If played = False Then
                For index As Integer = 0 To remindedcount4players - 1
                    If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) = sars(typesindex(playerscards(player, index).ToString().Substring(2))) - 1 And playerscards(player, index).ToString().Substring(2) <> hokm Then ' Then
                        Dim takplayed As Boolean = False
                        For index1 As Integer = 0 To 13 - remindedcount4players - 1
                            If playerplayed(player, index1).sequence = 0 And playerplayed(player, index1).cardname.Substring(2) = playerscards(player, index).ToString().Substring(2) And _
                            sarsbefor(typesindex(playerscards(player, index).ToString().Substring(2))) = sars(typesindex(playerscards(player, index).ToString().Substring(2))) Then
                                takplayed = True
                            End If
                        Next
                        If takplayed = False Then
                            If cutable(lastplayer, typesindex(playerscards(player, index).ToString().Substring(2))) = False _
                            And cutable(playerNext, typesindex(playerscards(player, index).ToString().Substring(2))) = False _
                            And javab(lastplayer, typesindex(playerscards(player, index).ToString().Substring(2))) = False _
                            And javab(playerNext, typesindex(playerscards(player, index).ToString().Substring(2))) = False Then
                                javab(player, typesindex(playerscards(player, index).ToString().Substring(2))) = True
                                sarsbefor(typesindex(playerscards(player, index).ToString().Substring(2))) = sars(typesindex(playerscards(player, index).ToString().Substring(2)))
                                playerplayed(player, 13 - remindedcount4players) = New playedcard()
                                playerplayed(player, 13 - remindedcount4players).cardname = playerscards(player, index + typescounts(player, typesindex(playerscards(player, index).ToString().Substring(2))) - 1).ToString()
                                playerplayed(player, 13 - remindedcount4players).sequence = 0
                                playcard(player, index + typescounts(player, typesindex(playerscards(player, index).ToString().Substring(2))) - 1)
                                played = True

                                Exit Sub
                            End If
                        Else
                            playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index + 1), 0)
                            playcard(player, index + 1)
                            Exit Sub
                        End If
                    End If
                Next
            End If
            If played = False Then
                For index As Integer = 0 To 3
                    If typescounts(player, index) = 1 And typesname(index) <> hokm And typescounts(player, typesindex(hokm)) > 0 Then

                        For index1 As Integer = 0 To remindedcount4players - 1
                            If playerscards(player, index1).ToString().Substring(2) = typesname(index) And (Convert.ToInt32(playerscards(player, index1).ToString().Substring(0, 2)) <= 10 Or Convert.ToInt32(playerscards(player, index1).ToString().Substring(0, 2)) = sars(typesindex(playerscards(player, index1).ToString().Substring(2)))) _
                            And javab(playerNext, typesindex(playerscards(player, index1).ToString().Substring(2))) = False _
                            And javab(lastplayer, typesindex(playerscards(player, index1).ToString().Substring(2))) = False Then
                                If cutable(lastplayer, typesindex(playerscards(player, index1).ToString().Substring(2))) = False _
                                And cutable(playerNext, typesindex(playerscards(player, index1).ToString().Substring(2))) = False Then
                                    javab(player, typesindex(playerscards(player, index1).ToString().Substring(2))) = True
                                    playerplayed(player, 13 - remindedcount4players) = New playedcard()
                                    playerplayed(player, 13 - remindedcount4players).cardname = playerscards(player, index1).ToString()
                                    playerplayed(player, 13 - remindedcount4players).sequence = 0
                                    playcard(player, index1)
                                    played = True

                                    Exit Sub
                                End If
                            End If
                        Next

                    End If
                Next
            End If

            
            If played = False Then
                For index As Integer = 0 To 3
                    If typescounts(player, index) = 2 And typesname(index) <> hokm And typescounts(player, typesindex(hokm)) > 0 Then

                        For index1 As Integer = 0 To remindedcount4players - 1
                            If playerscards(player, index1).ToString().Substring(2) = typesname(index) And (Convert.ToInt32(playerscards(player, index1).ToString().Substring(0, 2)) > 10 Or Convert.ToInt32(playerscards(player, index1).ToString().Substring(0, 2)) = sars(typesindex(playerscards(player, index1).ToString().Substring(2)))) _
                            And javab(playerNext, typesindex(playerscards(player, index1).ToString().Substring(2))) _
                            And javab(lastplayer, typesindex(playerscards(player, index1).ToString().Substring(2))) Then
                                If cutable(lastplayer, typesindex(playerscards(player, index1).ToString().Substring(2))) = False _
                                And cutable(playerNext, typesindex(playerscards(player, index1).ToString().Substring(2))) = False Then
                                    javab(player, typesindex(playerscards(player, index1).ToString().Substring(2))) = True
                                    playerplayed(player, 13 - remindedcount4players) = New playedcard()
                                    playerplayed(player, 13 - remindedcount4players).cardname = playerscards(player, index1).ToString()
                                    playerplayed(player, 13 - remindedcount4players).sequence = 0
                                    playcard(player, index1)
                                    played = True

                                    Exit Sub
                                End If
                            End If
                        Next

                    End If
                Next
            End If
            For index As Integer = 0 To remindedcount4players - 1
                If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) = sars(typesindex(playerscards(player, index).ToString().Substring(2))) - 1 And playerscards(player, index).ToString().Substring(2) <> hokm Then
                    If index + 1 <= remindedcount4players - 1 Then
                        If typesindex(playerscards(player, index).ToString().Substring(2)) = typesindex(playerscards(player, index + 1).ToString().Substring(2)) _
                        And Convert.ToInt32(playerscards(player, index + 1).ToString().Substring(0, 2)) = sars(typesindex(playerscards(player, index + 1).ToString().Substring(2))) - 2 _
                        And javab(playerNext, typesindex(playerscards(player, index).ToString().Substring(2))) = False _
                        And javab(lastplayer, typesindex(playerscards(player, index).ToString().Substring(2))) = False Then
                            If cutable(lastplayer, typesindex(playerscards(player, index).ToString().Substring(2))) = False _
                            And cutable(playerNext, typesindex(playerscards(player, index).ToString().Substring(2))) = False Then
                                javab(player, typesindex(playerscards(player, index).ToString().Substring(2))) = True
                                playerplayed(player, 13 - remindedcount4players) = New playedcard()
                                playerplayed(player, 13 - remindedcount4players).cardname = playerscards(player, index + 1).ToString()
                                playerplayed(player, 13 - remindedcount4players).sequence = 0
                                playcard(player, index + 1)
                                played = True

                                Exit Sub
                            End If
                        End If
                    End If
                End If
            Next
            For index As Integer = 0 To remindedcount4players - 1
                If playerscards(player, index).ToString().Substring(2) = hokm Then
                    If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) = sars(typesindex(hokm)) Then
                        playerplayed(player, 13 - remindedcount4players) = New playedcard()
                        playerplayed(player, 13 - remindedcount4players).cardname = playerscards(player, index).ToString()
                        playerplayed(player, 13 - remindedcount4players).sequence = 0
                        playcard(player, index)
                        played = True
                        'sars(typesindex(hokm)) -= 1
                        Exit Sub
                    End If
                End If
            Next
            sartarin = 0
            sartarinindex = 0
            For index As Integer = 0 To remindedcount4players - 1
                If Convert.ToInt32(playerscards(player, index).ToString.Substring(0, 2)) > sartarin And playerscards(player, index).ToString.Substring(2) <> hokm _
                And cutable(playerNext, typesindex(playerscards(player, index).ToString.Substring(2))) = False _
                And cutable(lastplayer, typesindex(playerscards(player, index).ToString.Substring(2))) = False _
                And javab(playerNext, typesindex(playerscards(player, index).ToString.Substring(2))) = False _
                And javab(lastplayer, typesindex(playerscards(player, index).ToString.Substring(2))) = False Then
                    sartarin = Convert.ToInt32(playerscards(player, index).ToString.Substring(0, 2))
                    sartarinindex = index
                End If
            Next
            If sartarin = 0 Then
                For index As Integer = 0 To remindedcount4players - 1
                    If Convert.ToInt32(playerscards(player, index).ToString.Substring(0, 2)) > sartarin And playerscards(player, index).ToString.Substring(2) <> hokm _
                    And cutable(playerNext, typesindex(playerscards(player, index).ToString.Substring(2))) = False _
                    And cutable(lastplayer, typesindex(playerscards(player, index).ToString.Substring(2))) = False Then
                        sartarin = Convert.ToInt32(playerscards(player, index).ToString.Substring(0, 2))
                        sartarinindex = index
                    End If
                Next
            End If
            playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, sartarinindex), 0)
            playcard(player, sartarinindex)
        End If
        If sequence = 1 Then
            If vasat(playerbegin).ToString().Substring(2) = hokm And typescounts(player, typesindex(hokm)) = 0 Then
                If ignor(sequence, player, hokm) = True Then
                    Exit Sub
                End If

            End If

            For index As Integer = 0 To remindedcount4players - 1
                If playerscards(player, index).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then
                    If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) Then

                        'Dim index1 As Integer
                        'index1 = index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1
                        'If Convert.ToInt32(playerscards(player, index1).ToString().Substring(0, 2)) < Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) Then

                        'For index2 As Integer = index1 To index Step -1
                        'If Convert.ToInt32(playerscards(player, index2).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) Then
                        playerplayed(player, 13 - remindedcount4players) = New playedcard()
                        playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index), 1)
                        playcard(player, index)
                        played = True
                        Exit Sub


                    Else
                        playerplayed(player, 13 - remindedcount4players) = New playedcard()
                        playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1), 1)
                        playcard(player, index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1)
                        played = True
                        Exit Sub
                    End If
                End If
            Next
            'Else
            'playerplayed(player, 13 - remindedcount4players) = New playedcard()
            'playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1), 1)
            'playcard(player, index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1)
            'played = True
            'Exit Sub
            'End If

            'End If
            'Next
            If typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) = 0 And vasat(playerbegin).ToString().Substring(2) <> hokm Then
                If typescounts(player, typesindex(hokm)) <> 0 Then
                    For index As Integer = 0 To remindedcount4players - 1
                        If playerscards(player, index).ToString().Substring(2) = hokm Then
                            If cutable(playerNext, typesindex(vasat(playerbegin).ToString().Substring(2))) = True Then
                                playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index), sequence)
                                playcard(player, index)
                                Exit Sub
                            Else

                                playerplayed(player, 13 - remindedcount4players) = New playedcard()
                                playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index + typescounts(player, typesindex(hokm)) - 1), 1)
                                playcard(player, index + typescounts(player, typesindex(hokm)) - 1)
                                played = True
                                Exit Sub
                            End If
                        End If
                    Next
                Else
                    If ignor(sequence, player, vasat(playerbegin).ToString().Substring(2)) = True Then
                        Exit Sub
                    End If

                End If
            End If
            If vasat(playerbegin).ToString().Substring(2) = hokm Then
                If typescounts(player, typesindex(hokm)) <> 0 Then

                    For index As Integer = 0 To remindedcount4players - 1
                        Dim index1 As Integer = index + typescounts(player, typesindex(hokm)) - 1
                        If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) Then


                            For index2 As Integer = index1 To index Step -1
                                If Convert.ToInt32(playerscards(player, index2).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) Then
                                    playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index2), sequence)
                                    playcard(player, index2)
                                    Exit Sub
                                End If
                            Next
                        Else
                            playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index1), sequence)
                            playcard(player, index1)
                            Exit Sub
                        End If

                    Next
                Else
                    If ignor(sequence, player, hokm) = True Then
                        Exit Sub
                    End If

                End If
            End If
            If ignor(sequence, player, vasat(playerbegin).ToString().Substring(2)) = True Then
                Exit Sub
            End If
        End If
        If sequence = 2 Then
            Dim playerbefor As Integer
            playerbefor = player - 1
            If playerbefor = -1 Then
                playerbefor = 3
            End If
            If vasat(playerbegin).ToString().Substring(2) = hokm Then
                For index As Integer = 0 To remindedcount4players - 1
                    If playerscards(player, index).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then
                        Dim dif As Integer = Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) - Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2))
                        If dif > 0 And dif <= typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) Then


                            If Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) + 1 = Convert.ToInt32(playerscards(player, index + dif - 1).ToString().Substring(0, 2)) Then
                                Dim index1 As Integer = index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1
                                playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index1), sequence)
                                playcard(player, index1)
                                Exit Sub
                            End If


                        End If
                        If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) < Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) Or Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) < Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) Then
                            Dim index1 As Integer = index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1
                            playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index1), sequence)
                            playcard(player, index1)
                            Exit Sub
                        End If
                        playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index), sequence)
                        playcard(player, index)
                        Exit Sub
                    End If
                Next
                If ignor(sequence, player, hokm) = True Then
                    Exit Sub
                End If

            End If
            If vasat(playerbegin).ToString().Substring(2) <> hokm And vasat(playerbefor).ToString().Substring(2) = hokm Then
                If typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) <> 0 Then
                    For index As Integer = 0 To remindedcount4players - 1
                        If playerscards(player, index).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then
                            playerplayed(player, 13 - remindedcount4players) = New playedcard()
                            playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1), 2)
                            playcard(player, index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1)
                            played = True
                            Exit Sub
                        End If
                    Next
                Else
                    If typescounts(player, typesindex(hokm)) <> 0 Then
                        For index0 As Integer = 0 To remindedcount4players - 1
                            If playerscards(player, index0).ToString().Substring(2) = hokm Then
                                If Convert.ToInt32(playerscards(player, index0).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(playerbefor).ToString().Substring(0, 2)) Then
                                    If cutable(playerNext, typesindex(vasat(playerbegin).ToString().Substring(2))) = True Then
                                        playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index0), sequence)
                                        playcard(player, index0)
                                        Exit Sub
                                    Else
                                        Dim index1 As Integer = index0 + typescounts(player, typesindex(hokm)) - 1
                                        For index As Integer = index1 To index0 Step -1
                                            If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(playerbefor).ToString().Substring(0, 2)) Then
                                                playerplayed(player, 13 - remindedcount4players) = New playedcard()
                                                playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index), 2)
                                                playcard(player, index)
                                                played = True
                                                Exit Sub
                                            End If
                                        Next
                                    End If
                                Else
                                    If ignor(sequence, player, vasat(playerbegin).ToString().Substring(2)) = True Then
                                        Exit Sub
                                    End If

                                End If
                            End If
                        Next
                    End If


                End If
            Else


                If Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) = sars(typesindex(vasat(playerbegin).ToString().Substring(2))) Then
                    If typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) <> 0 Then
                        For index As Integer = 0 To remindedcount4players - 1
                            If playerscards(player, index).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then
                                playerplayed(player, 13 - remindedcount4players) = New playedcard()
                                playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1), 2)
                                playcard(player, index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1)
                                played = True
                                Exit Sub
                            End If
                        Next
                    Else
                        If ignor(sequence, player, vasat(playerbegin).ToString().Substring(2)) = True Then
                            Exit Sub
                        End If

                    End If
                End If
                If Convert.ToInt32((vasat(playerbegin).ToString().Substring(0, 2))) = sars(typesindex(vasat(playerbegin).ToString().Substring(2))) - 1 Then

                    For index As Integer = 0 To remindedcount4players - 1
                        If playerscards(player, index).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) And Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) = sars(typesindex(vasat(playerbegin).ToString().Substring(2))) Then
                            Dim index1 As Integer = index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1
                            playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index1), sequence)
                            playcard(player, index1)
                            Exit Sub
                        End If
                    Next

                End If

                For index As Integer = 0 To remindedcount4players - 1
                    If playerscards(player, index).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then
                        Dim dif As Integer = Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) - Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2))
                        If dif > 0 And dif <= typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) Then


                            If Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) + 1 = Convert.ToInt32(playerscards(player, index + dif - 1).ToString().Substring(0, 2)) Then
                                Dim index1 As Integer = index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1
                                playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index1), sequence)
                                playcard(player, index1)
                                Exit Sub
                            End If

                        Else
                            If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) < Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) Or _
                                Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) < Convert.ToInt32(vasat(playerbefor).ToString().Substring(0, 2)) Then
                                Dim index1 As Integer = index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1
                                playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index1), sequence)
                                playcard(player, index1)
                                Exit Sub
                            Else
                                playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index), sequence)
                                playcard(player, index)
                                Exit Sub
                            End If
                        End If
                        Exit For
                    End If
                Next

                If typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) <> 0 Then
                    For index As Integer = 0 To remindedcount4players - 1
                        If playerscards(player, index).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then

                            If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(playerbefor).ToString().Substring(0, 2)) And vasat(playerbefor).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) And vasat(playerbefor).ToString().Substring(2) <> hokm Then
                                playerplayed(player, 13 - remindedcount4players) = New playedcard()
                                playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index), 2)
                                playcard(player, index)
                                played = True
                                Exit Sub
                            Else
                                playerplayed(player, 13 - remindedcount4players) = New playedcard()
                                playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1), 2)
                                playcard(player, index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1)
                                played = True
                                Exit Sub
                            End If
                        End If
                    Next
                Else
                    If Convert.ToInt32(vasat(playerbefor).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) And vasat(playerbefor).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) And vasat(playerbegin).ToString().Substring(2) <> hokm Then
                        For index As Integer = 0 To remindedcount4players - 1
                            If playerscards(player, index).ToString().Substring(2) = hokm Then
                                If cutable(playerNext, typesindex(vasat(playerbegin).ToString().Substring(2))) = True Then
                                    playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index), sequence)
                                    playcard(player, index)
                                    Exit Sub
                                Else
                                    playerplayed(player, 13 - remindedcount4players) = New playedcard()
                                    playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index + typescounts(player, typesindex(hokm)) - 1), 2)
                                    playcard(player, index + typescounts(player, typesindex(hokm)) - 1)
                                    played = True
                                    Exit Sub
                                End If
                            End If
                        Next

                    End If
                End If

                For index As Integer = 0 To remindedcount4players - 1
                    If playerscards(player, index).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then
                        playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index), sequence)
                        playcard(player, index)
                        Exit Sub
                    End If

                Next
                If typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) = 0 Then

                    For index As Integer = 0 To remindedcount4players - 1
                        If playerscards(player, index).ToString().Substring(2) = hokm Then
                            If cutable(playerNext, typesindex(vasat(playerbegin).ToString().Substring(2))) = True Then
                                playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index), sequence)
                                playcard(player, index)
                                Exit Sub
                            Else
                                Dim index1 As Integer = index + typescounts(player, typesindex(hokm)) - 1
                                playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index1), sequence)
                                playcard(player, index1)
                                Exit Sub
                            End If
                        End If

                    Next

                End If

            End If
            If ignor(sequence, player, vasat(playerbegin).ToString().Substring(2)) = True Then
                Exit Sub
            End If

        End If
        If sequence = 3 Then
            Dim playerbefor1, playerbefor2 As Integer
            playerbefor1 = player - 1
            playerbefor2 = player - 2
            If playerbefor1 = -1 Then
                playerbefor1 = 3
                playerbefor2 = 2
            End If
            If playerbefor2 = -1 Then
                playerbefor2 = 3
            End If
            If typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) <> 0 And vasat(playerbegin).ToString().Substring(2) <> hokm Then
                If vasat(playerbefor1).ToString().Substring(2) = hokm Or vasat(playerbefor2).ToString().Substring(2) = hokm _
                    Or Convert.ToInt32(vasat(playerbefor1).ToString().Substring(0, 2)) = sars(typesindex(vasat(playerbegin).ToString().Substring(2))) _
                    Or Convert.ToInt32(vasat(playerbefor2).ToString().Substring(0, 2)) = sars(typesindex(vasat(playerbegin).ToString().Substring(2))) _
                    Or Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) = sars(typesindex(vasat(playerbegin).ToString().Substring(2))) Then

                    For index As Integer = 0 To remindedcount4players - 1

                        If playerscards(player, index).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then

                            playerplayed(player, 13 - remindedcount4players) = New playedcard()
                            playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1), 3)
                            playcard(player, index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1)
                            played = True
                            Exit Sub
                        End If
                    Next
                End If
            End If
            Dim sar0 As Integer = -1
            For index1 As Integer = playerbegin To playerbegin + 2
                Dim index As Integer = index1
                If index1 > 3 Then
                    index = index1 Mod 4
                End If
                If sar0 = -1 Then
                    sar0 = playerbegin
                    If vasat(index).ToString().Substring(2) = hokm Then
                        sar0 = index
                    Else
                        If vasat(index).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) And Convert.ToInt32(vasat(index).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) Then
                            sar0 = index
                        End If
                    End If
                Else
                    If vasat(index).ToString().Substring(2) = hokm Then
                        If vasat(sar0).ToString().Substring(2) = hokm Then
                            If Convert.ToInt32(vasat(index).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(sar0).ToString().Substring(0, 2)) Then
                                sar0 = index
                            End If
                        Else
                            sar0 = index
                        End If
                    Else
                        If vasat(index).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then
                            If vasat(sar0).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then
                                If Convert.ToInt32(vasat(index).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(sar0).ToString().Substring(0, 2)) Then
                                    sar0 = index
                                End If
                            End If
                        End If
                    End If
                End If
            Next
            If sar0 = playerbefor2 Then
                For index As Integer = 0 To remindedcount4players - 1

                    If playerscards(player, index).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then

                        playerplayed(player, 13 - remindedcount4players) = New playedcard()
                        playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1), 3)
                        playcard(player, index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1)
                        played = True
                        Exit Sub
                    End If
                Next
                If typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) = 0 Then
                    If ignor(sequence, player, vasat(playerbegin).ToString().Substring(2)) = True Then
                        Exit Sub
                    End If

                End If
                playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, remindedcount4players - 1), sequence)
                playcard(player, remindedcount4players - 1)

            Else
                If vasat(playerbegin).ToString().Substring(2) = hokm Then
                    If typescounts(player, typesindex(hokm)) = 0 Then
                        If ignor(sequence, player, hokm) = True Then
                            Exit Sub
                        End If

                    Else

                        For index As Integer = 0 To remindedcount4players - 1
                            If playerscards(player, index).ToString().Substring(2) = hokm Then
                                If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) < Convert.ToInt32(vasat(sar0).ToString().Substring(0, 2)) Then
                                    Dim index1 = index + typescounts(player, typesindex(hokm)) - 1
                                    playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index1), sequence)
                                    playcard(player, index1)
                                    Exit Sub
                                Else
                                    Dim index1 = index + typescounts(player, typesindex(hokm)) - 1

                                    For index2 As Integer = index1 To index Step -1
                                        If Convert.ToInt32(playerscards(player, index2).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(sar0).ToString().Substring(0, 2)) Then
                                            playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index2), sequence)
                                            playcard(player, index2)
                                            Exit Sub
                                        End If
                                    Next

                                End If
                            End If

                        Next

                    End If
                Else
                    If vasat(sar0).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then

                        For index As Integer = 0 To remindedcount4players - 1
                            If playerscards(player, index).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then
                                Dim riz As Integer = index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1
                                If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(sar0).ToString().Substring(0, 2)) Then

                                    For index1 As Integer = riz To index Step -1
                                        If Convert.ToInt32(playerscards(player, index1).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(sar0).ToString().Substring(0, 2)) Then
                                            playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index1), 3)
                                            playcard(player, index1)
                                            Exit Sub
                                        End If
                                    Next
                                Else
                                    playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, riz), 3)
                                    playcard(player, riz)
                                    Exit Sub
                                End If
                            End If
                        Next
                        If typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) = 0 Then
                            If typescounts(player, typesindex(hokm)) <> 0 Then

                                For index As Integer = 0 To remindedcount4players - 1
                                    If playerscards(player, index).ToString().Substring(2) = hokm Then
                                        Dim index1 As Integer = index + typescounts(player, typesindex(hokm)) - 1
                                        playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index1), sequence)
                                        playcard(player, index1)
                                        Exit Sub
                                    End If
                                Next
                            Else
                                If ignor(sequence, player, vasat(playerbegin).ToString().Substring(2)) = True Then
                                    Exit Sub
                                End If

                            End If
                        End If
                    End If
                    If vasat(playerbegin).ToString().Substring(2) <> hokm And vasat(sar0).ToString().Substring(2) = hokm Then
                        If typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) = 0 Then

                            For index As Integer = 0 To remindedcount4players - 1
                                If playerscards(player, index).ToString().Substring(2) = hokm Then
                                    If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(sar0).ToString().Substring(0, 2)) Then
                                        Dim index1 As Integer = index + typescounts(player, typesindex(hokm)) - 1

                                        For index2 As Integer = index1 To index Step -1
                                            If Convert.ToInt32(playerscards(player, index2).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(sar0).ToString().Substring(0, 2)) Then
                                                playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index2), sequence)
                                                playcard(player, index2)
                                                Exit Sub
                                            End If

                                        Next

                                    End If
                                End If

                            Next
                            If ignor(sequence, player, vasat(playerbegin).ToString().Substring(2)) = True Then
                                Exit Sub
                            End If

                        End If
                    End If
                End If

                For index As Integer = 0 To remindedcount4players - 1
                    If playerscards(player, index).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then
                        Dim index1 = index + typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) - 1
                        If vasat(sar0).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then
                            If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(sar0).ToString().Substring(0, 2)) Then
                                For index2 As Integer = index1 To index Step -1
                                    If Convert.ToInt32(playerscards(player, index2).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(sar0).ToString().Substring(0, 2)) Then
                                        playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index2), sequence)
                                        playcard(player, index2)
                                        Exit Sub
                                    End If

                                Next
                            Else
                                playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index1), sequence)
                                playcard(player, index1)
                                Exit Sub
                            End If
                        Else
                            playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index1), sequence)
                            playcard(player, index1)
                            Exit Sub
                        End If
                    End If
                Next

                For index As Integer = 0 To remindedcount4players - 1
                    If playerscards(player, index).ToString().Substring(2) = hokm Then
                        Dim index1 = index + typescounts(player, typesindex(hokm)) - 1
                        If vasat(sar0).ToString().Substring(2) <> hokm Then
                            playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index1), sequence)
                            playcard(player, index1)
                            Exit Sub
                        Else
                            If Convert.ToInt32(vasat(sar0).ToString().Substring(0, 2)) < Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) Then

                                For index2 As Integer = index1 To index Step -1

                                    If Convert.ToInt32(vasat(sar0).ToString().Substring(0, 2)) < Convert.ToInt32(playerscards(player, index2).ToString().Substring(0, 2)) Then
                                        playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, index2), sequence)
                                        playcard(player, index2)
                                        Exit Sub
                                    End If
                                Next
                            Else
                                If ignor(sequence, player, vasat(playerbegin).ToString().Substring(2)) = True Then
                                    Exit Sub
                                End If

                            End If
                        End If
                    End If

                Next

            End If
            If ignor(sequence, player, vasat(playerbegin).ToString().Substring(2)) = True Then
                Exit Sub
            End If
            If sar0 = playerbefor2 Then
                playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, 13 - remindedcount4players), sequence)
                playcard(player, 13 - remindedcount4players)
            Else
                If playerscards(player, 0).ToString().Substring(2) = hokm Then
                    If Convert.ToInt32(vasat(sar0).ToString().Substring(0, 2)) > Convert.ToInt32(playerscards(player, 0).ToString().Substring(0, 2)) Then
                        playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, 13 - remindedcount4players), sequence)
                        playcard(player, 13 - remindedcount4players)

                    End If
                End If
                playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, 0), sequence)
                playcard(player, 0)
            End If
        End If
    End Sub
    Public Function ignor(ByVal seq As Integer, ByVal player As Integer, ByVal zamine As String) As Boolean
        Dim kamtarindex0 As Integer = -1
        Dim kamtarindex1 As Integer = -1
        If typescounts(player, typesindex(zamine)) <> 0 Then
            Return False
        End If
        If typescounts(player, typesindex(hokm)) = remindedcount4players Then
            playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, remindedcount4players - 1), seq)
            playcard(player, remindedcount4players - 1)
            Return True
        End If
        For index As Integer = 0 To 3
            If typesname(index) <> hokm And zamine <> typesname(index) And typescounts(player, index) <> 0 Then
                Dim kamtar0, kamtar1 As Integer

                If kamtar0 = 0 Then
                    kamtar0 = typescounts(player, index)
                    kamtarindex0 = index
                End If
                If index <> kamtarindex0 Then
                    If typescounts(player, index) < kamtar0 Then
                        kamtarindex1 = kamtarindex0
                        kamtarindex0 = index
                        kamtar1 = kamtar0
                        kamtar0 = typescounts(player, index)
                    Else
                        If kamtarindex1 = -1 Then
                            kamtarindex1 = index
                            kamtar1 = typescounts(player, index)
                        Else
                            If typescounts(player, index) < kamtar1 Then
                                kamtarindex1 = index
                            End If
                        End If


                    End If
                End If
            End If
        Next
        If kamtarindex1 = -1 Then
            kamtarindex1 = kamtarindex0
        End If
        If typescounts(player, typesindex(hokm)) = 0 Then
            Dim temp As Integer
            temp = kamtarindex0
            kamtarindex0 = kamtarindex1
            kamtarindex1 = temp
        End If
        If zamine = hokm And typescounts(player, typesindex(hokm)) = 0 Then

            For index As Integer = 0 To remindedcount4players - 1
                If playerscards(player, index).ToString().Substring(2) <> typesname(kamtarindex0) And playerscards(player, index).ToString().Substring(2) <> typesname(kamtarindex1) Then
                    If Convert.ToInt32(playerscards(player, index + typescounts(player, typesindex(playerscards(player, index).ToString().Substring(2))) - 1).ToString().Substring(0, 2)) <= 5 Then
                        playerplayed(player, 13 - remindedcount4players) = New playedcard()
                        playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index + typescounts(player, typesindex(playerscards(player, index).ToString().Substring(2))) - 1), seq)
                        playcard(player, index + typescounts(player, typesindex(playerscards(player, index).ToString().Substring(2))) - 1)
                        Return True
                    Else
                        Exit For
                    End If
                End If
            Next

        End If
        For index As Integer = 0 To remindedcount4players - 1
            If playerscards(player, index).ToString().Substring(2) = typesname(kamtarindex0) Then
                If Convert.ToInt32(playerscards(player, index + typescounts(player, kamtarindex0) - 1).ToString().Substring(0, 2)) <= 5 Then
                    playerplayed(player, 13 - remindedcount4players) = New playedcard()
                    playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index + typescounts(player, kamtarindex0) - 1), seq)
                    playcard(player, index + typescounts(player, kamtarindex0) - 1)
                    Return True
                Else
                    Exit For
                End If

            End If
        Next
        For index As Integer = 0 To remindedcount4players - 1
            If playerscards(player, index).ToString().Substring(2) = typesname(kamtarindex1) Then
                If Convert.ToInt32(playerscards(player, index + typescounts(player, kamtarindex1) - 1).ToString().Substring(0, 2)) <= 5 Then
                    playerplayed(player, 13 - remindedcount4players) = New playedcard()
                    playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index + typescounts(player, kamtarindex1) - 1), seq)
                    playcard(player, index + typescounts(player, kamtarindex1) - 1)
                    Return True
                Else
                    Exit For
                End If

            End If
        Next
        If zamine = hokm And typescounts(player, typesindex(hokm)) = 0 Then

            For index As Integer = 0 To remindedcount4players - 1
                If playerscards(player, index).ToString().Substring(2) <> typesname(kamtarindex0) And playerscards(player, index).ToString().Substring(2) <> typesname(kamtarindex1) Then
                    If Convert.ToInt32(playerscards(player, index + typescounts(player, typesindex(playerscards(player, index).ToString().Substring(2))) - 1).ToString().Substring(0, 2)) <= 10 Then
                        playerplayed(player, 13 - remindedcount4players) = New playedcard()
                        playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index + typescounts(player, typesindex(playerscards(player, index).ToString().Substring(2))) - 1), seq)
                        playcard(player, index + typescounts(player, typesindex(playerscards(player, index).ToString().Substring(2))) - 1)
                        Return True
                    Else
                        Exit For
                    End If
                End If
            Next

        End If
        For index As Integer = 0 To remindedcount4players - 1
            If playerscards(player, index).ToString().Substring(2) = typesname(kamtarindex0) Then
                If Convert.ToInt32(playerscards(player, index + typescounts(player, kamtarindex0) - 1).ToString().Substring(0, 2)) <= 10 Then
                    playerplayed(player, 13 - remindedcount4players) = New playedcard()
                    playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index + typescounts(player, kamtarindex0) - 1), seq)
                    playcard(player, index + typescounts(player, kamtarindex0) - 1)
                    Return True
                Else
                    Exit For
                End If

            End If
        Next

        For index As Integer = 0 To remindedcount4players - 1
            If playerscards(player, index).ToString().Substring(2) = typesname(kamtarindex1) Then
                If Convert.ToInt32(playerscards(player, index + typescounts(player, kamtarindex1) - 1).ToString().Substring(0, 2)) <= 10 Then
                    playerplayed(player, 13 - remindedcount4players) = New playedcard()
                    playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index + typescounts(player, kamtarindex1) - 1), seq)
                    playcard(player, index + typescounts(player, kamtarindex1) - 1)
                    Return True
                Else
                    Exit For
                End If

            End If
        Next
        If zamine = hokm And typescounts(player, typesindex(hokm)) = 0 Then

            For index As Integer = 0 To remindedcount4players - 1
                If playerscards(player, index).ToString().Substring(2) <> typesname(kamtarindex0) And playerscards(player, index).ToString().Substring(2) <> typesname(kamtarindex1) Then
                    playerplayed(player, 13 - remindedcount4players) = New playedcard()
                    playerplayed(player, 13 - remindedcount4players).playedcard(playerscards(player, index + typescounts(player, typesindex(playerscards(player, index).ToString().Substring(2))) - 1), seq)
                    playcard(player, index + typescounts(player, typesindex(playerscards(player, index).ToString().Substring(2))) - 1)
                    Return True

                End If
            Next

        End If
        Dim kamtarin As Integer = Convert.ToInt32(playerscards(player, remindedcount4players - 1).ToString().Substring(0, 2))
        Dim kamtarinIndex As Integer = remindedcount4players - 1
        kamtarin = Convert.ToInt32(playerscards(player, remindedcount4players - 1).ToString().Substring(0, 2))
        For index As Integer = 1 To remindedcount4players - 1
            If Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) < kamtarin And _
                playerscards(player, index).ToString().Substring(2) <> hokm And _
                 Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2)) < 13 Then
                kamtarin = Convert.ToInt32(playerscards(player, index).ToString().Substring(0, 2))
                kamtarinIndex = index
            End If
        Next
        playerplayed(player, 13 - remindedcount4players) = New playedcard(playerscards(player, kamtarinIndex), seq)
        playcard(player, kamtarinIndex)
        Return True
    End Function
    Sub shift(ByVal player As Integer, ByVal cardno As Integer)

        For index As Integer = cardno To 12
            If index < 12 Then
                playerscards(player, index) = playerscards(player, index + 1)
                'If player = 2 And PBs(2, index + 1).Visible = True Then
                If PBs(player, index + 1).Visible = True Then
                    PBs(player, index).Image = PBs(player, index + 1).Image
                    ' End If
                End If
            Else
                playerscards(player, 12) = Nothing



            End If
        Next

    End Sub
    Sub playcard(ByVal player As Integer, ByVal no As Integer)
        If player = 2 And playerbegin <> 2 Then
            If playerscards(player, no).ToString().Substring(2) <> vasat(playerbegin).ToString().Substring(2) _
            And typescounts(player, typesindex(vasat(playerbegin).ToString().Substring(2))) <> 0 Then
                Exit Sub
            End If
        End If
        If playerbegin = 2 And player = 2 And Convert.ToInt32(playerscards(player, no).ToString().Substring(0, 2)) <> sars(typesindex(playerscards(player, no).ToString().Substring(2))) Then
            javab(player, typesindex(playerscards(player, no).ToString().Substring(2))) = True
        End If
        vasat(player) = playerscards(player, no)
        cent(player).Image = Image.FromFile(path + playerscards(player, no) + ".bmp")
        cent(player).Visible = True
        If player = 2 Then
            Select Case 2 - playerbegin
                Case -1
                    playerplayed(2, 13 - remindedcount4players) = New playedcard(playerscards(2, no).ToString(), 3)
                Case 0
                    playerplayed(2, 13 - remindedcount4players) = New playedcard(playerscards(2, no).ToString(), 0)
                Case 1
                    playerplayed(2, 13 - remindedcount4players) = New playedcard(playerscards(2, no).ToString(), 1)

                Case 2
                    playerplayed(2, 13 - remindedcount4players) = New playedcard(playerscards(2, no).ToString(), 2)


            End Select
        End If
        typescounts(player, typesindex(playerscards(player, no).ToString().Substring(2))) -= 1
        'playedcards(52 - remindedcardkol) = playerscards(player, no).ToString()
        'remindedcardkol -= 1
        shift(player, no)
        If PBs(player, 12).Visible = True Then
            PBs(player, 12).Visible = False
        Else
            For index As Integer = 1 To 12
                If PBs(player, index).Visible = False Then
                    PBs(player, index - 1).Visible = False
                End If

            Next
        End If

        If player = 2 Then
            Select Case 2 - playerbegin
                Case 2

                    play(3, 3)
                Case 1

                    play(3, 2)
                    play(0, 3)
                Case 0

                    play(3, 1)
                    play(0, 2)
                    play(1, 3)

            End Select
            Timer2.Interval = 5000
            Timer2.Start()
        End If
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        Counter()
    End Sub
    Sub Counter()
        remindedcount4players -= 1
        Dim playerNext As Integer = playerbegin + 1
        Dim yar As Integer = playerbegin + 2
        Dim playerlast As Integer = playerbegin + 3
        If playerNext > 3 Then
            playerNext = playerNext Mod 4
        End If
        If yar > 3 Then
            yar = yar Mod 4
        End If
        If playerlast > 3 Then
            playerlast = playerlast Mod 4
        End If

        For index As Integer = 0 To 3
            If index <> playerbegin Then
                javab(index, typesindex(vasat(playerbegin).ToString().Substring(2))) = False
            End If
        Next

        For index As Integer = playerbegin To playerbegin + 3
            Dim index1 As Integer = index
            If index1 > 3 Then
                index1 = index1 Mod 4
            End If
            If vasat(index1).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) And Convert.ToInt32(vasat(index1).ToString().Substring(0, 2)) = sars(typesindex(vasat(playerbegin).ToString().Substring(2))) Then

                For index2 As Integer = 1 To 3 - (index - playerbegin)
                    Dim index3 As Integer = index1 + index2
                    If index3 > 3 Then
                        index3 = index3 Mod 4
                    End If
                    If vasat(index3).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) And (Convert.ToInt32(vasat(index3).ToString().Substring(0, 2)) = sars(typesindex(vasat(playerbegin).ToString().Substring(2))) - 1 Or Convert.ToInt32(vasat(index3).ToString().Substring(0, 2)) > 10) Then
                        cutable(index3, typesindex(vasat(index3).ToString().Substring(2))) = True
                    End If
                Next

            End If
            If vasat(playerbegin).ToString().Substring(2) <> hokm And vasat(index1).ToString().Substring(2) = hokm Then
                cuted(index1, typesindex(vasat(playerbegin).ToString().Substring(2))) = True
                cutable(index1, typesindex(vasat(playerbegin).ToString().Substring(2))) = True
            End If
            If vasat(index1).ToString().Substring(2) <> vasat(playerbegin).ToString().Substring(2) And vasat(index1).ToString().Substring(2) <> hokm Then
                zerocount(index1, typesindex(vasat(playerbegin).ToString().Substring(2))) = True
                cutable(index1, typesindex(vasat(playerbegin).ToString().Substring(2))) = True
            End If
            If vasat(playerbegin).ToString().Substring(2) = hokm And vasat(index1).ToString().Substring(2) <> hokm Then
                zerocount(index1, typesindex(hokm)) = True
                For index2 As Integer = 0 To 3
                    cuted(index1, index2) = False
                    cutable(index1, index2) = False
                Next
            End If
            If index1 = playerNext And cutable(yar, typesindex(vasat(playerbegin).ToString().Substring(2))) = False _
            And cutable(playerlast, typesindex(vasat(playerbegin).ToString().Substring(2))) = False And vasat(index1).ToString().Substring(2) <> hokm _
            And vasat(index1).ToString().Substring(2) <> vasat(playerbegin).ToString().Substring(2) Then
                zerocount(index1, typesindex(vasat(playerbegin).ToString().Substring(2))) = True
                zerocount(index1, typesindex(hokm)) = True
                For index2 As Integer = 0 To 3
                    cuted(index1, index2) = False
                    cutable(index1, index2) = False
                Next
            End If
            If index1 = yar And vasat(index1).ToString().Substring(2) <> hokm And Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) <= 10 _
            And Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) <> sars(typesindex(vasat(playerbegin).ToString().Substring(2))) And vasat(index1).ToString().Substring(2) <> vasat(playerbegin).ToString().Substring(2) Then
                zerocount(index1, typesindex(vasat(playerbegin).ToString().Substring(2))) = True
                zerocount(index1, typesindex(hokm)) = True
                For index2 As Integer = 0 To 3
                    cuted(index1, index2) = False
                    cutable(index1, index2) = False
                Next
            End If
            

        Next

        For index0 As Integer = 0 To 3
            For index As Integer = 0 To 3
                If Convert.ToInt32(vasat(index).ToString().Substring(0, 2)) = sars(typesindex(vasat(index).ToString().Substring(2))) Then
                    sars(typesindex(vasat(index).ToString().Substring(2))) -= 1
                End If

            Next
        Next

        For index As Integer = 0 To 3
            remindedcounts(typesindex(vasat(index).ToString().Substring(2))) -= 1

        Next

        For index As Integer = 0 To 3
            cent(index).Visible = False

        Next

        Dim sar As Integer = -1
        For index As Integer = 0 To 3
            If sar = -1 Then
                sar = playerbegin
                If vasat(index).ToString().Substring(2) = hokm Then
                    sar = index
                Else
                    If vasat(index).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) And Convert.ToInt32(vasat(index).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(playerbegin).ToString().Substring(0, 2)) Then
                        sar = index
                    End If
                End If
            Else
                If vasat(index).ToString().Substring(2) = hokm Then
                    If vasat(sar).ToString().Substring(2) = hokm Then
                        If Convert.ToInt32(vasat(index).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(sar).ToString().Substring(0, 2)) Then
                            sar = index
                        End If
                    Else
                        sar = index
                    End If
                Else
                    If vasat(index).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then
                        If vasat(sar).ToString().Substring(2) = vasat(playerbegin).ToString().Substring(2) Then
                            If Convert.ToInt32(vasat(index).ToString().Substring(0, 2)) > Convert.ToInt32(vasat(sar).ToString().Substring(0, 2)) Then
                                sar = index
                            End If
                        End If
                    End If
                End If
            End If
        Next
        If vasat(playerlast).ToString().Substring(2) <> vasat(playerbegin).ToString().Substring(2) And vasat(playerlast).ToString().Substring(2) <> hokm _
        And sar <> playerNext And vasat(yar).ToString().Substring(2) <> hokm Then
            zerocount(playerlast, typesindex(vasat(playerbegin).ToString().Substring(2))) = True
            zerocount(playerlast, typesindex(hokm)) = True
            For index2 As Integer = 0 To 3
                cuted(playerlast, index2) = False
                cutable(playerlast, index2) = False
            Next
        End If
        playerbegin = sar
        Select Case sar
            Case 0
                stjarigroup1.Text = (Convert.ToInt32(stjarigroup1.Text) + 1).ToString()
            Case 1
                stjarigroup2.Text = (Convert.ToInt32(stjarigroup2.Text) + 1).ToString()
            Case 2
                stjarigroup1.Text = (Convert.ToInt32(stjarigroup1.Text) + 1).ToString()
            Case 3
                stjarigroup2.Text = (Convert.ToInt32(stjarigroup2.Text) + 1).ToString()
        End Select
        If Convert.ToInt32(stjarigroup1.Text) = 7 Then
            stjarigroup1.Text = "0"
            stkoligroup1.Text = (Convert.ToInt32(stkoligroup1.Text) + 1).ToString()
            If Convert.ToInt32(stkoligroup1.Text) >= 7 Then
                'Dim s As String = String.Format("گروه1:بازیگر1-{0} برنده شد", playerName)
                'MessageBox.Show(s)
                Dialogstart.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\" + "تبریک.bmp")
                Dialogstart.Timerstart.Start()
                Dialogstart.ShowDialog()
                Dim dr As DialogResult
                dr = MessageBox.Show("آیا دوباره بازی میکنید؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, False)
                If dr = Windows.Forms.DialogResult.Yes Then
                    stkoligroup1.Text = "0"
                    stkoligroup2.Text = "0"
                    stjarigroup2.Text = "0"
                    reset()
                    start()
                    Exit Sub
                End If
                If dr = Windows.Forms.DialogResult.No Then
                    Application.Exit()
                End If
            End If
            If stjarigroup2.Text = "0" Then
                If hakem = 1 Or hakem = 3 Then
                    stkoligroup1.Text = (Convert.ToInt32(stkoligroup1.Text) + 2).ToString()
                    MessageBox.Show("گروه 2 :بازیگر2-بازیگر4 حاکم کوت شدند")
                Else
                    stkoligroup1.Text = (Convert.ToInt32(stkoligroup1.Text) + 1).ToString()
                    MessageBox.Show("گروه 2 :بازیگر2-بازیگر4 کوت شدند")
                End If
                If Convert.ToInt32(stkoligroup1.Text) >= 7 Then
                    'Dim s As String = String.Format("گروه1:بازیگر1-{0} برنده شد", playerName)
                    'MessageBox.Show(s)
                    Dialogstart.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\" + "تبریک.bmp")
                    Dialogstart.Timerstart.Start()
                    Dialogstart.ShowDialog()
                    Dim dr As DialogResult
                    dr = MessageBox.Show("آیا دوباره بازی میکنید؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, False)
                    If dr = Windows.Forms.DialogResult.Yes Then
                        stkoligroup1.Text = "0"
                        stkoligroup2.Text = "0"
                        stjarigroup2.Text = "0"
                        reset()
                        start()
                        Exit Sub
                    End If
                    If dr = Windows.Forms.DialogResult.No Then
                        Application.Exit()
                    End If
                End If

            End If
            If hakem = 1 Then
                hakem = 2
            End If
            If hakem = 3 Then
                hakem = 0
            End If
            If hakem = 0 Then
                lbhakemName.Text = "بازیگر1"
            End If
            If hakem = 1 Then
                lbhakemName.Text = "بازیگر2"
            End If
            If hakem = 2 Then
                lbhakemName.Text = playerName
            End If
            If hakem = 3 Then
                lbhakemName.Text = "بازیگر4"
            End If

            reset()
            stjarigroup2.Text = "0"
            forhokm()
        ElseIf stjarigroup2.Text = "7" Then
            stjarigroup2.Text = "0"
            stkoligroup2.Text = (Convert.ToInt32(stkoligroup2.Text) + 1).ToString()
            If stkoligroup2.Text = "7" Then
                MessageBox.Show("گروه2:بازیگر2-بازیگر4 برنده شد")
                Dim dr As DialogResult
                dr = MessageBox.Show("آیا دوباره بازی میکنید؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, False)
                If dr = Windows.Forms.DialogResult.Yes Then
                    stkoligroup1.Text = "0"
                    stkoligroup2.Text = "0"
                    stjarigroup1.Text = "0"
                    reset()
                    start()
                    Exit Sub
                End If
                If dr = Windows.Forms.DialogResult.No Then
                    Application.Exit()
                End If
            End If
            If stjarigroup1.Text = "0" Then
                If hakem = 0 Or hakem = 2 Then
                    stkoligroup2.Text = (Convert.ToInt32(stkoligroup2.Text) + 2).ToString()
                    Dim s As String = String.Format("گروه 1:بازیگر 1-{0} حاکم کوت شدند", playerName)
                    MessageBox.Show(s)
                Else
                    stkoligroup2.Text = (Convert.ToInt32(stkoligroup2.Text) + 1).ToString()
                    Dim s As String = String.Format("گروه 1:بازیگر 1-{0} کوت شدند", playerName)
                    MessageBox.Show(s)
                End If
            End If
            If Convert.ToInt32(stkoligroup2.Text) >= 7 Then
                MessageBox.Show("گروه2:بازیگر2-بازیگر4 برنده شد")
                Dim dr As DialogResult
                dr = MessageBox.Show("آیا دوباره بازی میکنید؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, False)
                If dr = Windows.Forms.DialogResult.Yes Then
                    stkoligroup1.Text = "0"
                    stkoligroup2.Text = "0"
                    stjarigroup1.Text = "0"
                    reset()
                    start()
                    Exit Sub
                End If
                If dr = Windows.Forms.DialogResult.No Then
                    Application.Exit()
                End If
            End If
            If hakem = 0 Then
                hakem = 1
            End If
            If hakem = 2 Then
                hakem = 3
            End If

            If hakem = 0 Then
                lbhakemName.Text = "بازیگر1"
            End If
            If hakem = 1 Then
                lbhakemName.Text = "بازیگر2"
            End If
            If hakem = 2 Then
                lbhakemName.Text = playerName
            End If
            If hakem = 3 Then
                lbhakemName.Text = "بازیگر4"
            End If
            stjarigroup1.Text = "0"
            reset()
            forhokm()
        Else

            For index As Integer = 0 To 3
                vasat(index) = Nothing
            Next

            Dim player As Integer = -1
            player = playerbegin
            For index As Integer = playerbegin To playerbegin + 3
                player = index
                If index > 3 Then
                    player = index Mod 4
                End If
                If player = 2 Then
                    Exit For
                End If
                play(player, index - playerbegin)
            Next
        End If
    End Sub
    Sub reset()
        For index As Integer = 0 To 3
            sars(index) = 14
        Next

        For index As Integer = 0 To 3
            remindedcounts(index) = 13
        Next

        For index As Integer = 0 To 3
            sarsbefor(index) = 0
        Next
        For index As Integer = 0 To 3

            For index1 As Integer = 0 To 12
                playerscards(index, index1) = Nothing
                PBs(index, index1).Visible = False
            Next


        Next

        For index As Integer = 0 To 3

            For index1 As Integer = 0 To 3
                cuted(index, index1) = False
                cutable(index, index1) = False
                zerocount(index, index1) = False

            Next

        Next

        remindedcount4players = 13
        remindedcard = 52

    End Sub
    Function typesindex(ByVal type As String) As Integer
        Select Case type
            Case "اسپیک"
                Return 0
            Case "خشت"
                Return 1
            Case "گیشنیز"
                Return 2
            Case "دل"
                Return 3
        End Select
    End Function
    Sub initializ()

        For index As Integer = 0 To 3
            cent(index) = New PictureBox()
            For index1 As Integer = 0 To 12
                PBs(index, index1) = New PictureBox()
            Next


        Next
        cent(0) = cent1
        cent(1) = cent2
        cent(2) = cent3
        cent(3) = cent4
        PBs(0, 0) = PB1_1
        PBs(0, 1) = PB1_2
        PBs(0, 2) = PB1_3
        PBs(0, 3) = PB1_4
        PBs(0, 4) = PB1_5
        PBs(0, 5) = PB1_6
        PBs(0, 6) = PB1_7
        PBs(0, 7) = PB1_8
        PBs(0, 8) = PB1_9
        PBs(0, 9) = PB1_10
        PBs(0, 10) = PB1_11
        PBs(0, 11) = PB1_12
        PBs(0, 12) = PB1_13
        PBs(1, 0) = PB2_1
        PBs(1, 1) = PB2_2
        PBs(1, 2) = PB2_3
        PBs(1, 3) = PB2_4
        PBs(1, 4) = PB2_5
        PBs(1, 5) = PB2_6
        PBs(1, 6) = PB2_7
        PBs(1, 7) = PB2_8
        PBs(1, 8) = PB2_9
        PBs(1, 9) = PB2_10
        PBs(1, 10) = PB2_11
        PBs(1, 11) = PB2_12
        PBs(1, 12) = PB2_13
        PBs(2, 0) = PB3_1
        PBs(2, 1) = PB3_2
        PBs(2, 2) = PB3_3
        PBs(2, 3) = PB3_4
        PBs(2, 4) = PB3_5
        PBs(2, 5) = PB3_6
        PBs(2, 6) = PB3_7
        PBs(2, 7) = PB3_8
        PBs(2, 8) = PB3_9
        PBs(2, 9) = PB3_10
        PBs(2, 10) = PB3_11
        PBs(2, 11) = PB3_12
        PBs(2, 12) = PB3_13
        PBs(3, 0) = PB4_1
        PBs(3, 1) = PB4_2
        PBs(3, 2) = PB4_3
        PBs(3, 3) = PB4_4
        PBs(3, 4) = PB4_5
        PBs(3, 5) = PB4_6
        PBs(3, 6) = PB4_7
        PBs(3, 7) = PB4_8
        PBs(3, 8) = PB4_9
        PBs(3, 9) = PB4_10
        PBs(3, 10) = PB4_11
        PBs(3, 11) = PB4_12
        PBs(3, 12) = PB4_13

        For index As Integer = 0 To 3

            For index1 As Integer = 0 To 12
                PBs(index, index1).Visible = False
            Next


        Next



    End Sub





    Private Sub PB3_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB3_1.Click
        If cent(2).Visible = False Then
            playcard(2, 0)
        End If
    End Sub

    Private Sub PB3_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB3_2.Click
        If cent(2).Visible = False Then
            playcard(2, 1)
        End If
    End Sub

    Private Sub PB3_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB3_3.Click
        If cent(2).Visible = False Then
            playcard(2, 2)
        End If
    End Sub


    Private Sub PB3_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB3_4.Click
        If cent(2).Visible = False Then
            playcard(2, 3)
        End If
    End Sub

    Private Sub PB3_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB3_5.Click
        If cent(2).Visible = False Then
            playcard(2, 4)
        End If
    End Sub

    Private Sub PB3_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB3_6.Click
        If cent(2).Visible = False Then
            playcard(2, 5)
        End If
    End Sub

    Private Sub PB3_7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB3_7.Click
        If cent(2).Visible = False Then
            playcard(2, 6)
        End If
    End Sub

    Private Sub PB3_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB3_8.Click
        If cent(2).Visible = False Then
            playcard(2, 7)
        End If
    End Sub

    Private Sub PB3_9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB3_9.Click
        If cent(2).Visible = False Then
            playcard(2, 8)
        End If
    End Sub

    Private Sub PB3_10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB3_10.Click
        If cent(2).Visible = False Then
            playcard(2, 9)
        End If
    End Sub

    Private Sub PB3_11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB3_11.Click
        If cent(2).Visible = False Then
            playcard(2, 10)
        End If
    End Sub

    Private Sub PB3_12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB3_12.Click
        If cent(2).Visible = False Then
            playcard(2, 11)
        End If
    End Sub

    Private Sub PB3_13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB3_13.Click
        If cent(2).Visible = False Then
            playcard(2, 12)
        End If
    End Sub
End Class


