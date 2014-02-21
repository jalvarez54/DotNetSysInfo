'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Controls/ListeProcessControl.ascx.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : Controle Affichant la liste des Process en action
' *************************************************************************

Imports System.Management
Imports System.Data


Namespace DotNetSysInfoJA


''' -----------------------------------------------------------------------------
''' Project	 : DotNetSysInfo
''' Class	 : ListeProcessControl
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Controle Affichant la liste des Process en action
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[moi]	23/06/2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Partial Class ListeProcessControl
    Inherits System.Web.UI.UserControl

    Public DataTableListeProcesses As New DataTable

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
    ''' Chargement du Controle fournissant la liste des Processes actifs
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
            oq = New System.Management.ObjectQuery("SELECT * FROM Win32_Process")
            query = New ManagementObjectSearcher(ms, oq)

            PrepareDatatables()

            queryCollection = query.Get()
            For Each MonMO In queryCollection
                myRow = DataTableListeProcesses.NewRow()
                myRow("NOM") = MonMO("Name")
                myRow("PROCESS_ID") = MonMO("ProcessId")
                myRow("EXEC_PATH") = MonMO("ExecutablePath")
                myRow("COMMAND_LINE") = MonMO("CommandLine")
                If Not IsNothing(MonMO("CreationDate")) Then
                    myRow("CREATION_DATE") = Fonctions.AfficheDateTimeComplete(RecupDateLancementProcess(MonMO("CreationDate").ToString()))
                Else
                    myRow("CREATION_DATE") = ""
                End If
                DataTableListeProcesses.Rows.Add(myRow)
            Next

            query.Dispose()

            DataGridListeProcesses.DataSource = DataTableListeProcesses
            DataGridListeProcesses.DataBind()

        Catch ex As Exception
            LabelAlert.Text = ex.Message
            LabelAlert.Visible = True
        End Try

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' A partir de la chaine donnée par WMI transforme pour obtenir une date standard
    ''' </summary>
    ''' <param name="DateProcess"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	24/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function RecupDateLancementProcess(ByVal DateProcess As String) As DateTime
        ' 20040622140147            .031250+120
        Dim TabChaine As String() = DateProcess.Trim.Split(".")
        Dim TempChaine As String = TabChaine(0)
        Dim Temp As String = TempChaine.Substring(0, 4) & "-" & TempChaine.Substring(4, 2) & "-" & TempChaine.Substring(6, 2) & " " & TempChaine.Substring(8, 2) & ":" & TempChaine.Substring(10, 2) & ":" & TempChaine.Substring(12, 2)

        Return CType(Temp, DateTime)

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Préparation de la DataTable qui va stocker les données pour le Datagrid
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	24/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub PrepareDatatables()
        ' Préparation de la DataTable qui va stocker les données pour le Datagrid
        Dim myColumn As DataColumn = New DataColumn

        ' ----------- Liste des Colonnes -------------------
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.AllowDBNull = False
        myColumn.Caption = "NOM"
        myColumn.ColumnName = "NOM"
        DataTableListeProcesses.Columns.Add(myColumn)

        myColumn = New DataColumn
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.Caption = "PROCESS_ID"
        myColumn.ColumnName = "PROCESS_ID"
        DataTableListeProcesses.Columns.Add(myColumn)

        myColumn = New DataColumn
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.Caption = "EXEC_PATH"
        myColumn.ColumnName = "EXEC_PATH"
        DataTableListeProcesses.Columns.Add(myColumn)

        myColumn = New DataColumn
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.Caption = "COMMAND_LINE"
        myColumn.ColumnName = "COMMAND_LINE"
        DataTableListeProcesses.Columns.Add(myColumn)

        myColumn = New DataColumn
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.Caption = "CREATION_DATE"
        myColumn.ColumnName = "CREATION_DATE"
        DataTableListeProcesses.Columns.Add(myColumn)

    End Sub
    ' -----------------------------------------------------
End Class

End Namespace
