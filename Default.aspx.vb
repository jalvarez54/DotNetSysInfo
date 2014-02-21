'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Default.aspx.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : Page par défaut rassemblant l'ensemble des Users Controls
' *************************************************************************

''' -----------------------------------------------------------------------------
''' Project	 : DotNetSysInfo
''' Class	 : _Default
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Page par défaut rassemblant l'ensemble des Users Controls
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[moi]	23/06/2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Namespace DotNetSysInfoJA

Partial Class _Default
    Inherits System.Web.UI.Page



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
    ''' Chargement de la page par défaut
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

        Dim TempRequest As String = Request.QueryString("detail")

        If Trim(TempRequest) <> "" Then
            BasePanel.Visible = False
            BasePanel.Enabled = False
            DetailPanel.Visible = True
            DetailPanel.Enabled = True

            Select Case LCase(Trim(TempRequest))
                Case "logiciel"
                    Dim MaListePrograms As ListeProgramsControl = CType(LoadControl("~/Controls/ListeProgramsControl.ascx"), ListeProgramsControl)
                    DetailPanel.Controls.Add(MaListePrograms)
                Case "process"
                    Dim MaListeProcess As ListeProcessControl = CType(LoadControl("~/Controls/ListeProcessControl.ascx"), ListeProcessControl)
                    DetailPanel.Controls.Add(MaListeProcess)
                Case "service"
                    Dim MaListeService As ListeServicesControl = CType(LoadControl("~/Controls/ListeServicesControl.ascx"), ListeServicesControl)
                    DetailPanel.Controls.Add(MaListeService)
            End Select
        Else
            BasePanel.Visible = True
            BasePanel.Enabled = True
            DetailPanel.Visible = False
            DetailPanel.Enabled = False
            If Trim(Session("Serveur")) <> constantes.ServeurATester Then
                FrameworkControl1.Visible = False
            End If
        End If
    End Sub

    ' -----------------------------------------------------
End Class

End Namespace
