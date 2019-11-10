Imports System
Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' DataGridViewProgressBarCellオブジェクトの列
''' </summary>
Public Class cDataGridViewProgressBarColumn
    Inherits DataGridViewTextBoxColumn

    'コンストラクタ
    Public Sub New()
        Me.CellTemplate = New DataGridViewProgressBarCell()
    End Sub

    'CellTemplateの取得と設定
    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)
            'DataGridViewProgressBarCell以外はホストしない
            If Not TypeOf value Is DataGridViewProgressBarCell Then
                Throw New InvalidCastException( _
                    "DataGridViewProgressBarCellオブジェクトを" + _
                    "指定してください。")
            End If
            MyBase.CellTemplate = value
        End Set
    End Property

    ''' <summary>
    ''' ProgressBarの最大値
    ''' </summary>
    Public Property Maximum() As Integer
        Get
            Return CType(Me.CellTemplate, DataGridViewProgressBarCell).Maximum
        End Get
        Set(ByVal value As Integer)
            If Me.Maximum = value Then
                Return
            End If
            'セルテンプレートの値を変更する
            CType(Me.CellTemplate, DataGridViewProgressBarCell).Maximum = value
            'DataGridViewにすでに追加されているセルの値を変更する
            If Me.DataGridView Is Nothing Then
                Return
            End If
            Dim rowCount As Integer = Me.DataGridView.RowCount
            Dim i As Integer
            For i = 0 To rowCount - 1
                Dim r As DataGridViewRow = Me.DataGridView.Rows.SharedRow(i)
                CType(r.Cells(Me.Index), DataGridViewProgressBarCell).Maximum = _
                    value
            Next i
        End Set
    End Property

    ''' <summary>
    ''' ProgressBarの最小値
    ''' </summary>
    Public Property Mimimum() As Integer
        Get
            Return CType(Me.CellTemplate, DataGridViewProgressBarCell).Mimimum
        End Get
        Set(ByVal value As Integer)
            If Me.Mimimum = value Then
                Return
            End If
            'セルテンプレートの値を変更する
            CType(Me.CellTemplate, DataGridViewProgressBarCell).Mimimum = value
            'DataGridViewにすでに追加されているセルの値を変更する
            If Me.DataGridView Is Nothing Then
                Return
            End If
            Dim rowCount As Integer = Me.DataGridView.RowCount
            Dim i As Integer
            For i = 0 To rowCount - 1
                Dim r As DataGridViewRow = Me.DataGridView.Rows.SharedRow(i)
                CType(r.Cells(Me.Index), DataGridViewProgressBarCell).Mimimum = _
                    value
            Next i
        End Set
    End Property
End Class

''' <summary>
''' ProgressBarをDataGridViewに表示する
''' </summary>
Public Class DataGridViewProgressBarCell
    Inherits DataGridViewTextBoxCell

    'コンストラクタ
    Public Sub New()
        Me.maximumValue = 100
        Me.mimimumValue = 0
    End Sub

    Private maximumValue As Integer

    Public Property Maximum() As Integer
        Get
            Return Me.maximumValue
        End Get
        Set(ByVal value As Integer)
            Me.maximumValue = value
        End Set
    End Property

    Private mimimumValue As Integer

    Public Property Mimimum() As Integer
        Get
            Return Me.mimimumValue
        End Get
        Set(ByVal value As Integer)
            Me.mimimumValue = value
        End Set
    End Property

    'セルの値のデータ型を指定する
    'ここでは、整数型とする
    Public Overrides ReadOnly Property ValueType() As Type
        Get
            Return GetType(Integer)
        End Get
    End Property

    '新しいレコード行のセルの既定値を指定する
    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            Return 0
        End Get
    End Property

    '新しいプロパティを追加しているため、
    ' Cloneメソッドをオーバーライドする必要がある
    Public Overrides Function Clone() As Object
        Dim cell As DataGridViewProgressBarCell = _
            CType(MyBase.Clone(), DataGridViewProgressBarCell)
        cell.Maximum = Me.Maximum
        cell.Mimimum = Me.Mimimum
        Return cell
    End Function

    Protected Overrides Sub Paint(ByVal graphics As Graphics, _
        ByVal clipBounds As Rectangle, _
        ByVal cellBounds As Rectangle, _
        ByVal rowIndex As Integer, _
        ByVal cellState As DataGridViewElementStates, _
        ByVal value As Object, _
        ByVal formattedValue As Object, _
        ByVal errorText As String, _
        ByVal cellStyle As DataGridViewCellStyle, _
        ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, _
        ByVal paintParts As DataGridViewPaintParts)

        '値を決定する
        Dim intValue As Integer = 0
        If TypeOf value Is Integer Then
            intValue = CInt(value)
        End If
        If intValue < Me.mimimumValue Then
            intValue = Me.mimimumValue
        End If
        If intValue > Me.maximumValue Then
            intValue = Me.maximumValue
        End If
        '割合を計算する
        Dim rate As Double = CDbl(intValue - Me.mimimumValue) / _
            (Me.maximumValue - Me.mimimumValue)

        'セルの境界線（枠）を描画する
        If (paintParts And DataGridViewPaintParts.Border) = _
                DataGridViewPaintParts.Border Then
            Me.PaintBorder(graphics, clipBounds, cellBounds, _
                cellStyle, advancedBorderStyle)
        End If

        '境界線の内側に範囲を取得する
        Dim borderRect As Rectangle = Me.BorderWidths(advancedBorderStyle)
        Dim paintRect As New Rectangle(cellBounds.Left + borderRect.Left, _
            cellBounds.Top + borderRect.Top, _
            cellBounds.Width - borderRect.Right, _
            cellBounds.Height - borderRect.Bottom)

        '背景色を決定する
        '選択されている時とされていない時で色を変える
        Dim isSelected As Boolean = _
            ((cellState And DataGridViewElementStates.Selected) = _
                DataGridViewElementStates.Selected)
        Dim bkColor As Color
        If isSelected AndAlso _
            (paintParts And DataGridViewPaintParts.SelectionBackground) = _
                DataGridViewPaintParts.SelectionBackground Then
            bkColor = cellStyle.SelectionBackColor
        Else
            bkColor = cellStyle.BackColor
        End If

        '背景を描画する
        If (paintParts And DataGridViewPaintParts.Background) = _
            DataGridViewPaintParts.Background Then
            Dim backBrush As New SolidBrush(bkColor)
            Try
                graphics.FillRectangle(backBrush, paintRect)
            Finally
                backBrush.Dispose()
            End Try
        End If

        'Paddingを差し引く
        paintRect.Offset(cellStyle.Padding.Right, cellStyle.Padding.Top)
        paintRect.Width -= cellStyle.Padding.Horizontal
        paintRect.Height -= cellStyle.Padding.Vertical

        'ProgressBarを描画する
        If (paintParts And DataGridViewPaintParts.ContentForeground) = _
            DataGridViewPaintParts.ContentForeground Then
            If ProgressBarRenderer.IsSupported Then
                'visualスタイルで描画する

                'ProgressBarの枠を描画する
                ProgressBarRenderer.DrawHorizontalBar(graphics, paintRect)
                'ProgressBarのバーを描画する
                Dim barBounds As New Rectangle(paintRect.Left + 3, _
                    paintRect.Top + 3, _
                    paintRect.Width - 4, _
                    paintRect.Height - 6)
                barBounds.Width = CInt(Math.Round((barBounds.Width * rate)))
                ProgressBarRenderer.DrawHorizontalChunks(graphics, barBounds)
            Else
                'visualスタイルで描画できない時
                graphics.FillRectangle(Brushes.White, paintRect)
                graphics.DrawRectangle(Pens.Black, paintRect)
                Dim barBounds As New Rectangle(paintRect.Left + 1, _
                    paintRect.Top + 1, _
                    paintRect.Width - 1, _
                    paintRect.Height - 1)
                barBounds.Width = CInt(Math.Round((barBounds.Width * rate)))
                graphics.FillRectangle(Brushes.Blue, barBounds)
            End If
        End If

        ''フォーカスの枠を表示する
        'If Me.DataGridView.CurrentCellAddress.X = Me.ColumnIndex AndAlso _
        '    Me.DataGridView.CurrentCellAddress.Y = Me.RowIndex AndAlso _
        '    (paintParts And DataGridViewPaintParts.Focus) = _
        '        DataGridViewPaintParts.Focus AndAlso _
        '    Me.DataGridView.Focused Then

        '    'フォーカス枠の大きさを適当に決める
        '    Dim focusRect As Rectangle = paintRect
        '    focusRect.Inflate(-3, -3)
        '    ControlPaint.DrawFocusRectangle(graphics, focusRect)
        '    '背景色を指定してフォーカス枠を描画する時
        '    'ControlPaint.DrawFocusRectangle(
        '    '    graphics, focusRect, Color.Empty, bkColor);
        'End If

        'テキストを表示する
        If (paintParts And DataGridViewPaintParts.ContentForeground) = _
            DataGridViewPaintParts.ContentForeground Then
            '表示するテキストを決定
            Dim txt As String = String.Format("{0}%", Math.Round((rate * 100)))
            'string txt = formattedValue.ToString();
            '本来は、cellStyleによりTextFormatFlagsを決定すべき
            Dim flags As TextFormatFlags = _
                TextFormatFlags.HorizontalCenter Or _
                    TextFormatFlags.VerticalCenter
            '色を決定
            Dim fColor As Color = cellStyle.ForeColor
            'if (isSelected)
            '    fColor = cellStyle.SelectionForeColor;
            'else
            '    fColor = cellStyle.ForeColor;
            'テキストを描画する
            'paintRect.Inflate(-2, -2)
            'TextRenderer.DrawText( _
            '    graphics, txt, cellStyle.Font, paintRect, fColor, flags)
        End If

        'エラーアイコンの表示
        If (paintParts And DataGridViewPaintParts.ErrorIcon) = _
                DataGridViewPaintParts.ErrorIcon AndAlso _
            Me.DataGridView.ShowCellErrors AndAlso _
            Not String.IsNullOrEmpty(errorText) Then

            'エラーアイコンを表示させる領域を取得
            Dim iconBounds As Rectangle = _
                Me.GetErrorIconBounds(graphics, cellStyle, rowIndex)
            iconBounds.Offset(cellBounds.X, cellBounds.Y)
            'エラーアイコンを描画
            Me.PaintErrorIcon(graphics, iconBounds, cellBounds, errorText)
        End If
    End Sub
End Class


