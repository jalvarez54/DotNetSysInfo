'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Classes/TimeClass.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : Classe de gestion des temps
' *************************************************************************
Namespace DotNetSysInfoJA

    ''' -----------------------------------------------------------------------------
    ''' Project	 : DotNetSysInfo
    ''' Class	 : TimeClass
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Classe de gestion des temps
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	27/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class TimeClass

        Private _Secondes As Integer
        Private _Minutes As Integer
        Private _Heures As Integer
        Private _Jours As Integer

#Region "Liste Propriétés de la Classe"

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Propriété du nombre des secondes de l'objet
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	28/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property Secondes() As Integer
            Get
                Return _Secondes
            End Get
            Set(ByVal Value As Integer)
                _Secondes = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Propriété du nombre des minutes de l'objet
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	28/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property Minutes() As Integer
            Get
                Return _Minutes
            End Get
            Set(ByVal Value As Integer)
                _Minutes = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Propriété du nombre des heures de l'objet
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	28/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property Heures() As Integer
            Get
                Return _Heures
            End Get
            Set(ByVal Value As Integer)
                _Heures = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Propriété du nombre des Jours de l'objet
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	28/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property Jours() As Integer
            Get
                Return _Jours
            End Get
            Set(ByVal Value As Integer)
                _Jours = Value
            End Set
        End Property
#End Region

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constructeur par Défaut de la classe
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	27/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub New()
            _Secondes = 0
            _Minutes = 0
            _Heures = 0
            _Jours = 0
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constructeur transmettant la valeur de chaque parametre de temps (jour, heure, minute et seconde)
        ''' </summary>
        ''' <param name="NbJours"></param>
        ''' <param name="NbHeures"></param>
        ''' <param name="NbMinutes"></param>
        ''' <param name="NbSecondes"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	27/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub New(ByVal NbJours As Integer, ByVal NbHeures As Integer, ByVal NbMinutes As Integer, ByVal NbSecondes As Integer)
            _Secondes = NbSecondes
            _Minutes = NbMinutes
            _Heures = NbHeures
            _Jours = NbJours
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constructeur transmettant le nombre total de secondes
        ''' </summary>
        ''' <param name="TotalNbSecondes"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	27/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub New(ByVal TotalNbSecondes As Long)
            Dim LeTemps As New TimeClass
            LeTemps.ConversionDetaillee(TotalNbSecondes)
            Secondes = LeTemps.Secondes
            Minutes = LeTemps.Minutes
            Heures = LeTemps.Heures
            Jours = LeTemps.Jours
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Procédure permettant de calculer chaque variable à partir du Nombre total de secondes
        ''' </summary>
        ''' <param name="NBSec"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	27/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub ConversionDetaillee(ByVal NBSec As Long)
            Jours = NBSec \ 86400
            Heures = (NBSec - (Jours * 86400)) \ 3600
            Minutes = (NBSec - (Heures * 3600) - (Jours * 86400)) \ 60
            Secondes = NBSec - (Minutes * 60) - (Heures * 3600) - (Jours * 86400)
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Fonction permettant de connaître le nombre total de seconde à partir des valeurs des variables
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	27/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConversionSeconde() As Long
            Return CType(((((Jours * 24) + Heures) * 60 + Minutes) * 60) + Secondes, Long)
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Fonction de test d'égalité de 2 objets TimeClass
        ''' </summary>
        ''' <param name="ValeurAComparer"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	27/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function Egal(ByVal ValeurAComparer As TimeClass) As Boolean
            Dim ValeurBase As Long = ConversionSeconde()
            Dim ValeurComp As Long = ValeurAComparer.ConversionSeconde
            If ValeurBase = ValeurComp Then
                Return True
            Else
                Return False
            End If
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Fonction qui renvoie la différence entre 2 objets TimeClass en secondes
        ''' </summary>
        ''' <param name="ValeurAComparer"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	27/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function DifferenceA(ByVal ValeurAComparer As TimeClass) As Integer
            Dim ValeurBase As Long = ConversionSeconde()
            Dim ValeurComp As Long = ValeurAComparer.ConversionSeconde
            Return CType(ValeurBase - ValeurComp, Integer)
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Fonction qui ajoute un objet TimeClass à un autre par la somme des 2 totaux de secondes
        ''' </summary>
        ''' <param name="ValAAjouter"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	27/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function AjouterTemps(ByVal ValAAjouter As TimeClass) As TimeClass
            Dim ValeurBase As Long = ConversionSeconde()
            Dim ValeurComp As Long = ValAAjouter.ConversionSeconde
            Dim TemptResult As New TimeClass(ValeurBase + ValeurComp)
            Return TemptResult
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Fonction qui renvoie la chaine permettant de définir textuellement la valeur d'un objet TimeClass
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	27/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ReturnChaineTemps() As String
            Dim TempChaine As String = ""
            If Jours > 1 Then
                TempChaine &= Jours & " Jours "
            Else
                TempChaine &= Jours & " Jour "
            End If
            If Heures > 1 Then
                TempChaine &= Heures & " Heures "
            Else
                TempChaine &= Heures & " Heure "
            End If
            If Minutes > 1 Then
                TempChaine &= Minutes & " Minutes "
            Else
                TempChaine &= Minutes & " Minute "
            End If
            If Secondes > 1 Then
                TempChaine &= Secondes & " Secondes "
            Else
                TempChaine &= Secondes & " Seconde "
            End If
            Return TempChaine
        End Function

        ' -----------------------------------------------------
    End Class

End Namespace
