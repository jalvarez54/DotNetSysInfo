'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Controls/NetworkTrafficControl.ascx.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : Controle G�rant le Traffic R�seau par l'utilisation d'SNMP
' *************************************************************************


Imports System.Management


Namespace DotNetSysInfoJA


''' -----------------------------------------------------------------------------
''' Project	 : DotNetSysInfo
''' Class	 : NetworkTrafficControl
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Controle G�rant le Traffic R�seau par l'utilisation d'SNMP
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[moi]	23/06/2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Partial Class NetworkTrafficControl
    Inherits System.Web.UI.UserControl

#Region " Code g�n�r� par le Concepteur Web Form "

    'Cet appel est requis par le Concepteur Web Form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'REMARQUE�: la d�claration d'espace r�serv� suivante est requise par le Concepteur Web Form.
    'Ne pas supprimer ou d�placer.

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN�: cet appel de m�thode est requis par le Concepteur Web Form
        'Ne le modifiez pas en utilisant l'�diteur de code.
        InitializeComponent()
    End Sub

#End Region

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chargement du Controle du Traffic R�seau
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
        Dim Reseau As New CoucheReseau

        Fonctions.ChargeConnexionParam(co, stringMachineName)
        Try
            ms = New System.Management.ManagementScope("\\" + stringMachineName + "\root\cimv2", co)
            oq = New System.Management.ObjectQuery("SELECT * FROM Win32_Service WHERE Name = 'SNMP'")
            query = New ManagementObjectSearcher(ms, oq)
            queryCollection = query.Get()
            For Each MonMO In queryCollection
                If (MonMO("Started").Equals(True)) Then
                    Try
                        Dim sess As New CoucheReseau.ManagerSession_
                        sess.agentAddress = Fonctions.IP(Server.MachineName)
                        sess.agentCommunity = "public"
                        LabelAlert.Visible = False
                        Reseau = New CoucheReseau(sess)
                        DataGridTraffic.Visible = True
                    Catch ex As Exception
                        LabelAlert.Text = ex.Message
                        LabelAlert.Visible = True
                    End Try
                Else
                    DataGridTraffic.Visible = False
                    LabelAlert.Visible = True
                    LabelAlert.Text = "Le Service SNMP n'est pas activ� sur la machine. Celui-ci est utilis� par cette application pour les informations du traffic r�seau"
                End If
            Next

            If Reseau.DatatableInterface.Rows.Count > 0 Then
                DataGridTraffic.DataSource = Reseau.DatatableInterface
                DataGridTraffic.CssClass = "boxbody"
                DataGridTraffic.DataBind()
            Else
                DataGridTraffic.Visible = False
                LabelAlert.Visible = True
                LabelAlert.Text = "Le Service SNMP n'est pas install� sur la machine. Celui-ci est utilis� par cette application pour les informations du traffic r�seau"
            End If

            query.Dispose()

        Catch ex As Exception
            LabelAlert.Text = ex.Message
            LabelAlert.Visible = True
        End Try

    End Sub
 
    ' ------------------------------------------------------------------------------
End Class

End Namespace
