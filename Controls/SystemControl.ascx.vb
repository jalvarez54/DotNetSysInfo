'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Controls/SystemControl.ascx.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : Control affichant les Informations système de la machine
' *************************************************************************

Imports System.Management
Imports System.Reflection.Assembly


Namespace DotNetSysInfoJA


''' -----------------------------------------------------------------------------
''' Project	 : DotNetSysInfo
''' Class	 : SystemControl
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Control affichant les Informations système de la machine
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[moi]	23/06/2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Partial  Class SystemControl
    Inherits System.Web.UI.UserControl




#Region " Code généré par le Concepteur Web Form "

    'Cet appel est requis par le Concepteur Web Form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN : cet appel de méthode est requis par le Concepteur Web Form
        'Ne le modifiez pas en utilisant l'éditeur de code.
        InitializeComponent()
    End Sub

#End Region

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chargement du Controle Informations système 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	22/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Charge toutes les Informations Système
        Dim stringMachineName As String
        Dim osInfo As System.OperatingSystem = System.Environment.OSVersion
        Dim MaVersion As Version = GetExecutingAssembly.GetName.Version
        Dim co As New ConnectionOptions
        Dim oq As System.Management.ObjectQuery
        Dim query As ManagementObjectSearcher
        Dim ms As System.Management.ManagementScope
        Dim queryCollection As ManagementObjectCollection
        Dim MonMO As ManagementObject

        Fonctions.ChargeConnexionParam(co, stringMachineName)
        Try
            ms = New System.Management.ManagementScope("\\" + stringMachineName + "\root\cimv2", co)
            oq = New System.Management.ObjectQuery("SELECT * FROM Win32_OperatingSystem")
            query = New ManagementObjectSearcher(ms, oq)
            queryCollection = query.Get()
            For Each MonMO In queryCollection
                LabelVersionOS.Text = MonMO("Manufacturer") & " - " & MonMO("Caption") & " (" & osInfo.Version.ToString & ")"
                LabelNumSerieOS.Text = MonMO("SerialNumber")
                LabelMachine.Text = MonMO("CSName")

                Dim NBSecondes As Long = DateDiff(DateInterval.Second, RecupDateLancementOS(MonMO("LastBootUpTime").ToString()), Now())
                Dim UpTimeRef As New TimeClass(NBSecondes)
                LabelUptime.Text = UpTimeRef.ReturnChaineTemps
            Next
            LabelIP.Text = Fonctions.IP(stringMachineName)

            LabelIPMachineHebergeant.Text = Fonctions.IP(Server.MachineName)
            LabelMachineHebergeant.Text = Server.MachineName

            LabelHostname.Text = Request.ServerVariables("SERVER_NAME")
            LabelVersion.Text = System.Environment.Version.ToString
            LabelVersionApplication.Text = MaVersion.ToString
            query.Dispose()
        Catch ex As Exception
            LabelAlert.Text = ex.Message
            LabelAlert.Visible = True
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="DateProcess"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	27/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function RecupDateLancementOS(ByVal DateProcess As String) As DateTime
        Dim TabChaine As String() = DateProcess.Trim.Split(".")
        Dim TempChaine As String = TabChaine(0)
        Dim Temp As String = TempChaine.Substring(0, 4) & "-" & TempChaine.Substring(4, 2) & "-" & TempChaine.Substring(6, 2) & " " & TempChaine.Substring(8, 2) & ":" & TempChaine.Substring(10, 2) & ":" & TempChaine.Substring(12, 2)
        Return CType(Temp, DateTime)
    End Function

    ' -----------------------------------------------------
End Class

End Namespace
