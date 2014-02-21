'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Controls/NetworkControl.ascx.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : Controle affichant tous les matériels Réseaux installés
' *************************************************************************

Imports System.Management


Namespace DotNetSysInfoJA


''' -----------------------------------------------------------------------------
''' Project	 : DotNetSysInfo
''' Class	 : NetworkControl
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Controle affichant tous les matériels Réseaux installés
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[moi]	23/06/2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Partial Class NetworkControl
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
    ''' Chargement du Controle des matériels Réseaux
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
        Dim CSS As Boolean = True

        Fonctions.ChargeConnexionParam(co, stringMachineName)
        Try
            ms = New System.Management.ManagementScope("\\" + stringMachineName + "\root\cimv2", co)
            oq = New System.Management.ObjectQuery("SELECT * FROM Win32_NetworkAdapter")
            query = New ManagementObjectSearcher(ms, oq)

            queryCollection = query.Get()
            For Each MonMO In queryCollection
                Dim MaLigneTotal As New HtmlControls.HtmlTableRow

                AddCell(MaLigneTotal, MonMO("DeviceID"), "left", CSS)
                AddCell(MaLigneTotal, MonMO("AdapterType"), "left", CSS)
                AddCell(MaLigneTotal, MonMO("ProductName"), "left", CSS)
                AddCell(MaLigneTotal, MonMO("AdapterType"), "left", CSS)
                AddCell(MaLigneTotal, MonMO("ServiceName"), "left", CSS)
                AddCell(MaLigneTotal, MonMO("MACAddress"), "left", CSS)
                TableauReseau.Rows.Add(MaLigneTotal)

                CSS = Not (CSS)
            Next
            query.Dispose()
        Catch ex As Exception
            LabelAlert.Text = ex.Message
            LabelAlert.Visible = True
        End Try

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Ajoute une cellule dans la ligne du tableau
    ''' </summary>
    ''' <param name="tr"></param>
    ''' <param name="sM"></param>
    ''' <param name="Alignement"></param>
    ''' <param name="ColSpan"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	22/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub AddCell(ByVal tr As HtmlTableRow, ByVal sM As String, ByVal Alignement As String, ByVal Style As Boolean, Optional ByVal ColSpan As Integer = 0)
        Dim td As New HtmlTableCell
        td.Align = Alignement
        td.VAlign = "top"
        If Style Then
            td.Attributes.Add("class", "boxbody")
        Else
            td.Attributes.Add("class", "boxbodyalternate")
        End If
        If ColSpan > 0 Then
            td.ColSpan = ColSpan
        End If
        td.InnerHtml = sM
        tr.Cells.Add(td)
    End Sub

    ' -----------------------------------------------------
End Class

End Namespace
