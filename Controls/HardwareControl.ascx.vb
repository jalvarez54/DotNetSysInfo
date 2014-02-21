'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Controls/HardwareControl.ascx.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : Controle chargeant les Infos sur les Composants matériels
' *************************************************************************

Imports System.Management


Namespace DotNetSysInfoJA


''' -----------------------------------------------------------------------------
''' Project	 : DotNetSysInfo
''' Class	 : HardwareControl
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Controle chargeant les Infos sur les Composants matériels
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[moi]	23/06/2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Partial  Class HardwareControl
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
    ''' Chargement du controle des composants matériels
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
			Dim stringMachineName As String
			Dim co As New ConnectionOptions
			Dim oq As System.Management.ObjectQuery
			Dim query As ManagementObjectSearcher
			Dim ms As System.Management.ManagementScope
			Dim queryCollection As ManagementObjectCollection
			Dim MonMO As ManagementObject
			Dim NBBarettes As Integer = 0
			Dim TaillesBarettes As String = "|"

			Fonctions.ChargeConnexionParam(co, stringMachineName)
			Try

				ms = New System.Management.ManagementScope("\\" + stringMachineName + "\root\cimv2", co)
				oq = New System.Management.ObjectQuery("SELECT * FROM Win32_processor")
				query = New ManagementObjectSearcher(ms, oq)
				queryCollection = query.Get()
				For Each MonMO In queryCollection
					LabelFabriquant.Text = MonMO("Manufacturer")
					LabelReferenceModele.Text = MonMO("Caption")
					LabelNomModele.Text = Trim(MonMO("Name"))
					LabelVitesseProc.Text = Fonctions.AfficheVitesse(Int64.Parse(MonMO("MaxClockSpeed").ToString()))
					LabelMemL2.Text = Fonctions.formatSize(Int64.Parse(MonMO("L2CacheSize").ToString()), False)
				Next

				oq = New System.Management.ObjectQuery("SELECT * FROM Win32_bios")
				query = New ManagementObjectSearcher(ms, oq)
				queryCollection = query.Get()
				For Each MonMO In queryCollection
					LabelNomBIOS.Text = MonMO("Caption")
					LabelVersionBIOS.Text = MonMO("version")
				Next

				oq = New System.Management.ObjectQuery("SELECT * FROM Win32_VideoController")
				query = New ManagementObjectSearcher(ms, oq)
				queryCollection = query.Get()
				For Each MonMO In queryCollection
					LabelNomVideoCarte.Text = MonMO("Name")
					LabelProcesseurCarte.Text = MonMO("VideoProcessor")
					LabelModeVideo.Text = MonMO("VideoModeDescription")
					LabelRAMVideo.Text = Fonctions.formatSize(Int64.Parse(MonMO("AdapterRAM").ToString()), False)
				Next

				oq = New System.Management.ObjectQuery("SELECT * FROM Win32_MemoryDevice")
				query = New ManagementObjectSearcher(ms, oq)
				queryCollection = query.Get()
				For Each MonMO In queryCollection
					Dim tempVal As Long = Int64.Parse(MonMO("EndingAddress").ToString()) - Int64.Parse(MonMO("StartingAddress").ToString())
					TaillesBarettes &= Fonctions.formatSize(tempVal, True) & "|"
					NBBarettes += 1
				Next
				LabelTailleBarettes.Text = TaillesBarettes
				LabelNbBarettesRAM.Text = NBBarettes

				oq = New System.Management.ObjectQuery("SELECT * FROM Win32_SoundDevice")
				query = New ManagementObjectSearcher(ms, oq)
				queryCollection = query.Get()
				For Each MonMO In queryCollection
					LabelCarteSon.Text = MonMO("Name") & " (" & MonMO("Manufacturer") & ")"
				Next
				query.Dispose()
			Catch ex As Exception
				LabelAlert.Text = ex.Message
				LabelAlert.Visible = True
			End Try

		End Sub


		' -----------------------------------------------------
	End Class

End Namespace
