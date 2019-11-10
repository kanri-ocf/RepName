Module mConst
    '検索モード用
    Public Const PRODUCT_MODE = 1
    Public Const JAN_MODE = 2

    '周辺機器-機器種別用
    Public Const RECIRT_PRINTER = 1         'レシートプリンター
    Public Const CASH_DRAWER = 2            'ドローワ
    Public Const CUSTOMER_DISPLAY = 3       'カスタマディスプレー
    Public Const CARD_READER = 4            '磁気カードリーダー
    Public Const AUTO_CHANGEER = 5          '自動釣銭機
    Public Const CTI = 6                    'CTI
    Public Const CARD_PRINTER = 7           'カードプリンター

    'OPOS関連定義
    '*******************************
    '*     グローバル変数宣言      *
    '*******************************
    Public Const PTR_BM_ASIS = -11
    Public Const PTR_BM_CENTER = -2
    Public Const PTR_S_RECEIPT = 2

    Public Const PTR_BCS_JAN13 = 104

    Public Const PTR_BC_TEXT_NONE = -11
    Public Const PTR_BC_TEXT_BELOW = -13

    Public Const PTR_RP_NORMAL = &H1
    Public Const PTR_RP_RIGHT90 = &H101
    Public Const PTR_RP_ROTATE180 = &H103

    Public Const PTR_RP_BITMAP = &H2000
    Public Const PTR_RP_BARCODE = &H1000

    Public Const PTR_TP_TRANSACTION = 11
    Public Const PTR_TP_NORMAL = 12

    Public Const PTR_BC_LEFT = -1
    Public Const PTR_BC_CENTER = -2
    Public Const PTR_BC_RIGHT = -3

    '/////////////////////////////////////////////////////////////////////
    '// "CapBlink" Property Constants
    '/////////////////////////////////////////////////////////////////////

    Public Const DISP_CB_NOBLINK = 0
    Public Const DISP_CB_BLINKALL = 1
    Public Const DISP_CB_BLINKEACH = 2

    Public Const DISP_DEF_CB_NOBLINK = "DISP_CB_NOBLINK"
    Public Const DISP_DEF_CB_BLINKALL = "DISP_CB_BLINKALL"
    Public Const DISP_DEF_CB_BLINKEACH = "DISP_CB_BLINKEACH"


    '/////////////////////////////////////////////////////////////////////
    '// "CapCharacterSet" Property Constants
    '/////////////////////////////////////////////////////////////////////

    Public Const DISP_CCS_NUMERIC = 0
    Public Const DISP_CCS_ALPHA = 1
    Public Const DISP_CCS_ASCII = 998
    Public Const DISP_CCS_KANA = 10
    Public Const DISP_CCS_KANJI = 11

    Public Const DISP_DEF_CCS_NUMERIC = "DISP_CCS_NUMERIC"
    Public Const DISP_DEF_CCS_ALPHA = "DISP_CCS_ALPHA"
    Public Const DISP_DEF_CCS_ASCII = "DISP_CCS_ASCII"
    Public Const DISP_DEF_CCS_KANA = "DISP_DEF_CCS_KANA"
    Public Const DISP_DEF_CCS_KANJI = "DISP_DEF_CCS_KANJI"


    '/////////////////////////////////////////////////////////////////////
    '// "CharacterSet" Property Constants
    '/////////////////////////////////////////////////////////////////////

    Public Const DISP_CS_ASCII = 998
    Public Const DISP_CS_WINDOWS = 999

    Public Const DISP_DEF_CS_ASCII = "DISP_CS_ASCII"
    Public Const DISP_DEF_CS_WINDOWS = "DISP_CS_WINDOWS"


    '/////////////////////////////////////////////////////////////////////
    '// "MarqueeType" Property Constants
    '/////////////////////////////////////////////////////////////////////

    Public Const DISP_MT_NONE = 0
    Public Const DISP_MT_UP = 1
    Public Const DISP_MT_DOWN = 2
    Public Const DISP_MT_LEFT = 3
    Public Const DISP_MT_RIGHT = 4
    Public Const DISP_MT_INIT = 5

    Public Const DISP_DEF_MT_NONE = "DISP_MT_NONE"
    Public Const DISP_DEF_MT_UP = "DISP_MT_UP"
    Public Const DISP_DEF_MT_DOWN = "DISP_MT_DOWN"
    Public Const DISP_DEF_MT_LEFT = "DISP_MT_LEFT"
    Public Const DISP_DEF_MT_RIGHT = "DISP_MT_RIGHT"
    Public Const DISP_DEF_MT_INIT = "DISP_DEF_MT_INIT"


    '/////////////////////////////////////////////////////////////////////
    '// "DisplayText" Method: "Attribute" Property Constants
    '// "DisplayTextAt" Method: "Attribute" Property Constants
    '/////////////////////////////////////////////////////////////////////

    Public Const DISP_DT_NORMAL = 0
    Public Const DISP_DT_BLINK = 1

    Public Const DISP_DEF_DT_NORMAL = "DISP_DT_NORMAL"
    Public Const DISP_DEF_DT_BLINK = "DISP_DT_BLINK"


    '/////////////////////////////////////////////////////////////////////
    '// "ScrollText" Method: "Direction" Parameter Constants
    '/////////////////////////////////////////////////////////////////////

    Public Const DISP_ST_UP = 1
    Public Const DISP_ST_DOWN = 2
    Public Const DISP_ST_LEFT = 3
    Public Const DISP_ST_RIGHT = 4

    Public Const DISP_DEF_ST_UP = "DISP_ST_UP"
    Public Const DISP_DEF_ST_DOWN = "DISP_ST_DOWN"
    Public Const DISP_DEF_ST_LEFT = "DISP_ST_LEFT"
    Public Const DISP_DEF_ST_RIGHT = "DISP_ST_RIGHT"


    '/////////////////////////////////////////////////////////////////////
    '// "SetDescriptor" Method: "Attribute" Parameter Constants
    '/////////////////////////////////////////////////////////////////////

    Public Const DISP_SD_OFF = 0
    Public Const DISP_SD_ON = 1
    Public Const DISP_SD_BLINK = 2

    Public Const DISP_DEF_SD_OFF = "DISP_SD_OFF"
    Public Const DISP_DEF_SD_ON = "DISP_SD_ON"
    Public Const DISP_DEF_SD_BLINK = "DISP_SD_BLINK"

    '///////////////////////////////////////////////////////////////////
    ' OPOS "CapPowerReporting", "PowerState", "PowerNotify" Property
    '   Constants
    '///////////////////////////////////////////////////////////////////

    Public Const OPOS_PR_NONE = 0
    Public Const OPOS_PR_STANDARD = 1
    Public Const OPOS_PR_ADVANCED = 2

    Public Const OPOS_PN_DISABLED = 0
    Public Const OPOS_PN_ENABLED = 1

    Public Const OPOS_PS_UNKNOWN = 2000
    Public Const OPOS_PS_ONLINE = 2001
    Public Const OPOS_PS_OFF = 2002
    Public Const OPOS_PS_OFFLINE = 2003
    Public Const OPOS_PS_OFF_OFFLINE = 2004

End Module
