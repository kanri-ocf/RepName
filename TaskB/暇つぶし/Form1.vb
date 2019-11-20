Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '入力時にIMEモードを無効にする
        B_1.ImeMode = ImeMode.Disable
        B_2.ImeMode = ImeMode.Disable
        B_3.ImeMode = ImeMode.Disable
        B_4.ImeMode = ImeMode.Disable
        B_5.ImeMode = ImeMode.Disable

        '入力時に文字数を制限する
        B_1.MaxLength = 3
        B_2.MaxLength = 3
        B_3.MaxLength = 3
        B_4.MaxLength = 3
        B_5.MaxLength = 3

        'aaaaaa
        'aaa


    End Sub

    'バブルソートイベント
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As Integer = B_1.Text
        Dim b As Integer = B_2.Text
        Dim c As Integer = B_3.Text
        Dim d As Integer = B_4.Text
        Dim f As Integer = B_5.Text
        Dim hantei As Boolean

        'If a = "" Or b = "" Or c = "" Or d = "" Or f = "" Then
        '    hantei = hikaku()
        'End If

        hantei = hikaku()

        While hantei = False

            'dよりfが小さい場合に入れ替え
            If d > f Then
                Dim n As Integer = f
                f = d
                d = n
            End If

            If c > d Then
                Dim n As Integer = d
                d = c
                c = n
            End If

            If b > c Then
                Dim n As Integer = c
                c = b
                b = n
            End If

            If a > b Then
                Dim n As Integer = b
                b = a
                a = n
            End If

            If a < b Then
                If b < c Then
                    If c < d Then
                        If d < f Then
                            hantei = True
                        Else
                            hantei = False
                        End If
                    Else
                        hantei = False
                    End If
                Else
                    hantei = False
                End If
            ElseIf a = b Then
                If b = c Then
                    If c = d Then
                        If d = f Then
                            hantei = True
                        Else
                            hantei = False
                        End If
                    Else
                        hantei = False
                    End If
                Else
                    hantei = False
                End If
            Else
                hantei = False
            End If
        End While


        A_1.Text = a
        A_2.Text = b
        A_3.Text = c
        A_4.Text = d
        A_5.Text = f

    End Sub

    '数値を比較する
    Private Function hikaku()
        If B_1.Text > B_2.Text Then
            If B_2.Text > B_3.Text Then
                If B_3.Text > B_4.Text Then
                    If B_4.Text > B_5.Text Then
                        hikaku = True
                    Else
                        hikaku = False
                    End If
                Else
                    hikaku = False
                End If
            Else
                hikaku = False
            End If
        Else
            hikaku = False
        End If

    End Function

    'クイックソートイベント
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Num(4) As Integer

        Num(0) = B_1.Text
        Num(1) = B_2.Text
        Num(2) = B_3.Text
        Num(3) = B_4.Text
        Num(4) = B_5.Text

        QuickSort(Num, 0, Num.Length - 1)

        A_1.Text = Num(0)
        A_2.Text = Num(1)
        A_3.Text = Num(2)
        A_4.Text = Num(3)
        A_5.Text = Num(4)

    End Sub

    Shared Sub QuickSort(ByVal data() As Integer, ByVal left As Integer, ByVal right As Integer)
        '左端と右端が一致していたらメソッドを抜ける
        If right <= left Then Exit Sub

        '軸の値を決める
        Dim pivot As Integer = data((left + right) \ 2)
        Dim i As Integer = left
        Dim j As Integer = right

        '並び替えるまでループを繰り返す
        Do
            While data(i) < pivot
                i += 1
            End While

            While pivot < data(j)
                j -= 1
            End While

            If j <= i Then Exit Do

            ' 入れ替え
            Dim temp As Integer = data(i)
            data(i) = data(j)
            data(j) = temp

            i += 1
            j -= 1
        Loop
        QuickSort(data, left, i - 1)
        QuickSort(data, j + 1, right)
    End Sub

    Private Sub B_1_LostFocus(sender As Object, e As EventArgs) Handles B_1.LostFocus
        If Not IsNumeric(B_1.Text) Then
            '押されたキーが数字以外は、メッセージボックスを表示する
            MsgBox("数字以外が入力されています。")
            B_1.Text = ""
            B_1.Focus()

        End If
    End Sub

    Private Sub B_2_LostFocus(sender As Object, e As EventArgs) Handles B_2.LostFocus
        If Not IsNumeric(B_2.Text) Then
            '押されたキーが数字以外は、メッセージボックスを表示する
            MsgBox("数字以外が入力されています。")
            B_2.Text = ""
            B_2.Focus()
        End If
    End Sub

    Private Sub B_3_LostFocus(sender As Object, e As EventArgs) Handles B_3.LostFocus
        If Not IsNumeric(B_3.Text) Then
            '押されたキーが数字以外は、メッセージボックスを表示する
            MsgBox("数字以外が入力されています。")
            B_3.Text = ""
            B_3.Focus()
        End If
    End Sub

    Private Sub B_4_LostFocus(sender As Object, e As EventArgs) Handles B_4.LostFocus
        If Not IsNumeric(B_4.Text) Then
            '押されたキーが数字以外は、メッセージボックスを表示する
            MsgBox("数字以外が入力されています。")
            B_4.Text = ""
            B_4.Focus()
        End If
    End Sub

    Private Sub B_5_LostFocus(sender As Object, e As EventArgs) Handles B_5.LostFocus
        If Not IsNumeric(B_5.Text) Then
            '押されたキーが数字以外は、メッセージボックスを表示する
            MsgBox("数字以外が入力されています。")
            B_5.Text = ""
            B_5.Focus()
        End If
    End Sub


End Class
