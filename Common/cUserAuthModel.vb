Option Explicit On
' 楽天の入力パラメータの認証モデルを定義
Public Class cUserAuthModel
    ' ユーザー名
    Private userName As String
    ' 店舗URL
    Private shopUrl As String
    ' 認証キー
    Private authKey As String

    Public Sub setUserName(ByVal iUserName As String)
        Me.userName = iUserName
    End Sub
    Public Function xmlUserName() As String
        Return "<userName>" & Me.userName & "</userName>"
    End Function

    Public Sub setShopUrl(ByVal iShopUrl As String)
        Me.shopUrl = iShopUrl
    End Sub
    Public Function xmlShopUrl() As String
        Return "<shopUrl>" & Me.shopUrl & "</shopUrl>"
    End Function

    Public Sub setAuthKey(ByVal iAuthKey As String)
        Me.authKey = iAuthKey
    End Sub
    Public Function xmlauthkey() As String
        Return "<authKey>" & Me.authKey & "</authKey>"
    End Function
End Class

