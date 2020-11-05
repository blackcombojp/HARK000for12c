'/*-----------------------------------------------------------------------------
' * COPYRIGHT(C) ITI CORPORATION 2019
' * ITI CONFIDENTIAL AND PROPRIETARY
' *
' * All rights reserved by ITI Corporation.
' *-----------------------------------------------------------------------------/
Option Compare Binary
Option Explicit On
Option Strict On

Module HARK_Define

    '*********************************************************************
    '�A�v���P�[�V�����^�C�g��
    '*********************************************************************
    Public Const DEVSection As String = "�����d����"
    Public Const DebugVer As String = "�f�o�b�O�o�[�W����"


    '*********************************************************************
    '�e���b�Z�[�W(�v���O�����j
    '*********************************************************************
    Public Const MSG_101001 As String = "�捞�t�@�C�����w�肵�Ă�������"
    Public Const MSG_101002 As String = "�t�@�C����������������܂���"
    Public Const MSG_101103 As String = "�t�@�C���g���q���Ⴂ�܂�"
    Public Const MSG_101104 As String = "�G���[�f�[�^�o�͐���w�肵�Ă�������"
    Public Const MSG_101105 As String = "�������J�n���܂����H"
    Public Const MSG_101106 As String = "�󒍃f�[�^�捞��"
    Public Const MSG_101107 As String = "�󒍃f�[�^�捞�͐���I�����܂���"
    Public Const MSG_101108 As String = "�󒍃f�[�^�捞�ُ͈�I�����܂���"
    Public Const MSG_101109 As String = "�Ώۃf�[�^�͂���܂���"
    Public Const MSG_101110 As String = "�捞�ԍ��F"
    Public Const MSG_101111 As String = "�Ώی����F"
    Public Const MSG_101112 As String = "���팏���F"
    Public Const MSG_101113 As String = "�G���[�����F"
    Public Const MSG_101114 As String = "�ėp�󒍃f�[�^�쐬��"
    Public Const MSG_101115 As String = "�G���[�f�[�^�o�͒�"
    Public Const MSG_101116 As String = "�G���[�f�[�^�o�͂͐���I�����܂���"
    Public Const MSG_101117 As String = "�G���[�f�[�^�o�ُ͈͂�I�����܂���"
    Public Const MSG_101118 As String = "�G���[�f�[�^�X�V�͐���I�����܂���"
    Public Const MSG_101119 As String = "�G���[�f�[�^�X�V�ُ͈�I�����܂���"
    Public Const MSG_101120 As String = "�G���[�f�[�^�͂���܂���"
    Public Const MSG_101121 As String = "���M�p�G���[�f�[�^�o�͒�"
    Public Const MSG_101122 As String = "���M�p�G���[�f�[�^�o�͂͐���I�����܂���"
    Public Const MSG_101123 As String = "���M�p�G���[�f�[�^�o�ُ͈͂�I�����܂���"
    Public Const MSG_101124 As String = "���M�p�G���[�f�[�^�X�V�͐���I�����܂���"
    Public Const MSG_101125 As String = "���M�p�G���[�f�[�^�X�V�ُ͈�I�����܂���"
    Public Const MSG_101126 As String = "���M�p�G���[�f�[�^�͂���܂���"
    Public Const MSG_101127 As String = "�G���[�f�[�^���M��"
    Public Const MSG_101128 As String = "�G���[�f�[�^���M�͐���I�����܂���"
    Public Const MSG_101129 As String = "�G���[�f�[�^���M�ُ͈�I�����܂���"
    Public Const MSG_101130 As String = "���M��A�h���X���s���ł�"
    Public Const MSG_101131 As String = "�ėp�󒍃f�[�^�쐬�͐���I�����܂���"
    Public Const MSG_101132 As String = "�ėp�󒍃f�[�^�쐬�ُ͈�I�����܂���"
    Public Const MSG_101133 As String = "���Ӑ�F"
    Public Const MSG_101134 As String = "�Ώۓ��Ӑ�ꗗ�F"

    Public Const MSG_201001 As String = "�f�[�^�o�͒�"
    Public Const MSG_201002 As String = "�f�[�^�o�͂͐���I�����܂���"
    Public Const MSG_201003 As String = "�f�[�^�o�ُ͈͂�I�����܂���"
    Public Const MSG_201004 As String = "�f�[�^�X�V�͐���I�����܂���"
    Public Const MSG_201005 As String = "�f�[�^�X�V�ُ͈�I�����܂���"
    Public Const MSG_201006 As String = "�Y���f�[�^�͂���܂���"
    Public Const MSG_201007 As String = "�s�b�L���O�A�g"
    Public Const MSG_201008 As String = "�o�׌��i������"
    Public Const MSG_201009 As String = "�o�͔ԍ��F"
    Public Const MSG_201010 As String = "���["
    Public Const MSG_201011 As String = "EXCEL"
    Public Const MSG_201012 As String = "�L�������ؔ�"
    Public Const MSG_201013 As String = "�Ώی����F"



    Public Const MSG_301001 As String = "�`���ԍ��F"
    Public Const MSG_301002 As String = "���ё��M�f�[�^�쐬��"
    Public Const MSG_301003 As String = "���ё��M�f�[�^�쐬�͐���I�����܂���"
    Public Const MSG_301004 As String = "���ё��M�f�[�^�쐬�ُ͈�I�����܂���"
    Public Const MSG_301005 As String = "�Ώۃf�[�^�͂���܂���"
    Public Const MSG_301006 As String = "���уf�[�^���M��"
    Public Const MSG_301007 As String = "���уf�[�^���M�ُ͈�I�����܂���"
    Public Const MSG_301008 As String = "���уf�[�^���M�͐���I�����܂���"
    Public Const MSG_301009 As String = "�f�[�^�X�V�͐���I�����܂���"
    Public Const MSG_301010 As String = "�f�[�^�X�V�ُ͈�I�����܂���"
    Public Const MSG_301011 As String = "�Ώۓ����w�肵�Ă�������"
    Public Const MSG_301012 As String = "���t�̏������Ԉ���Ă��܂�"
    Public Const MSG_301013 As String = "OliverEAN�f�[�^���w�肵�Ă�������"
    Public Const MSG_301014 As String = "�f�[�^�捞��"
    Public Const MSG_301015 As String = "�f�[�^�捞�͐���I�����܂���"
    Public Const MSG_301016 As String = "�f�[�^�捞�ُ͈�I�����܂���"
    Public Const MSG_301017 As String = "�f�[�^�o�͒�"
    Public Const MSG_301018 As String = "�f�[�^�o�͂͐���I�����܂���"
    Public Const MSG_301019 As String = "�f�[�^�o�ُ͈͂�I�����܂���"
    Public Const MSG_301020 As String = "�����F"
    Public Const MSG_301021 As String = "�f�[�^�o�͐���w�肵�Ă�������"
    Public Const MSG_301022 As String = "[����ς݂��o��]�̏ꍇ�A���Ԃ��|����\��������܂�"
    Public Const MSG_301023 As String = "��낵���ł����H"
    Public Const MSG_301024 As String = "�����M�̎��уt�@�C��������܂�"
    Public Const MSG_301025 As String = "���M��A�h���X���s���ł�"
    Public Const MSG_301026 As String = "[���v��S��]�̏ꍇ�A���Ԃ��|����\��������܂�"
    Public Const MSG_301027 As String = "�����ݏo�ԍ����w�肵�Ă�������"
    Public Const MSG_301028 As String = "���������w�肵�Ă�������"
    Public Const MSG_301029 As String = "���ɏ���ς݂̒����ݏo�ԍ��ł�"
    Public Const MSG_301030 As String = "�����ݏo�ԍ��̎w�肪�s���ł�"
    Public Const MSG_301031 As String = "�w�肳�ꂽ�����ݏo�ԍ��͑��݂��܂���"
    Public Const MSG_301032 As String = "�����͐���I�����܂���"
    Public Const MSG_301033 As String = "�����ُ͈�I�����܂���"
    Public Const MSG_301034 As String = "�w�肳�ꂽ�����ݏo�ԍ��͑��̒[���ŕ\�����ł�"
    Public Const MSG_301035 As String = "���i�R�[�h�̎w�肪�s���ł�"
    Public Const MSG_301036 As String = "�w�肵�����i�R�[�h�͏��i�}�X�^�ɑ��݂��܂���"
    Public Const MSG_301037 As String = "�w�肵�����i�R�[�h�͏��i�ϊ��}�X�^�ŏd�����Ă��܂�"
    Public Const MSG_301038 As String = "���i�R�[�h���w�肵�Ă�������"
    Public Const MSG_301039 As String = "�@���R�[�h���w�肵�Ă�������"
    Public Const MSG_301040 As String = "�󒍌`�ԁy�s���z�Ŋm��͂ł��܂���"
    Public Const MSG_301041 As String = "�X�V�͐���I�����܂���"
    Public Const MSG_301042 As String = "�X�V�ُ͈�I�����܂���"
    Public Const MSG_301043 As String = "�A�g�L�[�̎w�肪�s���ł�"
    Public Const MSG_301044 As String = "�A�g�L�[���w�肵�Ă�������"
    Public Const MSG_301045 As String = "���[�f�[�^���������Ă�������"
    Public Const MSG_301046 As String = "���������͐���I�����܂���"
    Public Const MSG_301047 As String = "���������ُ͈�I�����܂���"

    Public Const MSG_304001 As String = "���|����w�肵�Ă�������"
    Public Const MSG_304002 As String = "�ΏۊJ�n�����w�肵�Ă�������"
    Public Const MSG_304003 As String = "�ΏۏI�������w�肵�Ă�������"
    Public Const MSG_304004 As String = "�Ώۃf�[�^�o�͒�"
    Public Const MSG_304005 As String = "�o�̓f�[�^��������܂���"


    Public Const MSG_401001 As String = "�`�F�b�N���ʏo�͒�"
    Public Const MSG_401002 As String = "�o�͒�"
    Public Const MSG_401003 As String = "�o�ُ͈͂�I�����܂���"
    Public Const MSG_401004 As String = "�o�͂͐���I�����܂���"
    Public Const MSG_401005 As String = "�`�F�b�N���ʏo�ُ͈͂�I�����܂���"
    Public Const MSG_401006 As String = "�`�F�b�N���ʏo�͂͐���I�����܂���"

    Public Const MSG_402001 As String = "�d���ꗗ�f�[�^���w�肵�Ă�������"
    Public Const MSG_402002 As String = "���Ӑ���w�肵�Ă�������"

    Public Const MSG_403001 As String = "�����������w�肵�Ă�������"
    Public Const MSG_403002 As String = "�����Ӄf�[�^�o�͒�"
    Public Const MSG_403003 As String = "�������׃f�[�^�o�͒�"


    Public Const MSG_501001 As String = "�̗p���i���X�g�t�@�C�����w�肵�Ă�������"
    Public Const MSG_501002 As String = "�̗p���i���X�g�捞��"
    Public Const MSG_501003 As String = "�}�X�^�X�V�͐���I�����܂���"
    Public Const MSG_501004 As String = "�}�X�^�X�V�ُ͈�I�����܂���"

    Public Const MSG_502001 As String = "�@���R�[�h���͏��i�R�[�h�̂ǂ��炩���w�肵�Ă�������"
    Public Const MSG_502002 As String = "�@���R�[�h�A���i�R�[�h�̗����͎w��ł��܂���"

    Public Const MSG_503001 As String = "���؋敪��I�����Ă�������"
    Public Const MSG_503002 As String = "���ؔԍ�����͂��Ă�������"
    Public Const MSG_503003 As String = "���؊J�n������͂��Ă�������"
    Public Const MSG_503004 As String = "���؏I��������͂��Ă�������"
    Public Const MSG_503005 As String = "�摜�t�@�C�����w�肵�Ă�������"
    Public Const MSG_503006 As String = "���p�����Ӑ���w�肵�Ă�������"
    Public Const MSG_503007 As String = "���؏��o�^��"
    Public Const MSG_503008 As String = "���Ӑ�ƈ��p�����Ӑ悪����ł�"
    Public Const MSG_503009 As String = "���p�����Ӑ�Ŏw��̋��؂�����܂���"
    Public Const MSG_503010 As String = "�����ł��܂���"
    Public Const MSG_503011 As String = "���ɋ��؂��o�^����Ă��܂�"
    Public Const MSG_503012 As String = "�㏑�����܂����A��낵���ł����H"
    Public Const MSG_503013 As String = "���؏��o�^�͐���I�����܂���"
    Public Const MSG_503014 As String = "���؏��o�^�ُ͈�I�����܂���"
    Public Const MSG_503015 As String = "���؊m�F�����ɂė\�����Ȃ��G���[���������܂���"
    Public Const MSG_503016 As String = "(���p)���؊m�F�����ɂė\�����Ȃ��G���[���������܂���"
    Public Const MSG_503017 As String = "���؁F"

    Public Const MSG_504001 As String = "�����������w�肵�Ă�������"
    Public Const MSG_504002 As String = "�Ǝ��I�����Ă�������"
    Public Const MSG_504003 As String = "���؂�I�����Ă�������"
    Public Const MSG_504004 As String = "������I�����Ă�������"
    Public Const MSG_504005 As String = "�Ώۓ����w�肵�Ă�������"
    Public Const MSG_504006 As String = "�Y���f�[�^�͂���܂���"
    Public Const MSG_504007 As String = "�w�肳�ꂽ�����͑��̒[���ŕ\�����ł�"
    Public Const MSG_504008 As String = "�f�[�^���������A�폜�Ƀ`�F�b�N�����Ă�������"
    Public Const MSG_504009 As String = "�폜�Ƀ`�F�b�N�����Ă�������"
    Public Const MSG_504010 As String = "�폜�͐���I�����܂���"
    Public Const MSG_504011 As String = "�폜�ُ͈�I�����܂���"
    Public Const MSG_504012 As String = "�o�͂͐���I�����܂���"
    Public Const MSG_504013 As String = "�o�ُ͈͂�I�����܂���"


    Public Const MSG_505001 As String = "��Ë@�ւ�I�����Ă�������"

    '*********************************************************************
    '�e���b�Z�[�W�i�A�b�v�f�[�g�j
    '*********************************************************************
    Public Const MSG_UPD001 As String = "�ŐV�ł������[�X����Ă��܂��̂ōX�V���܂�"
    Public Const MSG_UPD002 As String = "�X�V�ُ͈�I�����܂���"
    Public Const MSG_UPD003 As String = "���g���̃o�[�W�������ŐV�łł�"

    '*********************************************************************
    '�e���b�Z�[�W�i���ʁj
    '*********************************************************************
    Public Const MSG_COM001 As String = "�\�����N���A���܂����H"
    Public Const MSG_COM002 As String = "���O�t�@�C��������܂���"
    Public Const MSG_COM003 As String = "�c�[�����I�����܂����H"
    Public Const MSG_COM004 As String = "�T�[�o�Ƃ̐ڑ����Ւf����Ă��܂�"
    Public Const MSG_COM005 As String = "���ɋN�����Ă��܂�"
    Public Const MSG_COM006 As String = "PrintScreen�͖����ł�"
    Public Const MSG_COM007 As String = "���Ə���I�����Ă�������"
    Public Const MSG_COM008 As String = "���͒S���R�[�h���w�肵�Ă�������"
    Public Const MSG_COM009 As String = "���͒S���R�[�h�̎w�肪�Ԉ���Ă��܂�"
    Public Const MSG_COM010 As String = "�I�������@�\�͎��s�ł��܂���"
    Public Const MSG_COM011 As String = "���g���̒[���ł͋�����Ă��܂���"
    Public Const MSG_COM012 As String = "�T�u�v���O������I�����Ă�������"
    Public Const MSG_COM013 As String = "���v���I�����Ă�������"
    Public Const MSG_COM014 As String = "SPD�V�X�e���R�[�h���擾�ł��܂���ł���"
    Public Const MSG_COM015 As String = "�捞�w�肵���t�@�C���𑼃A�v���P�[�V�����ŊJ���Ă��܂��B���Ă�������"
    Public Const MSG_COM016 As String = "�捞�w�肵���t�@�C�������݂��܂���"
    Public Const MSG_COM017 As String = "�w�肵���t�@�C������荞�߂܂���ł���"
    Public Const MSG_COM018 As String = "�捞�w�肵���t�@�C���ւ̃A�N�Z�X��������܂���"
    Public Const MSG_COM019 As String = "�{�Џ��V�X�e���ۂ֘A�����Ă�������"


    Public Const MSG_COM896 As String = "�O��o�͂̓����t�@�C�������A�v���P�[�V�����ŊJ���Ă��܂��B���Ă�������"
    Public Const MSG_COM897 As String = "�O��o�͂̓����t�@�C���͑��݂��܂���"
    Public Const MSG_COM898 As String = "�O��o�͂̓����t�@�C�����폜�ł��܂���ł���"
    Public Const MSG_COM899 As String = "�G���[�R�[�h�F"
    Public Const MSG_COM900 As String = "�G���[���b�Z�[�W�F"
    Public Const MSG_COM901 As String = "�V�X�e���Ǘ��҂܂ł��A����������"
    Public Const MSG_COM902 As String = "�\�����Ȃ��G���[���������܂���"
    Public Const MSG_COM903 As String = "SPD�c�[�� for Aptage.MD2���ċN�����Ă�������"
    Public Const MSG_COM904 As String = "�w��̃��j���[��"
    Public Const MSG_COM905 As String = "�p�ł͂Ȃ����ߎg�p�ł��܂���"
    Public Const MSG_COM906 As String = "�J�����ׁ̈A�w��̃��j���[�͎g�p�ł��܂���"
    Public Const MSG_COM907 As String = "�ғ������Ə��F"
    Public Const MSG_COM908 As String = "�ݒ�����擾�ł��܂���ł���"
    Public Const MSG_COM909 As String = "�ݒ���͎��Ə��I�����Ɏ擾���܂�"
    Public Const MSG_COM910 As String = "���O�C�����X�V�Ɏ��s���܂���"


    '*********************************************************************
    '�e�V�X�e���K��l
    '*********************************************************************
    Public Const DUMMY_INTCODE As Integer = 999999999    '�����󔒎��_�~�[�萔
    Public Const DUMMY_LNGCODE As Long = 9999999999      '�����󔒎��_�~�[�萔
    Public Const DUMMY_STRCODE As String = "999999999"   '�����󔒎��_�~�[�萔
    Public Const DUMMY_REGKEY As String = "NULL"         '�_�~�[���W�X�g���L�[
    Public Const DUMMY_FILENAME As String = "DUMMY.txt"  '�_�~�[�t�@�C����
    Public Const DUMMY_STRNULL As String = "NULL"        '�_�~�[�t�@�C����


    Public Const HARKP101ImpFileName As String = "�s�b�L���O�f�[�^�A�g"
    Public Const HARKP102ImpFileName As String = "ONLINE-ITC"
    Public Const HARKP103ImpFileName As String = "���㋦�����f�[�^"
    Public Const HARKP104ImpFileName As String = "Romulus�󒍃f�[�^"
    Public Const HARKP105ImpFileName As String = "PHsmos_��_�󒍃f�[�^"
    Public Const HARKP106ImpFileName As String = "_HAT_"
    Public Const HARKP301ImpFileName As String = "Aptage�A�g�p�t�@�C��"
    Public Const HARKP4011ImpFileName As String = "WEB�݌Ɉړ����O"
    Public Const HARKP4012ImpFileName As String = "��������"
    Public Const HARKP402ImpFileName As String = "�d���ꗗ"
    Public Const HARKP501ImpFileName As String = "�̗p���i���X�g"


    Public Const CSVExtension As String = "csv"
    Public Const DATExtension As String = "dat"
    Public Const TXTExtension As String = "txt"
    Public Const XLSXExtension As String = "xlsx"
    Public Const TIFExtension As String = "tif"



    '*********************************************************************
    'Get_OSVersion�֐��ߒl
    '*********************************************************************
    Public Const OS_WINDOWS95 As Integer = 0
    Public Const OS_WINDOWS98 As Integer = 1
    Public Const OS_WINDOWSME As Integer = 2
    Public Const OS_WINDOWSNT3 As Integer = 3
    Public Const OS_WINDOWSNT31 As Integer = 4
    Public Const OS_WINDOWSNT35 As Integer = 5
    Public Const OS_WINDOWSNT351 As Integer = 6
    Public Const OS_WINDOWSNT4 As Integer = 7
    Public Const OS_WINDOWS2000 As Integer = 8
    Public Const OS_WINDOWSXP As Integer = 9
    Public Const OS_WINDOWSSERVER2003 As Integer = 10
    Public Const OS_WINDOWSVISTA As Integer = 11
    Public Const OS_WINDOWS7 As Integer = 12
    Public Const OS_WINDOWS32s As Integer = 13
    Public Const OS_WINDOWSCE As Integer = 14
    Public Const OS_UNIX As Integer = 15
    Public Const OS_XBOX As Integer = 16
    Public Const OS_MACINTOSH As Integer = 17
    Public Const OS_UNKNOWN As Integer = 18
    Public Const OS_WINDOWS8 As Integer = 19
    Public Const OS_WINDOWS81 As Integer = 20
    Public Const OS_WINDOWS10 As Integer = 21

    '*********************************************************************
    'Entry_Check�֐��p�萔(Check_SIZE)
    '*********************************************************************
    Public Const CHECK_SIZE_WIDE As Integer = 1           '�S�p
    Public Const CHECK_SIZE_NARROW As Integer = 2         '���p
    Public Const CHECK_SIZE_BOTH As Integer = 0           '���p

    '*********************************************************************
    'Entry_Check�֐��p�萔(Check_STYLE)
    '*********************************************************************
    Public Const CHECK_STYLE_NUMBER As Integer = 0        '�����̂�
    Public Const CHECK_STYLE_ALPH As Integer = 1          '�p�����̂�
    Public Const CHECK_STYLE_ELSE As Integer = 2          '���̑�

    '*********************************************************************
    'Entry_Check�֐��p�萔(Check_LEN)
    '*********************************************************************
    Public Const CHECK_LEN_MAKERCODE As Integer = 10            '���[�J�R�[�h
    Public Const CHECK_LEN_ITEMMAKERCODE As Integer = 20        '���[�J�i��
    Public Const CHECK_LEN_HPITEMOCDE As Integer = 30           '�@���R�[�h
 
End Module
