'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Controls/SignatureControl.ascx.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : Controle Gérant la Signature de l'Application
' *************************************************************************

Imports System.Reflection.Assembly
Imports System.IO
Imports System.Data


Namespace DotNetSysInfoJA


''' -----------------------------------------------------------------------------
''' Project	 : DotNetSysInfo
''' Class	 : SignatureControl
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Controle Gérant la Signature de l'Application
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[moi]	23/06/2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Partial Class SignatureControl
    Inherits System.Web.UI.UserControl

    Public DataTableListeFichierCSS As New DataTable

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
    ''' Chargement du Controle de la Signature
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

        Dim MaVersion As Version = GetExecutingAssembly.GetName.Version
        LabelSignature.Text = "Créé par "
        HyperLinkSignature.Text = "Romelard Fabrice (Alias F___)"
        HyperLinkSignature.Target = "_blank"
        HyperLinkSignature.NavigateUrl = "http://fromelard.free.fr"
        HyperLinkSignature.Attributes.Add("onMouseOver", "status='Voir le Site perso de Romelard Fabrice (Alias F___).';return true;")
        HyperLinkSignature.Attributes.Add("onMouseOut", "status='';return true;")
        LabelDate.Text = " - Version " & MaVersion.ToString & " - Le " & Fonctions.AfficheDateTimeComplete(Now)

        If Not Page.IsPostBack Then
            ChargeDropDown()
        End If

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Définit le Fichier CSS à utiliser suivant la valeur choisie dans le DropDown
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	12/07/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub AfficheCSS()
        Dim constanteCSS As String = ""
        Dim FichierCSS As String = ""
        If Session("CSS") <> "" Then
            FichierCSS = Session("CSS")
        Else
            FichierCSS = constantes.FichierCSS
        End If
        constanteCSS = "<LINK href='./CSS/" & FichierCSS & "' type='text/css' rel='stylesheet'>"
        If Not Page.IsClientScriptBlockRegistered("DeclarationFichierCSS") Then
            Page.RegisterClientScriptBlock("DeclarationFichierCSS", constanteCSS)
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Permet de remplir le DropDown avec la liste des CSS existant dans le répertoire
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	23/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ChargeDropDown()
        Dim lePath As String = Server.MapPath("./CSS/")

        Dim myDirInfo As DirectoryInfo = New DirectoryInfo(lePath)
        Dim TableauFileInfo As Array
        Dim myFileInfo As FileInfo
        Dim myRow As DataRow

        TableauFileInfo = myDirInfo.GetFiles()
        PrepareDatatables()

        For Each myFileInfo In TableauFileInfo
            If Right(myFileInfo.Name.Trim.ToLower, 4) = ".css" Then
                myRow = DataTableListeFichierCSS.NewRow()
                myRow("NOM") = myFileInfo.Name.Trim.ToLower
                myRow("LIBELLE") = UCase(Replace(myFileInfo.Name.ToLower.Trim, ".css", ""))
                DataTableListeFichierCSS.Rows.Add(myRow)
            End If
        Next myFileInfo

        CSSDropDownList.DataSource = DataTableListeFichierCSS
        CSSDropDownList.DataTextField = "LIBELLE"
        CSSDropDownList.DataValueField = "NOM"
        CSSDropDownList.DataBind()

        If Session("CSS") <> "" Then
            Dim b As ListItem = CSSDropDownList.Items.FindByValue(Session("CSS"))
            If Not b Is Nothing Then
                b.Selected = True
            Else
                CSSDropDownList.Items.FindByValue(constantes.FichierCSS).Selected = True
            End If
        Else
            CSSDropDownList.Items.FindByValue(constantes.FichierCSS).Selected = True
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Préparation de la DataTable qui va stocker la liste des fichiers du répertoire
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	23/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub PrepareDatatables()
        ' Préparation de la DataTable qui va stocker la liste des fichiers du répertoire
        Dim myColumn As DataColumn = New DataColumn

        ' ----------- Liste des Fichiers -------------------
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.AllowDBNull = False
        myColumn.Caption = "NOM"
        myColumn.ColumnName = "NOM"
        DataTableListeFichierCSS.Columns.Add(myColumn)

        myColumn = New DataColumn
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.Caption = "LIBELLE"
        myColumn.ColumnName = "LIBELLE"
        DataTableListeFichierCSS.Columns.Add(myColumn)

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Mise a jour de la page avec changement du CSS suivant le choix dans la dropdown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	23/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub CSSDropDownList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CSSDropDownList.SelectedIndexChanged
        Dim FichierCSS As String = ""
        FichierCSS = CSSDropDownList.SelectedItem.Value.ToLower
        Session("CSS") = FichierCSS
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Exécution du choix du CSS juste avant l'affichage de la page
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	12/07/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        AfficheCSS()
    End Sub

    ' -----------------------------------------------------
End Class

End Namespace
