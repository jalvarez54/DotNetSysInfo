'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Controls/ProgramsControl.ascx.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : Controle Affichant le nombre d'Applications installées
' *************************************************************************

Imports System.Management


Namespace DotNetSysInfoJA


''' -----------------------------------------------------------------------------
''' Project	 : DotNetSysInfo
''' Class	 : ProgramsControl
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Controle Affichant le nombre d'Applications installées
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[moi]	23/06/2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Partial Class ProgramsControl
    Inherits System.Web.UI.UserControl


#Region " Code généré par le Concepteur Web Form "

    'Cet appel est requis par le Concepteur Web Form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'REMARQUE : la déclaration d'espace réservé suivante est requise par le Concepteur Web Form.
    'Ne pas supprimer ou déplacer.

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN : cet appel de méthode est requis par le Concepteur Web Form
        'Ne le modifiez pas en utilisant l'éditeur de code.
        InitializeComponent()
    End Sub

#End Region

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chargement du Controle des Applications installées
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
        Dim NBPrograms As Integer = 0
        Dim co As New ConnectionOptions
        Dim oq As System.Management.ObjectQuery
        Dim query As ManagementObjectSearcher
        Dim ms As System.Management.ManagementScope
        Dim queryCollection As ManagementObjectCollection
        Dim MonMO As ManagementObject

        Fonctions.ChargeConnexionParam(co, stringMachineName)
        Try
            ms = New System.Management.ManagementScope("\\" + stringMachineName + "\root\cimv2", co)
            oq = New System.Management.ObjectQuery("SELECT * FROM Win32_Product")
            query = New ManagementObjectSearcher(ms, oq)

            queryCollection = query.Get()
            For Each MonMO In queryCollection
                NBPrograms += 1
            Next
            LabelNbPrograms.Text = NBPrograms
            query.Dispose()

        Catch ex As Exception
            LabelAlert.Text = ex.Message & ":Sous Win 2003 Installez le module concernant WMI et les logiciels"
            LabelAlert.Visible = True
        End Try
    End Sub

    ' -----------------------------------------------------
End Class

End Namespace
