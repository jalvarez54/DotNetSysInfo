'**************************************************************************
' $Archive: /Fab_/DotNetSysInfo.root/DotNetSysInfo_1/Classes/constantes.vb $ 
' $Author: Jalvarez $ 
' $Date: 20/01/06 18:15 $  $Revision: 1 $
'  Description : Classe des Constantes utilisées dans le projet
' *************************************************************************

Namespace DotNetSysInfoJA
    ''' -----------------------------------------------------------------------------
    ''' Project	 : DotNetSysInfo
    ''' Class	 : constantes
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Classe des Constantes utilisées dans le projet
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[moi]	23/06/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------

    Public Class constantes

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Chargement de la clé du fichier CSS à utiliser.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[moi]	22/06/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FichierCSS As String = Trim(ConfigurationManager.AppSettings("StyleCSS"))

        Public Shared ReadOnly ServeurATester As String = Trim(ConfigurationManager.AppSettings("ServeurATester"))

        ' ------------------------------------------------------------------------------
    End Class

End Namespace
