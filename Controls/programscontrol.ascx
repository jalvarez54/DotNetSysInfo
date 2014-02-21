<%@ Control Language="vb" AutoEventWireup="false" Inherits="DotNetSysInfoJA.ProgramsControl" CodeFile="ProgramsControl.ascx.vb" %>
<TABLE class="arpege" cellSpacing="0" cellPadding="0" width="99%" border="1">
	<TR>
		<TD>
			<TABLE class="boxheader" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR vAlign="top">
					<TD class="boxheader" align="center">Logiciels</TD>
				<TR height="1">
					<TD height="1" class="interligne"></TD>
				</TR>
				<TR>
					<TD class="SecondNiveau">Liste des Logiciels de la machine</TD>
				</TR>
				<TR>
					<TD class="boxbody">
			<table width="100%" class="boxbody">
				<tr>
					<td width="50%" class="boxbody"><b>Nb. de Logiciels :</b>
					</td>
					<td class="boxbody"><asp:Label id="LabelNbPrograms" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
					<td class="boxbody" width=50 align=left valign=top><a href="./default.aspx?detail=logiciel" target="_blank"><img src="./images/information.gif" border="0" alt="Liste des Logiciels installés" width=25></A></td>
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
