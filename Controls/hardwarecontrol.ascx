<%@ Control Language="vb" AutoEventWireup="false" Inherits="DotNetSysInfoJA.HardwareControl" CodeFile="HardwareControl.ascx.vb" %>
<TABLE class="arpege" cellSpacing="0" cellPadding="0" width="99%" border="1">
	<TR>
		<TD>
			<TABLE class="boxheader" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR vAlign="top">
					<TD class="boxheader" align="center">Informations Mat�rielles</TD>
				<TR height="1">
					<TD height="1" class="interligne"></TD>
				</TR>
				<TR>
					<TD class="SecondNiveau">Configuration Systeme de la machine</TD>
				</TR>
				<TR>
					<TD class="boxbody">
						<table width="100%" class="boxbody"> 
							<tr>
								<td colspan="2" width="100%" align=center class="boxbody"><b>Processeur</b></td>
							</tr>
							<tr>
								<td width="40%" class="boxbody"><b>Fabriquant :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelFabriquant" runat="server" Width="100%"  EnableViewState=False></asp:Label></td>
							</tr>
							<tr>
								<td width="40%" class="boxbody"><b>Nom Mod�le :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelNomModele" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</tr>
							<tr>
								<td width="40%" class="boxbody"><b>R�f�rence Mod�le :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelReferenceModele" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</tr>
							<tr>
								<td width="40%" class="boxbody"><b>Vitesse :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelVitesseProc" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</tr>
							<tr>
								<td width="40%" class="boxbody"><b>M�moire L2 :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelMemL2" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</tr>
							<tr>
								<td colspan="2" width="100%" align=center class="boxbody"><b>BIOS</b></td>
							</tr>
							<tr>
								<td width="40%" class="boxbody"><b>Nom BIOS :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelNomBIOS" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</tr>
							<tr>
								<td width="40%" class="boxbody"><b>Version :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelVersionBIOS" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</tr>
							<tr>
								<td colspan="2" width="100%" align=center class="boxbody"><b>MEMOIRE VIVE</b></td>
							</tr>
							<tr>
								<td width="40%" class="boxbody"><b>Nombre de Barettes :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelNbBarettesRAM" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</tr>
							<tr>
								<td width="40%" class="boxbody"><b>Taille des Barettes :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelTailleBarettes" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</tr>
							<tr>
								<td colspan="2" width="100%" align=center class="boxbody"><b>Carte Vid�o</b></td>
							</tr>
							<tr>
								<td width="40%" class="boxbody"><b>Nom :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelNomVideoCarte" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</tr>
							<tr>
								<td width="40%" class="boxbody"><b>Processeur : </b>
								</td>
								<td class="boxbody"><asp:Label id="LabelProcesseurCarte" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</tr>
							<tr>
								<td width="40%" class="boxbody"><b>Mode Video : </b>
								</td>
								<td class="boxbody"><asp:Label id="LabelModeVideo" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</tr>
							<tr>
								<td width="40%" class="boxbody"><b>RAM :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelRAMVideo" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
							</tr>
							<tr>
								<td colspan="2" width="100%" align=center class="boxbody"><b>Carte Son</b></td>
							</tr>
							<tr>
								<td width="40%" class="boxbody"><b>Nom :</b>
								</td>
								<td class="boxbody"><asp:Label id="LabelCarteSon" runat="server" Width="100%" EnableViewState=False></asp:Label></td>
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
