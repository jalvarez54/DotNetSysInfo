<%@ Control Language="vb" AutoEventWireup="false" Inherits="DotNetSysInfoJA.NetworkControl" CodeFile="NetworkControl.ascx.vb" %>
<TABLE class="arpege" cellSpacing="0" cellPadding="0" width="99%" border="1">
	<TR>
		<TD>
			<TABLE class="boxheader" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR vAlign="top">
					<TD class="boxheader" align="center">Périphériques Réseau</TD>
				<TR height="1">
					<TD height="1" class="interligne"></TD>
				</TR>
				<TR>
					<TD class="SecondNiveau">Liste des périphériques réseau de la machine</TD>
				</TR>
				<TR>
					<TD class="boxbody">
			<table width="100%" id="TableauReseau" align="center" runat="server">
				<tr>
					<td align="left" valign="top" class="auteur">ID</td>
					<td align="left" valign="top" class="auteur">Type</td>
					<td align="left" valign="top" class="auteur">Nom</td>
					<td align="left" valign="top" class="auteur">Type</td>
					<td align="left" valign="top" class="auteur">Service</td>
					<td align="left" valign="top" class="auteur">Addresse MAC</td>
				</tr>
			</table>
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
