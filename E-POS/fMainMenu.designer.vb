<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fMainMenu
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fMainMenu))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.MONTH_CLOSE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.OUT_CASH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.IN_CASH_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.REQ_ORDER_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.DAYCLOSE_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.REGISTER_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.REG_OPEN_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.INVCHECK_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ARRIVAL_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ORDER_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PRODUCT_OUTPUT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.PRODUCT_INPUT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.NET_IMPORT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BOM_MST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ROOM_MST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ACCOUNT_MST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.MEMBER_MST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.STAFF_MST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SUPPLIER_MST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.DELIVERY_MST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.PAYMENT_MST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.BUMON_MST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.ROLE_MST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.PRODUCT_MST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CHANNEL_MST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.DELIVERY_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SHIPMENT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.SALE_DATA_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.POINT_CARD_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.RESERV_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.TAG_PRINT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SYSTEM_G = New System.Windows.Forms.GroupBox()
        Me.STOCK_MST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CATEGORY_MST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.CONFIG_MST_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.SYSTEM_TOP_L = New System.Windows.Forms.Label()
        Me.SYSTEM_BOTTOM_L = New System.Windows.Forms.Label()
        Me.EXIT_B = New Softgroup.NetButton.NetButton(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SYSTEM_G.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.MONTH_CLOSE_B)
        Me.GroupBox1.Controls.Add(Me.OUT_CASH_B)
        Me.GroupBox1.Controls.Add(Me.IN_CASH_B)
        Me.GroupBox1.Controls.Add(Me.REQ_ORDER_B)
        Me.GroupBox1.Controls.Add(Me.DAYCLOSE_B)
        Me.GroupBox1.Controls.Add(Me.REGISTER_B)
        Me.GroupBox1.Controls.Add(Me.REG_OPEN_B)
        Me.GroupBox1.Location = New System.Drawing.Point(91, 179)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(848, 90)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "【販売管理】"
        '
        'MONTH_CLOSE_B
        '
        Me.MONTH_CLOSE_B.ColorBottom = System.Drawing.Color.Wheat
        Me.MONTH_CLOSE_B.CornerRadius = 15
        Me.MONTH_CLOSE_B.Location = New System.Drawing.Point(484, 18)
        Me.MONTH_CLOSE_B.Name = "MONTH_CLOSE_B"
        Me.MONTH_CLOSE_B.Size = New System.Drawing.Size(116, 59)
        Me.MONTH_CLOSE_B.TabIndex = 31
        Me.MONTH_CLOSE_B.TextButton = "月次締め処理"
        '
        'OUT_CASH_B
        '
        Me.OUT_CASH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.OUT_CASH_B.CornerRadius = 15
        Me.OUT_CASH_B.Location = New System.Drawing.Point(722, 18)
        Me.OUT_CASH_B.Name = "OUT_CASH_B"
        Me.OUT_CASH_B.Size = New System.Drawing.Size(116, 59)
        Me.OUT_CASH_B.TabIndex = 6
        Me.OUT_CASH_B.TextButton = "出　金"
        '
        'IN_CASH_B
        '
        Me.IN_CASH_B.ColorBottom = System.Drawing.Color.Wheat
        Me.IN_CASH_B.CornerRadius = 15
        Me.IN_CASH_B.Location = New System.Drawing.Point(603, 18)
        Me.IN_CASH_B.Name = "IN_CASH_B"
        Me.IN_CASH_B.Size = New System.Drawing.Size(116, 59)
        Me.IN_CASH_B.TabIndex = 5
        Me.IN_CASH_B.TextButton = "入　金"
        '
        'REQ_ORDER_B
        '
        Me.REQ_ORDER_B.ColorBottom = System.Drawing.Color.Wheat
        Me.REQ_ORDER_B.CornerRadius = 15
        Me.REQ_ORDER_B.Location = New System.Drawing.Point(365, 18)
        Me.REQ_ORDER_B.Name = "REQ_ORDER_B"
        Me.REQ_ORDER_B.Size = New System.Drawing.Size(116, 59)
        Me.REQ_ORDER_B.TabIndex = 4
        Me.REQ_ORDER_B.TextButton = "注文登録"
        '
        'DAYCLOSE_B
        '
        Me.DAYCLOSE_B.ColorBottom = System.Drawing.Color.Wheat
        Me.DAYCLOSE_B.CornerRadius = 15
        Me.DAYCLOSE_B.Location = New System.Drawing.Point(246, 18)
        Me.DAYCLOSE_B.Name = "DAYCLOSE_B"
        Me.DAYCLOSE_B.Size = New System.Drawing.Size(116, 59)
        Me.DAYCLOSE_B.TabIndex = 3
        Me.DAYCLOSE_B.TextButton = "日次締め処理"
        '
        'REGISTER_B
        '
        Me.REGISTER_B.ColorBottom = System.Drawing.Color.Wheat
        Me.REGISTER_B.CornerRadius = 15
        Me.REGISTER_B.Location = New System.Drawing.Point(127, 18)
        Me.REGISTER_B.Name = "REGISTER_B"
        Me.REGISTER_B.Size = New System.Drawing.Size(116, 59)
        Me.REGISTER_B.TabIndex = 2
        Me.REGISTER_B.TextButton = "レジ登録"
        '
        'REG_OPEN_B
        '
        Me.REG_OPEN_B.ColorBottom = System.Drawing.Color.Wheat
        Me.REG_OPEN_B.CornerRadius = 15
        Me.REG_OPEN_B.Location = New System.Drawing.Point(8, 18)
        Me.REG_OPEN_B.Name = "REG_OPEN_B"
        Me.REG_OPEN_B.Size = New System.Drawing.Size(116, 59)
        Me.REG_OPEN_B.TabIndex = 1
        Me.REG_OPEN_B.TextButton = "レジ入金"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.INVCHECK_B)
        Me.GroupBox2.Controls.Add(Me.ARRIVAL_B)
        Me.GroupBox2.Controls.Add(Me.ORDER_B)
        Me.GroupBox2.Location = New System.Drawing.Point(595, 270)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(344, 100)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "【在庫管理】"
        '
        'INVCHECK_B
        '
        Me.INVCHECK_B.ColorBottom = System.Drawing.Color.Tan
        Me.INVCHECK_B.CornerRadius = 25
        Me.INVCHECK_B.Location = New System.Drawing.Point(232, 25)
        Me.INVCHECK_B.Name = "INVCHECK_B"
        Me.INVCHECK_B.Size = New System.Drawing.Size(106, 59)
        Me.INVCHECK_B.TabIndex = 3
        Me.INVCHECK_B.TextButton = "棚　卸"
        '
        'ARRIVAL_B
        '
        Me.ARRIVAL_B.ColorBottom = System.Drawing.Color.Tan
        Me.ARRIVAL_B.CornerRadius = 25
        Me.ARRIVAL_B.Location = New System.Drawing.Point(121, 25)
        Me.ARRIVAL_B.Name = "ARRIVAL_B"
        Me.ARRIVAL_B.Size = New System.Drawing.Size(106, 59)
        Me.ARRIVAL_B.TabIndex = 2
        Me.ARRIVAL_B.TextButton = "入　庫"
        '
        'ORDER_B
        '
        Me.ORDER_B.ColorBottom = System.Drawing.Color.Tan
        Me.ORDER_B.CornerRadius = 25
        Me.ORDER_B.Location = New System.Drawing.Point(11, 25)
        Me.ORDER_B.Name = "ORDER_B"
        Me.ORDER_B.Size = New System.Drawing.Size(106, 59)
        Me.ORDER_B.TabIndex = 1
        Me.ORDER_B.TextButton = "発　注"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PRODUCT_OUTPUT_B)
        Me.GroupBox3.Controls.Add(Me.PRODUCT_INPUT_B)
        Me.GroupBox3.Controls.Add(Me.NET_IMPORT_B)
        Me.GroupBox3.Location = New System.Drawing.Point(91, 271)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(498, 99)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "【ネットショップ管理】"
        '
        'PRODUCT_OUTPUT_B
        '
        Me.PRODUCT_OUTPUT_B.ColorBottom = System.Drawing.Color.BurlyWood
        Me.PRODUCT_OUTPUT_B.CornerRadius = 15
        Me.PRODUCT_OUTPUT_B.Location = New System.Drawing.Point(336, 24)
        Me.PRODUCT_OUTPUT_B.Name = "PRODUCT_OUTPUT_B"
        Me.PRODUCT_OUTPUT_B.Size = New System.Drawing.Size(155, 59)
        Me.PRODUCT_OUTPUT_B.TabIndex = 3
        Me.PRODUCT_OUTPUT_B.TextButton = "商品情報CSV出力"
        '
        'PRODUCT_INPUT_B
        '
        Me.PRODUCT_INPUT_B.ColorBottom = System.Drawing.Color.BurlyWood
        Me.PRODUCT_INPUT_B.CornerRadius = 15
        Me.PRODUCT_INPUT_B.Location = New System.Drawing.Point(171, 24)
        Me.PRODUCT_INPUT_B.Name = "PRODUCT_INPUT_B"
        Me.PRODUCT_INPUT_B.Size = New System.Drawing.Size(155, 59)
        Me.PRODUCT_INPUT_B.TabIndex = 2
        Me.PRODUCT_INPUT_B.TextButton = "商品情報CSV取込"
        '
        'NET_IMPORT_B
        '
        Me.NET_IMPORT_B.ColorBottom = System.Drawing.Color.BurlyWood
        Me.NET_IMPORT_B.CornerRadius = 15
        Me.NET_IMPORT_B.Location = New System.Drawing.Point(7, 24)
        Me.NET_IMPORT_B.Name = "NET_IMPORT_B"
        Me.NET_IMPORT_B.Size = New System.Drawing.Size(155, 59)
        Me.NET_IMPORT_B.TabIndex = 1
        Me.NET_IMPORT_B.TextButton = "注文データ取込"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.BOM_MST_B)
        Me.GroupBox4.Controls.Add(Me.ROOM_MST_B)
        Me.GroupBox4.Controls.Add(Me.ACCOUNT_MST_B)
        Me.GroupBox4.Controls.Add(Me.MEMBER_MST_B)
        Me.GroupBox4.Controls.Add(Me.STAFF_MST_B)
        Me.GroupBox4.Controls.Add(Me.SUPPLIER_MST_B)
        Me.GroupBox4.Controls.Add(Me.DELIVERY_MST_B)
        Me.GroupBox4.Controls.Add(Me.PAYMENT_MST_B)
        Me.GroupBox4.Controls.Add(Me.BUMON_MST_B)
        Me.GroupBox4.Controls.Add(Me.ROLE_MST_B)
        Me.GroupBox4.Controls.Add(Me.PRODUCT_MST_B)
        Me.GroupBox4.Location = New System.Drawing.Point(91, 376)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(498, 186)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "【マスタ管理】"
        '
        'BOM_MST_B
        '
        Me.BOM_MST_B.ColorBottom = System.Drawing.Color.Peru
        Me.BOM_MST_B.CornerRadius = 25
        Me.BOM_MST_B.Location = New System.Drawing.Point(135, 16)
        Me.BOM_MST_B.Name = "BOM_MST_B"
        Me.BOM_MST_B.Size = New System.Drawing.Size(100, 50)
        Me.BOM_MST_B.TabIndex = 12
        Me.BOM_MST_B.TextButton = "構成"
        '
        'ROOM_MST_B
        '
        Me.ROOM_MST_B.ColorBottom = System.Drawing.Color.Peru
        Me.ROOM_MST_B.CornerRadius = 25
        Me.ROOM_MST_B.Location = New System.Drawing.Point(11, 120)
        Me.ROOM_MST_B.Name = "ROOM_MST_B"
        Me.ROOM_MST_B.Size = New System.Drawing.Size(100, 50)
        Me.ROOM_MST_B.TabIndex = 11
        Me.ROOM_MST_B.TextButton = "ルーム"
        '
        'ACCOUNT_MST_B
        '
        Me.ACCOUNT_MST_B.ColorBottom = System.Drawing.Color.Peru
        Me.ACCOUNT_MST_B.CornerRadius = 25
        Me.ACCOUNT_MST_B.Location = New System.Drawing.Point(258, 120)
        Me.ACCOUNT_MST_B.Name = "ACCOUNT_MST_B"
        Me.ACCOUNT_MST_B.Size = New System.Drawing.Size(100, 50)
        Me.ACCOUNT_MST_B.TabIndex = 10
        Me.ACCOUNT_MST_B.TextButton = "勘定科目"
        '
        'MEMBER_MST_B
        '
        Me.MEMBER_MST_B.ColorBottom = System.Drawing.Color.Peru
        Me.MEMBER_MST_B.CornerRadius = 25
        Me.MEMBER_MST_B.Location = New System.Drawing.Point(11, 68)
        Me.MEMBER_MST_B.Name = "MEMBER_MST_B"
        Me.MEMBER_MST_B.Size = New System.Drawing.Size(100, 50)
        Me.MEMBER_MST_B.TabIndex = 5
        Me.MEMBER_MST_B.TextButton = "会員"
        '
        'STAFF_MST_B
        '
        Me.STAFF_MST_B.ColorBottom = System.Drawing.Color.Peru
        Me.STAFF_MST_B.CornerRadius = 25
        Me.STAFF_MST_B.Location = New System.Drawing.Point(368, 16)
        Me.STAFF_MST_B.Name = "STAFF_MST_B"
        Me.STAFF_MST_B.Size = New System.Drawing.Size(100, 50)
        Me.STAFF_MST_B.TabIndex = 9
        Me.STAFF_MST_B.TextButton = "スタッフ"
        '
        'SUPPLIER_MST_B
        '
        Me.SUPPLIER_MST_B.ColorBottom = System.Drawing.Color.Peru
        Me.SUPPLIER_MST_B.CornerRadius = 25
        Me.SUPPLIER_MST_B.Location = New System.Drawing.Point(258, 68)
        Me.SUPPLIER_MST_B.Name = "SUPPLIER_MST_B"
        Me.SUPPLIER_MST_B.Size = New System.Drawing.Size(100, 50)
        Me.SUPPLIER_MST_B.TabIndex = 4
        Me.SUPPLIER_MST_B.TextButton = "仕入先"
        '
        'DELIVERY_MST_B
        '
        Me.DELIVERY_MST_B.ColorBottom = System.Drawing.Color.Peru
        Me.DELIVERY_MST_B.CornerRadius = 25
        Me.DELIVERY_MST_B.Location = New System.Drawing.Point(135, 120)
        Me.DELIVERY_MST_B.Name = "DELIVERY_MST_B"
        Me.DELIVERY_MST_B.Size = New System.Drawing.Size(100, 50)
        Me.DELIVERY_MST_B.TabIndex = 3
        Me.DELIVERY_MST_B.TextButton = "配送"
        '
        'PAYMENT_MST_B
        '
        Me.PAYMENT_MST_B.ColorBottom = System.Drawing.Color.Peru
        Me.PAYMENT_MST_B.CornerRadius = 25
        Me.PAYMENT_MST_B.Location = New System.Drawing.Point(368, 68)
        Me.PAYMENT_MST_B.Name = "PAYMENT_MST_B"
        Me.PAYMENT_MST_B.Size = New System.Drawing.Size(100, 50)
        Me.PAYMENT_MST_B.TabIndex = 7
        Me.PAYMENT_MST_B.TextButton = "支払方法"
        '
        'BUMON_MST_B
        '
        Me.BUMON_MST_B.ColorBottom = System.Drawing.Color.Peru
        Me.BUMON_MST_B.CornerRadius = 25
        Me.BUMON_MST_B.Location = New System.Drawing.Point(135, 68)
        Me.BUMON_MST_B.Name = "BUMON_MST_B"
        Me.BUMON_MST_B.Size = New System.Drawing.Size(100, 50)
        Me.BUMON_MST_B.TabIndex = 2
        Me.BUMON_MST_B.TextButton = "部門"
        '
        'ROLE_MST_B
        '
        Me.ROLE_MST_B.ColorBottom = System.Drawing.Color.Peru
        Me.ROLE_MST_B.CornerRadius = 25
        Me.ROLE_MST_B.Location = New System.Drawing.Point(258, 16)
        Me.ROLE_MST_B.Name = "ROLE_MST_B"
        Me.ROLE_MST_B.Size = New System.Drawing.Size(100, 50)
        Me.ROLE_MST_B.TabIndex = 6
        Me.ROLE_MST_B.TextButton = "役割"
        '
        'PRODUCT_MST_B
        '
        Me.PRODUCT_MST_B.ColorBottom = System.Drawing.Color.Peru
        Me.PRODUCT_MST_B.CornerRadius = 25
        Me.PRODUCT_MST_B.Location = New System.Drawing.Point(11, 16)
        Me.PRODUCT_MST_B.Name = "PRODUCT_MST_B"
        Me.PRODUCT_MST_B.Size = New System.Drawing.Size(100, 50)
        Me.PRODUCT_MST_B.TabIndex = 1
        Me.PRODUCT_MST_B.TextButton = "商品"
        '
        'CHANNEL_MST_B
        '
        Me.CHANNEL_MST_B.ColorBottom = System.Drawing.Color.Peru
        Me.CHANNEL_MST_B.CornerRadius = 30
        Me.CHANNEL_MST_B.Location = New System.Drawing.Point(137, 30)
        Me.CHANNEL_MST_B.Name = "CHANNEL_MST_B"
        Me.CHANNEL_MST_B.Size = New System.Drawing.Size(106, 59)
        Me.CHANNEL_MST_B.TabIndex = 8
        Me.CHANNEL_MST_B.TextButton = "チャネル"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.DELIVERY_B)
        Me.GroupBox5.Controls.Add(Me.SHIPMENT_B)
        Me.GroupBox5.Location = New System.Drawing.Point(595, 375)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(344, 100)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "【出荷管理】"
        '
        'DELIVERY_B
        '
        Me.DELIVERY_B.ColorBottom = System.Drawing.Color.BurlyWood
        Me.DELIVERY_B.CornerRadius = 25
        Me.DELIVERY_B.Location = New System.Drawing.Point(181, 23)
        Me.DELIVERY_B.Name = "DELIVERY_B"
        Me.DELIVERY_B.Size = New System.Drawing.Size(157, 59)
        Me.DELIVERY_B.TabIndex = 2
        Me.DELIVERY_B.TextButton = "配送伝票データ出力"
        '
        'SHIPMENT_B
        '
        Me.SHIPMENT_B.ColorBottom = System.Drawing.Color.BurlyWood
        Me.SHIPMENT_B.CornerRadius = 25
        Me.SHIPMENT_B.Location = New System.Drawing.Point(11, 23)
        Me.SHIPMENT_B.Name = "SHIPMENT_B"
        Me.SHIPMENT_B.Size = New System.Drawing.Size(157, 59)
        Me.SHIPMENT_B.TabIndex = 1
        Me.SHIPMENT_B.TextButton = "出　庫"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.SALE_DATA_B)
        Me.GroupBox6.Controls.Add(Me.POINT_CARD_B)
        Me.GroupBox6.Controls.Add(Me.RESERV_B)
        Me.GroupBox6.Controls.Add(Me.TAG_PRINT_B)
        Me.GroupBox6.Location = New System.Drawing.Point(595, 480)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(344, 100)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "【その他業務】"
        '
        'SALE_DATA_B
        '
        Me.SALE_DATA_B.ColorBottom = System.Drawing.Color.Moccasin
        Me.SALE_DATA_B.CornerRadius = 30
        Me.SALE_DATA_B.Location = New System.Drawing.Point(255, 23)
        Me.SALE_DATA_B.Name = "SALE_DATA_B"
        Me.SALE_DATA_B.Size = New System.Drawing.Size(80, 59)
        Me.SALE_DATA_B.TabIndex = 3
        Me.SALE_DATA_B.TextButton = "売上データCSV出力"
        '
        'POINT_CARD_B
        '
        Me.POINT_CARD_B.ColorBottom = System.Drawing.Color.Moccasin
        Me.POINT_CARD_B.CornerRadius = 30
        Me.POINT_CARD_B.Location = New System.Drawing.Point(172, 23)
        Me.POINT_CARD_B.Name = "POINT_CARD_B"
        Me.POINT_CARD_B.Size = New System.Drawing.Size(80, 59)
        Me.POINT_CARD_B.TabIndex = 3
        Me.POINT_CARD_B.TextButton = "ポイントカード管理"
        '
        'RESERV_B
        '
        Me.RESERV_B.ColorBottom = System.Drawing.Color.Moccasin
        Me.RESERV_B.CornerRadius = 30
        Me.RESERV_B.Location = New System.Drawing.Point(89, 23)
        Me.RESERV_B.Name = "RESERV_B"
        Me.RESERV_B.Size = New System.Drawing.Size(80, 59)
        Me.RESERV_B.TabIndex = 2
        Me.RESERV_B.TextButton = "予　約"
        '
        'TAG_PRINT_B
        '
        Me.TAG_PRINT_B.ColorBottom = System.Drawing.Color.Moccasin
        Me.TAG_PRINT_B.CornerRadius = 30
        Me.TAG_PRINT_B.Location = New System.Drawing.Point(7, 23)
        Me.TAG_PRINT_B.Name = "TAG_PRINT_B"
        Me.TAG_PRINT_B.Size = New System.Drawing.Size(80, 59)
        Me.TAG_PRINT_B.TabIndex = 1
        Me.TAG_PRINT_B.TextButton = "タグ発行"
        '
        'SYSTEM_G
        '
        Me.SYSTEM_G.Controls.Add(Me.STOCK_MST_B)
        Me.SYSTEM_G.Controls.Add(Me.CATEGORY_MST_B)
        Me.SYSTEM_G.Controls.Add(Me.CONFIG_MST_B)
        Me.SYSTEM_G.Controls.Add(Me.CHANNEL_MST_B)
        Me.SYSTEM_G.Enabled = False
        Me.SYSTEM_G.Location = New System.Drawing.Point(91, 568)
        Me.SYSTEM_G.Name = "SYSTEM_G"
        Me.SYSTEM_G.Size = New System.Drawing.Size(498, 99)
        Me.SYSTEM_G.TabIndex = 7
        Me.SYSTEM_G.TabStop = False
        Me.SYSTEM_G.Text = "【システム管理】"
        '
        'STOCK_MST_B
        '
        Me.STOCK_MST_B.ColorBottom = System.Drawing.Color.Peru
        Me.STOCK_MST_B.CornerRadius = 30
        Me.STOCK_MST_B.Location = New System.Drawing.Point(375, 30)
        Me.STOCK_MST_B.Name = "STOCK_MST_B"
        Me.STOCK_MST_B.Size = New System.Drawing.Size(106, 59)
        Me.STOCK_MST_B.TabIndex = 4
        Me.STOCK_MST_B.TextButton = "在庫"
        '
        'CATEGORY_MST_B
        '
        Me.CATEGORY_MST_B.ColorBottom = System.Drawing.Color.Peru
        Me.CATEGORY_MST_B.CornerRadius = 30
        Me.CATEGORY_MST_B.Location = New System.Drawing.Point(258, 30)
        Me.CATEGORY_MST_B.Name = "CATEGORY_MST_B"
        Me.CATEGORY_MST_B.Size = New System.Drawing.Size(106, 59)
        Me.CATEGORY_MST_B.TabIndex = 2
        Me.CATEGORY_MST_B.TextButton = "カテゴリ"
        '
        'CONFIG_MST_B
        '
        Me.CONFIG_MST_B.ColorBottom = System.Drawing.Color.Peru
        Me.CONFIG_MST_B.CornerRadius = 30
        Me.CONFIG_MST_B.Location = New System.Drawing.Point(9, 30)
        Me.CONFIG_MST_B.Name = "CONFIG_MST_B"
        Me.CONFIG_MST_B.Size = New System.Drawing.Size(106, 59)
        Me.CONFIG_MST_B.TabIndex = 1
        Me.CONFIG_MST_B.TextButton = "環　境"
        '
        'SYSTEM_TOP_L
        '
        Me.SYSTEM_TOP_L.BackColor = System.Drawing.Color.Red
        Me.SYSTEM_TOP_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SYSTEM_TOP_L.ForeColor = System.Drawing.Color.White
        Me.SYSTEM_TOP_L.Location = New System.Drawing.Point(50, 34)
        Me.SYSTEM_TOP_L.Name = "SYSTEM_TOP_L"
        Me.SYSTEM_TOP_L.Size = New System.Drawing.Size(929, 18)
        Me.SYSTEM_TOP_L.TabIndex = 27
        Me.SYSTEM_TOP_L.Text = "システム管理モード"
        Me.SYSTEM_TOP_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SYSTEM_BOTTOM_L
        '
        Me.SYSTEM_BOTTOM_L.BackColor = System.Drawing.Color.Red
        Me.SYSTEM_BOTTOM_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SYSTEM_BOTTOM_L.ForeColor = System.Drawing.Color.White
        Me.SYSTEM_BOTTOM_L.Location = New System.Drawing.Point(50, 718)
        Me.SYSTEM_BOTTOM_L.Name = "SYSTEM_BOTTOM_L"
        Me.SYSTEM_BOTTOM_L.Size = New System.Drawing.Size(929, 13)
        Me.SYSTEM_BOTTOM_L.TabIndex = 28
        Me.SYSTEM_BOTTOM_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EXIT_B
        '
        Me.EXIT_B.ColorBottom = System.Drawing.Color.SandyBrown
        Me.EXIT_B.CornerRadius = 20
        Me.EXIT_B.Location = New System.Drawing.Point(657, 598)
        Me.EXIT_B.Name = "EXIT_B"
        Me.EXIT_B.Size = New System.Drawing.Size(234, 45)
        Me.EXIT_B.TabIndex = 8
        Me.EXIT_B.TextButton = "終　了"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.E_POS.My.Resources.Resources.CopyRight
        Me.PictureBox2.Location = New System.Drawing.Point(349, 679)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(375, 20)
        Me.PictureBox2.TabIndex = 30
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.E_POS.My.Resources.Resources.Title_back
        Me.PictureBox1.InitialImage = Global.E_POS.My.Resources.Resources.Title_back
        Me.PictureBox1.Location = New System.Drawing.Point(379, 97)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(293, 58)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 29
        Me.PictureBox1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.SaddleBrown
        Me.RectangleShape1.CornerRadius = 10
        Me.RectangleShape1.Location = New System.Drawing.Point(48, 63)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(928, 642)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2, Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1024, 768)
        Me.ShapeContainer1.TabIndex = 31
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BorderColor = System.Drawing.Color.SaddleBrown
        Me.RectangleShape2.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot
        Me.RectangleShape2.CornerRadius = 10
        Me.RectangleShape2.Location = New System.Drawing.Point(69, 77)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(887, 595)
        '
        'fMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.EXIT_B)
        Me.Controls.Add(Me.SYSTEM_BOTTOM_L)
        Me.Controls.Add(Me.SYSTEM_TOP_L)
        Me.Controls.Add(Me.SYSTEM_G)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "fMainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "<< EZ-POSシステム >>"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.SYSTEM_G.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents SYSTEM_G As System.Windows.Forms.GroupBox
    Friend WithEvents SYSTEM_TOP_L As System.Windows.Forms.Label
    Friend WithEvents SYSTEM_BOTTOM_L As System.Windows.Forms.Label
    Friend WithEvents EXIT_B As Softgroup.NetButton.NetButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents RESERV_B As Softgroup.NetButton.NetButton
    Friend WithEvents TAG_PRINT_B As Softgroup.NetButton.NetButton
    Friend WithEvents ARRIVAL_B As Softgroup.NetButton.NetButton
    Friend WithEvents ORDER_B As Softgroup.NetButton.NetButton
    Friend WithEvents PRODUCT_OUTPUT_B As Softgroup.NetButton.NetButton
    Friend WithEvents PRODUCT_INPUT_B As Softgroup.NetButton.NetButton
    Friend WithEvents NET_IMPORT_B As Softgroup.NetButton.NetButton
    Friend WithEvents ACCOUNT_MST_B As Softgroup.NetButton.NetButton
    Friend WithEvents MEMBER_MST_B As Softgroup.NetButton.NetButton
    Friend WithEvents STAFF_MST_B As Softgroup.NetButton.NetButton
    Friend WithEvents SUPPLIER_MST_B As Softgroup.NetButton.NetButton
    Friend WithEvents CHANNEL_MST_B As Softgroup.NetButton.NetButton
    Friend WithEvents DELIVERY_MST_B As Softgroup.NetButton.NetButton
    Friend WithEvents PAYMENT_MST_B As Softgroup.NetButton.NetButton
    Friend WithEvents BUMON_MST_B As Softgroup.NetButton.NetButton
    Friend WithEvents ROLE_MST_B As Softgroup.NetButton.NetButton
    Friend WithEvents PRODUCT_MST_B As Softgroup.NetButton.NetButton
    Friend WithEvents SHIPMENT_B As Softgroup.NetButton.NetButton
    Friend WithEvents STOCK_MST_B As Softgroup.NetButton.NetButton
    Friend WithEvents CATEGORY_MST_B As Softgroup.NetButton.NetButton
    Friend WithEvents CONFIG_MST_B As Softgroup.NetButton.NetButton
    Friend WithEvents OUT_CASH_B As Softgroup.NetButton.NetButton
    Friend WithEvents IN_CASH_B As Softgroup.NetButton.NetButton
    Friend WithEvents REQ_ORDER_B As Softgroup.NetButton.NetButton
    Friend WithEvents DAYCLOSE_B As Softgroup.NetButton.NetButton
    Friend WithEvents REGISTER_B As Softgroup.NetButton.NetButton
    Friend WithEvents REG_OPEN_B As Softgroup.NetButton.NetButton
    Friend WithEvents INVCHECK_B As Softgroup.NetButton.NetButton
    Friend WithEvents DELIVERY_B As Softgroup.NetButton.NetButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents SALE_DATA_B As Softgroup.NetButton.NetButton
    Friend WithEvents ROOM_MST_B As Softgroup.NetButton.NetButton
    Friend WithEvents POINT_CARD_B As Softgroup.NetButton.NetButton
    Friend WithEvents BOM_MST_B As Softgroup.NetButton.NetButton
    Friend WithEvents MONTH_CLOSE_B As Softgroup.NetButton.NetButton
    Private WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Private WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Private WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
End Class
