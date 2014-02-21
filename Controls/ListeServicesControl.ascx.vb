'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Controls/ListeServicesControl.ascx.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : Controle Affichant la liste de tous les services Windows
' *************************************************************************

Imports System.Management
Imports System.Data


Namespace DotNetSysInfoJA


''' -----------------------------------------------------------------------------
''' Project	 : DotNetSysInfo
''' Class	 : ListeServicesControl
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Controle Affichant la liste de tous les services Windows
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[moi]	23/06/2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Partial Class ListeServicesControl
    Inherits System.Web.UI.UserControl

    Public DataTableListeServices As New DataTable

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
    ''' Chargement du Controle avec la liste de tous les services Windows
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
            oq = New System.Management.ObjectQuery("SELECT * FROM Win32_Service")
            query = New ManagementObjectSearcher(ms, oq)

            PrepareDatatables()

            queryCollection = query.Get()
            For Each MonMO In queryCollection
                myRow = DataTableListeServices.NewRow()
                myRow("NOM") = MonMO("Name")
                myRow("LIBELLE") = MonMO("Caption")
                myRow("STATUT") = MonMO("State")
                myRow("DESCRIPTION") = MonMO("Description")
                myRow("TYPE_SERVICE") = MonMO("ServiceType")
                DataTableListeServices.Rows.Add(myRow)
            Next

            query.Dispose()

            DataGridListeServices.DataSource = DataTableListeServices
            DataGridListeServices.DataBind()

        Catch ex As Exception
            LabelAlert.Text = ex.Message
            LabelAlert.Visible = True
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Pr�paration de la DataTable qui va stocker les donn�es pour le Datagrid
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	23/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub PrepareDatatables()
        ' Pr�paration de la DataTable qui va stocker les donn�es pour le Datagrid
        Dim myColumn As DataColumn = New DataColumn

        ' ----------- Liste des Colonnes -------------------
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.AllowDBNull = False
        myColumn.Caption = "NOM"
        myColumn.ColumnName = "NOM"
        DataTableListeServices.Columns.Add(myColumn)

        myColumn = New DataColumn
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.Caption = "LIBELLE"
        myColumn.ColumnName = "LIBELLE"
        DataTableListeServices.Columns.Add(myColumn)

        myColumn = New DataColumn
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.Caption = "STATUT"
        myColumn.ColumnName = "STATUT"
        DataTableListeServices.Columns.Add(myColumn)

        myColumn = New DataColumn
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.Caption = "DESCRIPTION"
        myColumn.ColumnName = "DESCRIPTION"
        DataTableListeServices.Columns.Add(myColumn)

        myColumn = New DataColumn
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.Caption = "TYPE_SERVICE"
        myColumn.ColumnName = "TYPE_SERVICE"
        DataTableListeServices.Columns.Add(myColumn)

    End Sub
    ' -----------------------------------------------------
End Class

End Namespace
