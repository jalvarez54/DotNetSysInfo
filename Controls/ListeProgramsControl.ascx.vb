'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Controls/ListeProgramsControl.ascx.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : Controle Affichant le nombre d'Applications installées
' *************************************************************************

Imports System.Management
Imports System.Data


Namespace DotNetSysInfoJA


''' -----------------------------------------------------------------------------
''' Project	 : DotNetSysInfo
''' Class	 : ListeProgramsControl
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
Partial Class ListeProgramsControl
    Inherits System.Web.UI.UserControl

    Public DataTableListePrograms As New DataTable

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
    ''' Chargement du User control pour l'affichage de la liste des Programmes installés
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	23/06/2004	Created
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
        Dim myRow As DataRow

        Fonctions.ChargeConnexionParam(co, stringMachineName)
        Try
            ms = New System.Management.ManagementScope("\\" + stringMachineName + "\root\cimv2", co)
            oq = New System.Management.ObjectQuery("SELECT * FROM Win32_Product")
            query = New ManagementObjectSearcher(ms, oq)

            PrepareDatatables()

            queryCollection = query.Get()
            For Each MonMO In queryCollection
                myRow = DataTableListePrograms.NewRow()
                myRow("NOM") = MonMO("Name")
                myRow("EDITEUR") = MonMO("Vendor")
                myRow("VERSION") = MonMO("Version")
                myRow("DATE") = MonMO("InstallDate")
                myRow("CODE_IDENTIFICATION") = MonMO("IdentifyingNumber")
                DataTableListePrograms.Rows.Add(myRow)
            Next

            query.Dispose()

            DataGridListePrograms.DataSource = DataTableListePrograms
            DataGridListePrograms.DataBind()

        Catch ex As Exception
            LabelAlert.Text = ex.Message & ":Sous Win 2003 Installez le module concernant WMI et les logiciels"
            LabelAlert.Visible = True
        End Try


    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Préparation de la DataTable qui va stocker les données pour le Datagrid
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	23/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub PrepareDatatables()
        ' Préparation de la DataTable qui va stocker les données pour le Datagrid
        Dim myColumn As DataColumn = New DataColumn

        ' ----------- Liste des Colonnes -------------------
        myColumn.DataType = System.Type.GetType("System.String")
        'myColumn.AllowDBNull = False
        myColumn.Caption = "NOM"
        myColumn.ColumnName = "NOM"
        DataTableListePrograms.Columns.Add(myColumn)

        myColumn = New DataColumn
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.Caption = "EDITEUR"
        myColumn.ColumnName = "EDITEUR"
        DataTableListePrograms.Columns.Add(myColumn)

        myColumn = New DataColumn
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.Caption = "VERSION"
        myColumn.ColumnName = "VERSION"
        DataTableListePrograms.Columns.Add(myColumn)

        myColumn = New DataColumn
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.Caption = "DATE"
        myColumn.ColumnName = "DATE"
        DataTableListePrograms.Columns.Add(myColumn)

        myColumn = New DataColumn
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.Caption = "CODE_IDENTIFICATION"
        myColumn.ColumnName = "CODE_IDENTIFICATION"
        DataTableListePrograms.Columns.Add(myColumn)

    End Sub
    ' -----------------------------------------------------
End Class

End Namespace
