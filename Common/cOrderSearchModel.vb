Option Explicit On
' 楽天の入力パラメータの受注情報モデル(受注検索モデル)を定義
Public Class cOrderSearchModel
    ' 受注ステータス
    Private status As String
    ' 期間検索種別
    Private dateType As Integer
    ' 期間FROM
    Private startDate As Date
    ' 期間TO
    Private endDate As Date

    Public Sub setStatus(ByVal iStatus As String)
        Me.status = iStatus
    End Sub
    Public Function xmlStatus() As String
        Return "<status>" & Me.status & "</status>"
    End Function
    Public Sub setDateType(ByVal iDateType As Integer)
        Me.dateType = iDateType
    End Sub
    Public Function xmlDateType() As String
        Return "<dateType>" & Me.dateType & "</dateType>"
    End Function
    Public Sub setStartDate(ByVal iStartDate As Date)
        Me.startDate = iStartDate
    End Sub
    Public Function xmlStartDate() As String
        ' 日付はISO 8601に準拠する型へ置換する
        Return "<startDate>" & Me.startDate.ToString("s") & "</startDate>"
    End Function
    Public Sub setEndDate(ByVal iEndDate As Date)
        Me.endDate = iEndDate
    End Sub
    Public Function xmlEndDate() As String
        ' 日付はISO 8601に準拠する型へ置換する
        Return "<endDate>" & Me.endDate.ToString("s") & "</endDate>"
    End Function

End Class
