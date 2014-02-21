<%@ Control Language="vb" AutoEventWireup="false" Inherits="DotNetSysInfoJA.MemoireControl" CodeFile="MemoireControl.ascx.vb" %>
<TABLE class="arpege" cellSpacing="0" cellPadding="0" width="99%" border="1">
	<TR>
		<TD>
			<TABLE class="boxheader" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR vAlign="top">
					<TD class="boxheader" align="center">Utilisation mémoire</TD>
				<TR height="1">
					<TD height="1" class="interligne"></TD>
				</TR>
				<TR>
					<TD class="SecondNiveau">Utilisation de la Mémoire sur la machine</TD>
				</TR>
				<TR>
					<TD class="boxbody">
						<table width="100%" class="boxbody">
							<tr>
								<td width="50%" class="boxbody"><b>Nombre de Process :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelProcessus" runat="server" Width="50%" EnableViewState="False"></asp:Label><a href="./default.aspx?detail=process" target="_blank"><img src="./images/information.gif" border="0" alt="Liste des Processes en cours" width="15"></a></td>
							</tr>
							<tr>
								<td width="50%" class="boxbody"><b>Mémoire Vive Disponible :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelMemoireDispo" runat="server" Width="100%" EnableViewState="False"></asp:Label></td>
							</tr>
							<tr>
								<td width="50%" class="boxbody"><b>Taux d'utilisation du SWAP :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelSwapUtilise" runat="server" Width="100%" EnableViewState="False"></asp:Label></td>
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
