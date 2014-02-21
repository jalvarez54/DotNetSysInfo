'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Classes/Fonctions.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : Classe avec les fonctions du Projet
' *************************************************************************

Imports System.Net.Sockets
Imports System.Net
Imports System.Diagnostics
Imports System.Globalization
Imports System.Management


Namespace DotNetSysInfoJA


''' -----------------------------------------------------------------------------
''' Project	 : DotNetSysInfo
''' Class	 : Fonctions
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Classe avec les fonctions du Projet
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[moi]	23/06/2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class Fonctions

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Recupère l'IP de la machine
    ''' </summary>
    ''' <param name="adIp"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	22/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function IP(ByVal adIp As String) As String
            Dim myIP As IPHostEntry = Dns.GetHostEntry(adIp)
        Dim sIP As String = Trim(myIP.AddressList(0).ToString)

        Return sIP
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Vérifie la valeur est supérieure à 1 et affiche le pluriel
    ''' </summary>
    ''' <param name="Lavaleur"></param>
    ''' <param name="LUnite"></param>
    ''' <param name="TestPlur"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	22/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function TestZero(ByVal Lavaleur As Integer, ByVal LUnite As String, ByVal TestPlur As Boolean) As String
        If Lavaleur > 1 And TestPlur = True Then
            Return Lavaleur & " " & LUnite & "s"
        ElseIf Lavaleur > 0 Then
            Return Lavaleur & " " & LUnite
        End If
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Affiche le temps en détail de vie du process ASPNET
    ''' </summary>
    ''' <param name="LeTimeSpan"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	22/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function AfficheAge(ByVal LeTimeSpan As TimeSpan) As String
        Dim Retour As String = ""
        Retour = TestZero(LeTimeSpan.Days, "J", False)
        Retour &= " " & TestZero(LeTimeSpan.Hours, "H", False)
        Retour &= " " & TestZero(LeTimeSpan.Minutes, "M", False)
        Retour &= " " & TestZero(LeTimeSpan.Seconds, "S", False)
        Retour &= " " & TestZero(LeTimeSpan.Milliseconds, "mS", False)

        Return Retour
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Formatte la taille en Ko
    ''' </summary>
    ''' <param name="lSize"></param>
    ''' <param name="booleanFormatOnly"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	22/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function formatSize(ByVal lSize As Int64, ByVal booleanFormatOnly As Boolean) As String
        Dim stringSize As String = ""
        Dim myNfi As NumberFormatInfo = New NumberFormatInfo

        Dim lKBSize As Int64 = 0

        If (lSize < 1024) Then
            If (lSize = 0) Then
                'zéro Octet
                stringSize = "0"
            Else
                'Moins de 1 Ko mais pas 0 Octet
                stringSize = "1"
            End If
        Else
            If (booleanFormatOnly = False) Then
                'Formatte en Ko
                lKBSize = lSize / 1024
            Else
                lKBSize = lSize
            End If

            'Formatte avec le Format par défaut
            stringSize = lKBSize.ToString("n", myNfi)
            'Supprime les Décimales
            stringSize = stringSize.Replace(".00", "")

        End If
        Return stringSize & " Ko"

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Crée le détail de la taille des données 
    ''' </summary>
    ''' <param name="TailleMemoire"></param>
    ''' <param name="Unite"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	22/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function AfficheTaille(ByVal TailleMemoire As Double, ByVal Unite As String) As String

        Dim TailleGO As Double = 0
        Dim TailleMO As Double = 0
        Dim TailleKO As Double = 0
        Dim TailleO As Double = 0
        Dim Retour As String = ""
        If Unite = "o" Then
            TailleGO = (TailleMemoire / 1073741824) ' Nombre de Giga Octets
        Else
            TailleGO = (TailleMemoire / 1048576) ' Nombre de Giga Octets
        End If
        TailleMO = (TailleGO - Int(TailleGO)) * 1024 ' Nombre de Mega Octets
        TailleKO = (TailleMO - Int(TailleMO)) * 1024 ' Nombre de Kilo Octets
        If Unite = "o" Then
            TailleO = (TailleKO - Int(TailleKO)) * 1024 ' Nombre d'Octets
        End If
        Retour = TestZero(TailleGO, "Go", False)
        Retour &= " " & TestZero(TailleMO, "Mo", False)
        Retour &= " " & TestZero(TailleKO, "Ko", False)
        If Unite = "o" Then
            Retour &= " " & TestZero(TailleO, "o", False)
        End If
        Return Retour
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Formatte la vitesse en Hz
    ''' </summary>
    ''' <param name="laVitesse"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	22/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function AfficheVitesse(ByVal laVitesse As Int64) As String

        Dim TempVitesse As System.Double = 0
        Dim ChaineVitesse As String = ""
        Dim myNfi As NumberFormatInfo = New NumberFormatInfo

        If (laVitesse < 1000) Then
            'Moins d'un G Hz
            ChaineVitesse = laVitesse.ToString() + " M Hz"
        Else
            'conversion en Giga Hz
            TempVitesse = laVitesse / 1000

            ChaineVitesse = TempVitesse.ToString() + " G Hz"
        End If
        Return ChaineVitesse
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Permet d afficher la date au format texte complet, 
    ''' en partant d'une date au format francais DD/MM/YYYY à HH:mm:SS:mmmm
    ''' </summary>
    ''' <param name="LaDate"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	22/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function AfficheDateTimeComplete(ByVal LaDate As DateTime) As String

        Dim Result As String = ""
        Result = PremiereLettreMaj(WeekdayName(Weekday(LaDate), False, Microsoft.VisualBasic.FirstDayOfWeek.Sunday))
        Result &= " " & FormatHeureAffiche(Day(LaDate))
        Result &= " " & PremiereLettreMaj(MonthName(Month(LaDate), False))
        Result &= " " & Year(LaDate)
        Result &= " à " & FormatHeureAffiche(Hour(LaDate))
        Result &= ":" & FormatHeureAffiche(Minute(LaDate))
        Result &= ":" & FormatHeureAffiche(Second(LaDate))
        Return Result
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Permet de donner le texte avec la premiere lettre en majuscule
    ''' </summary>
    ''' <param name="texte"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	22/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function PremiereLettreMaj(ByVal texte As String) As String

        Return UCase(Left(texte, 1)) & Mid(texte, 2, Len(texte) - 1)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Permet de formatter l heure ou les minutes sur 2 caracteres
    ''' </summary>
    ''' <param name="Valeur"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	22/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function FormatHeureAffiche(ByVal Valeur As Integer) As String

        If (Valeur < 10) And (Valeur >= 0) Then
            Return "0" & Valeur.ToString
        Else
            Return Valeur.ToString
        End If
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Permet de renvoyer l'utilisateur de la page après un travail vers une autre page
    ''' </summary>
    ''' <param name="LaPage"></param>
    ''' <param name="LeTemps"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	14/07/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function Redirect(ByVal LaPage As String, ByVal LeTemps As Integer) As String
        Dim retour As String = "window.location='" & LaPage & "'"
        Return "<SCRIPT Language='javascript'>setTimeout(""" & retour & """," & LeTemps & " );</SCRIPT>"
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Modifie les valeurs des paramètres de connexion sur la machine
    ''' </summary>
    ''' <param name="LeCo"></param>
    ''' <param name="stringMachineName"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	06/09/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub ChargeConnexionParam(ByRef LeCo As ConnectionOptions, ByRef stringNomMachine As String)
        If Trim(System.Web.HttpContext.Current.Session("Serveur")) <> "" And Trim(LCase(System.Web.HttpContext.Current.Session("Serveur"))) <> "localhost" Then
            stringNomMachine = Trim(LCase(System.Web.HttpContext.Current.Session("Serveur")))
            LeCo.Username = Trim(System.Web.HttpContext.Current.Session("Login"))
            LeCo.Password = Trim(System.Web.HttpContext.Current.Session("Password"))
        Else
            stringNomMachine = constantes.ServeurATester
        End If
    End Sub

    ' -----------------------------------------------------
End Class

End Namespace
