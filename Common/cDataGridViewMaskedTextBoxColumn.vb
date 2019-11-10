Imports System
Imports System.Windows.Forms

''' <summary>
''' DataGridViewMaskedTextBoxCellオブジェクトの列を表します。
''' </summary>
Public Class cDataGridViewMaskedTextBoxColumn
    Inherits DataGridViewColumn

    'CellTemplateとするDataGridViewMaskedTextBoxCellオブジェクトを指定して
    '基本クラスのコンストラクタを呼び出す
    Public Sub New()
        MyBase.New(New DataGridViewMaskedTextBoxCell())
    End Sub

    Private maskValue As String = ""
    ''' <summary>
    ''' MaskedTextBoxのMaskプロパティに適用する値
    ''' </summary>
    Public Property Mask() As String
        Get
            Return Me.maskValue
        End Get
        Set(ByVal value As String)
            Me.maskValue = value
        End Set
    End Property

    '新しいプロパティを追加しているため、
    ' Cloneメソッドをオーバーライドする必要がある
    Public Overrides Function Clone() As Object
        Dim col As cDataGridViewMaskedTextBoxColumn = _
            CType(MyBase.Clone(), cDataGridViewMaskedTextBoxColumn)
        col.Mask = Me.Mask
        Return col
    End Function

    'CellTemplateの取得と設定
    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)
            'DataGridViewMaskedTextBoxCellしか
            ' CellTemplateに設定できないようにする
            If Not TypeOf value Is DataGridViewMaskedTextBoxCell Then
                Throw New InvalidCastException( _
                    "DataGridViewMaskedTextBoxCellオブジェクトを" + _
                    "指定してください。")
            End If
            MyBase.CellTemplate = value
        End Set
    End Property
End Class

''' <summary>
''' MaskedTextBoxで編集できるテキスト情報を
''' DataGridViewコントロールに表示します。
''' </summary>
Public Class DataGridViewMaskedTextBoxCell
    Inherits DataGridViewTextBoxCell

    'コンストラクタ
    Public Sub New()
    End Sub

    '編集コントロールを初期化する
    '編集コントロールは別のセルや列でも使いまわされるため、初期化の必要がある
    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

        '編集コントロールの取得
        Dim maskedBox As DataGridViewMaskedTextBoxEditingControl = _
            Me.DataGridView.EditingControl
        If Not (maskedBox Is Nothing) Then
            'Textを設定
            maskedBox.Text = IIf(Me.Value Is Nothing, "", Me.Value.ToString())
            'カスタム列のプロパティを反映させる
            Dim column As cDataGridViewMaskedTextBoxColumn = Me.OwningColumn
            If Not (column Is Nothing) Then
                maskedBox.Mask = column.Mask
            End If
        End If
    End Sub

    '編集コントロールの型を指定する
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(DataGridViewMaskedTextBoxEditingControl)
        End Get
    End Property

    'セルの値のデータ型を指定する
    'ここでは、Object型とする
    '基本クラスと同じなので、オーバーライドの必要なし
    Public Overrides ReadOnly Property ValueType() As Type
        Get
            Return GetType(Object)
        End Get
    End Property

    '新しいレコード行のセルの既定値を指定する
    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            Return MyBase.DefaultNewRowValue
        End Get
    End Property
End Class

''' <summary>
''' DataGridViewMaskedTextBoxCellでホストされる
''' MaskedTextBoxコントロールを表します。
''' </summary>
Public Class DataGridViewMaskedTextBoxEditingControl
    Inherits MaskedTextBox
    Implements IDataGridViewEditingControl

    '編集コントロールが表示されているDataGridView
    Private dataGridView As DataGridView
    '編集コントロールが表示されている行
    Private rowIndex As Integer
    '編集コントロールの値とセルの値が違うかどうか
    Private valueChanged As Boolean

    'コンストラクタ
    Public Sub New()
        Me.TabStop = False
    End Sub

    '編集コントロールで変更されたセルの値
    Public Function GetEditingControlFormattedValue( _
        ByVal context As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Return Me.Text
    End Function

    '編集コントロールで変更されたセルの値
    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return Me.GetEditingControlFormattedValue( _
                DataGridViewDataErrorContexts.Formatting)
        End Get
        Set(ByVal value As Object)
            Me.Text = CStr(value)
        End Set
    End Property

    'セルスタイルを編集コントロールに適用する
    '編集コントロールの前景色、背景色、フォントなどをセルスタイルに合わせる
    Public Sub ApplyCellStyleToEditingControl( _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.ForeColor = dataGridViewCellStyle.ForeColor
        Me.BackColor = dataGridViewCellStyle.BackColor
        Select Case dataGridViewCellStyle.Alignment
            Case DataGridViewContentAlignment.BottomCenter, _
                    DataGridViewContentAlignment.MiddleCenter, _
                    DataGridViewContentAlignment.TopCenter
                Me.TextAlign = HorizontalAlignment.Center
            Case DataGridViewContentAlignment.BottomRight, _
                    DataGridViewContentAlignment.MiddleRight, _
                    DataGridViewContentAlignment.TopRight
                Me.TextAlign = HorizontalAlignment.Right
            Case Else
                Me.TextAlign = HorizontalAlignment.Left
        End Select
    End Sub

    '編集するセルがあるDataGridView
    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return Me.dataGridView
        End Get
        Set(ByVal value As DataGridView)
            Me.dataGridView = value
        End Set
    End Property

    '編集している行のインデックス
    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return Me.rowIndex
        End Get
        Set(ByVal value As Integer)
            Me.rowIndex = value
        End Set
    End Property

    '値が変更されたかどうか
    '編集コントロールの値とセルの値が違うかどうか
    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return Me.valueChanged
        End Get
        Set(ByVal value As Boolean)
            Me.valueChanged = value
        End Set
    End Property

    '指定されたキーをDataGridViewが処理するか、編集コントロールが処理するか
    'Trueを返すと、編集コントロールが処理する
    'dataGridViewWantsInputKeyがTrueの時は、DataGridViewが処理できる
    Public Function EditingControlWantsInputKey(ByVal keyData As Keys, _
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        'Keys.Left、Right、Home、Endの時は、Trueを返す
        'このようにしないと、これらのキーで別のセルにフォーカスが移ってしまう
        Select Case keyData And Keys.KeyCode
            Case Keys.Right, Keys.End, Keys.Left, Keys.Home
                Return True
            Case Else
                Return False
        End Select
    End Function

    'マウスカーソルがEditingPanel上にあるときのカーソルを指定する
    'EditingPanelは編集コントロールをホストするパネルで、
    '編集コントロールがセルより小さいとコントロール以外の部分がパネルとなる
    Public ReadOnly Property EditingPanelCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property

    'コントロールで編集する準備をする
    'テキストを選択状態にしたり、挿入ポインタを末尾にしたりする
    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        If selectAll Then
            '選択状態にする
            Me.SelectAll()
        Else
            '挿入ポインタを末尾にする
            Me.SelectionStart = Me.TextLength
        End If
    End Sub

    '値が変更した時に、セルの位置を変更するかどうか
    '値が変更された時に編集コントロールの大きさが変更される時はTrue
    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean _
        Implements _
            IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    '値が変更された時
    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        '値が変更されたことをDataGridViewに通知する
        Me.valueChanged = True
        Me.dataGridView.NotifyCurrentCellDirty(True)
    End Sub
End Class


