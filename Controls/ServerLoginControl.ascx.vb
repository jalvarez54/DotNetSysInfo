'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Controls/ServerLoginControl.ascx.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : Classe avec les fonctions du Projet
' *************************************************************************


''' -----------------------------------------------------------------------------
''' Project	 : DotNetSysInfo
''' Class	 : ServerLoginControl
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Classe de renseignement pour une connexion sur une machine distante
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[moi]	12/07/2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Namespace DotNetSysInfoJA

Partial Class ServerLoginControl
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
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	12/07/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	15/07/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub TestSession()
        If Trim(Session("Serveur")) <> "" Then
            ServerTextBox.Text = Trim(Session("Serveur"))
            LoginTextBox.Text = Trim(Session("Login"))
            PasswordTextBox.Text = Trim(Session("Password"))
        Else
            ServerTextBox.Text = constantes.ServeurATester
            LoginTextBox.Text = ""
            PasswordTextBox.Text = ""
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	12/07/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ButtonValidationSRV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonValidationSRV.Click
        Session("Serveur") = Trim(ServerTextBox.Text)
        Session("Login") = Trim(LoginTextBox.Text)
        Session("Password") = Trim(PasswordTextBox.Text)
        Response.Write(Fonctions.Redirect("./", 1))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	15/07/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        TestSession()
    End Sub
    ' -----------------------------------------------------
End Class

End Namespace
