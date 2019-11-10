Option Explicit On
' 楽天の入力パラメータの受注情報モデルを定義
Public Class cGetOrderRequestModel
    '注文情報取得フラグ
    Private isOrderNumberOnlyFlg As Boolean

    '受注検索モデル
    Private orderSearchModel As String

    Public Sub setIsOrderNumberOnlyFlg(ByVal iIsOrderNumberOnlyFlg As Boolean)
        Me.isOrderNumberOnlyFlg = iIsOrderNumberOnlyFlg
    End Sub
    Public Function xmlIsOrderNumberOnlyFlg() As String
        Return "<isOrderNumberOnlyFlg>" & Me.isOrderNumberOnlyFlg & "</isOrderNumberOnlyFlg>"
    End Function

    Public Sub setOrderSearchModel(ByVal strOrderSearchModel As String)
        Me.orderSearchModel = strOrderSearchModel
    End Sub

    Public Function xmlOrderSearchModel() As String
        Return "<orderSearchModel>" & Me.orderSearchModel & "</orderSearchModel>"
    End Function
End Class
