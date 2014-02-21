'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Classes/CoucheReseau.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : Classe de Gestion du Traffic Réseau à partir de SNMP
' *************************************************************************

Imports System.Management
Imports System.Web
Imports System.Data


Namespace DotNetSysInfoJA


    ''' -----------------------------------------------------------------------------
    ''' Project	 : DotNetSysInfo
    ''' Class	 : CoucheReseau
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Classe de Gestion du Traffic Réseau à partir de SNMP
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	23/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class CoucheReseau

        Public DatatableInterface As New DataTable

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Cree une nouvelle instance 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	22/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub New()

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Crée une nouvelle instance de l'objet Couche Réseau en transmettant les paramètres
        ''' nécessaires
        ''' </summary>
        ''' <param name="LaSession"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	22/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub New(ByVal LaSession As ManagerSession_)
            chargeInterfaceReseau(LaSession)
        End Sub


        Public Structure ManagerSession_
            Public agentAddress As String
            Public agentCommunity As String
        End Structure




        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Fonction de chargement de toute la table avec les informations sur les interfaces réseau
        ''' </summary>
        ''' <param name="Session"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	22/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub chargeInterfaceReseau(ByVal Session As ManagerSession_)

            Dim TableIP As DataTable = chargeIP(Session)

            Dim scope As ManagementScope
            Dim mpath As ManagementPath
            Dim mo As ManagementObject
            Dim queryParameters As ManagementNamedValueCollection
            Dim queryOptions As EnumerationOptions

            scope = New ManagementScope("\root\snmp\localhost")
            mpath = New ManagementPath("SNMP_RFC1213_MIB_ifTable")

            queryParameters = New ManagementNamedValueCollection
            queryParameters.Add("AgentAddress", Session.agentAddress)
            queryParameters.Add("AgentReadCommunityName", Session.agentCommunity)

            queryOptions = New EnumerationOptions
            queryOptions.Context = queryParameters
            Dim mc As New ManagementClass(scope, mpath, New ObjectGetOptions(Nothing, New TimeSpan(0, 0, 0, 5), True))

            Dim myColumn As DataColumn = New DataColumn
            Dim myRow As DataRow

            myColumn.DataType = System.Type.GetType("System.Int32")
            myColumn.AllowDBNull = False
            myColumn.Caption = "Numero"
            myColumn.ColumnName = "Numero"
            DatatableInterface.Columns.Add(myColumn)

            myColumn = New DataColumn
            myColumn.DataType = System.Type.GetType("System.String")
            myColumn.Caption = "Description"
            myColumn.ColumnName = "Description"
            DatatableInterface.Columns.Add(myColumn)

            myColumn = New DataColumn
            myColumn.DataType = System.Type.GetType("System.String")
            myColumn.Caption = "Type"
            myColumn.ColumnName = "Type"
            DatatableInterface.Columns.Add(myColumn)

            myColumn = New DataColumn
            myColumn.DataType = System.Type.GetType("System.Int32")
            myColumn.Caption = "MTU"
            myColumn.ColumnName = "MTU"
            DatatableInterface.Columns.Add(myColumn)

            myColumn = New DataColumn
            myColumn.DataType = System.Type.GetType("System.String")
            myColumn.Caption = "StaOp"
            myColumn.ColumnName = "StaOp"
            DatatableInterface.Columns.Add(myColumn)

            myColumn = New DataColumn
            myColumn.DataType = System.Type.GetType("System.String")
            myColumn.Caption = "StaAd"
            myColumn.ColumnName = "StaAd"
            DatatableInterface.Columns.Add(myColumn)

            myColumn = New DataColumn
            myColumn.DataType = System.Type.GetType("System.String")
            myColumn.Caption = "Vitesse"
            myColumn.ColumnName = "Vitesse"
            DatatableInterface.Columns.Add(myColumn)

            myColumn = New DataColumn
            myColumn.DataType = System.Type.GetType("System.String")
            myColumn.Caption = "Entree"
            myColumn.ColumnName = "Entree"
            DatatableInterface.Columns.Add(myColumn)

            myColumn = New DataColumn
            myColumn.DataType = System.Type.GetType("System.String")
            myColumn.Caption = "Sortie"
            myColumn.ColumnName = "Sortie"
            DatatableInterface.Columns.Add(myColumn)

            myColumn = New DataColumn
            myColumn.DataType = System.Type.GetType("System.String")
            myColumn.Caption = "IP"
            myColumn.ColumnName = "IP"
            DatatableInterface.Columns.Add(myColumn)

            myColumn = New DataColumn
            myColumn.DataType = System.Type.GetType("System.String")
            myColumn.Caption = "Masque"
            myColumn.ColumnName = "Masque"
            DatatableInterface.Columns.Add(myColumn)

            Dim i As Integer
            With (mc)
                For Each mo In mc.GetInstances(queryOptions)
                    myRow = DatatableInterface.NewRow()
                    myRow("Numero") = mo("ifIndex")
                    myRow("Description") = Replace(mo("ifDescr"), """", "", 1, -1, CompareMethod.Text)
                    myRow("Type") = mo("ifType")
                    myRow("MTU") = mo("ifMtu")
                    myRow("StaOp") = mo("ifOperStatus")
                    myRow("StaAd") = mo("ifAdminStatus")
                    myRow("Vitesse") = CalculeVitesse(mo("ifSpeed").ToString)
                    myRow("Entree") = CalculeTrafic(mo("ifInOctets").ToString)
                    myRow("Sortie") = CalculeTrafic(mo("ifOutOctets").ToString)
                    myRow("IP") = TableIP.Rows.Item(i)("IP")
                    myRow("Masque") = TableIP.Rows.Item(i)("Masque")
                    DatatableInterface.Rows.Add(myRow)
                    i = i + 1
                Next

            End With

        End Sub
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Function de chargement des informations sur les IP associées aux interfaces
        ''' </summary>
        ''' <param name="Session"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	22/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function chargeIP(ByVal Session As ManagerSession_) As DataTable
            Dim LaTableTemp As New DataTable

            Dim scope As ManagementScope
            Dim mpath As ManagementPath
            Dim mo As ManagementObject
            Dim queryParameters As ManagementNamedValueCollection
            Dim queryOptions As EnumerationOptions

            scope = New ManagementScope("\root\snmp\localhost")
            mpath = New ManagementPath("SNMP_RFC1213_MIB_ipAddrTable")

            queryParameters = New ManagementNamedValueCollection
            queryParameters.Add("AgentAddress", Session.agentAddress)
            queryParameters.Add("AgentReadCommunityName", Session.agentCommunity)

            queryOptions = New EnumerationOptions
            queryOptions.Context = queryParameters
            Dim mc As New ManagementClass(scope, mpath, New ObjectGetOptions(Nothing, New TimeSpan(0, 0, 0, 5), True))

            Dim myColumnTemp As DataColumn = New DataColumn
            Dim myRowTemp As DataRow
            myColumnTemp = New DataColumn
            myColumnTemp.DataType = System.Type.GetType("System.String")
            myColumnTemp.Caption = "IP"
            myColumnTemp.ColumnName = "IP"
            LaTableTemp.Columns.Add(myColumnTemp)

            myColumnTemp = New DataColumn
            myColumnTemp.DataType = System.Type.GetType("System.String")
            myColumnTemp.Caption = "Masque"
            myColumnTemp.ColumnName = "Masque"
            LaTableTemp.Columns.Add(myColumnTemp)

            With (mc)
                For Each mo In mc.GetInstances(queryOptions)
                    myRowTemp = LaTableTemp.NewRow()
                    myRowTemp("IP") = mo("ipAdEntAddr")
                    myRowTemp("Masque") = mo("ipAdEntNetMask")
                    LaTableTemp.Rows.Add(myRowTemp)
                Next

            End With

            mc.Dispose()

            Return LaTableTemp
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Permet de calculer le volume traffic afin de l'afficher avec les unités
        ''' </summary>
        ''' <param name="NombreOctets"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	22/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function CalculeTrafic(ByVal NombreOctets As String) As String
            Dim Val As Int64 = CType(NombreOctets, Double)
            If (Val / 1000000000) > 1 Then
                Return Math.Round(Val / 1000000000, 2) & " Go"
            ElseIf (Val / 1000000) > 1 Then
                Return Math.Round(Val / 1000000, 2) & " Mo"
            Else
                Return Math.Round(Val / 1000, 2) & " Ko"
            End If
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Calcule la vitesse afin de la renvoyer avec les unités
        ''' </summary>
        ''' <param name="Vitesse"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	22/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function CalculeVitesse(ByVal Vitesse As String) As String
            Dim Val As Int64 = CType(Vitesse, Int64)
            If (Val / 1000000000) > 1 Then
                Return Math.Round((Val / 1000000000), 2) & " Gb/S"
            ElseIf (Val / 1000000) > 1 Then
                Return Math.Round((Val / 1000000), 2) & " Mb/S"
            Else
                Return Math.Round((Val / 1000), 2) & " Kb/S"
            End If
        End Function
        ' ------------------------------------------------------------------------------
    End Class

End Namespace


