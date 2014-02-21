<%@ Control Language="vb" AutoEventWireup="false" Inherits="DotNetSysInfoJA.SystemControl" CodeFile="SystemControl.ascx.vb" %>
<TABLE class="boxheader" cellSpacing="0" cellPadding="0" width="99%" border="1">
	<TR>
		<TD>
			<TABLE class="boxheader" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR vAlign="top">
					<TD class="boxheader" align="center">Système</TD>
				<TR height="1">
					<TD height="1" class="interligne"></TD>
				</TR>
				<TR>
					<TD class="SecondNiveau">Liste des Partitions présentes sur la machine</TD>
				</TR>
				<TR>
					<TD class="boxbody">
						<table width="100%" class="boxbody">
							<tr>
								<td colspan="2" width="100%" align=center class="boxbody"><b>Serveur Hébergeant l'application</b></td>
							</tr>
							<tr>
								<td width="150" class="boxbody"><b>Host Header Name :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelHostname" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</tr>
							<tr>
								<td width="150" class="boxbody"><b>Machine :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelMachineHebergeant" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</tr>
							<TR>
								<td width="150" class="boxbody"><b>IP :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelIPMachineHebergeant" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</TR>
							<TR>
								<td width="150" class="boxbody"><b>Version FrameWork :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelVersion" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</TR>
							<TR>
								<td width="150" class="boxbody"><b>Version Application :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelVersionApplication" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</TR>
							<tr>
								<td colspan="2" width="100%" align=center class="boxbody"><b>Serveur Cible</b></td>
							</tr>
							<tr>
								<td width="150" class="boxbody"><b>Machine :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelMachine" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
								<td width="100" rowspan="5" class="boxbody"><img src="./images/WinXP.gif" border="0" alt="Logo windows"></td>
							</tr>
							<TR>
								<td width="150" class="boxbody"><b>IP :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelIP" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</TR>
							<TR>
								<td width="150" class="boxbody"><b>Uptime :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelUptime" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</TR>
							<TR>
								<td width="150" class="boxbody"><b>Version OS :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelVersionOS" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</TR>
							<TR>
								<td width="150" class="boxbody"><b>Numéro de Série :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelNumSerieOS" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</TR>
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
