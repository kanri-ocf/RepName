Option Strict On       'プロジェクトのプロパティでも設定可能

'Imports System.Data.OleDb
'Imports System.Text.RegularExpressions


Public Class cDataCalcDBIO
    Private pConn As OleDb.OleDbConnection
    Private pCommand As OleDb.OleDbCommand
    Private pDataReader As OleDb.OleDbDataReader
    Private pMessageBox As cMessageLib.fMessage

    Sub New(ByRef iConn As OleDb.OleDbConnection, ByRef iCommand As OleDb.OleDbCommand, ByRef iDataReader As OleDb.OleDbDataReader)
        pConn = iConn
        pCommand = iCommand
        pDataReader = iDataReader
    End Sub
    '----------------------------------------------------------------------
    '　機能：精算データから該当精算コード以上のレコードを取得する関数
    '　引数：ParCalc 取得データセット用バッファ
    '        KeyCalcCode 精算コード
    '        Mode          1:指定精算コードのデータ取得
    '                      2:指定精算コード以上の入金データ取得
    '　戻値：取得レコード数
    '----------------------------------------------------------------------
    Public Function getCalc(ByRef ParCalc() As cStructureLib.sCalc, _
                              ByVal KeyCalcCode As Long, _
                              ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long

        Dim i As Integer
        Dim StrSelect As String

        StrSelect = "SELECT * FROM 集計データ WHERE 集計コード = @CalcCode "

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = StrSelect

            '集計コード
            pCommand.Parameters.Add _
                (New OleDb.OleDbParameter("@CalcCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@CalcCode").Value = KeyCalcCode

            pDataReader = pCommand.ExecuteReader()

            i = 0
            While pDataReader.Read()

                ReDim Preserve ParCalc(CInt(i))

                'レコードが取得できた時の処理
                '集計コード
                ParCalc(i).sCalcCode = CLng(pDataReader("集計コード"))
                '集計区分
                ParCalc(i).sCalcClass = pDataReader("集計区分").ToString
                '集計日
                ParCalc(i).sCalcDate = pDataReader("集計日").ToString
                '集計時間
                ParCalc(i).sCalcTime = pDataReader("集計時間").ToString
                '現金売上
                ParCalc(i).sCashSales = CLng(pDataReader("現金売上"))
                '現金売上数
                ParCalc(i).sCashSalesCnt = CInt(pDataReader("現金売上数"))
                '現金値引き額
                ParCalc(i).sCashDiscount = CLng(pDataReader("現金値引き額"))
                'クレジット売上
                ParCalc(i).sCreditSales = CLng(pDataReader("クレジット売上"))
                'クレジット売上数
                ParCalc(i).sCreditSalesCnt = CInt(pDataReader("クレジット売上数"))
                'クレジット値引き額
                ParCalc(i).sCreditDiscount = CLng(pDataReader("クレジット値引き額"))
                '入金額
                ParCalc(i).sInCash = CLng(pDataReader("入金額"))
                '入金回数
                ParCalc(i).sInCashCnt = CInt(pDataReader("入金回数"))
                '出金額
                ParCalc(i).sOutCash = CLng(pDataReader("出金額"))
                '出金回数
                ParCalc(i).sOutCashCnt = CInt(pDataReader("出金回数"))
                '回収金額
                ParCalc(i).sBalance = CLng(pDataReader("回収金額"))
                '残高
                ParCalc(i).sBalance = CLng(pDataReader("残高"))
                '顧客数_0_1
                ParCalc(i).sCustCnt_0_1 = CLng(pDataReader("顧客数_0_1"))
                '顧客数_1_2
                ParCalc(i).sCustCnt_1_2 = CLng(pDataReader("顧客数_1_2"))
                '顧客数_2_3
                ParCalc(i).sCustCnt_2_3 = CLng(pDataReader("顧客数_2_3"))
                '顧客数_3_4
                ParCalc(i).sCustCnt_3_4 = CLng(pDataReader("顧客数_3_4"))
                '顧客数_4_5
                ParCalc(i).sCustCnt_4_5 = CLng(pDataReader("顧客数_4_5"))
                '顧客数_5_6
                ParCalc(i).sCustCnt_5_6 = CLng(pDataReader("顧客数_5_6"))
                '顧客数_6_7
                ParCalc(i).sCustCnt_6_7 = CLng(pDataReader("顧客数_6_7"))
                '顧客数_7_8
                ParCalc(i).sCustCnt_7_8 = CLng(pDataReader("顧客数_7_8"))
                '顧客数_8_9
                ParCalc(i).sCustCnt_8_9 = CLng(pDataReader("顧客数_8_9"))
                '顧客数_9_10
                ParCalc(i).sCustCnt_9_10 = CLng(pDataReader("顧客数_9_10"))
                '顧客数_10_11
                ParCalc(i).sCustCnt_10_11 = CLng(pDataReader("顧客数_10_11"))
                '顧客数_11_12
                ParCalc(i).sCustCnt_11_12 = CLng(pDataReader("顧客数_11_12"))
                '顧客数_12_13
                ParCalc(i).sCustCnt_12_13 = CLng(pDataReader("顧客数_12_13"))
                '顧客数_13_14
                ParCalc(i).sCustCnt_13_14 = CLng(pDataReader("顧客数_13_14"))
                '顧客数_14_15
                ParCalc(i).sCustCnt_14_15 = CLng(pDataReader("顧客数_14_15"))
                '顧客数_15_16
                ParCalc(i).sCustCnt_15_16 = CLng(pDataReader("顧客数_15_16"))
                '顧客数_16_17
                ParCalc(i).sCustCnt_16_17 = CLng(pDataReader("顧客数_16_17"))
                '顧客数_17_18
                ParCalc(i).sCustCnt_17_18 = CLng(pDataReader("顧客数_17_18"))
                '顧客数_18_19
                ParCalc(i).sCustCnt_18_19 = CLng(pDataReader("顧客数_18_19"))
                '顧客数_19_20
                ParCalc(i).sCustCnt_19_20 = CLng(pDataReader("顧客数_19_20"))
                '顧客数_20_21
                ParCalc(i).sCustCnt_20_21 = CLng(pDataReader("顧客数_20_21"))
                '顧客数_21_22
                ParCalc(i).sCustCnt_21_22 = CLng(pDataReader("顧客数_21_22"))
                '顧客数_22_23
                ParCalc(i).sCustCnt_22_23 = CLng(pDataReader("顧客数_22_23"))
                '顧客数_23_24
                ParCalc(i).sCustCnt_23_24 = CLng(pDataReader("顧客数_23_24"))
                '登録日
                ParCalc(i).sCreateDate = pDataReader("登録日").ToString
                '登録時間
                ParCalc(i).sCreateTime = pDataReader("登録時間").ToString
                '最終更新日付
                ParCalc(i).sUpdateDate = pDataReader("最終更新日付").ToString
                '最終更新時間
                ParCalc(i).sUpdateTime = pDataReader("最終更新時間").ToString
                'レコードが取得できた時の処理
                i = i + 1
            End While
            getCalc = i

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataCalcDBIO.getCalc)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function


    '----------------------------------------------------------------------
    '　機能：取引テーブルに１レコードを登録するメソッド
    '　引数：in cSubCalcオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function insertCalc(ByRef parCalc() As cStructureLib.sCalc, _
                               ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Try

            'SQL文の設定
            Const strInsertCalc As String = "INSERT INTO 集計データ" & _
            "( 集計コード, 集計区分, 集計日, 集計時間, 現金売上, 現金売上数, 現金値引き額, " & _
            "クレジット売上, クレジット売上数, クレジット値引き額, 入金額, 入金回数, 出金額, 出金回数, 回収金額, 残高, " & _
            "顧客数_0_1, 顧客数_1_2, 顧客数_2_3, 顧客数_3_4, 顧客数_4_5, 顧客数_5_6, " & _
            "顧客数_6_7, 顧客数_7_8, 顧客数_8_9, 顧客数_9_10, 顧客数_10_11, 顧客数_11_12, " & _
            "顧客数_12_13, 顧客数_13_14, 顧客数_14_15, 顧客数_15_16, 顧客数_16_17, 顧客数_17_18, " & _
            "顧客数_18_19, 顧客数_19_20, 顧客数_20_21, 顧客数_21_22, 顧客数_22_23, 顧客数_23_24, " & _
            "登録日, 登録時間, 最終更新日, 最終更新時間 ) " & _
            "VALUES (@CalcCode, @CalcClass, @CalcDate, @CalcTime, @CashSales, @CashSalesCnt, @CashDiscount, " & _
            "@CreditSales, @CreditSalesCnt, @CreditDiscount, @InCash, @InCashCnt, @OutCash, @OutCashCnt, @RetCash, @Balance, " & _
            "@CustCnt_0_1, @CustCnt_1_2, @CustCnt_2_3, @CustCnt_3_4, @CustCnt_4_5, @CustCnt_5_6, " & _
            "@CustCnt_6_7, @CustCnt_7_8, @CustCnt_8_9, @CustCnt_9_10, @CustCnt_10_11, @CustCnt_11_12, " & _
            "@CustCnt_12_13, @CustCnt_13_14, @CustCnt_14_15, @CustCnt_15_16, @CustCnt_16_17, @CustCnt_17_18, " & _
            "@CustCnt_18_19, @CustCnt_19_20, @CustCnt_20_21, @CustCnt_21_22, @CustCnt_22_23, @CustCnt_23_24, " & _
            "@CreateDate, @CreateTime, @UpdateDate, @UpdateTime)"

            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strInsertCalc

            '***********************
            '   パラメータの設定
            '***********************

            '集計コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CalcCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@CalcCode").Value = parCalc(0).sCalcCode

            '集計区分
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CalcClass", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@CalcClass").Value = parCalc(0).sCalcClass

            '集計日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CalcDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@CalcDate").Value = parCalc(0).sCalcDate

            '集計時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CalcTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@CalcTime").Value = parCalc(0).sCalcTime

            '現金売上
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CashSales", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@CashSales").Value = parCalc(0).sCashSales

            '現金売上数
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CashSalesCnt", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CashSalesCnt").Value = parCalc(0).sCashSalesCnt

            '現金値引き額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CashDiscount", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@CashDiscount").Value = parCalc(0).sCashDiscount

            'クレジット売上
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreditSales", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@CreditSales").Value = parCalc(0).sCreditSales

            'クレジット売上数
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreditSalesCnt", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CreditSalesCnt").Value = parCalc(0).sCreditSalesCnt

            'クレジット値引き額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreditDiscount", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@CreditDiscount").Value = parCalc(0).sCreditDiscount

            '入金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@InCash", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@InCash").Value = parCalc(0).sInCash

            '入金回数
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@InCashCnt", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@InCashCnt").Value = parCalc(0).sInCashCnt

            '出金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OutCash", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@OutCash").Value = parCalc(0).sOutCash

            '出金回数
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@OutCashCnt", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@OutCashCnt").Value = parCalc(0).sOutCashCnt

            '回収金額
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@RetCash", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@RetCash").Value = parCalc(0).sRetCash

            '残高
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@Balance", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@Balance").Value = parCalc(0).sBalance

            '顧客数_0_1
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_0_1", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_0_1").Value = parCalc(0).sCustCnt_0_1

            '顧客数_1_2
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_1_2", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_1_2").Value = parCalc(0).sCustCnt_1_2

            '顧客数_2_3
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_2_3", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_2_3").Value = parCalc(0).sCustCnt_2_3

            '顧客数_3_4
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_3_4", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_3_4").Value = parCalc(0).sCustCnt_3_4

            '顧客数_4_5
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_4_5", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_4_5").Value = parCalc(0).sCustCnt_4_5

            '顧客数_5_6
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_5_6", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_5_6").Value = parCalc(0).sCustCnt_5_6

            '顧客数_6_7
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_6_7", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_6_7").Value = parCalc(0).sCustCnt_6_7

            '顧客数_7_8
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_7_8", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_7_8").Value = parCalc(0).sCustCnt_7_8

            '顧客数_8_9
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_8_9", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_8_9").Value = parCalc(0).sCustCnt_8_9

            '顧客数_9_10
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_9_10", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_9_10").Value = parCalc(0).sCustCnt_9_10

            '顧客数_10_11
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_10_11", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_10_11").Value = parCalc(0).sCustCnt_10_11

            '顧客数_11_12
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_11_12", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_11_12").Value = parCalc(0).sCustCnt_11_12

            '顧客数_12_13
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_12_13", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_12_13").Value = parCalc(0).sCustCnt_12_13

            '顧客数_13_14
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_13_14", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_13_14").Value = parCalc(0).sCustCnt_13_14

            '顧客数_14_15
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_14_15", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_14_15").Value = parCalc(0).sCustCnt_14_15

            '顧客数_15_16
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_15_16", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_15_16").Value = parCalc(0).sCustCnt_15_16

            '顧客数_16_17
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_16_17", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_16_17").Value = parCalc(0).sCustCnt_16_17

            '顧客数_17_18
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_17_18", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_17_18").Value = parCalc(0).sCustCnt_17_18

            '顧客数_18_19
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_18_19", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_18_19").Value = parCalc(0).sCustCnt_18_19

            '顧客数_19_20
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_19_20", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_19_20").Value = parCalc(0).sCustCnt_19_20

            '顧客数_20_21
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_20_21", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_20_21").Value = parCalc(0).sCustCnt_20_21

            '顧客数_21_22
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_21_22", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_21_22").Value = parCalc(0).sCustCnt_21_22

            '顧客数_22_23
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_22_23", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_22_23").Value = parCalc(0).sCustCnt_22_23

            '顧客数_23_24
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CustCnt_23_24", OleDb.OleDbType.Numeric, 3))
            pCommand.Parameters("@CustCnt_23_24").Value = parCalc(0).sCustCnt_23_24

            '登録日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@CreateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)

            '登録時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CreateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@CreateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            '最終更新日
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateDate", OleDb.OleDbType.Char, 10))
            pCommand.Parameters("@UpdateDate").Value = String.Format("{0:yyyy/MM/dd}", Now)

            '最終更新時間
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@UpdateTime", OleDb.OleDbType.Char, 8))
            pCommand.Parameters("@UpdateTime").Value = String.Format("{0:HH:mm:ss}", Now)

            '取引テーブル挿入処理実行
            pCommand.ExecuteNonQuery()

            insertCalc = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataCalcDBIO.insertCalc)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function
    Public Function readMaxCalcCode(ByRef Tran As System.Data.OleDb.OleDbTransaction) As Long
        Dim strSelectCalc As String

        strSelectCalc = ""

        strSelectCalc = "SELECT 集計コード FROM 集計データ ORDER BY 集計コード DESC"

        Try
            'SQL文の設定
            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strSelectCalc

            '精算データから該当MAX取引IDのレコード読込 
            pDataReader = pCommand.ExecuteReader(CommandBehavior.SingleRow)

            If pDataReader.Read() Then
                'レコードが取得できた時の処理

                'NULL値を許している項目は、NULL値の判定をする
                If IsDBNull(pDataReader("集計コード")) Then
                    readMaxCalcCode = 0
                Else
                    readMaxCalcCode = CLng(pDataReader("集計コード"))
                End If
            Else
                readMaxCalcCode = 0
            End If

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataCalcDBIO.readMaxCalcCode)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function
    '----------------------------------------------------------------------
    '　機能：取引明細テーブルから該当レコードを削除するメソッド
    '　引数：in cSubTrnオブジェクト
    '　戻値：True  --> 登録成功.  False --> 登録失敗
    '----------------------------------------------------------------------
    Public Function deleteMaxCalc(ByVal KetCalcCode As Long, _
                                  ByRef Tran As System.Data.OleDb.OleDbTransaction) As Boolean

        Dim strDeleteCalc As String

        Try

            'SQL文の設定

            strDeleteCalc = "DELETE * FROM 精算データ " & _
                            "WHERE 精算区分=@CalcClass " & _
                            "AND 精算コード=@CalcCode"


            pCommand = pConn.CreateCommand
            pCommand.Transaction = Tran

            pCommand.CommandText = strDeleteCalc

            '***********************
            '   パラメータの設定
            '***********************

            '精算区分
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CalcClass", OleDb.OleDbType.Char, 6))
            pCommand.Parameters("@CalcClass").Value = "精算"

            '精算コード
            pCommand.Parameters.Add _
            (New OleDb.OleDbParameter("@CalcCode", OleDb.OleDbType.Numeric, 10))
            pCommand.Parameters("@CalcCode").Value = KetCalcCode

            '取引テーブル挿入処理実行
            pCommand.ExecuteNonQuery()

            deleteMaxCalc = True

        Catch oExcept As Exception
            '例外が発生した時の処理
            pMessageBox = New cMessageLib.fMessage(1, "システムエラー(cDataCalcDBIO.readMaxCalcCode)", Nothing, Nothing, oExcept.ToString)
            pMessageBox.ShowDialog()
            pMessageBox.Dispose()
            pMessageBox = Nothing
            Environment.Exit(1)
        Finally
            If IsNothing(pDataReader) = False Then
                pDataReader.Close()
            End If
        End Try

    End Function


End Class
