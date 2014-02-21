<%@ Control Language="vb" AutoEventWireup="false" Inherits="DotNetSysInfoJA.DisquesControl" CodeFile="DisquesControl.ascx.vb" %>
<TABLE class="boxheader" cellSpacing="0" cellPadding="0" width="99%" border="1">
	<TR>
		<TD>
			<TABLE class="boxheader" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR vAlign="top">
					<TD class="boxheader" align="center">Systèmes de fichiers du Serveur</TD>
				<TR height="1">
					<TD height="1" class="interligne"></TD>
				</TR>
				<TR>
					<TD class="SecondNiveau">Liste des Partitions présentes sur la machine</TD>
				</TR>
				<TR>
					<TD class="boxbody">
						<TABLE id="TableauDisque" width="100%" align="center" runat="server" class="boxbody">
							<TR>
								<TD class="boxbody" vAlign="top" align="left"></TD>
								<TD class="auteur" vAlign="top" align="left">Lettre</TD>
								<TD class="auteur" vAlign="top" align="left">Informations</TD>
								<TD class="auteur" vAlign="top" align="left">Type</TD>
								<TD class="auteur" vAlign="top" align="left">Utilisation</TD>
								<TD class="auteur" vAlign="top" align="right">Libre</TD>
								<TD class="auteur" vAlign="top" align="right">Utililisé</TD>
								<TD class="auteur" vAlign="top" align="right">Taille</TD>
							</TR>
						</TABLE>
						<asp:Label id="LabelAlert" runat="server" EnableViewState="False" ForeColor="DarkRed" Font-Italic="True" Font-Bold="True" Visible=False></asp:Label>
					</TD>
				</TR>
				<TR height="1">
					<TD height="1" class="interligne"></TD>
				</TR>
				<TR vAlign="top">
					<TD class="boxheader" align="left">&nbsp;</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
