<%@ Control Language="vb" AutoEventWireup="false" Inherits="DotNetSysInfoJA.FrameworkControl" CodeFile="FrameworkControl.ascx.vb" %>
<TABLE class="arpege" cellSpacing="0" cellPadding="0" width="99%" border="1">
	<TR>
		<TD>
			<TABLE class="boxheader" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR vAlign="top">
					<TD class="boxheader" align="center">FrameWork .Net (<asp:Label id="LabelVersion" runat="server" EnableViewState=False></asp:Label>)</TD>
				<TR height="1">
					<TD height="1" class="interligne"></TD>
				</TR>
				<TR>
					<TD class="SecondNiveau">Liste des derniers lancements du Process ASP.NET et les détails sur ceux-ci</TD>
				</TR>
				<TR>
					<TD class="boxbody">
						<asp:Table id="tbProcess" runat="server" CellPadding="1" HorizontalAlign="Center" Width="100%" EnableViewState=False></asp:Table>
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
