Imports Microsoft.VisualBasic

Public Class MonAbstraite
	Inherits System.Web.UI.UserControl
	Implements MonInterface

	Public Function MaFonction() As String Implements MonInterface.MaFonction
		Return "Bonjour"
	End Function
End Class
