'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Controls/DisquesControl.ascx.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : User Control affichant la liste des Partitions avec les Tailles
'                   et Taux d'Occupation de chaque Partition
' *************************************************************************

Imports System.Web.UI.HtmlControls
Imports System
Imports System.Management


Namespace DotNetSysInfoJA


    ''' -----------------------------------------------------------------------------
    ''' Project	 : DotNetSysInfo
    ''' Class	 : DisquesControl
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' User Control affichant la liste des Partitions avec les Tailles
    ''' et Taux d'Occupation de chaque Partition
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	23/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Partial Class DisquesControl
        Inherits MonAbstraite

        Private _NomServer As String = ""
        Private _NomLogin As String = ""
        Private _NomPassword As String = ""


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

#Region "Liste Propriétés de la Classe"

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	15/07/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property NomServer() As String
            Get
                Return _NomServer
            End Get
            Set(ByVal Value As String)
                _NomServer = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	15/07/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property NomLogin() As String
            Get
                Return _NomLogin
            End Get
            Set(ByVal Value As String)
                _NomLogin = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	15/07/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property NomPassword() As String
            Get
                Return _NomPassword
            End Get
            Set(ByVal Value As String)
                _NomPassword = Value
            End Set
        End Property

#End Region

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Chargement du Controle avec la liste des partitions
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

            'ChargeTableauUseFSO()

            ChargeTableauUseWMI()
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Utilisation des classes WMI
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	22/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub ChargeTableauUseWMI()

            Dim stringMachineName As String = ""
            Dim co As New ConnectionOptions
            Dim oq As System.Management.ObjectQuery
            Dim query As ManagementObjectSearcher
            Dim ms As System.Management.ManagementScope
            Dim queryCollection As ManagementObjectCollection
            Dim MonMO As ManagementObject
            Dim CSS As Boolean = True

            Dim TotalDisqueLibre As Long = 0
            Dim TotalDisque As Long = 0

            Fonctions.ChargeConnexionParam(co, stringMachineName)
            Try

                ms = New System.Management.ManagementScope("\\" + stringMachineName + "\root\cimv2", co)
                oq = New System.Management.ObjectQuery("SELECT * FROM Win32_LogicalDisk")
                query = New ManagementObjectSearcher(ms, oq)

                queryCollection = query.Get()
                For Each MonMO In queryCollection
                    If Not (IsNothing(MonMO("Size"))) Then
                        Dim MaLigne As New HtmlControls.HtmlTableRow
                        Dim Prop As Integer = CalculProportion(Double.Parse(MonMO("FreeSpace").ToString()), Double.Parse(MonMO("Size").ToString()))
                        Dim OccupationDisk As Double = Double.Parse(MonMO("Size").ToString()) - Double.Parse(MonMO("FreeSpace").ToString())

                        TotalDisqueLibre += Int64.Parse(MonMO("FreeSpace").ToString())
                        TotalDisque += Int64.Parse(MonMO("Size").ToString())

                        AddCell(MaLigne, RenvoieIconeTypeDisk(Int32.Parse(MonMO("DriveType").ToString())), "right", CSS)
                        AddCell(MaLigne, "[" & MonMO("Caption") & "]", "left", CSS)
                        AddCell(MaLigne, MonMO("VolumeName") & " (" & MonMO("Description") & ")", "left", CSS)
                        AddCell(MaLigne, MonMO("FileSystem"), "left", CSS)
                        AddCell(MaLigne, RenvoiCodeImage(Prop), "left", CSS)
                        AddCell(MaLigne, Fonctions.AfficheTaille(Double.Parse(MonMO("FreeSpace").ToString()), "o"), "right", CSS)
                        AddCell(MaLigne, Fonctions.AfficheTaille((OccupationDisk), "o"), "right", CSS)
                        AddCell(MaLigne, Fonctions.AfficheTaille(Double.Parse(MonMO("Size").ToString()), "o"), "right", CSS)
                        TableauDisque.Rows.Add(MaLigne)

                        CSS = Not (CSS)
                    End If
                Next

                query.Dispose()


                Dim PropTotal As Integer = CalculProportion(TotalDisqueLibre, TotalDisque)
                Dim MaLigneTotal As New HtmlControls.HtmlTableRow

                AddCell(MaLigneTotal, "<i>Totaux :&nbsp;&nbsp;</i>", "right", CSS, 4)
                AddCell(MaLigneTotal, RenvoiCodeImage(PropTotal), "left", CSS)
                AddCell(MaLigneTotal, Fonctions.AfficheTaille(TotalDisqueLibre, "o"), "right", CSS)
                AddCell(MaLigneTotal, Fonctions.AfficheTaille((TotalDisque - TotalDisqueLibre), "o"), "right", CSS)
                AddCell(MaLigneTotal, Fonctions.AfficheTaille(TotalDisque, "o"), "right", CSS)

                TableauDisque.Rows.Add(MaLigneTotal)

            Catch ex As Exception
                LabelAlert.Text = ex.Message
                LabelAlert.Visible = True
            End Try

        End Sub


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' renvoie le chemin de limage du type de disque
        ''' </summary>
        ''' <param name="TypeDisk"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	22/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Function RenvoieIconeTypeDisk(ByVal TypeDisk As Int32) As String

            Dim TempRetour As String
            Select Case TypeDisk
                Case 2
                    TempRetour = "./images/disk_removable.gif"
                Case 3
                    TempRetour = "./images/disk_hard.gif"
                Case 4
                    TempRetour = "./images/disk_network.gif"
                Case 5
                    TempRetour = "./images/disk_cdrom.gif"
                Case Else
                    TempRetour = "./images/disk_removable.gif"
            End Select
            Return "<img src='" & TempRetour & "' border='0' width='15' alt='Type Disque'>"
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Utilisation de l'objet FileSystem
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	22/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub ChargeTableauUseFSO()

            Dim fso = Server.CreateObject("Scripting.FileSystemObject")
            Dim drives = fso.Drives
            Dim Drive
            Dim isReady
            Dim CSS As Boolean = True

            Dim TotalDisqueLibre As Double = 0
            Dim TotalDisque As Double = 0

            For Each Drive In drives
                isReady = Drive.IsReady
                If isReady Then
                    Dim MaLigne As New HtmlControls.HtmlTableRow
                    Dim Prop As Integer = CalculProportion(Drive.FreeSpace, Drive.TotalSize)
                    TotalDisque += Drive.TotalSize
                    TotalDisqueLibre += Drive.FreeSpace
                    AddCell(MaLigne, "", "left", CSS)
                    AddCell(MaLigne, Drive.DriveLetter, "left", CSS)
                    AddCell(MaLigne, "[" & Drive.Path & "] (" & Drive.VolumeName & ")", "left", CSS)
                    AddCell(MaLigne, Drive.FileSystem, "left", CSS)
                    AddCell(MaLigne, RenvoiCodeImage(Prop), "left", CSS)
                    AddCell(MaLigne, Fonctions.AfficheTaille(Drive.FreeSpace, "o"), "right", CSS)
                    AddCell(MaLigne, Fonctions.AfficheTaille((Drive.TotalSize - Drive.FreeSpace), "o"), "right", CSS)
                    AddCell(MaLigne, Fonctions.AfficheTaille(Drive.TotalSize, "o"), "right", CSS)
                    TableauDisque.Rows.Add(MaLigne)
                    CSS = Not (CSS)

                End If
            Next

            Dim PropTotal As Integer = CalculProportion(TotalDisqueLibre, TotalDisque)
            Dim MaLigneTotal As New HtmlControls.HtmlTableRow

            AddCell(MaLigneTotal, "<i>Totaux :&nbsp;&nbsp;</i>", "right", 3)
            AddCell(MaLigneTotal, RenvoiCodeImage(PropTotal), "left", CSS)
            AddCell(MaLigneTotal, Fonctions.AfficheTaille(TotalDisqueLibre, "o"), "right", CSS)
            AddCell(MaLigneTotal, Fonctions.AfficheTaille((TotalDisque - TotalDisqueLibre), "o"), "right", CSS)
            AddCell(MaLigneTotal, Fonctions.AfficheTaille(TotalDisque, "o"), "right", CSS)

            TableauDisque.Rows.Add(MaLigneTotal)

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

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Calcule la proportion d'espace libre par rapport au total
        ''' </summary>
        ''' <param name="TailleLibre"></param>
        ''' <param name="TailleTotale"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	22/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Function CalculProportion(ByVal TailleLibre As Double, ByVal TailleTotale As Double) As Integer
            Return Int(((TailleTotale - TailleLibre) / TailleTotale) * 100)
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Permet de fournir le code pour la bonne image suivant le Taux d'Occupation
        ''' </summary>
        ''' <param name="Taille"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	22/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Function RenvoiCodeImage(ByVal Taille As Integer) As String
            Dim couleur As String = ""
            Dim Retour As String = ""
            If Taille > 95 Then couleur = "red"

            Retour = "<img height='10' src='./images/" & couleur & "bar_left.gif'>"
            Retour &= "<img src='./images/" & couleur & "bar_middle.gif' height='10' width='"
            Retour &= (Taille * 2) & "'><img height='10' src='./images/" & couleur & "bar_right.gif'>&nbsp;" & Taille & "%"
            Return Retour
        End Function

        ' -----------------------------------------------------

    End Class

End Namespace
