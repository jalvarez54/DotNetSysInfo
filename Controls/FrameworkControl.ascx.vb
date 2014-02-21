'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Controls/FrameworkControl.ascx.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : User Control affichant la liste des derniers lancements du Process
'                   ASP.NET et les d�tails sur ceux-ci.
' *************************************************************************

''' -----------------------------------------------------------------------------
''' Project	 : DotNetSysInfo
''' Class	 : FrameworkControl
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' User Control affichant la liste des derniers lancements du Process
''' ASP.NET et les d�tails sur ceux-ci.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[moi]	23/06/2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Namespace DotNetSysInfoJA

Partial  Class FrameworkControl
    Inherits System.Web.UI.UserControl

#Region " Code g�n�r� par le Concepteur Web Form "

    'Cet appel est requis par le Concepteur Web Form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN�: cet appel de m�thode est requis par le Concepteur Web Form
        'Ne le modifiez pas en utilisant l'�diteur de code.
        InitializeComponent()
    End Sub

#End Region

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chargement du Controle des Process ASP.NET
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
        AffProcessInfo()
        LabelVersion.Text = System.Environment.Version.ToString
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Lancement de la r�cup�ration des informations depuis le Serveur
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	22/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub AffProcessInfo()

        ' D�claration des Objets n�cessaires
        Dim mP As New ProcessModelInfo
        Dim mPITab As ProcessInfo()
        Dim mPi As ProcessInfo
        Dim trET As New TableRow
        Dim i As Integer = 1
        Dim CSS As Boolean = True

        Try

            ' Chargement de l'historique (les 10 derniers lancements) des donn�es sur le process ASP_NET
            mPITab = mP.GetHistory(10)

            ' Mise en forme de la Premiere ligne
            trET.Font.Bold = True
            trET.ForeColor = System.Drawing.Color.Black

            ' Ajout des Noms de Colonne et Ajout de la ligne dans le Tableau
            AddCell(trET, "N�", CSS, "auteur")
            AddCell(trET, "ID", CSS, "auteur")
            AddCell(trET, "Age", CSS, "auteur")
            AddCell(trET, "M�moire max utilis�e", CSS, "auteur")
            AddCell(trET, "Nbr requ�tes", CSS, "auteur")
            AddCell(trET, "Date d�but", CSS, "auteur")
            AddCell(trET, "Statut", CSS, "auteur")
            AddCell(trET, "Raison �chec", CSS, "auteur")
            tbProcess.Rows.Add(trET)

            ' Boucle de lecture et d'affichage dans le tableau des Informations sur les Process
            For Each mPi In mPITab
                Dim tr As New TableRow
                tr.ForeColor = System.Drawing.Color.Black

                AddCell(tr, i, CSS) ' Ajoute le N� de l'historique
                AddCell(tr, mPi.ProcessID.ToString, CSS) ' Affiche l'ID du process
                AddCell(tr, Fonctions.AfficheAge(mPi.Age), CSS) 'Affiche l'�ge du process en D�tail
                AddCell(tr, Fonctions.AfficheTaille(mPi.PeakMemoryUsed, "Ko"), CSS) 'Affiche la m�moire maximale utilis�e
                AddCell(tr, mPi.RequestCount.ToString, CSS) 'nombre de requ�te trait�es
                AddCell(tr, mPi.StartTime.ToString, CSS) 'la date du d�but du process
                AddCell(tr, mPi.Status.ToString, CSS) 'son statut
                AddCell(tr, mPi.ShutdownReason.ToString, CSS) 'la raison de son arr�t

                CSS = Not (CSS)
                tbProcess.Rows.Add(tr)
                i += 1
            Next

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
    ''' <param name="CSS"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	22/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub AddCell(ByVal tr As TableRow, ByVal sM As String, ByVal CSS As Boolean, Optional ByVal CSSString As String = "")
        Dim td As New TableCell
        td.Text = sM
        If CSSString <> "" Then
            td.CssClass = CSSString
        Else
            If CSS Then
                td.CssClass = "boxbody"
            Else
                td.CssClass = "boxbodyalternate"
            End If
        End If
        tr.Cells.Add(td)
    End Sub

    ' -----------------------------------------------------
End Class

End Namespace
