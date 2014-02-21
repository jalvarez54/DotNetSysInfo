<%@ Control Language="vb" AutoEventWireup="false" Inherits="DotNetSysInfoJA.ServerLoginControl" CodeFile="ServerLoginControl.ascx.vb" %>
<TABLE class="arpege" cellSpacing="0" cellPadding="0" width="99%" border="1">
	<TR>
		<TD>
			<TABLE class="boxheader" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR vAlign="top">
					<TD class="boxheader" align="center">Serveur</TD>
				<TR height="1">
					<TD height="1" class="interligne"></TD>
				</TR>
				<TR>
					<TD class="SecondNiveau">Paramètres du serveur à tester</TD>
				</TR>
				<TR>
					<TD class="boxbody">
						<table width="100%" class="boxbody">
							<tr>
								<td width="50%" class="boxbody"><b>Serveur :</b>
								</td>
								<td class="boxbody">
									<asp:TextBox id="ServerTextBox" runat="server" Width="100%"></asp:TextBox></td>
							</tr>
							<tr>
								<td width="50%" class="boxbody"><b>Login :</b>
								</td>
								<td class="boxbody">
									<asp:TextBox id="LoginTextBox" runat="server" Width="100%"></asp:TextBox></td>
							</tr>
							<tr>
								<td width="50%" class="boxbody"><b>Mot de Passe :</b>
								</td>
								<td class="boxbody">
									<asp:TextBox id="PasswordTextBox" runat="server" Width="100%"></asp:TextBox></td>
							</tr>
						</table>
						<asp:Label id="LabelAlert" runat="server" EnableViewState="False" ForeColor="DarkRed" Font-Italic="True"
							Font-Bold="True" Visible="False"></asp:Label>
					</TD>
				</TR>
				<TR height="1">
					<TD height="1" class="interligne"></TD>
				</TR>
				<TR vAlign="top">
					<TD class="boxheader" align="left">&nbsp;
						<asp:Button id="ButtonValidationSRV" runat="server" Text="Connexion au Serveur" Width="95%"></asp:Button></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
